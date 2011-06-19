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
        Molecule[] molecules;

        [TestFixtureSetUp]
        public void SetUp()
        {
            molecules = new Molecule[2];
            
            var habitat = new Habitat(1, 1, 1);

            molecules[0] = new Molecule(habitat);
            molecules[0].Position.X = 0;
            molecules[0].Position.Y = 0;
            molecules[0].BelongsToFlake = true;
            molecules[0].BoundType = BoundType.I;

            molecules[1] = new Molecule(habitat);
            molecules[1].Position = molecules[0].Position.PointOfAngle(Molecule.TETRAHEDRON_SITE, Math.PI * 5 / 6);

        }

        [Test]
        public void FreeBoundTest()
        {
            Assert.AreEqual(1, molecules[0].FreeBound(molecules[1]));
        }


        [Test]
        public void TryToAttachDefinitely()
        {

            molecules[1].TryToAttachDefinitely(molecules[0]);

            Assert.AreEqual(1, molecules[0].GetBoundNr(molecules[1]));

            Assert.AreEqual(1, molecules[1].GetBoundNr(molecules[0]));

            Assert.AreEqual(BoundType.II, molecules[1].BoundType);

            var poz = molecules[0].BoundPosition(2);

            AssertExtensions.AreAlmostEqual(poz.X, molecules[1].Position.X);
            AssertExtensions.AreAlmostEqual(poz.Y, molecules[1].Position.Y);


            Assert.AreEqual(2, molecules[1].Position.TetrahedronPart(molecules[0].Position));

        }
    }
}
