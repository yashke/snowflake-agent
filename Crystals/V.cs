using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crystals
{
    public class V
    {
        public double X, Y;

        public double Speed
        {
            get
            {
                return Math.Sqrt(X * X + Y * Y);
            }
            set
            {
                lock (this)
                {
                    double old = Speed;
                    X = X * value / old;
                    Y = Y * value / old;
                }
            }
        }

        public V(double x, double y)
        {
            X = x; Y = y;
        }

        public override string ToString()
        {
            return String.Format("<{0},{1},{2}>", X, Y);
        }

    }

}
