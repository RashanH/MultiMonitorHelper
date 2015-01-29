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
        public void TestIfResolutionChangingWorks()
        {
            IDisplayModel displayModel = DisplayFactory.GetDisplayModel();
            Display primary = displayModel.GetPrimaryDisplay();

            var newResolution = new Size(800, 600);

            Assert.IsTrue(displayModel.SetResolution(primary, newResolution));

            primary = displayModel.GetPrimaryDisplay();

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
            Assert.IsTrue(displayModel.SetRotation(primary, DisplayRotation.Rotated180));

            // refresh
            primary = displayModel.GetPrimaryDisplay();

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