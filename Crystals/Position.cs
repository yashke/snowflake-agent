using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Crystals
{
    public class Position
    {
        double X, Y, Z;
        public Position(double x, double y, double z)
        {
            X = x; Y = y; Z = z;
        }
        public void Move(V direction)
        {
            lock (this)
            {
                this.X += direction.X;
                this.Y += direction.Y;
                this.Z += direction.Z;
            }
        }
    }

    public class V
    {
        public double X, Y, Z;
        public double Speed
        {
            get
            {
                return Math.Sqrt(X * X + Y * Y + Z * Z);
            }
            set
            {
                lock (this)
                {
                    double old = Speed;
                    X = X * value / old;
                    Y = Y * value / old;
                    Z = Z * value / old;
                }
            }
        }

        public V(double x, double y, double z)
        {
            X = x; Y = y; Z = z;
        }
        public void Bump(V normal)
        {

        }

    }
}
