using NUnit.Framework;
using UITest.Appium;
using UITest.Core;
using System;

namespace Microsoft.Maui.TestCases.Tests.Issues
{
	public class Bugzilla58779 : _IssuesUITest
	{
		const string ButtonId = "button";
		const string CancelId = "cancel";

		public Bugzilla58779(TestDevice testDevice) : base(testDevice)
		{
		}

		public override string Issue => "[MacOS] DisplayActionSheet on MacOS needs scroll bars if list is long";

		[Test]
		[Category(UITestCategories.DisplayAlert)]
		public void Bugzilla58779Test()
		{
			// Wait for the button to appear and tap it
			App.WaitForElement(ButtonId);
			App.Tap(ButtonId);
			App.Screenshot("Tapped 'Click Here' to show DisplayActionSheet");

			// Wait for the DisplayActionSheet to appear
			App.WaitForElement(CancelId, timeout: TimeSpan.FromSeconds(10));

			// If the Cancel button is not visible, scroll to it
			ScrollToElement(CancelId);

			// Wait for the Cancel button to be visible and tap it
			App.WaitForElement(CancelId, timeout: TimeSpan.FromSeconds(10));
			App.Tap(CancelId);
			App.Screenshot("Tapped 'Cancel' on DisplayActionSheet");
		}

		// Function to scroll until the target element is visible
		private void ScrollToElement(string elementId)
		{
			bool elementFound = false;
			int attempts = 0;

			// Try to find the element and scroll until found
			while (!elementFound && attempts < 5)
			{
				// Use WaitForElement to ensure the element exists
				try
				{
					App.WaitForElement(elementId, timeout: TimeSpan.FromSeconds(2)); // Timeout for each check
					elementFound = true;
				}
				catch
				{
					// If not found, scroll to the element
					App.ScrollTo(elementId);  // Use ScrollTo() to scroll to the specific element
					attempts++;
				}
			}

			// Fail the test if the element wasn't found after several attempts
			if (!elementFound)
			{
				Assert.Fail($"Unable to find the element with ID '{elementId}' after scrolling.");
			}
		}
	}
}
