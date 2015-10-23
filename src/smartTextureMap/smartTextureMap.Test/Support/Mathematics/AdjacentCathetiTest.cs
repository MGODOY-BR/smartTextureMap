using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smartTextureMap.Support.Mathematics;

namespace smartTextureMap.Test.Support.Mathematics
{
    [TestClass]
    public class AdjacentCathetiTest
    {
        [TestMethod]
        public void CalculateAngleTest()
        {
            #region Scenario setup

            Cathetus oposite =
                new Cathetus(
                    new smartTextureMap.Support.Point(4000, 0),
                    new smartTextureMap.Support.Point(4000, 2300));

            Cathetus adjacent =
                new Cathetus(
                    new smartTextureMap.Support.Point(0, 0),
                    new smartTextureMap.Support.Point(4000, 0));

            #endregion

            #region Running the tested operation

            AdjacentCatheti adjacentCatheti = new AdjacentCatheti(adjacent, oposite);
            var evidence = adjacentCatheti.CalculateAngle();

            #endregion

            #region Getting the evidences

            // Rounding evidence to match
            evidence = Math.Round(evidence, 0);

            #endregion

            #region Validating the evidences

            Assert.AreEqual(30, evidence);

            #endregion
        }
    }
}
