using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Crystals;

namespace CrystalsTests
{
    [TestFixture]
    public class PositionTests
    {
        [Test]
        public void TetrahedronPartTest()
        {
            Position zero = new Position(3.45, 7.93, null, null);
            Position p = new Position(3.45, 10, null, null);

            Assert.AreEqual(1, p.TetrahedronPart(zero));

            p.X = -100;
            p.Y = 8;

            Assert.AreEqual(2, p.TetrahedronPart(zero));


            p.X = 100;
            p.Y = 1;

            Assert.AreEqual(5, p.TetrahedronPart(zero));

        }

        [Test]
        public void PointOfAngleTest()
        {
            var zero = new Position(0, 0, null, null);
            var p = zero.PointOfAngle(Molecule.TETRAHEDRON_SITE, Math.PI * 5 / 6);
            Assert.Less(p.X, zero.X);

            Assert.AreEqual(2, p.TetrahedronPart(zero));
        }

        [Test]
        public void PointOnBorderOfTetrahedronPartTest()
        {
            Position zero = new Position(3.45, 7.93, null, null);

            Double r = 10;

            var p = zero.PointOnBorderOfTetrahedronPart(r, 3);

            var p_expected = new Position(zero.X - r, zero.Y, null, null);

            AssertExtensions.AreAlmostEqual(p_expected.X, p.X);

            AssertExtensions.AreAlmostEqual(p_expected.Y, p.Y);

            p = zero.PointOnBorderOfTetrahedronPart(r, 5);

            p_expected = new Position(zero.X + r / 2, zero.Y - r * Math.Sqrt(3) / 2, null, null);

            AssertExtensions.AreAlmostEqual(p_expected.X, p.X);

            AssertExtensions.AreAlmostEqual(p_expected.Y, p.Y);

        }
    }
}
