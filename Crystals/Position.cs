using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Crystals
{
    public class Position
    {
        double X, Y;
        V Direction { get; set; }

        public Position(double x, double y, V direction)
        {
            X = x; Y = y; Direction = direction;
        }
        public void Move()
        {
            lock (this)
            {
                this.X += Direction.X;
                this.Y += Direction.Y;
            }
        }

        public V Sub(Position poz)
        {
            return new V(X - poz.X, Y - poz.Y);
        }

        public override string ToString()
        {
            return String.Format("({0},{1})", X, Y);
        }

        public static Random random = new Random();

        public static Position NextRandomPosition(double width, double height, double speed)
        {
            var d = 2 * (width + height) * random.NextDouble();

            double x, y;

            if (d < width)
            {
                x = d;
                y = 0;
            }
            else if (d < 2 * width)
            {
                x = d - width;
                y = height;
            }
            else if (d < 2 * width + height)
            {
                x = 0;
                y = d - 2 * width;
            }
            else
            {
                x = width;
                y = d - 2 * width - height;
            }
            return new Position(x, y, Position.NextRandomDirection(speed));
        }

        public static V NextRandomDirection(double speed)
        {
            var v = new V(random.NextDouble(), random.NextDouble());
            v.Speed = speed;

            return v;
        }
    

    }

 }
