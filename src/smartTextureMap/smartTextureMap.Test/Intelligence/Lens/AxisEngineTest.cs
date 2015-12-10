using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smartTextureMap.Support;
using smartTextureMap.Intelligence.Lens;
using smartTextureMap.IO;
using smartTextureMap.Test.Trace;

namespace smartTextureMap.Test.Intelligence.Lens
{
    [TestClass]
    public class AxisEngineTest
    {
        [TestInitialize]
        public void Setup()
        {
            OutputManager.SetOutPutWay(new TraceOutput());
        }

        [TestMethod]
        public void RunTest()
        {
            #region Scenario setup

            using (Picture image = new Picture(Resource1.ShapeMarkTest))

            #endregion
            {
                #region Running the tested operation

                AxisEngine axisEngine = new AxisEngine(new ContextMap(), image);
                axisEngine.Run();

                #endregion

                #region Getting the evidences

                var evidence = axisEngine.GetSquares();

                #endregion

                #region Validating the evidences

                Assert.AreEqual(1, evidence.Count);
                Assert.AreEqual(8, evidence[0].PointA.X);
                Assert.AreEqual(9, evidence[0].PointA.Y);

                Assert.AreEqual(39, evidence[0].PointB.X);
                Assert.AreEqual(26, evidence[0].PointB.Y);

                #endregion
            }
        }
    }
}
