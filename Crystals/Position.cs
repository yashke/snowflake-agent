using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Crystals
{
    public class Position
    {
        public double X, Y;
        public V Direction { get; set; }

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

        public static Position NextRandomPosition(double radius, double speed)
        {
            var alpha = 2 * Math.PI * random.NextDouble();

            var x = Math.Cos(alpha);
            var y = Math.Sin(alpha);

            return new Position(x, y, Position.NextRandomDirection(speed));
        }

        public static V NextRandomDirection(double speed)
        {
            var v = new V(random.NextDouble(), random.NextDouble());
            v.Speed = speed;

            return v;
        }

        public static double NextRandomSpeed(double maxSpeed)
        {
            return random.NextDouble() * maxSpeed;
           }
    
    }

 }
