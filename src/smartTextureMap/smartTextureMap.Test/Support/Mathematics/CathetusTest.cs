using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smartTextureMap.Support.Mathematics;

namespace smartTextureMap.Test.Support.Mathematics
{
    [TestClass]
    public class CathetusTest
    {
        [TestMethod]
        public void GetSizeTest()
        {
            #region Scenario setup

            Cathetus cathetus =
                new Cathetus(
                    new smartTextureMap.Support.Point(0, 0),
                    new smartTextureMap.Support.Point(10, 10));

            #endregion

            #region Running the tested operation

            var evidence = cathetus.GetSize();

            #endregion

            #region Getting the evidences

            #endregion

            #region Validating the evidences

            Assert.AreEqual(14.142135623730951, evidence);

            #endregion
        }
    }
}
