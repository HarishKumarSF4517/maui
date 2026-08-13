using NUnit.Framework;
using NUnit.Framework.Legacy;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues
{
	public class Issue24996 : _IssuesUITest
	{
		public Issue24996(TestDevice testDevice) : base(testDevice)
		{
		}

		public override string Issue => "Changing Translation of an element causes Maui in iOS to constantly run Measure & ArrangeChildren";

		[Test]
		[Category(UITestCategories.Layout)]
		public void ChangingTranslationShouldNotCauseLayoutPassOnAncestors()
		{
			string[] expectedCoordinates = ["X: 40, Y: 80", "X: 1000, Y: 20", "X: 20, Y: 1000", "X: 1000, Y: 1000"];

			App.WaitForElement("Stats");
			// Tries to translate the element in different positions, on-screen and off-screen.
			foreach (string expectedCoordinate in expectedCoordinates)
			{
				App.Tap("Stats");
				App.WaitForTextToBePresentInElement("Coords", expectedCoordinate);
				var element = App.WaitForElement("Stats");
				ClassicAssert.True(element.GetText()!.StartsWith("Lvl1[0/0]"));
			}
		}
	}
}