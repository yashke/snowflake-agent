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
                    if (old == 0)
                    {
                        X = value;
                        Y = 0;
                    }
                    else
                    {
                        X = X * value / old;
                        Y = Y * value / old;
                    }
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

        public static double operator *(V a, V b)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        public static V operator *(double a, V b)
        {
            return new V(a * b.X, a * b.Y);
        }


		/// <summary>
        /// Get a unit vector in the direction of this vector
        /// If this vector is the 0 vector, return a 0 vector
        /// </summary>
		/// <returns></returns>
        public V UnitVector() 
        {
			double mag = Speed;
			if (mag != 0.0) 
                return new V(X / mag, Y / mag);
			else 
                return new V(0, 0);
		}
    }
}
