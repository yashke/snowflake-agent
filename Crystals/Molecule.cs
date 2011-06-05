using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Crystals
{
    public class Molecule
    {
        Environment environment;

        Position Position { get; set; }
        V Direction { get; set; }

        public Molecule(Environment environment)
        {
            this.environment = environment;
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
            }
        }

        public void Move()
        {
            Position.Move(Direction);
        }

        public void TryToAttach()
        {
        }

    }
}
