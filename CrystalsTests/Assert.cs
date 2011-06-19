using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Crystals;

namespace CrystalsTests
{
    public static class AssertExtensions
    {
        public static double DOUBLE_DELTA = 0.00000000001;

        public static void AreAlmostEqual(double expected, double actual)
        {
            AreAlmostEqual(expected, actual, null);
        }

        public static void AreAlmostEqual(double expected, double actual, string message)
        {
            Assert.Less(Math.Abs(expected - actual), DOUBLE_DELTA, String.Format("{2}  Expected: {0}\n  But was:{1}", expected, actual, message + Environment.NewLine));
        }


        public static void AreAlmostEqual(Position expected, Position actual)
        {
            AssertExtensions.AreAlmostEqual(expected.X, actual.X, "X");
            AssertExtensions.AreAlmostEqual(expected.Y, actual.Y, "Y");
        }

    }
}
