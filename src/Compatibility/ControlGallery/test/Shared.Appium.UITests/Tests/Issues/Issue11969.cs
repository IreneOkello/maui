﻿using NUnit.Framework;
using UITest.Appium;

namespace UITests
{
	public class Issue11969 : IssuesUITest
	{
		const string SwipeViewId = "SwipeViewId";
		const string SwipeButtonId = "SwipeButtonId";

		const string Failed = "SwipeView Button not tapped";
		const string Success = "SUCCESS";

		public Issue11969(TestDevice testDevice) : base(testDevice)
		{
		}

		public override string Issue => "[Bug] Disabling Swipe view not handling tap gesture events on the content in iOS of Xamarin Forms";

		[Test]
		[Category(UITestCategories.SwipeView)]
		public void SwipeDisableChildButtonTest()
		{
			this.IgnoreIfPlatforms([TestDevice.Android, TestDevice.Mac, TestDevice.Windows]);

			App.WaitForNoElement(Failed);
			App.WaitForElement(SwipeViewId);
			App.Click("SwipeViewCheckBoxId");
			App.Click("SwipeViewContentCheckBoxId");
			App.Click(SwipeButtonId);
			App.WaitForNoElement(Success);
		}
	}
}