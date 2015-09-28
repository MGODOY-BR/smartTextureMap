using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using smartTextureMap.Support;

namespace smartTextureMap.Test.Support
{
    [TestClass]
    public class PictureTest
    {
        [TestMethod]
        public void MarkTest()
        {
            #region Scenario setup

            #endregion

            #region Running the tested operation

            FontFamily fontFamily = new FontFamily("Arial");
            Font font = new Font(
               fontFamily,
               24,
               FontStyle.Regular,
               GraphicsUnit.Pixel);

            Picture picture = new Picture(Resource1.blank);
            picture.Mark("A", new smartTextureMap.Support.Point(1, 1), font);

            #endregion

            #region Getting the evidences

            picture.SaveAs("PictureTest.MarkTest.png");

            #endregion

            #region Validating the evidences

            // This test is going to be visual

            #endregion
        }

        [TestMethod]
        public void CheckBoundaryTest()
        {

            #region Scenario setup

            #endregion

            #region Running the tested operation

            Picture picture = new Picture(Resource1.checkBoundaryStub);
            bool evidency = picture.CheckBoundary(new smartTextureMap.Support.Point(22, 22));

            #endregion

            #region Getting the evidences

            #endregion

            #region Validating the evidences

            Assert.IsTrue(evidency);

            #endregion
        }

        [TestMethod]
        public void CheckBoundaryTestNegative()
        {

            #region Scenario setup

            #endregion

            #region Running the tested operation

            Picture picture = new Picture(Resource1.checkBoundaryStub);
            bool evidency = picture.CheckBoundary(new smartTextureMap.Support.Point(5, 5));

            #endregion

            #region Getting the evidences

            #endregion

            #region Validating the evidences

            Assert.IsFalse(evidency);

            #endregion
        }

    }
}