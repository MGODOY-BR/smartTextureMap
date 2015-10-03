using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smartTextureMap.Support;
using smartTextureMap.Intelligence.Lens;

namespace smartTextureMap.Test.Intelligence.Lens
{
    [TestClass]
    public class AxisEngineTest
    {
        [TestMethod]
        public void RunTest()
        {
            #region Scenario setup

            Picture image = new Picture(Resource1.ShapeMarkTest);

            #endregion

            #region Running the tested operation

            AxisEngine axisEngine = new AxisEngine(image);
            axisEngine.Run();

            #endregion

            #region Getting the evidences

            var evidence = axisEngine.GetSquares();

            #endregion

            #region Validating the evidences

            Assert.AreEqual(1, evidence.Count);
            Assert.AreEqual(8, evidence[0].PointA.X);
            Assert.AreEqual(8, evidence[0].PointA.Y);

            Assert.AreEqual(38, evidence[0].PointB.X);
            Assert.AreEqual(27, evidence[0].PointB.Y);

            #endregion
        }
    }
}
