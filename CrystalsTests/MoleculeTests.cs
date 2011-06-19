using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Crystals;

namespace CrystalsTests
{
    [TestFixture]
    class MoleculeTests
    {
        Molecule mZero;
        Habitat habitat;

        [SetUp]
        public void SetUp()
        {
            habitat = new Habitat(1, 1, 1);

            mZero = new Molecule(habitat);
            mZero.Position.X = 0;
            mZero.Position.Y = 0;
            mZero.BelongsToFlake = true;
            mZero.BoundType = BoundType.I;

        }

        [Test]
        public void FreeBoundTest()
        {
            var mAttach = new Molecule(habitat);
            mAttach.Position = mZero.Position.PointOfAngle(Molecule.TETRAHEDRON_SITE, Math.PI * 5 / 6);

            Assert.AreEqual(1, mZero.FreeBound(mAttach));
        }

        [Test]
        public void BoundPositionTest()
        {
            BoundPositionTest(mZero, 0, mZero.Position.X + Molecule.TETRAHEDRON_SITE, mZero.Position.Y);
            BoundPositionTest(mZero, 1, mZero.Position.X - Molecule.TETRAHEDRON_SITE / 2, mZero.Position.Y + Math.Sqrt(3) * Molecule.TETRAHEDRON_SITE / 2);
            BoundPositionTest(mZero, 2, mZero.Position.X - Molecule.TETRAHEDRON_SITE / 2, mZero.Position.Y - Math.Sqrt(3) * Molecule.TETRAHEDRON_SITE / 2);

            mZero.BoundType = BoundType.II;
            BoundPositionTest(mZero, 0, mZero.Position.X - Molecule.TETRAHEDRON_SITE, mZero.Position.Y);
            BoundPositionTest(mZero, 1, mZero.Position.X + Molecule.TETRAHEDRON_SITE / 2, mZero.Position.Y - Math.Sqrt(3) * Molecule.TETRAHEDRON_SITE / 2);
            BoundPositionTest(mZero, 2, mZero.Position.X + Molecule.TETRAHEDRON_SITE / 2, mZero.Position.Y + Math.Sqrt(3) * Molecule.TETRAHEDRON_SITE / 2);

        }

        public void BoundPositionTest(Molecule molecule, int boundNr, double xExp, double yExp)
        {
            var poz = molecule.BoundPosition(boundNr);

            var poz_expected = new Position(xExp, yExp);

            AssertExtensions.AreAlmostEqual(poz_expected, poz);

        }

        [Test]
        public void TryToAttachDefinitelyTest()
        {
            Molecule mTo, mAttach;

            mTo = mZero;
            mAttach = new Molecule(habitat);
            mAttach.Position = mTo.Position.PointOfAngle(Molecule.TETRAHEDRON_SITE, Math.PI * 5 / 6);

            TryToAttachDefinitelyTest(mTo, mAttach, 1, BoundType.II);

            //------

            mTo = mAttach;
            mAttach = new Molecule(habitat);
            mAttach.Position = mTo.Position.PointOfAngle(Molecule.TETRAHEDRON_SITE, Math.PI);

            TryToAttachDefinitelyTest(mTo, mAttach, 0, BoundType.I);

            //------

            mTo = mAttach;
            mAttach = new Molecule(habitat);
            mAttach.Position = mTo.Position.PointOfAngle(Molecule.TETRAHEDRON_SITE, 3 * Math.PI / 2);

            TryToAttachDefinitelyTest(mTo, mAttach, 2, BoundType.II);

            //------

            mTo = mAttach;
            mAttach = new Molecule(habitat);
            mAttach.Position = mTo.Position.PointOfAngle(Molecule.TETRAHEDRON_SITE, 3 * Math.PI / 2);

            TryToAttachDefinitelyTest(mTo, mAttach, 1, BoundType.I);
            
            //------

            mTo = mAttach;
            mAttach = new Molecule(habitat);
            mAttach.Position = mTo.Position.PointOfAngle(Molecule.TETRAHEDRON_SITE, 11 * Math.PI / 6);

            Assert.AreEqual(5, mAttach.Position.TetrahedronPart(mTo.Position));

            Assert.AreEqual(0, mTo.FreeBound(mAttach));

            TryToAttachDefinitelyTest(mTo, mAttach, 0, BoundType.II);

            Assert.AreEqual(2, mZero.GetBoundNr(mAttach));

            Assert.AreEqual(2, mAttach.GetBoundNr(mZero));

        }

        public void TryToAttachDefinitelyTest(Molecule mTo, Molecule mAttach, int boundNr_expected, BoundType boudType_expected)
        {
            mAttach.TryToAttachDefinitely(mTo);

            Assert.AreEqual(boundNr_expected, mTo.GetBoundNr(mAttach));

            Assert.AreEqual(boundNr_expected, mAttach.GetBoundNr(mTo));

            Assert.AreEqual(boudType_expected, mAttach.BoundType);

            var poz_expected = mTo.BoundPosition(boundNr_expected);

            AssertExtensions.AreAlmostEqual(poz_expected, mAttach.Position);

            // Assert.AreEqual(tetraNr_expected, mAttach.Position.TetrahedronPart(mTo.Position));
        }
    }
}
