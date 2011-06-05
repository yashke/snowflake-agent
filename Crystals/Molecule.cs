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

        public Molecule(Habitat habitat)
        {
            this.habitat = habitat;
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
