using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crystals
{
    class Collision
    {
        public static void DoElasticCollisionOfTwoBalls(double mass1, Position b1, double mass2, Position b2)
        {
            // Avoid division by zero below in computing new normal velocities
            // Doing a collision where both balls have no mass makes no sense anyway
            if (mass1 <= 0.0 || mass2 <= 0.0) return;
            
            // Compute unit normal and unit tangent vectors
            V v_n = b2 - b1; // v_n = normal vec. - a vector normal to the collision surface
            V v_un = v_n.UnitVector(); // unit normal vector
            V v_ut = new V(-v_un.Y, v_un.X); // unit tangent vector

            // Compute scalar projections of velocities onto v_un and v_ut
            double v1n = v_un * b1.Direction; // Dot product
            double v1t = v_ut * b1.Direction;
            double v2n = v_un * b2.Direction;
            double v2t = v_ut * b2.Direction;

            // Compute new tangential velocities
            double v1tPrime = v1t; // Note: in reality, the tangential velocities do not change after the collision
            double v2tPrime = v2t;

            // Compute new normal velocities using one-dimensional elastic collision equations in the normal direction
            // Division by zero avoided. See early return above.
            double v1nPrime = (v1n * (mass1 - mass2) + 2.0 * mass2 * v2n) / (mass1 + mass2);
            double v2nPrime = (v2n * (mass2 - mass1) + 2.0 * mass1 * v1n) / (mass1 + mass2);

            // Compute new normal and tangential velocity vectors
            V v_v1nPrime = v1nPrime * v_un; // Multiplication by a scalar
            V v_v1tPrime = v1tPrime * v_ut;
            V v_v2nPrime = v2nPrime * v_un;
            V v_v2tPrime = v2tPrime * v_ut;

            // Set new velocities in x and y coordinates
            b1.Direction.X = v_v1nPrime.X + v_v1tPrime.X;
            b1.Direction.Y = v_v1nPrime.Y + v_v1tPrime.Y;
            b2.Direction.X = v_v2nPrime.X + v_v2tPrime.X;
            b2.Direction.Y = v_v2nPrime.Y + v_v2tPrime.Y;
        }
    }
}
