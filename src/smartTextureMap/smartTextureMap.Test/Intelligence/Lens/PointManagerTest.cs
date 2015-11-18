using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smartTextureMap.Intelligence.Lens;
using smartTextureMap.Support;

namespace smartTextureMap.Test.Intelligence.Lens
{
    [TestClass]
    public class PointManagerTest
    {
        [TestMethod]
        public void GetRightCornerTest()
        {
            #region Scenario setup

            #endregion

            #region Running the tested operation

            PointManager pointManager = new PointManager();

            pointManager.Register(new Point(12, 13));
            pointManager.Register(new Point(0, 0));
            pointManager.Register(new Point(50, 13));
            pointManager.Register(new Point(50, 9));

            #endregion

            #region Getting the evidences

            var evidence = pointManager.GetRightCorner();

            #endregion

            #region Validating the evidences

            Assert.AreEqual(50, evidence.X);
            Assert.AreEqual(13, evidence.Y);

            #endregion
        }
    }
}
