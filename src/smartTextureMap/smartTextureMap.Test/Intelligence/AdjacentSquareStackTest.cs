using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smartTextureMap.Support;
using System.Collections.Generic;
using smartTextureMap.Intelligence;

namespace smartTextureMap.Test.Intelligence
{
    [TestClass]
    public class AdjacentSquareStackTest
    {
        [TestMethod]
        public void TryCollectTest()
        {
            #region Scenario setup

            List<LogicalSquare> stubList = new List<LogicalSquare>()
            {
                new LogicalSquare(
                    new Point(291, 29), new Point(612, 50)),
                new LogicalSquare(
                    new Point(279, 50), new Point(640, 100)),
                new LogicalSquare(
                    new Point(248, 100), new Point(684, 179)),
                new LogicalSquare(
                    new Point(201, 179), new Point(739, 279)),
                new LogicalSquare(
                    new Point(817, 38), new Point(892, 105)),       // <-- That square it's out of adjacency
            };

            #endregion

            #region Running the tested operation

            AdjacentSquareStack adjacentSquareStack = new AdjacentSquareStack();
            foreach (var stub in stubList)
            {
                adjacentSquareStack.TryCollect(stub);
            }

            #endregion

            #region Getting the evidences

            var evidenceList = adjacentSquareStack.GetList();
            var evidenceEquivalent = adjacentSquareStack.GetEquivalent();

            #endregion

            #region Validating the evidences

            Assert.AreEqual(4, evidenceList.Count);

            Assert.AreEqual(201, evidenceEquivalent.PointA.X);
            Assert.AreEqual(29, evidenceEquivalent.PointA.Y);

            Assert.AreEqual(739, evidenceEquivalent.PointB.X);
            Assert.AreEqual(279, evidenceEquivalent.PointB.Y);

            #endregion
        }
    }
}
