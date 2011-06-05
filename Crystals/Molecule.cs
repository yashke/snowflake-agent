using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Crystals
{
    public class Molecule
    {
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
                Move();
                TryToAttach();
                Thread.Sleep(100);
            }
        }

        public void Move()
        {
            Position.Move();
            habitat.Logger.Log(Position);
        }

        public void TryToAttach()
        {
        }

    }
}
