using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CrystalsTests
{
    public static class AssertExtensions
    {
        public static double DOUBLE_DELTA = 0.00000000001;
     
        public static void AreAlmostEqual(double expected, double actual)
        {
            Assert.Less(Math.Abs(expected - actual), DOUBLE_DELTA, String.Format("Expected: {0} Actual:{1}", expected, actual));
        }

    }
}
