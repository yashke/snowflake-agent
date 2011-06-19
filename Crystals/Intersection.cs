using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crystals
{
    public class Intersections
    {
        /// <summary>
        ///    Circle equation: 
        ///    x = s.X + r*cos(t)
        ///    y = s.Y + r*sin(t)
        ///    Segment equation:
        ///    x = p1.X + k*(p2.X-p1.X) 
        ///    y = p1.Y + k*(p2.Y-p1.Y)
        ///    where k in [0, 1], t in [0, 360)
        ///    =>
        ///    t = acos((x - s.X)/r OR t = asin((y - s.Y)/r
        ///    k = (x - p1.X)/(p2.X-p1.X) OR k = (y - p1.Y)/(p2.Y-p1.Y) 
        /// </summary>
        static public List<Position> CircleAndSegmentIntersections(Position p1, Position p2, double r, Position s)
        {
            List<Position> ret = new List<Position>();
            if (p1.X != p2.X)
            {
                /*
                 y = ax + b
                (s.x - x)^2 + (s.y - y)^2 = r^2
                =>
                (s.x-x)^2 + (s.y - b - ax) ^2 = r^2
                =>
                (1 + a^2)x^2- 2[(s.y-b)a + s.x] x + s.x^2 + (s.y-b)^2 - r^2   = 0
                */
                double a = (p2.Y - p1.Y) / (p2.X - p1.X);
                double b = p1.Y - a * p1.X;
                double[] xs = SolveQuadraticalEquation(
                    1 + a * a,
                    -2 * ((s.Y - b) * a + s.X),
                    s.X * s.X + (s.Y - b) * (s.Y - b) - r * r
                );
                foreach (double x in xs)
                {
                    double k = (x - p1.X) / (p2.X - p1.X);
                    if (0 <= k && k <= 1)
                    {
                        ret.Add(new Position(x, a * x + b));
                    }
                }
            }
            else
            {
                /*
                x = a
                (s.x - x)^2 + (s.y - y)^2 = r^2
                =>
                (s.X - a)^2 + (s.Y - y)^2 = r^2
                =>
                y^2 + -2*s.Y*y + s.Y^2 + (s.X - a)^2 - r^2 = 0         
                 */
                double a = p1.X;
                double[] ys = SolveQuadraticalEquation(
                    1,
                    -2 * s.Y,
                    s.Y * s.Y + (s.X - a) * (s.X - a) - r * r
                );
                foreach (double y in ys)
                {
                    double k = (y - p1.Y) / (p2.Y - p1.Y);
                    if (0 <= k && k <= 1)
                    {
                        ret.Add(new Position(a, y));
                    }
                }
            }
            return ret;
        }

        static public double[] SolveQuadraticalEquation(double a, double b, double c)
        {
            if (a == 0)
                return new double[] { -c / b };
            double delta = b * b - 4 * a * c;
            if (delta > 0)
                return new double[] { (-b + Math.Sqrt(delta)) / (2 * a), (-b - Math.Sqrt(delta)) / (2 * a) };
            else if (delta == 0)
                return new double[] { -b / (2 * a) };
            else
                return new double[0];
        }


    }


}
