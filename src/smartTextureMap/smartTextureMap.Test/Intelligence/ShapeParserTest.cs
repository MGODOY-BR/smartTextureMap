using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smartTextureMap.Support;
using smartTextureMap.Intelligence;
using System.Collections.Generic;
using smartTextureMap.IO;
using smartTextureMap.Test.Trace;

namespace smartTextureMap.Test.Intelligence
{
    [TestClass]
    public class ShapeParserTest
    {
        [TestInitialize]
        public void Setup()
        {
            OutputManager.SetOutPutWay(new TraceOutput());
        }

        [TestMethod]
        public void DiscoverTest()
        {
            #region Scenario setup

            using (Picture image = new Picture(Resource1.ShapeParser_DiscoverTest))
            {
                #endregion

                #region Running the tested operation

                ShapeParser parser = new ShapeParser(new ContextMap());
                List<Shape> evidenceList = parser.Discover(new Point(0, 0), image);

                #endregion

                #region Getting the evidences

                #endregion

                #region Validating the evidences

                Assert.IsTrue(evidenceList.Count > 5);

                #endregion
            }
        }
    }
}
