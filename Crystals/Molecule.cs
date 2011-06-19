using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;

namespace Crystals
{
    public enum BoundType
    {
        I,
        II
    }

    public class Molecule
    {
        public static double RADIUS = 2.5;
        public static double TETRAHEDRON_SITE = 3.9;

        List<IPositionChangeListener> positionChangeListeners = new List<IPositionChangeListener>();

        Habitat habitat;

        public bool BelongsToFlake { get; set; }
        public BoundType BoundType { get; set; }

        public double HabitatRadius { get { return habitat.Radius; } }
        public Molecule HabitatCondensationCenter { get { return habitat.CondensationCenter; } }

        public Molecule[] Neigbours = new Molecule[3];
        List<MoleculeAttachedListener> MoleculeAttachedListeners = new List<MoleculeAttachedListener>();

        MoleculePresenter presenter;

        public MoleculePresenter Presenter
        {
            get
            {
                if (presenter == null)
                {
                    presenter = new MoleculePresenter(this);
                }
                return presenter;
            }
        }

        Molecule LastInCell(int boundNr, bool clockwise, ref int count, ref int nextBoundNr)
        {
            count++;
            nextBoundNr = (boundNr + (clockwise ? 1 : -1) + 3) % 3;
            if (Neigbours[nextBoundNr] != null)
                return Neigbours[nextBoundNr].LastInCell(nextBoundNr, clockwise, ref count, ref nextBoundNr);
            else
                return this;
        }
        public int? FreeBound(Molecule other)
        {
            int tetrahedronPart = other.Position.TetrahedronPart(Position);

            int b = BoundType == BoundType.I ? (tetrahedronPart + 1) % 6 / 2 :
                (tetrahedronPart + 4) % 6 / 2;

            return Neigbours[b] == null ? (int?)b : null;
        }
        public int? GetBoundNr(Molecule other)
        {
            for (int b = 0; b < Neigbours.Length; b++)
            {
                if (Neigbours[b] == other)
                    return b;
            }
            return null;
        }
        public Position BoundPosition(int boundNr)
        {
            return Position.PointOnBorderOfTetrahedronPart(
                TETRAHEDRON_SITE,
                BoundType == BoundType.I ? boundNr * 2 :
                boundNr * 2 + 3);
        }

        public Position Position { get; set; }

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
            Init(habitat, false);
        }

        public Molecule(Habitat habitat, bool isCondensationCenter)
        {
            Init(habitat, isCondensationCenter);
        }

        public void Init(Habitat habitat, bool isCondensationCenter)
        {
            this.habitat = habitat;
            if (isCondensationCenter)
            {
                BelongsToFlake = true;
                Position = new Position(0, 0, null, this);
            }
            else
            {
                Position = Position.NextRandomPosition(HabitatRadius, this.Speed, this);
            }
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
                TryToAttachDefinitely(boundMember1);
            }
        }
        public void TryToAttachDefinitely(Molecule boundMember1)
        {
            int? bound1 = boundMember1.FreeBound(this);
            if (bound1 != null)
            {
                int count2 = 0, bound2 = 0;
                var boundMember2 = boundMember1.LastInCell((int)bound1, true, ref count2, ref bound2);
                int count3 = 0, bound3 = 0;
                var boundMember3 = boundMember1.LastInCell((int)bound1, true, ref count3, ref bound3);

                this.BelongsToFlake = true;
                boundMember1.Neigbours[(int)bound1] = this;
                this.Neigbours[(int)bound1] = boundMember1;
                this.BoundType = boundMember1.BoundType == BoundType.I ? BoundType.II : BoundType.I;
                this.Position = boundMember1.BoundPosition((int)bound1);
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
