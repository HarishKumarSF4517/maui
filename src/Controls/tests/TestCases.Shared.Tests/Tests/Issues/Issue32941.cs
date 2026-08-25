#if ANDROID || IOS // SafeAreaEdges not supported on Catalyst and Windows

using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue32941 : _IssuesUITest
{
	public Issue32941(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "Label Overlapped by Android Status Bar When Using SafeAreaEdges=Container in .NET MAUI";

	[Test]
	[Category(UITestCategories.SafeAreaEdges)]
	public void ShellContentShouldRespectSafeAreaEdges_After_Navigation()
	{
		App.WaitForElement("MainPageLabel");
		App.WaitForElement("GoToSignOutButton");
		App.Tap("GoToSignOutButton");
		App.WaitForElement("SignOutLabel", timeout: TimeSpan.FromSeconds(30));

		App.RetryAssert(() =>
		{
			var labelRect = App.FindElement("SignOutLabel").GetRect();
			Assert.That(labelRect.Y, Is.GreaterThanOrEqualTo(20),
				$"Label Y position should be  at least 20 pixels from top to avoid status bar overlap, but was {labelRect.Y}");
		}, timeout: TimeSpan.FromSeconds(5));
	}
}
#endif
