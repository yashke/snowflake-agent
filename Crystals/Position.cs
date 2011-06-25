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
        public Molecule Molecule;

        public double HabitatRadius { get { return Molecule.HabitatRadius; } }
        public Molecule HabitatCondensationCenter { get { return Molecule.HabitatCondensationCenter; } }

        public Position(double x, double y)
        {
            X = x;
            Y = y;
            Direction = null;
            Molecule = null;
        }

        public Position(double x, double y, V direction, Molecule molecule)
        {
            X = x;
            Y = y;
            Direction = direction;
            Molecule = molecule;
        }

        /// <summary>
        /// Do której ćwiartki układu współrzędych należy punkt numerowane 1 - 4
        /// </summary>
        /// <param name="zero">Początek układu współrzędnych</param>
        /// <returns></returns>
        public int Quadrant(Position zero)
        {
            if (X - zero.X >= 0)
                if (Y - zero.Y >= 0)
                    return 1;
                else
                    return 4;
            else
                if (Y - zero.Y >= 0)
                    return 2;
                else
                    return 3;
        }

        /// <summary>
        /// Do której szóstki układu współrzędych należy punkt numerowane 0 - 5
        /// </summary>
        /// <param name="zero">Początek układu współrzędnych</param>
        /// <returns></returns>
        public int TetrahedronPart(Position zero)
        {
            double angle = Angle(zero);
            return (int)(angle / (Math.PI / 3));
        }

        /// <summary>
        /// Position on first border of tetrahedron part in counterclockwise order.
        /// </summary>
        /// <param name="r">length of tetrahedron site</param>
        /// <param name="part">id of tetrahedron part <seealso cref="Position.TetrahedronPart"/></param>
        /// <returns></returns>
        public Position PointOnBorderOfTetrahedronPart(double r, int part)
        {
            return PointOfAngle(r, part * (Math.PI / 3));
        }

        /// <summary>
        /// Pod  jakim jest kątem do dodaniej osi OX
        /// </summary>
        /// <param name="zero">Początek układu współrzędnych</param>
        /// <returns></returns>
        public double Angle(Position zero)
        {
            double angle;
            double x_rel = X - zero.X;
            double y_rel = Y - zero.Y;
            if (x_rel == 0)
                angle = y_rel > 0 ? Math.PI / 2 : 3 * Math.PI / 2;
            else
            {
                switch (Quadrant(zero))
                {
                    case 1: angle = Math.Atan(y_rel / x_rel);
                        break;
                    case 4: angle = Math.Atan(y_rel / x_rel) + 2 * Math.PI;
                        break;
                    default: angle = Math.Atan(y_rel / x_rel) + Math.PI;
                        break;
                }
            }
            angle = (angle + 2 * Math.PI) % (Math.PI * 2);
            return angle;
        }

        /// <summary>
        /// Oblicz punkt w odległości r od środka układu z kątem angle, jeśli nasz punkt jest środkiem
        /// </summary>
        /// <param name="r"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public Position PointOfAngle(double r, double angle)
        {
            return new Position(X + r * Math.Cos(angle), Y + r * Math.Sin(angle), null, Molecule);
        }

        public void Move()
        {
            double x, y;

            lock (this)
            {
                x = this.X + Direction.X;
                y = this.Y + Direction.Y;
                if (Math.Pow(x - Molecule.HabitatCondensationCenter.Position.X, 2) + Math.Pow(y - Molecule.HabitatCondensationCenter.Position.Y, 2) < Math.Pow(HabitatRadius, 2))
                {
                    this.X += Direction.X;
                    this.Y += Direction.Y;
                }
                else
                {
                    BumpWalls();
                }
            }
        }

        public void BumpWalls()
        {
            V d = new V(Direction.X, Direction.Y);
            Position expectedPosition = new Position(this.X + Direction.X, this.Y + Direction.Y);
            while (d.Speed > 0)
            {
                List<Position> crossing = Intersections.CircleAndSegmentIntersections(this, expectedPosition, HabitatRadius, HabitatCondensationCenter.Position, false);
                if (crossing.Count == 0)
                    break;
                Position crossPosition = crossing.First<Position>();
                double alpha = (4 * Math.PI / 9) * random.NextDouble() - (2 * Math.PI / 9);
                double angle = HabitatCondensationCenter.Position.Angle(crossPosition);
                double dMoved = crossPosition.Sub(this).Speed;
                expectedPosition = crossPosition.PointOfAngle(dMoved, angle + alpha);
                this.X = crossPosition.X;
                this.Y = crossPosition.Y;
                double oldSpeed = Direction.Speed;
                Direction = expectedPosition.Sub(crossPosition);
                Direction.Speed = oldSpeed;
                d.Speed -= dMoved;
            }
            Direction.Speed = EvaluateSpeed();
            this.X = expectedPosition.X;
            this.Y = expectedPosition.Y;

        }

        public double EvaluateSpeed()
        {
            double speedSum = Math.Pow(Direction.Speed, 2) + Math.Pow(Molecule.DefaultSpeed, 2);
            return NextRandomSpeed(Math.Sqrt(speedSum));
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

        public static Position NextRandomPosition(double radius, double speed, Molecule molecule)
        {
            var alpha = 2 * Math.PI * random.NextDouble();

            var x = radius * Math.Cos(alpha);
            var y = radius * Math.Sin(alpha);

            return new Position(x, y, Position.NextRandomDirection(speed), molecule);
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
