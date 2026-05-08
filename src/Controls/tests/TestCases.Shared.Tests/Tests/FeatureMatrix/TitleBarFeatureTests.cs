// This feature test is applicable only on desktop platforms (Windows and Mac).
#if MACCATALYST || WINDOWS
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests;

[Category(UITestCategories.TitleView)]
public class TitleBarFeatureTests : _GalleryUITest
{
	public const string TitleBarFeatureMatrix = "TitleBar Feature Matrix";
	public override string GalleryPageName => TitleBarFeatureMatrix;

	public TitleBarFeatureTests(TestDevice device)
		: base(device)
	{
	}

	[Test]
	[Order(1)]
	public void TitleBar_Window()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");

		App.WaitForElement("ShowLeadingContentCheckBox");
		App.Tap("ShowLeadingContentCheckBox");

		App.WaitForElement("ShowTrailingContentCheckBox");
		App.Tap("ShowTrailingContentCheckBox");

		App.WaitForElement("ShowTitleCheckBox");
		App.Tap("ShowTitleCheckBox");

		App.WaitForElement("ShowSubtitleCheckBox");
		App.Tap("ShowSubtitleCheckBox");

		App.WaitForElement("ShowIconCheckBox");
		App.Tap("ShowIconCheckBox");

		App.WaitForElement("ShowBackgroundColorCheckBox");
		App.Tap("ShowBackgroundColorCheckBox");

		App.WaitForElement("OrangeRadioButton");
		App.Tap("OrangeRadioButton");

		App.WaitForElement("ShowForegroundColorCheckBox");
		App.Tap("ShowForegroundColorCheckBox");
		App.WaitForElement("WhiteForegroundRadioButton");
		App.Tap("WhiteForegroundRadioButton");

		App.WaitForElement("IsTitleBarContentVisibleCheckBox");
		App.Tap("IsTitleBarContentVisibleCheckBox");

		App.WaitForElement("ProgressBarRadioButton");
		App.Tap("ProgressBarRadioButton");

		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");

		VerifyScreenshot(includeTitleBar: true, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test]
	[Order(2)]
	public void TitleBar_Icon_WithTrailingContentAndLeadingContent()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");

		App.WaitForElement("ShowIconCheckBox");
		App.Tap("ShowIconCheckBox");

		App.WaitForElement("ShowLeadingContentCheckBox");
		App.Tap("ShowLeadingContentCheckBox");
		App.WaitForElement("ShowTrailingContentCheckBox");
		App.Tap("ShowTrailingContentCheckBox");

		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");

		VerifyScreenshot(includeTitleBar: true, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test]
	[Order(3)]
	public void TitleBar_Icon_WithBackgroundColor()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");

		App.WaitForElement("ShowIconCheckBox");
		App.Tap("ShowIconCheckBox");

		App.WaitForElement("ShowBackgroundColorCheckBox");
		App.Tap("ShowBackgroundColorCheckBox");
		App.WaitForElement("RedRadioButton");
		App.Tap("RedRadioButton");

		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");

		VerifyScreenshot(includeTitleBar: true, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test]
	[Order(4)]
	public void TitleBar_Icon_WithSearchBar()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");

		App.WaitForElement("ShowIconCheckBox");
		App.Tap("ShowIconCheckBox");

		App.WaitForElement("IsTitleBarContentVisibleCheckBox");
		App.Tap("IsTitleBarContentVisibleCheckBox");
		App.WaitForElement("SearchBarRadioButton");
		App.Tap("SearchBarRadioButton");

		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");

		VerifyScreenshot(includeTitleBar: true, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test]
	[Order(5)]
	public void TitleBar_Icon_WithForegroundColor()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");

		App.WaitForElement("ShowIconCheckBox");
		App.Tap("ShowIconCheckBox");

		App.WaitForElement("ShowTitleCheckBox");
		App.Tap("ShowTitleCheckBox");
		App.WaitForElement("ShowSubtitleCheckBox");
		App.Tap("ShowSubtitleCheckBox");

		App.WaitForElement("ShowForegroundColorCheckBox");
		App.Tap("ShowForegroundColorCheckBox");
		App.WaitForElement("WhiteForegroundRadioButton");
		App.Tap("WhiteForegroundRadioButton");

		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");

		VerifyScreenshot(includeTitleBar: true, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test]
	[Order(6)]
	public void TitleBar_ForegroundColor_WithBackgroundColor()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");

		App.WaitForElement("ShowTitleCheckBox");
		App.Tap("ShowTitleCheckBox");
		App.WaitForElement("ShowSubtitleCheckBox");
		App.Tap("ShowSubtitleCheckBox");

		App.WaitForElement("ShowForegroundColorCheckBox");
		App.Tap("ShowForegroundColorCheckBox");
		App.WaitForElement("WhiteForegroundRadioButton");
		App.Tap("WhiteForegroundRadioButton");

		App.WaitForElement("ShowBackgroundColorCheckBox");
		App.Tap("ShowBackgroundColorCheckBox");
		App.WaitForElement("RedRadioButton");
		App.Tap("RedRadioButton");

		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");

		VerifyScreenshot(includeTitleBar: true, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test]
	[Order(7)]
	public void TitleBar_ForegroundColor_WithGrid()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");

		App.WaitForElement("ShowTitleCheckBox");
		App.Tap("ShowTitleCheckBox");
		App.WaitForElement("ShowSubtitleCheckBox");
		App.Tap("ShowSubtitleCheckBox");

		App.WaitForElement("ShowForegroundColorCheckBox");
		App.Tap("ShowForegroundColorCheckBox");
		App.WaitForElement("WhiteForegroundRadioButton");
		App.Tap("WhiteForegroundRadioButton");

		App.WaitForElement("IsTitleBarContentVisibleCheckBox");
		App.Tap("IsTitleBarContentVisibleCheckBox");
		App.WaitForElement("ProgressBarRadioButton");
		App.Tap("ProgressBarRadioButton");

		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");

		VerifyScreenshot(includeTitleBar: true, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test]
	[Order(8)]
	public void TitleBar_TrailingContentAndLeadingContent_WithHorizontalStackLayout()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");

		App.WaitForElement("ShowLeadingContentCheckBox");
		App.Tap("ShowLeadingContentCheckBox");
		App.WaitForElement("ShowTrailingContentCheckBox");
		App.Tap("ShowTrailingContentCheckBox");

		App.WaitForElement("IsTitleBarContentVisibleCheckBox");
		App.Tap("IsTitleBarContentVisibleCheckBox");
		App.WaitForElement("HorizontalStackLayoutRadioButton");
		App.Tap("HorizontalStackLayoutRadioButton");

		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");

		VerifyScreenshot(includeTitleBar: true, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test]
	[Order(9)]
	public void TitleBar_TrailingContentAndLeadingContent_WithGrid()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");

		App.WaitForElement("ShowLeadingContentCheckBox");
		App.Tap("ShowLeadingContentCheckBox");
		App.WaitForElement("ShowTrailingContentCheckBox");
		App.Tap("ShowTrailingContentCheckBox");

		App.WaitForElement("IsTitleBarContentVisibleCheckBox");
		App.Tap("IsTitleBarContentVisibleCheckBox");
		App.WaitForElement("ProgressBarRadioButton");
		App.Tap("ProgressBarRadioButton");

		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");

		VerifyScreenshot(includeTitleBar: true, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test]
	[Order(10)]
	public void TitleBar_TrailingContentAndLeadingContent_WithTitleAndSubtitle()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");

		App.WaitForElement("ShowLeadingContentCheckBox");
		App.Tap("ShowLeadingContentCheckBox");
		App.WaitForElement("ShowTrailingContentCheckBox");
		App.Tap("ShowTrailingContentCheckBox");

		App.WaitForElement("ShowTitleCheckBox");
		App.Tap("ShowTitleCheckBox");
		App.WaitForElement("ShowSubtitleCheckBox");
		App.Tap("ShowSubtitleCheckBox");

		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");

		VerifyScreenshot(includeTitleBar: true, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test]
	[Order(11)]
	public void TitleBar_TrailingContentAndLeadingContent_WithBackgroundColor()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");

		App.WaitForElement("ShowLeadingContentCheckBox");
		App.Tap("ShowLeadingContentCheckBox");
		App.WaitForElement("ShowTrailingContentCheckBox");
		App.Tap("ShowTrailingContentCheckBox");

		App.WaitForElement("ShowBackgroundColorCheckBox");
		App.Tap("ShowBackgroundColorCheckBox");
		App.WaitForElement("OrangeRadioButton");
		App.Tap("OrangeRadioButton");

		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");

		VerifyScreenshot(includeTitleBar: true, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test]
	[Order(12)]
	public void TitleBar_TrailingContentAndLeadingContent_WithSearchBar()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");

		App.WaitForElement("ShowLeadingContentCheckBox");
		App.Tap("ShowLeadingContentCheckBox");
		App.WaitForElement("ShowTrailingContentCheckBox");
		App.Tap("ShowTrailingContentCheckBox");

		App.WaitForElement("IsTitleBarContentVisibleCheckBox");
		App.Tap("IsTitleBarContentVisibleCheckBox");
		App.WaitForElement("SearchBarRadioButton");
		App.Tap("SearchBarRadioButton");

		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");

		VerifyScreenshot(includeTitleBar: true, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test]
	[Order(13)]
	public void TitleBar_TitleAndSubTitle_WithBackgroundColor()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");

		App.WaitForElement("ShowTitleCheckBox");
		App.Tap("ShowTitleCheckBox");
		App.WaitForElement("ShowSubtitleCheckBox");
		App.Tap("ShowSubtitleCheckBox");

		App.WaitForElement("ShowBackgroundColorCheckBox");
		App.Tap("ShowBackgroundColorCheckBox");
		App.WaitForElement("OrangeRadioButton");
		App.Tap("OrangeRadioButton");

		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");

		VerifyScreenshot(includeTitleBar: true, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test]
	[Order(14)]
	public void TitleBar_TitleAndSubTitle_WithHorizontalStackLayout()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");

		App.WaitForElement("ShowTitleCheckBox");
		App.Tap("ShowTitleCheckBox");
		App.WaitForElement("ShowSubtitleCheckBox");
		App.Tap("ShowSubtitleCheckBox");
		App.WaitForElement("IsTitleBarContentVisibleCheckBox");
		App.Tap("IsTitleBarContentVisibleCheckBox");
		App.WaitForElement("HorizontalStackLayoutRadioButton");
		App.Tap("HorizontalStackLayoutRadioButton");

		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");

		VerifyScreenshot(includeTitleBar: true, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test]
	[Order(15)]
	public void TitleBar_TitleAndSubTitle_WithGrid()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");

		App.WaitForElement("ShowTitleCheckBox");
		App.Tap("ShowTitleCheckBox");
		App.WaitForElement("ShowSubtitleCheckBox");
		App.Tap("ShowSubtitleCheckBox");
		App.WaitForElement("IsTitleBarContentVisibleCheckBox");
		App.Tap("IsTitleBarContentVisibleCheckBox");
		App.WaitForElement("ProgressBarRadioButton");
		App.Tap("ProgressBarRadioButton");

		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");

		VerifyScreenshot(includeTitleBar: true, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test]
	[Order(16)]
	public void TitleBar_TitleAndSubTitle_WithSearchBar()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");

		App.WaitForElement("ShowTitleCheckBox");
		App.Tap("ShowTitleCheckBox");
		App.WaitForElement("ShowSubtitleCheckBox");
		App.Tap("ShowSubtitleCheckBox");
		App.WaitForElement("IsTitleBarContentVisibleCheckBox");
		App.Tap("IsTitleBarContentVisibleCheckBox");
		App.WaitForElement("SearchBarRadioButton");
		App.Tap("SearchBarRadioButton");

		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");

		VerifyScreenshot(includeTitleBar: true, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test]
	[Order(17)]
	public void TitleBar_BackgroundColor_WithGrid()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");

		App.WaitForElement("ShowBackgroundColorCheckBox");
		App.Tap("ShowBackgroundColorCheckBox");
		App.WaitForElement("RedRadioButton");
		App.Tap("RedRadioButton");
		App.WaitForElement("IsTitleBarContentVisibleCheckBox");
		App.Tap("IsTitleBarContentVisibleCheckBox");
		App.WaitForElement("ProgressBarRadioButton");
		App.Tap("ProgressBarRadioButton");

		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");

		VerifyScreenshot(includeTitleBar: true, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test]
	[Order(18)]
	public void TitleBar_IsVisible()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");

		// Set title content before hiding so the window content expansion is visible
		App.WaitForElement("ShowTitleCheckBox");
		App.Tap("ShowTitleCheckBox");
		App.WaitForElement("ShowSubtitleCheckBox");
		App.Tap("ShowSubtitleCheckBox");

		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");

		// Now hide the TitleBar — content should expand into the title bar region
		App.WaitForElement("ShowTitleBarCheckBox");
		App.Tap("ShowTitleBarCheckBox");

		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");

		VerifyScreenshot(includeTitleBar: true, retryTimeout: TimeSpan.FromSeconds(2));
	}

#if TEST_FAILS_ON_WINDOWS && TEST_FAILS_ON_MACCATALYST //For more information see: https://github.com/dotnet/maui/issues/30399
	[Test]
	[Order(19)]
	public void TitleBar_RTL_WithTrailingContentAndLeadingContent()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");

		App.WaitForElement("ShowLeadingContentCheckBox");
		App.Tap("ShowLeadingContentCheckBox");
		App.WaitForElement("ShowTrailingContentCheckBox");
		App.Tap("ShowTrailingContentCheckBox");
		App.WaitForElement("FlowDirectionRTLCheckBox");
		App.Tap("FlowDirectionRTLCheckBox");

		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");

		VerifyScreenshot(includeTitleBar: true, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test]
	[Order(20)]
	public void TitleBar_RTL_WithTitleAndSubTitle()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");

		App.WaitForElement("FlowDirectionRTLCheckBox");
		App.Tap("FlowDirectionRTLCheckBox");
		App.WaitForElement("ShowTitleCheckBox");
		App.Tap("ShowTitleCheckBox");
		App.WaitForElement("ShowSubtitleCheckBox");
		App.Tap("ShowSubtitleCheckBox");

		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");

		VerifyScreenshot(includeTitleBar: true, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test]
	[Order(21)]
	public void TitleBar_RTL_WithSearchBar()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");

		App.WaitForElement("FlowDirectionRTLCheckBox");
		App.Tap("FlowDirectionRTLCheckBox");
		App.WaitForElement("IsTitleBarContentVisibleCheckBox");
		App.Tap("IsTitleBarContentVisibleCheckBox");
		App.WaitForElement("SearchBarRadioButton");
		App.Tap("SearchBarRadioButton");

		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");

		VerifyScreenshot(includeTitleBar: true, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test]
	[Order(22)]
	public void TitleBar_RTL_WithHorizontalStackLayout()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");

		App.WaitForElement("FlowDirectionRTLCheckBox");
		App.Tap("FlowDirectionRTLCheckBox");
		App.WaitForElement("IsTitleBarContentVisibleCheckBox");
		App.Tap("IsTitleBarContentVisibleCheckBox");
		App.WaitForElement("HorizontalStackLayoutRadioButton");
		App.Tap("HorizontalStackLayoutRadioButton");

		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");

		VerifyScreenshot(includeTitleBar: true, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test]
	[Order(23)]
	public void TitleBar_RTL_WithGridWithProgressBar()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");

		App.WaitForElement("FlowDirectionRTLCheckBox");
		App.Tap("FlowDirectionRTLCheckBox");
		App.WaitForElement("IsTitleBarContentVisibleCheckBox");
		App.Tap("IsTitleBarContentVisibleCheckBox");
		App.WaitForElement("ProgressBarRadioButton");
		App.Tap("ProgressBarRadioButton");

		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");

		VerifyScreenshot(includeTitleBar: true, retryTimeout: TimeSpan.FromSeconds(2));
	}
#endif
	[Test]
	[Order(24)]
	public void TitleBar_TitleAndSubTitle_CustomTextEntry()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");

		App.WaitForElement("ShowTitleCheckBox");
		App.Tap("ShowTitleCheckBox");
		App.WaitForElement("TitleEntry");
		App.Tap("TitleEntry");
		App.ClearText("TitleEntry");
		App.EnterText("TitleEntry", "Custom Title");

		App.WaitForElement("ShowSubtitleCheckBox");
		App.Tap("ShowSubtitleCheckBox");
		App.WaitForElement("SubtitleEntry");
		App.Tap("SubtitleEntry");
		App.ClearText("SubtitleEntry");
		App.EnterText("SubtitleEntry", "Custom Subtitle");

		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");

		VerifyScreenshot(includeTitleBar: true, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test]
	[Order(25)]
	public void TitleBar_HeightRequest_Small()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");

		App.WaitForElement("ShowTitleCheckBox");
		App.Tap("ShowTitleCheckBox");

		App.WaitForElement("HeightSmallRadioButton");
		App.Tap("HeightSmallRadioButton");

		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");

		VerifyScreenshot(includeTitleBar: true, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test]
	[Order(26)]
	public void TitleBar_HeightRequest_Large()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");

		App.WaitForElement("ShowTitleCheckBox");
		App.Tap("ShowTitleCheckBox");

		App.WaitForElement("HeightLargeRadioButton");
		App.Tap("HeightLargeRadioButton");

		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");

		VerifyScreenshot(includeTitleBar: true, retryTimeout: TimeSpan.FromSeconds(2));
	}
}
#endif
