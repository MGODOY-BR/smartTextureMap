using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smartTextureMap.Support;
using smartTextureMap.Support.Mathematics;
using smartTextureMap.IO;
using smartTextureMap.Test.Trace;

namespace smartTextureMap.Test.Support.Mathematics
{
    [TestClass]
    public class CathetusParserTest
    {
        [TestInitialize]
        public void Setup()
        {
            OutputManager.SetOutPutWay(new TraceOutput());
        }

        [TestMethod]
        public void GetAdjacentCathetiTest()
        {
            #region Scenario setup

            LogicalSquare squareA = 
                new LogicalSquare(
                    new smartTextureMap.Support.Point(20, 4),
                    new smartTextureMap.Support.Point(30, 11));

            LogicalSquare squareB =
                new LogicalSquare(
                    new smartTextureMap.Support.Point(5, 11),
                    new smartTextureMap.Support.Point(30, 30));

            #endregion

            #region Running the tested operation

            CathetusParser parser = new CathetusParser(squareA, squareB);
            var evidence = parser.GetAdjacentCatheti(AngleStrategyEnum.AAAD);

            #endregion

            #region Getting the evidences

            #endregion

            #region Validating the evidences

            Assert.AreNotEqual(0, evidence.CalculateAngle());

            #endregion
        }
    }
}
