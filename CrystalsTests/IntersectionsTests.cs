using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Crystals;

namespace CrystalsTests
{
    [TestFixture]
    class IntersectionsTests
    {
        [Test]
        public void CircleAndSegmentIntersectionsTest()
        {
            var positions = Intersections.CircleAndSegmentIntersections(new Position(6, 6), new Position(6, 20), 10, new Position(0, 0), false);

            var pExp = new Position(6, 8);

            AssertExtensions.AreAlmostEqual(pExp, positions[0]);

            positions = Intersections.CircleAndSegmentIntersections(new Position(0, -8), new Position(12, -8), 10, new Position(0, 0), false);

            pExp = new Position(6, -8);

            AssertExtensions.AreAlmostEqual(pExp, positions[0]);

            positions = Intersections.CircleAndSegmentIntersections(new Position(0, -7.8), new Position(12, -8.2), 10, new Position(0, 0), false);

            pExp = new Position(6, -8);

            AssertExtensions.AreAlmostEqual(pExp, positions[0]);

        }
    }
}
