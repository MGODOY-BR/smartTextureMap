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

                String[] letterArray = new String[7] { "a", "b", "c", "d", "e", "f", "g" };

                for (int i = 0; i < letterArray.Length; i++)
                {
                    var item = evidenceList[i];

                    item.Mark(letterArray[i]);
                }

                // Print image
                // image.SaveAs("Teste.png");

                #endregion

                #region Validating the evidences

                Assert.IsTrue(evidenceList.Count > 5);

                #endregion
            }
        }
    }
}
