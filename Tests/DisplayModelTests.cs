using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiMonitorHelper;

namespace Tests
{
	[TestClass]
	public class DisplayModelTests
	{
		[TestMethod]
		public void TestRotation()
		{
			var displayModel = DisplayFactory.GetDisplayModel();

			var primary = displayModel.GetActiveDisplays().First(x => x.IsPrimary);
			var currentOrientation = primary.Rotation;

		    Assert.AreEqual(primary.Rotation, DisplayRotation.Rotated180);

		    Assert.AreEqual(primary.Rotation, currentOrientation);
		}

		[TestMethod]
		public void TestIfPrimaryMonitorExists()
		{
			var displayModel = DisplayFactory.GetDisplayModel();
			var primary = displayModel.GetActiveDisplays().FirstOrDefault(x => x.IsPrimary);

			Assert.AreNotEqual(primary, null);
		}
	}
}
