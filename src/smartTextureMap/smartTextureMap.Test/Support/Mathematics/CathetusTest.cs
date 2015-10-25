using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smartTextureMap.Support.Mathematics;

namespace smartTextureMap.Test.Support.Mathematics
{
    [TestClass]
    public class CathetusTest
    {
        [TestMethod]
        public void GetSizeTest()
        {
            #region Scenario setup

            Cathetus cathetus =
                new Cathetus(
                    new smartTextureMap.Support.Point(0, 0),
                    new smartTextureMap.Support.Point(10, 10));

            #endregion

            #region Running the tested operation

            var evidence = cathetus.GetSize();

            #endregion

            #region Getting the evidences

            #endregion

            #region Validating the evidences

            Assert.AreEqual(14.142135623730951, evidence);

            #endregion
        }

        [TestMethod]
        public void GetPerpendicularInterceptionPointTestByY()
        {
            #region Scenario setup

            Cathetus cathetusA =
                new Cathetus(
                    new smartTextureMap.Support.Point(20, 4),
                    new smartTextureMap.Support.Point(20, 20));

            Cathetus cathetusB =
                new Cathetus(
                    new smartTextureMap.Support.Point(11, 11),
                    new smartTextureMap.Support.Point(30, 11));

            #endregion

            #region Running the tested operation

            var evidence =
                cathetusA.GetPerpendicularInterceptionPoint(cathetusB);

            #endregion

            #region Getting the evidences

            #endregion

            #region Validating the evidences

            Assert.AreEqual(20, evidence.X);
            Assert.AreEqual(11, evidence.Y);

            #endregion
        }

        [TestMethod]
        public void GetPerpendicularInterceptionPointTestByX()
        {
            #region Scenario setup

            Cathetus cathetusA =
                new Cathetus(
                    new smartTextureMap.Support.Point(20, 4),
                    new smartTextureMap.Support.Point(20, 20));

            Cathetus cathetusB =
                new Cathetus(
                    new smartTextureMap.Support.Point(11, 11),
                    new smartTextureMap.Support.Point(30, 11));

            #endregion

            #region Running the tested operation

            var evidence =
                cathetusB.GetPerpendicularInterceptionPoint(cathetusA);

            #endregion

            #region Getting the evidences

            #endregion

            #region Validating the evidences

            Assert.AreEqual(20, evidence.X);
            Assert.AreEqual(11, evidence.Y);

            #endregion
        }
    }
}
