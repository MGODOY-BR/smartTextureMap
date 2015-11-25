using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smartTextureMap.Support;
using smartTextureMap.Intelligence.Lens;
using smartTextureMap.IO;
using smartTextureMap.Test.Trace;

namespace smartTextureMap.Test.Intelligence.Lens
{
    [TestClass]
    public class SensorTest
    {
        [TestInitialize]
        public void Setup()
        {
            OutputManager.SetOutPutWay(new TraceOutput());
        }

        [TestMethod]
        public void UpdateGetPointTest()
        {
            #region Scenario setup

            using (Picture image = new Picture(Resource1.ShapeMarkTest))
            {
                #endregion

                #region Running the tested operation

                Sensor sensor = new Sensor(image);
                sensor.Update(8, 9);

                #endregion

                #region Getting the evidences

                var evidence = sensor.GetPoint();

                #endregion

                #region Validating the evidences

                Assert.AreEqual(8, evidence.X);
                Assert.AreEqual(9, evidence.Y);

                #endregion
            }
        }

        [TestMethod]
        public void UpdateCheckTest()
        {
            #region Scenario setup

            using (Picture image = new Picture(Resource1.ShapeMarkTest))
            {
                #endregion

                #region Running the tested operation

                Sensor sensor = new Sensor(image);
                sensor.Update(8, 9);

                #endregion

                #region Getting the evidences

                var evidence = sensor.Check();

                #endregion

                #region Validating the evidences

                Assert.IsTrue(evidence.IsBoundary);

                #endregion
            }
        }

        [TestMethod]
        public void UpdateCheckTestNegative()
        {
            #region Scenario setup

            using (Picture image = new Picture(Resource1.ShapeMarkTest))
            {
                #endregion

                #region Running the tested operation

                Sensor sensor = new Sensor(image);
                sensor.Update(1, 1);

                #endregion

                #region Getting the evidences

                var evidence = sensor.Check();

                #endregion

                #region Validating the evidences

                Assert.IsFalse(evidence.IsBoundary);

                #endregion
            }
        }

    }
}
