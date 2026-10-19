using NUnit.Framework;
using UITest.Appium;
using UITest.Core;
namespace Microsoft.Maui.TestCases.Tests;

[Category(UITestCategories.WebView)]
public class WebViewFeatureTests : _GalleryUITest
{
	public const string WebViewFeatureMatrix = "WebView Feature Matrix";
	public override string GalleryPageName => WebViewFeatureMatrix;
	public const string Options = "Options";
	public const string Apply = "Apply";
	public const string WebViewControl = "WebViewControl";
	public const string HtmlSourceButton = "HtmlSourceButton";
	public const string GithubUrlButton = "GithubUrlButton";
	public const string EvaluateJSButton = "EvaluateJSButton";
	public const string GoBackButton = "GoBackButton";
	public const string CanGoBackLabel = "CanGoBackLabel";
	public const string CanGoForwardLabel = "CanGoForwardLabel";
	public const string NavigatingStatusLabel = "NavigatingStatusLabel";
	public const string NavigatedStatusLabel = "NavigatedStatusLabel";
	public const string JSResultLabel = "JSResultLabel";
	public const string AddTestCookieButton = "AddTestCookieButton";
	public const string ClearCookiesButton = "ClearCookiesButton";
	public const string CookieStatusMainLabel = "CookieStatusMainLabel";
	public WebViewFeatureTests(TestDevice device)
		: base(device)
	{
	}

	public override void TestSetup()
	{
		base.TestSetup();
		// Reset only the feature page, keeping the app and Appium session alive.
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement("ResetWebViewButton");
		App.Tap("ResetWebViewButton");
		App.WaitForElementTillPageNavigationSettled(Options);
		WaitForText(NavigatedStatusLabel, "Navigated: Success");
		WaitForText(CanGoBackLabel, "False");
		WaitForText(CanGoForwardLabel, "False");
	}

	// Android's native WebView does not expose its AutomationId to UIAutomator.
	AppiumQuery WebViewQuery => Device == TestDevice.Android
		? AppiumQuery.ByClass("android.webkit.WebView")
		: AppiumQuery.ById(WebViewControl);

	void WaitForText(string automationId, string expected)
	{
		static string Normalize(string? text) =>
			string.Join(" ", (text ?? string.Empty).Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries));

		App.WaitForElement(() =>
			{
				var element = App.FindElements(automationId).FirstOrDefault();
				return element != null && Normalize(element.GetText()) == Normalize(expected) ? element : null;
			},
			timeoutMessage: $"Expected '{automationId}' to contain exactly '{expected}'.");
	}

	void TapApplyAndWaitForMainPage(bool waitForNavigation = true, bool showDiagnostics = true)
	{
		if (showDiagnostics)
		{
			App.WaitForElement("ShowDiagnosticsButton");
			App.Tap("ShowDiagnosticsButton");
		}
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElementTillPageNavigationSettled(Options);
		if (waitForNavigation)
			WaitForText(NavigatedStatusLabel, "Navigated: Success");
	}

	void VerifyJavaScriptTitle(string title)
	{
		App.WaitForElement(() =>
			{
				var button = App.FindElements(EvaluateJSButton).FirstOrDefault();
				return button?.IsEnabled() == true ? button : null;
			});
		App.Tap(EvaluateJSButton);
		WaitForText(JSResultLabel, $"JS Result: {title}");
	}

	void NavigateAndWait(string button)
	{
		if (!int.TryParse(App.WaitForElement("NavigationCountLabel").GetText(), out var previousCount))
			throw new InvalidOperationException("The WebView navigation count is not a number.");
		App.WaitForElement(button);
		App.Tap(button);
		App.WaitForElement(() =>
			{
				var label = App.FindElements("NavigationCountLabel").FirstOrDefault();
				return int.TryParse(label?.GetText(), out var count) && count > previousCount ? label : null;
			},
			timeoutMessage: $"'{button}' did not complete a new WebView navigation.");
		WaitForText(NavigatedStatusLabel, "Navigated: Success");
	}

	void VerifyCookieContainer(string domain)
	{
		WaitForText(CookieStatusMainLabel, $"Domain: {domain}\nCount: 1\nDotNetMAUICookie = My cookie");
	}

	[Test, Order(1)]
	public void WebView_ValidateDefaultValues_VerifyInitialState()
	{
		App.WaitForElement(Options);
		WaitForText(NavigatedStatusLabel, "Navigated: Success");
		WaitForText(CanGoBackLabel, "False");
		WaitForText(CanGoForwardLabel, "False");
	}

#if TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_IOS // Issue Link: https://github.com/dotnet/maui/issues/30381
	[Test, Order(2)]
	public void WebView_VerifyCanGoBackForward()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement("HtmlSourceButton");
		App.Tap("HtmlSourceButton");
		TapApplyAndWaitForMainPage();
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement("GithubUrlButton");
		App.Tap("GithubUrlButton");
		TapApplyAndWaitForMainPage();
		VerifyJavaScriptTitle("Example Domain");
		WaitForText(CanGoBackLabel, "True");
		NavigateAndWait(GoBackButton);
		VerifyJavaScriptTitle("HTML WebView Source");
		WaitForText(CanGoForwardLabel, "True");
		NavigateAndWait("GoForwardButton");
		VerifyJavaScriptTitle("Example Domain");
	}
#endif

	[Test, Order(3)]
	public void WebView_SetHtmlSource_VerifyJavaScript()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(HtmlSourceButton);
		App.Tap(HtmlSourceButton);
		TapApplyAndWaitForMainPage();
		VerifyJavaScriptTitle("HTML WebView Source");
	}

	[Test, Order(4)]
	public void WebView_SetUrlSource_VerifyNavigatingEvent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(GithubUrlButton);
		App.Tap(GithubUrlButton);
		TapApplyAndWaitForMainPage();
		WaitForText(NavigatingStatusLabel, "Navigating to: example.com");
	}

	[Test, Order(5)]
	public void WebView_SetUrlSource_VerifyNavigatedEvent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(GithubUrlButton);
		App.Tap(GithubUrlButton);
		TapApplyAndWaitForMainPage();
		WaitForText(NavigatedStatusLabel, "Navigated: Success");
		VerifyJavaScriptTitle("Example Domain");
	}

	[Test, Order(6)]
	public void WebView_SetHtmlSource_VerifyNavigatingEvent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(HtmlSourceButton);
		App.Tap(HtmlSourceButton);
		TapApplyAndWaitForMainPage();
		WaitForText(NavigatingStatusLabel, "Navigating to: Embedded HTML");
	}

	[Test, Order(7)]
	public void WebView_SetHtmlSource_VerifyNavigatedEvent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(HtmlSourceButton);
		App.Tap(HtmlSourceButton);
		TapApplyAndWaitForMainPage();
		WaitForText(NavigatedStatusLabel, "Navigated: Success");
		VerifyJavaScriptTitle("HTML WebView Source");
	}

	[Test, Order(8)]
	public void WebView_TestCookieManagement_VerifyAddCookie()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(AddTestCookieButton);
		App.Tap(AddTestCookieButton);
		App.WaitForElement(HtmlSourceButton);
		App.Tap(HtmlSourceButton);
		TapApplyAndWaitForMainPage();
		VerifyCookieContainer("localhost");
	}

	[Test, Order(9)]
	public void WebView_TestCookieManagement_VerifyAddCookieWithUrlSource()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(GithubUrlButton);
		App.Tap(GithubUrlButton);
		App.WaitForElement(AddTestCookieButton);
		App.Tap(AddTestCookieButton);
		TapApplyAndWaitForMainPage();
		VerifyCookieContainer("example.com");
		NavigateAndWait("ReloadButton");
		VerifyJavaScriptTitle("Example Domain");
		WaitForText("BrowserCookiesLabel", "Browser cookies: [DotNetMAUICookie=My cookie]");
	}

	[Test, Order(10)]
	public void WebView_TestCookieManagement_VerifyAddCookieAndEvaluateJavaScript()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(AddTestCookieButton);
		App.Tap(AddTestCookieButton);
		App.WaitForElement(HtmlSourceButton);
		App.Tap(HtmlSourceButton);
		TapApplyAndWaitForMainPage();
		VerifyJavaScriptTitle("HTML WebView Source");
		VerifyCookieContainer("localhost");
	}

	[Test, Order(11)]
	public void WebView_TestClearCookies_VerifyCookiesCleared()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(GithubUrlButton);
		App.Tap(GithubUrlButton);
		App.WaitForElement(AddTestCookieButton);
		App.Tap(AddTestCookieButton);
		TapApplyAndWaitForMainPage();
		VerifyCookieContainer("example.com");
		NavigateAndWait("ReloadButton");
		VerifyJavaScriptTitle("Example Domain");
		WaitForText("BrowserCookiesLabel", "Browser cookies: [DotNetMAUICookie=My cookie]");
		App.ScrollDown("WebViewFeatureScrollView");
		App.WaitForElement("ClearBrowserCookiesButton");
		App.Tap("ClearBrowserCookiesButton");
		WaitForText(CookieStatusMainLabel, "No cookies available.");
		App.ScrollUp("WebViewFeatureScrollView");
		NavigateAndWait("ReloadButton");
		VerifyJavaScriptTitle("Example Domain");
		WaitForText("BrowserCookiesLabel", "Browser cookies: []");
	}

	[Test, Order(12)]
	public void WebView_TestReloadMethod_VerifyReloadFunctionality()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(GithubUrlButton);
		App.Tap(GithubUrlButton);
		TapApplyAndWaitForMainPage();
		NavigateAndWait("ReloadButton");
		VerifyJavaScriptTitle("Example Domain");
	}

#if TEST_FAILS_ON_IOS && TEST_FAILS_ON_CATALYST // Issue Link: https://github.com/dotnet/maui/issues/30515
	[Test, Order(13)]
	public void WebView_VerifyReloadFunctionalityForHtmlWebViewSource()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(HtmlSourceButton);
		App.Tap(HtmlSourceButton);
		TapApplyAndWaitForMainPage();
		NavigateAndWait("ReloadButton");
		VerifyJavaScriptTitle("HTML WebView Source");
	}
#endif

	[Test, Order(14)]
	public void WebView_TestEvaluateJavaScriptAsync_VerifyJavaScriptExecution()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement("LoadPage1Button");
		App.Tap("LoadPage1Button");
		TapApplyAndWaitForMainPage();
		VerifyJavaScriptTitle("Navigation Test - Page 1");
	}

	[Test, Order(15)]
	public void WebView_TestEvaluateJavaScriptAsync_VerifyJavaScriptExecutionWithMultiplePages()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement("LoadMultiplePagesButton");
		App.Tap("LoadMultiplePagesButton");
		TapApplyAndWaitForMainPage();
		VerifyJavaScriptTitle("Multiple Pages Navigation");
	}

	[Test, Order(16)]
	public void WebView_SetIsVisibleFalse_VerifyWebViewHidden()
	{
		App.WaitForElement(Options);
		App.WaitForElement(WebViewQuery);
		App.Tap(Options);
		App.WaitForElement(GithubUrlButton);
		App.Tap(GithubUrlButton);
		App.WaitForElement("IsVisibleFalse");
		App.Tap("IsVisibleFalse");
		TapApplyAndWaitForMainPage(waitForNavigation: false);
		App.WaitForNoElement(WebViewQuery);
	}

	[Test, Order(17)]
	public void WebView_CombineShadowAndIsVisibleFalse_VerifyWebViewHiddenRegardlessOfShadow()
	{
		App.WaitForElement(Options);
		App.WaitForElement(WebViewQuery);
		App.Tap(Options);
		App.WaitForElement("ShadowTrue");
		App.Tap("ShadowTrue");
		App.WaitForElement("IsVisibleFalse");
		App.Tap("IsVisibleFalse");
		TapApplyAndWaitForMainPage(waitForNavigation: false);
		App.WaitForNoElement(WebViewQuery);
	}

	[Test, Order(18)]
	public void WebView_CombineUrlSourceCookieAndReload_VerifyCookiePersistsAfterReload()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(GithubUrlButton);
		App.Tap(GithubUrlButton);
		App.WaitForElement(AddTestCookieButton);
		App.Tap(AddTestCookieButton);
		TapApplyAndWaitForMainPage();
		VerifyCookieContainer("example.com");
		NavigateAndWait("ReloadButton");
		VerifyJavaScriptTitle("Example Domain");
		WaitForText("BrowserCookiesLabel", "Browser cookies: [DotNetMAUICookie=My cookie]");
		NavigateAndWait("ReloadButton");
		VerifyJavaScriptTitle("Example Domain");
		WaitForText("BrowserCookiesLabel", "Browser cookies: [DotNetMAUICookie=My cookie]");
	}

	[Test, Order(19)]
	public void WebView_CombineCookieAndLoadMultiplePages_VerifyCookieContainerPreservedAcrossHtmlSourceChange()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(AddTestCookieButton);
		App.Tap(AddTestCookieButton);
		App.WaitForElement(HtmlSourceButton);
		App.Tap(HtmlSourceButton);
		App.WaitForElement("LoadMultiplePagesButton");
		App.Tap("LoadMultiplePagesButton");
		TapApplyAndWaitForMainPage();
		VerifyCookieContainer("localhost");
		VerifyJavaScriptTitle("Multiple Pages Navigation");
	}

	[Test, Order(20)]
	public void WebView_CombineSequentialPageNavigation_VerifyResetToDefaultsClearsPreviousJavaScriptResult()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement("LoadPage1Button");
		App.Tap("LoadPage1Button");
		TapApplyAndWaitForMainPage();
		VerifyJavaScriptTitle("Navigation Test - Page 1");

		App.WaitForElement(Options);
		App.Tap(Options);
		// Check reset before selecting a source, whose setter also clears the result.
		Assert.That(App.WaitForElement("InitialStateLabel").GetText(), Does.Contain("JavaScript: []"));
		App.WaitForElement("LoadPage2Button");
		App.Tap("LoadPage2Button");
		TapApplyAndWaitForMainPage();
		VerifyJavaScriptTitle("Navigation Test - Page 2");
	}

	[Test, Order(21)]
	public void WebView_ReopenOptions_VerifyCookiesVisibilityAndShadowReset()
	{
		App.WaitForElement(WebViewQuery);
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(AddTestCookieButton);
		App.Tap(AddTestCookieButton);
		App.WaitForElement("ShadowTrue");
		App.Tap("ShadowTrue");
		App.WaitForElement("IsVisibleFalse");
		App.Tap("IsVisibleFalse");
		TapApplyAndWaitForMainPage(waitForNavigation: false);
		VerifyCookieContainer("localhost");
		App.WaitForNoElement(WebViewQuery);

		App.WaitForElement(Options);
		App.Tap(Options);
		WaitForText("InitialStateLabel",
			"JavaScript: []\nCookies: 0\nVisible: True\nShadow: False\nProcess terminated: []");
		TapApplyAndWaitForMainPage();
		App.WaitForElement(WebViewQuery);
		WaitForText(CookieStatusMainLabel, "No cookies available.");
	}

	[Test, Order(22)]
	public void WebView_LoadMultiplePages_VerifyLinkNavigation()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement("LoadMultiplePagesButton");
		App.Tap("LoadMultiplePagesButton");
		TapApplyAndWaitForMainPage();
		VerifyJavaScriptTitle("Multiple Pages Navigation");
		// Mac2 reports incorrect WebKit link bounds; activate the DOM link through diagnostics.
		NavigateAndWait(Device == TestDevice.Mac ? "FollowFirstLinkButton" : "Go to Page 2 (Example.com)");
		VerifyJavaScriptTitle("Example Domain");
	}

#if TEST_FAILS_ON_WINDOWS // Issue Link: https://github.com/dotnet/maui/issues/29812
	[Test, Order(23)]
	public void VerifyWebViewWithShadow()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement("ShadowTrue");
		App.Tap("ShadowTrue");
		TapApplyAndWaitForMainPage(showDiagnostics: false);
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}
#endif
}
