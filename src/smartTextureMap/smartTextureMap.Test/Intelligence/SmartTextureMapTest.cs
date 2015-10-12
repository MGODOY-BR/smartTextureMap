using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smartTextureMap.Intelligence;

namespace smartTextureMap.Test.Intelligence
{
    [TestClass]
    public class SmartTextureMapTest
    {
        [TestMethod]
        public void GenerateTest()
        {
            #region Scenario setup

            String fileName = "SmartTextureMapTest.GenerateTest.png";
            String fileNameGenerated = "SmartTextureMapTest.GenerateTest.revisted.png";
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
