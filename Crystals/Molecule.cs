﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;

namespace Crystals
{
    public class Molecule
    {
        public static double RADIUS = 2.5;

        List<IPositionChangeListener> positionChangeListeners = new List<IPositionChangeListener>();
        
        Habitat habitat;

        bool BelongsToFlake { get; set; }
        Molecule[] Neigbours = new Molecule[3];
        List<MoleculeAttachedListener> MoleculeAttachedListeners = new List<MoleculeAttachedListener>();

        Molecule LastInCell(int boundNr, bool clockwise, ref int count, ref int nextBoundNr)
        {
            count++;
            nextBoundNr = (boundNr + (clockwise ? 1 : -1) + 3) % 3;
            if (Neigbours[nextBoundNr] != null)
                return Neigbours[nextBoundNr].LastInCell(nextBoundNr, clockwise, ref count, ref nextBoundNr);
            else
                return this;
        }
        int FreeBound()
        {
            int b = 0;
            while (Neigbours[b] != null)
            {
                b++;
                if (b == 2) break;
            }
            return b;
        }

        Position Position { get; set; }
        public Thread Thread { get; set; }

        /// <summary>
        /// [Angstrom / (100 piko sek)]
        /// </summary>
        double Speed
        {
            get
            {
                return 640 * Math.Sqrt(habitat.Temperature / 25);
            }
        }

        public Molecule(Habitat habitat)
        {
            this.habitat = habitat;
            Position = Position.NextRandomPosition(habitat.Radius, this.Speed);
        }

        public void Cycle()
        {
            Molecule interferer = habitat.GetMoveInterferer(this);
            if (interferer != null)
            {
                this.Bump(interferer);
                if (interferer.BelongsToFlake)
                    TryToAttach(interferer);
                Position.X = interferer.Position.X;
                Position.Y = interferer.Position.Y;
            }
            Move();
        }

        public void Move()
        {
            if (!BelongsToFlake)
            {
                Position.Move();
                habitat.ChangeMoleculePosition(this, Position.X, Position.Y);
                habitat.Logger.Log(Position);
            }
        }

        public void Bump(Molecule other)
        {
            double v2v2 = Math.Pow(this.Position.Direction.Speed, 2) + Math.Pow(other.Position.Direction.Speed, 2);
            var s1 = Position.NextRandomSpeed(Math.Sqrt(v2v2));
            this.Position.Direction = Position.NextRandomDirection(s1);
            var s2 = Math.Sqrt(v2v2 - s1 * s1);
            other.Position.Direction = Position.NextRandomDirection(s2);
        }

        Random random = new Random();

        public void TryToAttach(Molecule boundMember1)
        {
            if (random.NextDouble() > 0.5)
            {
                int bound1 = boundMember1.FreeBound();
                int count2 = 0, bound2 = 0;
                var boundMember2 = boundMember1.LastInCell(bound1, true, ref count2, ref bound2);
                int count3 = 0, bound3 = 0;
                var boundMember3 = boundMember1.LastInCell(bound1, true, ref count3, ref bound3);

                this.BelongsToFlake = true;
                boundMember1.Neigbours[bound1] = this;
                this.Neigbours[bound1] = boundMember1;

                if (count2 == 5)
                {
                    boundMember2.Neigbours[bound2] = this;
                    this.Neigbours[bound2] = boundMember2;
                }
                if (count3 == 5)
                {
                    boundMember3.Neigbours[bound3] = this;
                    this.Neigbours[bound3] = boundMember3;
                }
            }
        }

        public void FireMoleculeAttached(Point attached, List<Point> linked)
        {
            foreach (MoleculeAttachedListener listener in MoleculeAttachedListeners)
            {
                listener.MoleculeAttached(attached, linked);
            }
        }

        public void AddMoleculeAttachedListener(MoleculeAttachedListener listener)
        {
            MoleculeAttachedListeners.Add(listener);
        }

        public bool IsNearConflict(Molecule otherMolecule)
        {
            V vector = Position.Sub(otherMolecule.Position);
            return vector.Speed <= RADIUS * 2;
        }

    }
}
