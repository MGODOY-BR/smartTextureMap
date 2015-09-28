using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smartTextureMap.Support;

namespace smartTextureMap.Test.Support
{
    [TestClass]
    public class LogicalSquareTest
    {
        [TestMethod]
        public void CheckInsideTest()
        {
            #region Scenario setup

            Point stub = new Point(50, 60);

            #endregion

            #region Running the tested operation

            LogicalSquare logicalSquare
                = new LogicalSquare(
                    new Point(0, 0),
                    new Point(100, 100));

            Boolean evidence = logicalSquare.CheckInside(stub);

            #endregion

            #region Getting the evidences

            #endregion

            #region Validating the evidences

            Assert.IsTrue(evidence);

            #endregion
        }

        [TestMethod]
        public void CheckInsideTestNegative()
        {
            #region Scenario setup

            Point stub = new Point(50, 160);

            #endregion

            #region Running the tested operation

            LogicalSquare logicalSquare
                = new LogicalSquare(
                    new Point(0, 0),
                    new Point(100, 100));

            Boolean evidence = logicalSquare.CheckInside(stub);

            #endregion

            #region Getting the evidences

            #endregion

            #region Validating the evidences

            Assert.IsFalse(evidence);

            #endregion
        }
    }
}
