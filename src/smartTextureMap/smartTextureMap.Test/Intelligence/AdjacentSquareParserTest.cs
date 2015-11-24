using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using smartTextureMap.Support;
using smartTextureMap.Intelligence;

namespace smartTextureMap.Test.Intelligence
{
    [TestClass]
    public class AdjacentSquareParserTest
    {
        [TestMethod]
        public void TryToFitTest()
        {
            #region Scenario setup

            List<LogicalSquare> stubList = new List<LogicalSquare>()
            {
                new LogicalSquare(
                    new Point(291, 29), new Point(612, 50)),        // <-- Beginning of first pattern
                new LogicalSquare(
                    new Point(279, 50), new Point(640, 100)),
                new LogicalSquare(
                    new Point(248, 100), new Point(684, 179)),
                new LogicalSquare(
                    new Point(201, 179), new Point(739, 279)),
                new LogicalSquare(
                    new Point(817, 38), new Point(892, 105)),       // <-- Beginning of second pattern
                new LogicalSquare(
                    new Point(790, 105), new Point(884, 125)),
                new LogicalSquare(
                    new Point(782, 125), new Point(857, 149)),
                new LogicalSquare(
                    new Point(772, 149), new Point(811, 173)),
                new LogicalSquare(                                  // <-- Out of pattern square
                    new Point(862, 179), new Point(904, 212)),
            };

            #endregion

            #region Running the tested operation

            AdjacentSquareParser parser = new AdjacentSquareParser();
            foreach (var stub in stubList)
            {
                parser.TryToFit(stub);
            }

            #endregion

            #region Getting the evidences

            var evidenceSquareList = parser.GetAcceptedSquareList();
            var evidenceEquivalentSquares = parser.GetEquivalentSquares();

            #endregion

            #region Validating the evidences

            Assert.AreEqual(2, evidenceEquivalentSquares.Count);
            Assert.AreEqual(8, evidenceSquareList.Count);

            #endregion
        }
    }
}
