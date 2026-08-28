#if TEST_FAILS_ON_WINDOWS && TEST_FAILS_ON_CATALYST
// TEST_FAILS_ON_WINDOWS    : For more info : https://github.com/dotnet/maui/issues/31375
// TEST_FAILS_ON_CATALYST   : ScrollTo is not working properly on MacCatalyst.
using System.Globalization;
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues
{
	public class Issue24533 : _IssuesUITest
	{
		public override string Issue => "[iOS] RefreshView causes CollectionView scroll position to reset";

		public Issue24533(TestDevice device) : base(device)
		{
		}

		[Test]
		[Category(UITestCategories.RefreshView)]
		public void CollectionViewWithRefreshViewShouldNotReset()
		{
			TapFooter();
			ScrollToFooterAndWaitForOffset();
			TapFooter();
			var verticalOffsetBeforeRefresh = ScrollToFooterAndWaitForOffset();

			TapFooter();
			var verticalOffsetAfterRefresh = ScrollToFooterAndWaitForOffset();
			Assert.That(verticalOffsetAfterRefresh, Is.GreaterThan(verticalOffsetBeforeRefresh));
		}

		void TapFooter()
		{
			App.WaitForElement("Footer");
			App.Tap("Footer");
		}

		double ScrollToFooterAndWaitForOffset()
		{
			var verticalOffsetBeforeScroll = GetVerticalOffset();
			var verticalOffsetAfterScroll = verticalOffsetBeforeScroll;

			App.RetryAssert(() =>
			{
				App.ScrollTo("Footer");
				verticalOffsetAfterScroll = GetVerticalOffset();
				Assert.That(verticalOffsetAfterScroll, Is.GreaterThan(verticalOffsetBeforeScroll));
			});

			return verticalOffsetAfterScroll;
		}

		double GetVerticalOffset()
		{
			var verticalOffsetText = App.WaitForElement("VerticalOffsetLabel").GetText() ?? string.Empty;
			var verticalOffsetValue = verticalOffsetText.Replace("VerticalOffset:", string.Empty, StringComparison.Ordinal).Trim();

			return double.Parse(verticalOffsetValue, CultureInfo.InvariantCulture);
		}
	}
}
#endif