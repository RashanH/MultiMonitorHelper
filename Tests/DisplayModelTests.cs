#region Usings

using System.Drawing;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiMonitorHelper;

#endregion

namespace Tests
{
    [TestClass]
    public class DisplayModelTests
    {
        [TestMethod]
        public void TestIfActiveAndDeActiveWorks()
        {
            IDisplayModel displayModel = DisplayFactory.GetDisplayModel();
            Display primary = displayModel.GetPrimaryDisplay();

            Assert.IsTrue(primary.IsActive);

            primary.SetDeactive();

            Assert.IsFalse(primary.IsActive);

            primary.SetActive();

            Assert.IsTrue(primary.IsActive);
        }

        [TestMethod]
        public void TestIfResolutionChangingWorks()
        {
            IDisplayModel displayModel = DisplayFactory.GetDisplayModel();
            Display primary = displayModel.GetPrimaryDisplay();

            var newResolution = new Size(800, 600);

            Assert.IsTrue(primary.SetResolution(newResolution));

            Assert.AreEqual(newResolution, primary.Resolution);
        }

        [TestMethod]
        public void TestRotation()
        {
            IDisplayModel displayModel = DisplayFactory.GetDisplayModel();
            Display primary = displayModel.GetPrimaryDisplay();

            var currentOrientation = primary.Rotation;

            // yeah, the orientation is default currently.
            Assert.AreEqual(DisplayRotation.Default, currentOrientation);

            // set the rotation to 180.
            Assert.IsTrue(primary.SetRotation(DisplayRotation.Rotated180));

            // see if the change worked
            Assert.AreEqual(DisplayRotation.Rotated180, primary.Rotation);
        }

        [TestMethod]
        public void TestIfSinglePrimaryMonitorExists()
        {
            var displayModel = DisplayFactory.GetDisplayModel();
            var primary = displayModel
                .GetActiveDisplays()
                .Single(x => x.IsPrimary);

            Assert.AreNotEqual(primary, null);
        }
    }
}