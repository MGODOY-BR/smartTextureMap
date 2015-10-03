using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smartTextureMap.Support;
using smartTextureMap.Intelligence.Lens;

namespace smartTextureMap.Test.Intelligence.Lens
{
    [TestClass]
    public class ShapeLenTest
    {
        [TestMethod]
        public void ReadTest()
        {
            #region Scenario setup

            Picture image = new Picture(Resource1.Triangle);

            #endregion

            #region Running the tested operation

            ShapeLen shapeLen = new ShapeLen(image);
            var evidenceA = shapeLen.Read(101, 20);
            var evidenceB = shapeLen.Read(343, 20);
            var evidenceC = shapeLen.Read(260, 143);
            var evidenceD = shapeLen.Read(222, 204);
            var evidenceE = shapeLen.Read(129, 61);

            #endregion

            #region Getting the evidences

            #endregion

            #region Validating the evidences

            Assert.IsTrue(evidenceA);
            Assert.IsTrue(evidenceB);
            Assert.IsTrue(evidenceC);
            Assert.IsTrue(evidenceD);
            Assert.IsTrue(evidenceE);

            #endregion
        }

        [TestMethod]
        public void CheckRightBoundaryTest()
        {
            #region Scenario setup

            Picture image = new Picture(Resource1.Triangle);

            #endregion

            #region Running the tested operation

            ShapeLen shapeLen = new ShapeLen(image);
            shapeLen.Read(323, 47);

            #endregion

            #region Getting the evidences

            var evidence = shapeLen.CheckRightBoundary();

            #endregion

            #region Validating the evidences

            Assert.IsTrue(evidence);

            #endregion
        }

        [TestMethod]
        public void CheckBottomBoundaryTest()
        {
            #region Scenario setup

            Picture image = new Picture(Resource1.Triangle);

            #endregion

            #region Running the tested operation

            ShapeLen shapeLen = new ShapeLen(image);
            shapeLen.Read(222, 202);

            #endregion

            #region Getting the evidences

            var evidence = shapeLen.CheckBottomBoundary();

            #endregion

            #region Validating the evidences

            Assert.IsTrue(evidence);

            #endregion
        }

        [TestMethod]
        public void ReadTestNegative()
        {
            #region Scenario setup

            Picture image = new Picture(Resource1.Triangle);

            #endregion

            #region Running the tested operation

            ShapeLen shapeLen = new ShapeLen(image);
            var evidenceA = shapeLen.Read(328, 13);
            var evidenceB = shapeLen.Read(326, 38);
            var evidenceC = shapeLen.Read(318, 113);
            var evidenceD = shapeLen.Read(329, 214);
            var evidenceE = shapeLen.Read(220, 186);

            #endregion

            #region Getting the evidences

            #endregion

            #region Validating the evidences

            Assert.IsFalse(evidenceA);
            Assert.IsFalse(evidenceB);
            Assert.IsFalse(evidenceC);
            Assert.IsFalse(evidenceD);
            Assert.IsFalse(evidenceE);

            #endregion
        }

    }
}
