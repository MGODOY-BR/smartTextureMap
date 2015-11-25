using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smartTextureMap.Intelligence;
using smartTextureMap.IO;
using smartTextureMap.Test.Trace;

namespace smartTextureMap.Test.Intelligence
{
    [TestClass]
    public class SmartTextureMapTest
    {
        [TestInitialize]
        public void Setup()
        {
            OutputManager.SetOutPutWay(new TraceOutput());
        }

        [TestMethod]
        public void GenerateTest()
        {
            #region Scenario setup

            String fileName = "SmartTextureMapTest.GenerateTest.png";
            String fileNameGenerated = "SmartTextureMapTest.GenerateTest.smartMap.png";
            Resource1.ShapeParser_DiscoverTest.Save(fileName);
            
            SmartTextureMap smartTextureMap = new SmartTextureMap();
            smartTextureMap.Load(fileName);

            #endregion

            #region Running the tested operation

            smartTextureMap.Generate(fileNameGenerated);

            #endregion

            #region Getting the evidences

            #endregion

            #region Validating the evidences

            // This is a visual test.

            #endregion
        }
    }
}
