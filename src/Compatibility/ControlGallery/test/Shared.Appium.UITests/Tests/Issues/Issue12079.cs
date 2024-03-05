﻿using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace UITests
{
	public class Issue12079 : IssuesUITest
	{
		const string SwipeViewId = "SwipeViewId";

		public Issue12079(TestDevice testDevice) : base(testDevice)
		{
		}

		public override string Issue => "SwipeView crash if Text not is set on SwipeItem";

		[Test]
		[Ignore("Appium cannot find the SwipeControl, we have to review the reason.")]
		[Category(UITestCategories.SwipeView)]
		public void SwipeItemNoTextWindows()
		{
			this.IgnoreIfPlatforms([TestDevice.Android, TestDevice.iOS, TestDevice.Mac]);

			App.WaitForElement(SwipeViewId);
			App.SwipeLeftToRight(SwipeViewId);
			App.Click(SwipeViewId);
			App.WaitForElement("Success");
			App.Screenshot("The test has passed");
		}
	}
}