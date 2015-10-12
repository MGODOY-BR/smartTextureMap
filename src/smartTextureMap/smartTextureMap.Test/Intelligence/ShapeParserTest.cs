using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smartTextureMap.Support;
using smartTextureMap.Intelligence;
using System.Collections.Generic;

namespace smartTextureMap.Test.Intelligence
{
    [TestClass]
    public class ShapeParserTest
    {
        [TestMethod]
        public void DiscoverTest()
        {
            #region Scenario setup

            using (Picture image = new Picture(Resource1.ShapeParser_DiscoverTest))
            {
                #endregion

                #region Running the tested operation

                ShapeParser parser = new ShapeParser();
                List<Shape> evidenceList = parser.Discover(new Point(0, 0), image);

                #endregion

                #region Getting the evidences

                foreach (var item in evidenceList)
                {
                    item.Mark("A");
                }
                // Print image
                image.SaveAs("Teste.png");

                #endregion

                #region Validating the evidences

                Assert.AreEqual(5, evidenceList.Count);

                #endregion
            }
        }
    }
}
