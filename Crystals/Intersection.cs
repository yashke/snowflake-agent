using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crystals
{
    class Intersections
    {
        static public Boolean AreArchAndSegmentIntersecting(Position p1, Position p2, double r, Position s, double t1, double t2)
        {
            List<Position> intersections = ArchAndSegmentIntersections(p1, p2, r, s, t1, t2);
            return intersections.Count != 0;
        }

        /// <summary>
        ///    Arch equation: 
        ///    x = s.X + r*cos(t)
        ///    y = s.Y + r*sin(t)
        ///    Segment equation:
        ///    x = p1.X + k*(p2.X-p1.X) 
        ///    y = p1.Y + k*(p2.Y-p1.Y)
        ///    where k in [0, 1], t in [t1, t2]
        ///    =>
        ///    t = acos((x - s.X)/r OR t = asin((y - s.Y)/r
        ///    k = (x - p1.X)/(p2.X-p1.X) OR k = (y - p1.Y)/(p2.Y-p1.Y) 
        /// </summary>
        static public List<Position> ArchAndSegmentIntersections(Position p1, Position p2, double r, Position s, double t1, double t2)
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
                    if (SolveCosEqInInterval((x - s.X) / r, Math.Min(t1, t2), Math.Max(t1, t2)).Count() > 0)
                    {
                        double k = (x - p1.X) / (p2.X - p1.X);
                        if (0 <= k && k <= 1)
                        {
                            ret.Add(new Position(x, a * x + b));
                        }
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
                    if (SolveSinEqInInterval((y - s.Y) / r, Math.Min(t1, t2), Math.Max(t1, t2)).Count() > 0)
                    {
                        double k = (y - p1.Y) / (p2.Y - p1.Y);
                        if (0 <= k && k <= 1)
                        {
                            ret.Add(new Position(a, y));
                        }
                    }
                }
            }
            return ret;
        }

        /// <summary>
        ///    Arch equation: 
        ///    x = s.X + r*cos(t)
        ///    y = s.Y + r*sin(t)
        ///    Segment equation:
        ///    x = p1.X + k*(p2.X-p1.X) 
        ///    y = p1.Y + k*(p2.Y-p1.Y)
        ///    where k in [0, 1], t in [t1, t2]
        ///    =>
        ///    t = acos((x - s.X)/r OR t = asin((y - s.Y)/r
        ///    k = (x - p1.X)/(p2.X-p1.X) OR k = (y - p1.Y)/(p2.Y-p1.Y) 
        /// </summary>
        static public List<double> ArchAndSegmentIntersections_Angles(Position p1, Position p2, double r, Position s, double t1, double t2)
        {
            List<double> ret = new List<double>();
            if (p1.X != p2.X)
            {
                /*
                 y = ax + b
                (s.x - x)^2 + (s.y - y)^2 = r^2
                =>
                (s.x-x)^2 + (s.y - b - ax) ^2 = r^2
                =>
                 s.x^2 - 2*x*s.x + x^2 + (s.y-b)^2 - 2*(s.y-b)ax + a^2*x^2 - r^2 = 0 
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
                    List<double> ts = SolveCosEqInInterval((x - s.X) / r, Math.Min(t1, t2), Math.Max(t1, t2));
                    if (ts.Count() > 0)
                    {
                        double k = (x - p1.X) / (p2.X - p1.X);
                        if (0 <= k && k <= 1)
                        {
                            ret.AddRange(ts);
                        }
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
                    Console.Write((y - s.Y) / r);
                    List<double> ts = SolveSinEqInInterval((y - s.Y) / r, Math.Min(t1, t2), Math.Max(t1, t2));
                    if (ts.Count() > 0)
                    {
                        double k = (y - p1.Y) / (p2.Y - p1.Y);
                        if (0 <= k && k <= 1)
                        {
                            ret.AddRange(ts);
                        }
                    }
                }
            }
            return ret;
        }


        static public List<double> SolveCosEqInInterval(double cos, double t_m, double t_w)
        {
            List<double> ret = new List<double>();
            double t0 = cos >= 1 ? 0 : (cos <= -1 ? Math.PI : Math.Acos(cos));

            double[] t_0s = new double[] { t0, -t0 };

            foreach (double t_0 in t_0s)
            {
                for (int k = -5; k < 5; k++)
                {
                    double t = t_0 + k * 2 * Math.PI;
                    System.Diagnostics.Debug.Assert(!double.IsNaN(t));
                    if (t_m <= t && t <= t_w)
                        ret.Add(t);
                }
            }
            return ret;
        }

        static public List<double> SolveSinEqInInterval(double sin, double t_m, double t_w)
        {
            System.Diagnostics.Debug.Assert(!double.IsNaN(sin), "eh" + sin);

            List<double> ret = new List<double>();
            double t0 = sin >= 1 ? Math.PI / 2 : Math.Asin(sin);

            System.Diagnostics.Debug.Assert(!double.IsNaN(t0), "ah" + sin);


            double[] t_0s = new double[] { t0, Math.PI - t0 };

            foreach (double t_0 in t_0s)
            {
                for (int k = -5; k < 5; k++)
                {
                    double t = t_0 + k * 2 * Math.PI;
                    System.Diagnostics.Debug.Assert(!double.IsNaN(t));
                    if (t_m <= t && t <= t_w)
                        ret.Add(t);
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
