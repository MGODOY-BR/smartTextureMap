using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smartTextureMap.Support;

namespace smartTextureMap.Test.Support
{
    [TestClass]
    public class ShapeTest
    {
        [TestMethod]
        public void MarkTest()
        {
            #region Scenario setup

            Picture picture = new Picture(Resource1.ShapeMarkTest);

            #endregion

            #region Running the tested operation

            Shape shape =
                new Shape(
                    new LogicalSquare(
                        new Point(10, 10),
                        new Point(38, 25)),
                    picture);

            shape.Mark("M");

            #endregion

            #region Getting the evidences

            picture.SaveAs("ShapeMarkTest.result.png");

            #endregion

            #region Validating the evidences

            // This test is going to be visual

            #endregion
        }
    }
}
