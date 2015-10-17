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

        [TestMethod]
        public void CheckIntersectionTestA()
        {
            #region Scenario setup

            LogicalSquare squareA =
                new LogicalSquare(
                    new Point(10, 10),
                    new Point(100, 100));

            LogicalSquare squareB =
                new LogicalSquare(
                    new Point(80, 10),
                    new Point(180, 100));

            #endregion

            #region Running the tested operation

            var evidenceA = squareA.CheckIntersection(squareB);
            var evidenceB = squareB.CheckIntersection(squareA);

            #endregion

            #region Getting the evidences

            #endregion

            #region Validating the evidences

            Assert.IsTrue(evidenceA);
            Assert.IsTrue(evidenceB);

            #endregion
        }

        [TestMethod]
        public void CheckIntersectionTestB()
        {
            #region Scenario setup

            LogicalSquare squareA =
                new LogicalSquare(
                    new Point(10, 10),
                    new Point(100, 180));

            LogicalSquare squareB =
                new LogicalSquare(
                    new Point(80, 80),
                    new Point(180, 180));

            #endregion

            #region Running the tested operation

            var evidenceA = squareA.CheckIntersection(squareB);
            var evidenceB = squareB.CheckIntersection(squareA);

            #endregion

            #region Getting the evidences

            #endregion

            #region Validating the evidences

            Assert.IsTrue(evidenceA);
            Assert.IsTrue(evidenceB);

            #endregion
        }

        [TestMethod]
        public void CheckIntersectionTestC()
        {
            #region Scenario setup

            LogicalSquare squareA =
                new LogicalSquare(
                    new Point(10, 10),
                    new Point(100, 180));

            LogicalSquare squareB =
                new LogicalSquare(
                    new Point(20, 20),
                    new Point(80, 80));

            #endregion

            #region Running the tested operation

            var evidenceA = squareA.CheckIntersection(squareB);
            var evidenceB = squareB.CheckIntersection(squareA);

            #endregion

            #region Getting the evidences

            #endregion

            #region Validating the evidences

            Assert.IsTrue(evidenceA);
            Assert.IsTrue(evidenceB);

            #endregion
        }

        [TestMethod]
        public void CheckIntersectionTestD()
        {
            #region Scenario setup

            LogicalSquare squareA =
                new LogicalSquare(
                    new Point(10, 10),
                    new Point(100, 180));

            LogicalSquare squareB =
                new LogicalSquare(
                    new Point(10, 10),
                    new Point(100, 180));

            #endregion

            #region Running the tested operation

            var evidenceA = squareA.CheckIntersection(squareB);
            var evidenceB = squareB.CheckIntersection(squareA);

            #endregion

            #region Getting the evidences

            #endregion

            #region Validating the evidences

            Assert.IsTrue(evidenceA);
            Assert.IsTrue(evidenceB);

            #endregion
        }

        [TestMethod]
        public void CheckIntersectionTestNegative()
        {
            #region Scenario setup

            LogicalSquare squareA =
                new LogicalSquare(
                    new Point(10, 10),
                    new Point(100, 180));

            LogicalSquare squareB =
                new LogicalSquare(
                    new Point(200, 200),
                    new Point(300, 400));

            #endregion

            #region Running the tested operation

            var evidenceA = squareA.CheckIntersection(squareB);
            var evidenceB = squareB.CheckIntersection(squareA);

            #endregion

            #region Getting the evidences

            #endregion

            #region Validating the evidences

            Assert.IsFalse(evidenceA);
            Assert.IsFalse(evidenceB);

            #endregion
        }

        [TestMethod]
        public void CheckIntersectionTestNegative2()
        {
            #region Scenario setup

            LogicalSquare squareA =
                new LogicalSquare(
                    new Point(10, 10),
                    new Point(100, 180));

            LogicalSquare squareB =
                new LogicalSquare(
                    new Point(400, 180),
                    new Point(800, 1000));

            #endregion

            #region Running the tested operation

            var evidenceA = squareA.CheckIntersection(squareB);
            var evidenceB = squareB.CheckIntersection(squareA);

            #endregion

            #region Getting the evidences

            #endregion

            #region Validating the evidences

            Assert.IsFalse(evidenceA);
            Assert.IsFalse(evidenceB);

            #endregion
        }

        [TestMethod]
        public void CheckVerticalAdjacentTest()
        {
            #region Scenario setup

            LogicalSquare squareA =
                new LogicalSquare(
                        new Point(14, 14),
                        new Point(170, 125));

            LogicalSquare squareB =
                new LogicalSquare(
                        new Point(14, 125),
                        new Point(170, 220));

            #endregion

            #region Running the tested operation

            var evidenceA = squareA.CheckVerticalAdjacent(squareB);
            var evidenceB = squareB.CheckVerticalAdjacent(squareA);

            #endregion

            #region Getting the evidences

            #endregion

            #region Validating the evidences

            Assert.IsTrue(evidenceA);
            Assert.IsTrue(evidenceB);

            #endregion
        }

        [TestMethod]
        public void CheckVerticalAdjacentTest2()
        {
            #region Scenario setup

            LogicalSquare squareA =
                new LogicalSquare(
                        new Point(40, 14),
                        new Point(170, 125));

            LogicalSquare squareB =
                new LogicalSquare(
                        new Point(14, 125),
                        new Point(170, 220));

            #endregion

            #region Running the tested operation

            var evidenceA = squareA.CheckVerticalAdjacent(squareB);
            var evidenceB = squareB.CheckVerticalAdjacent(squareA);

            #endregion

            #region Getting the evidences

            #endregion

            #region Validating the evidences

            Assert.IsTrue(evidenceA);
            Assert.IsTrue(evidenceB);

            #endregion
        }

        [TestMethod]
        public void CheckVerticalAdjacentTest3()
        {
            #region Scenario setup

            LogicalSquare squareA =
                new LogicalSquare(
                        new Point(14, 14),
                        new Point(170, 125));

            LogicalSquare squareB =
                new LogicalSquare(
                        new Point(40, 125),
                        new Point(170, 220));

            #endregion

            #region Running the tested operation

            var evidenceA = squareA.CheckVerticalAdjacent(squareB);
            var evidenceB = squareB.CheckVerticalAdjacent(squareA);

            #endregion

            #region Getting the evidences

            #endregion

            #region Validating the evidences

            Assert.IsTrue(evidenceA);
            Assert.IsTrue(evidenceB);

            #endregion
        }

        [TestMethod]
        public void CheckVerticalAdjacentTestNegative()
        {
            #region Scenario setup

            LogicalSquare squareA =
                new LogicalSquare(
                        new Point(14, 14),
                        new Point(170, 125));

            LogicalSquare squareB =
                new LogicalSquare(
                        new Point(40, 140),
                        new Point(170, 220));

            #endregion

            #region Running the tested operation

            var evidenceA = squareA.CheckVerticalAdjacent(squareB);
            var evidenceB = squareB.CheckVerticalAdjacent(squareA);

            #endregion

            #region Getting the evidences

            #endregion

            #region Validating the evidences

            Assert.IsFalse(evidenceA);
            Assert.IsFalse(evidenceB);

            #endregion
        }
    }
}
