using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Crystals
{
    public class Molecule
    {
        bool BelongsToFlake { get; set; }
        List<Molecule> Neigbours = new List<Molecule>();

        List<IPositionChangeListener> positionChangeListeners = new List<IPositionChangeListener>();

        Habitat habitat;

        Position Position { get; set; }
        public Thread Thread { get; set; }

        /// <summary>
        /// [m/s]
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
            this.Thread = new Thread(new ParameterizedThreadStart(this.Appear));

        }

        public void ThreadStart()
        {
            this.Thread.Start(Position.NextRandomPosition(habitat.Radius, this.Speed));
        }

        public void ThreadJoin()
        {
            this.Thread.Join();
        }


        public void Appear(object position)
        {
            Position = position as Position;
            if (position == null)
                throw new InvalidProgramException(
                    String.Format(
                        "Argument was not of type {1}. Passed type was {0}",
                        position.GetType(), typeof(Position)));

            while (true)
            {
                Molecule interferer = habitat.GetMoveInterferer(this);
                if (interferer != null)
                {
                    this.Bump(interferer);
                    if(interferer.BelongsToFlake)
                        TryToAttach(interferer);
                }
                Move();
                Thread.Sleep(100);
            }
        }

        public void Move()
        {
            Position.Move();
            habitat.ChangeMoleculePosition(this, Position.X, Position.Y);
            habitat.Logger.Log(Position);
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

        public void TryToAttach(Molecule boundMember)
        {
            if (random.NextDouble() > 0.5)
            {

            }
        }

        public bool IsNear(Molecule otherMolecule)
        {
            return Position.IsNear(otherMolecule.Position);
        }

    }
}
