using System.Globalization;
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;


namespace Microsoft.Maui.TestCases.Tests;

[Category(UITestCategories.ScrollView)]
public class ScrollViewFeatureTests : _GalleryUITest
{
	public const string ScrollViewFeatureMatrix = "ScrollView Feature Matrix";
	public override string GalleryPageName => ScrollViewFeatureMatrix;
	public const string Options = "Options";
	public const string Apply = "Apply";
	public const string ContentLabel = "ContentLabel";
	public const string ContentImage = "ContentImage";
	public const string ContentEditor = "ContentEditor";
	public const string ContentVerticalStackLayout = "ContentVerticalStackLayout";
	public const string ContentHorizontalStackLayout = "ContentHorizontalStackLayout";
	public const string ContentGrid = "ContentGrid";
	public const string ContentAbsoluteLayout = "ContentAbsoluteLayout";
	public const string OrientationVertical = "OrientationVertical";
	public const string OrientationHorizontal = "OrientationHorizontal";
	public const string OrientationBoth = "OrientationBoth";
	public const string OrientationNeither = "OrientationNeither";
	public const string FlowDirectionRTL = "FlowDirectionRTL";
	public const string ShadowTrue = "ShadowTrue";
	public const string IsVisibleFalse = "IsVisibleFalse";
	public const string IsEnabledFalse = "IsEnabledFalse";
	public const string ScrollToStartPosition = "ScrollToStartPosition";
	public const string ScrollToCenterPosition = "ScrollToCenterPosition";
	public const string ScrollToEndPosition = "ScrollToEndPosition";
	public const string ScrollToMakeVisiblePosition = "ScrollToMakeVisiblePosition";
	public const string VerticalScrollBarVisibilityAlways = "VerticalSBAlways";
	public const string VerticalScrollBarVisibilityNever = "VerticalSBNever";
	public const string HorizontalScrollBarVisibilityAlways = "HorizontalSBAlways";
	public const string HorizontalScrollBarVisibilityNever = "HorizontalSBNever";

	public ScrollViewFeatureTests(TestDevice device)
		: base(device)
	{
	}

	public override void TestSetup()
	{
		base.TestSetup();
		ResetScrollView();
	}

	[Test, Order(1)]
	public void VerifyScrollViewWithScrollToPositionEnd()
	{
		App.WaitForElement(ScrollToEndPosition);
		App.Tap(ScrollToEndPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(2)]
	public void VerifyScrollViewWithScrollToPositionStart()
	{
		App.WaitForElement(ScrollToStartPosition);
		App.Tap(ScrollToStartPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(3)]
	public void VerifyScrollViewWithScrollToPositionCenter()
	{
		App.WaitForElement(ScrollToCenterPosition);
		App.Tap(ScrollToCenterPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(4)]
	public void VerifyScrollViewWithScrollToPositionMakeVisible()
	{
		App.WaitForElement(ScrollToMakeVisiblePosition);
		App.Tap(ScrollToMakeVisiblePosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

#if TEST_FAILS_ON_WINDOWS // Issue Link: https://github.com/dotnet/maui/issues/29805
	[Test, Order(5)]
	public void VerifyScrollViewWithScrollToPositionEndAndEditorContent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentEditor);
		App.Tap(ContentEditor);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToEndPosition);
		App.Tap(ScrollToEndPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(6)]
	public void VerifyScrollViewWithScrollToPositionStartAndEditorContent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentEditor);
		App.Tap(ContentEditor);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToStartPosition);
		App.Tap(ScrollToStartPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(7)]
	public void VerifyScrollViewWithScrollToPositionCenterAndEditorContent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentEditor);
		App.Tap(ContentEditor);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToCenterPosition);
		App.Tap(ScrollToCenterPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(8)]
	public void VerifyScrollViewWithScrollToPositionMakeVisibleAndEditorContent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentEditor);
		App.Tap(ContentEditor);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToMakeVisiblePosition);
		App.Tap(ScrollToMakeVisiblePosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}
#endif

	[Test, Order(9)]
	public void VerifyScrollViewWithScrollToPositionEndAndImageContent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentImage);
		App.Tap(ContentImage);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToEndPosition);
		App.Tap(ScrollToEndPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(10)]
	public void VerifyScrollViewWithScrollToPositionStartAndImageContent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentImage);
		App.Tap(ContentImage);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToStartPosition);
		App.Tap(ScrollToStartPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(11)]
	public void VerifyScrollViewWithScrollToPositionCenterAndImageContent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentImage);
		App.Tap(ContentImage);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToCenterPosition);
		App.Tap(ScrollToCenterPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(12)]
	public void VerifyScrollViewWithScrollToPositionMakeVisibleAndImageContent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentImage);
		App.Tap(ContentImage);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToMakeVisiblePosition);
		App.Tap(ScrollToMakeVisiblePosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(13)]
	public void VerifyScrollViewWithScrollToPositionEndAndGridContent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentGrid);
		App.Tap(ContentGrid);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToEndPosition);
		App.Tap(ScrollToEndPosition);
		App.WaitForElement("ScrollViewControl");
		// Use retryTimeout to allow scroll animation to settle
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(14)]
	public void VerifyScrollViewWithScrollToPositionStartAndGridContent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentGrid);
		App.Tap(ContentGrid);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToStartPosition);
		App.Tap(ScrollToStartPosition);
		App.WaitForElement("ScrollViewControl");
		// Use retryTimeout to allow scroll animation to settle
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(15)]
	public void VerifyScrollViewWithScrollToPositionCenterAndGridContent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentGrid);
		App.Tap(ContentGrid);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToCenterPosition);
		App.Tap(ScrollToCenterPosition);
		App.WaitForElement("ScrollViewControl");
		// Use retryTimeout to allow scroll animation to settle
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(16)]
	public void VerifyScrollViewWithScrollToPositionMakeVisibleAndGridContent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentGrid);
		App.Tap(ContentGrid);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToMakeVisiblePosition);
		App.Tap(ScrollToMakeVisiblePosition);
		App.WaitForElement("ScrollViewControl");
		// Use retryTimeout to allow scroll animation to settle
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(17)]
	public void VerifyScrollViewWithScrollToPositionEndAndAbsoluteLayoutContent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentAbsoluteLayout);
		App.Tap(ContentAbsoluteLayout);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToEndPosition);
		App.Tap(ScrollToEndPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(18)]
	public void VerifyScrollViewWithScrollToPositionStartAndAbsoluteLayoutContent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentAbsoluteLayout);
		App.Tap(ContentAbsoluteLayout);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToStartPosition);
		App.Tap(ScrollToStartPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(19)]
	public void VerifyScrollViewWithScrollToPositionCenterAndAbsoluteLayoutContent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentAbsoluteLayout);
		App.Tap(ContentAbsoluteLayout);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToCenterPosition);
		App.Tap(ScrollToCenterPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(20)]
	public void VerifyScrollViewWithScrollToPositionMakeVisibleAndAbsoluteContent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentAbsoluteLayout);
		App.Tap(ContentAbsoluteLayout);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToMakeVisiblePosition);
		App.Tap(ScrollToMakeVisiblePosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(21)]
	public void VerifyScrollViewWithScrollToPositionEndAndVerticalLayoutContent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentVerticalStackLayout);
		App.Tap(ContentVerticalStackLayout);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToEndPosition);
		App.Tap(ScrollToEndPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(22)]
	public void VerifyScrollViewWithScrollToPositionStartAndVerticalLayoutContent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentVerticalStackLayout);
		App.Tap(ContentVerticalStackLayout);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToStartPosition);
		App.Tap(ScrollToStartPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(23)]
	public void VerifyScrollViewWithScrollToPositionCenterAndVerticalLayoutContent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentVerticalStackLayout);
		App.Tap(ContentVerticalStackLayout);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToCenterPosition);
		App.Tap(ScrollToCenterPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(24)]
	public void VerifyScrollViewWithScrollToPositionMakeVisibleAndVerticalLayoutContent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentVerticalStackLayout);
		App.Tap(ContentVerticalStackLayout);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToMakeVisiblePosition);
		App.Tap(ScrollToMakeVisiblePosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

#if TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_IOS // Issue Link: https://github.com/dotnet/maui/issues/30070

	[Test, Order(25)]
	public void VerifyScrollViewWithScrollToPositionEndAndOrientationHorizontal()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToEndPosition);
		App.Tap(ScrollToEndPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(26)]
	public void VerifyScrollViewWithScrollToPositionStartAndOrientationHorizontal()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToStartPosition);
		App.Tap(ScrollToStartPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(27)]
	public void VerifyScrollViewWithScrollToPositionCenterAndOrientationHorizontal()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToCenterPosition);
		App.Tap(ScrollToCenterPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(28)]
	public void VerifyScrollViewWithScrollToPositionMakeVisibleAndOrientationHorizontal()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToMakeVisiblePosition);
		App.Tap(ScrollToMakeVisiblePosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(29)]
	public void VerifyScrollViewWithScrollToPositionEndAndImageContentWhenOrientationHorizontal()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentImage);
		App.Tap(ContentImage);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToEndPosition);
		App.Tap(ScrollToEndPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(30)]
	public void VerifyScrollViewWithScrollToPositionStartAndImageContentWhenOrientationHorizontal()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentImage);
		App.Tap(ContentImage);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToStartPosition);
		App.Tap(ScrollToStartPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(31)]
	public void VerifyScrollViewWithScrollToPositionCenterAndImageContentWhenOrientationHorizontal()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentImage);
		App.Tap(ContentImage);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToCenterPosition);
		App.Tap(ScrollToCenterPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(32)]
	public void VerifyScrollViewWithScrollToPositionMakeVisibleAndImageContentWhenOrientationHorizontal()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentImage);
		App.Tap(ContentImage);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToMakeVisiblePosition);
		App.Tap(ScrollToMakeVisiblePosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(33)]
	public void VerifyScrollViewWithScrollToPositionEndAndGridContentWhenOrientationHorizontal()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentGrid);
		App.Tap(ContentGrid);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToEndPosition);
		App.Tap(ScrollToEndPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(34)]
	public void VerifyScrollViewWithScrollToPositionStartAndGridContentWhenOrientationHorizontal()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentGrid);
		App.Tap(ContentGrid);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToStartPosition);
		App.Tap(ScrollToStartPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(35)]
	public void VerifyScrollViewWithScrollToPositionCenterAndGridContentWhenOrientationHorizontal()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentGrid);
		App.Tap(ContentGrid);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToCenterPosition);
		App.Tap(ScrollToCenterPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(36)]
	public void VerifyScrollViewWithScrollToPositionMakeVisibleAndGridContentWhenOrientationHorizontal()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentGrid);
		App.Tap(ContentGrid);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToMakeVisiblePosition);
		App.Tap(ScrollToMakeVisiblePosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(37)]
	public void VerifyScrollViewWithScrollToPositionEndAndAbsoluteLayoutContentWhenOrientationHorizontal()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentAbsoluteLayout);
		App.Tap(ContentAbsoluteLayout);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToEndPosition);
		App.Tap(ScrollToEndPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(38)]
	public void VerifyScrollViewWithScrollToPositionStartAndAbsoluteLayoutContentWhenOrientationHorizontal()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentAbsoluteLayout);
		App.Tap(ContentAbsoluteLayout);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToStartPosition);
		App.Tap(ScrollToStartPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(39)]
	public void VerifyScrollViewWithScrollToPositionCenterAndAbsoluteLayoutContentWhenOrientationHorizontal()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentAbsoluteLayout);
		App.Tap(ContentAbsoluteLayout);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToCenterPosition);
		App.Tap(ScrollToCenterPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(40)]
	public void VerifyScrollViewWithScrollToPositionMakeVisibleAndAbsoluteContentWhenOrientationHorizontal()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentAbsoluteLayout);
		App.Tap(ContentAbsoluteLayout);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToMakeVisiblePosition);
		App.Tap(ScrollToMakeVisiblePosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(41)]
	public void VerifyScrollViewWithScrollToPositionEndAndHorizontalLayoutContentWhenOrientationHorizontal()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentHorizontalStackLayout);
		App.Tap(ContentHorizontalStackLayout);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToEndPosition);
		App.Tap(ScrollToEndPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(42)]
	public void VerifyScrollViewWithScrollToPositionStartAndHorizontalLayoutContentWhenOrientationHorizontal()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentHorizontalStackLayout);
		App.Tap(ContentHorizontalStackLayout);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToStartPosition);
		App.Tap(ScrollToStartPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(43)]
	public void VerifyScrollViewWithScrollToPositionCenterAndHorizontalLayoutContentWhenOrientationHorizontal()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentHorizontalStackLayout);
		App.Tap(ContentHorizontalStackLayout);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToCenterPosition);
		App.Tap(ScrollToCenterPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(44)]
	public void VerifyScrollViewWithScrollToPositionMakeVisibleAndHorizontalLayoutContentWhenOrientationHorizontal()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentHorizontalStackLayout);
		App.Tap(ContentHorizontalStackLayout);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToMakeVisiblePosition);
		App.Tap(ScrollToMakeVisiblePosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

#if TEST_FAILS_ON_WINDOWS // Issue Link: https://github.com/dotnet/maui/issues/29805  
	[Test, Order(45)]
	public void VerifyScrollViewWithScrollToPositionEndAndEditorContentWhenOrientationHorizontal()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentEditor);
		App.Tap(ContentEditor);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToEndPosition);
		App.Tap(ScrollToEndPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(46)]
	public void VerifyScrollViewWithScrollToPositionStartAndEditorContentWhenOrientationHorizontal()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentEditor);
		App.Tap(ContentEditor);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToStartPosition);
		App.Tap(ScrollToStartPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(47)]
	public void VerifyScrollViewWithScrollToPositionCenterAndEditorContentWhenOrientationHorizontal()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentEditor);
		App.Tap(ContentEditor);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToCenterPosition);
		App.Tap(ScrollToCenterPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(48)]
	public void VerifyScrollViewWithScrollToPositionMakeVisibleAndEditorContentWhenOrientationHorizontal()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentEditor);
		App.Tap(ContentEditor);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToMakeVisiblePosition);
		App.Tap(ScrollToMakeVisiblePosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}
#endif
#endif

	[Test, Order(49)]
	public void VerifyScrollViewWithScrollX()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement("ScrollViewControl");
		App.ScrollRight("ScrollViewControl", ScrollStrategy.Gesture, 0.99);
		var scrollX = App.WaitForElement("ScrollXLabel").GetText();
		Assert.That(scrollX, Is.Not.EqualTo("0"), "ScrollX should not be zero after scrolling right");
	}

	[Test, Order(50)]
	public void VerifyScrollViewWithScrollY()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentVerticalStackLayout);
		App.Tap(ContentVerticalStackLayout);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement("ScrollViewControl");
		App.ScrollDown("ScrollViewControl", ScrollStrategy.Gesture, 0.99);
		var scrollY = App.WaitForElement("ScrollYLabel").GetText();
		Assert.That(scrollY, Is.Not.EqualTo("0"), "ScrollY should not be zero after scrolling down");
	}

	[Test, Order(51)]
	public void VerifyScrollViewWithVerticalOrientation()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentLabel);
		App.Tap(ContentLabel);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement("ScrollViewControl");
		App.ScrollDown("ScrollViewControl", ScrollStrategy.Gesture, 0.99, 500);
		var scrollY = App.WaitForElement("ScrollYLabel").GetText();
		Assert.That(scrollY, Is.GreaterThan("0"));
	}

#if TEST_FAILS_ON_IOS && TEST_FAILS_ON_CATALYST //Issue Link: https://github.com/dotnet/maui/issues/30070
	[Test, Order(52)]
	public void VerifyScrollViewWithHorizontalOrientation()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement("ScrollViewControl");
		App.ScrollRight("ScrollViewControl", ScrollStrategy.Gesture, 0.99, 500);
		var scrollX = App.WaitForElement("ScrollXLabel").GetText();
		Assert.That(scrollX, Is.GreaterThan("0"));
	}
#endif

	[Test, Order(53)]
	public void VerifyScrollViewWithOrientationBoth()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(OrientationBoth);
		App.Tap(OrientationBoth);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement("ScrollViewControl");
		App.ScrollRight("ScrollViewControl", ScrollStrategy.Gesture, 0.99, 500);
		App.ScrollDown("ScrollViewControl", ScrollStrategy.Gesture, 0.99, 500);
		var scrollX = App.WaitForElement("ScrollXLabel").GetText();
		var scrollY = App.WaitForElement("ScrollYLabel").GetText();
		Assert.That(scrollX, Is.GreaterThan("0"), "ScrollX should not be zero after scrolling right with Orientation Both");
		Assert.That(scrollY, Is.GreaterThan("0"), "ScrollY should not be zero after scrolling down with Orientation Both");
	}


	[Test, Order(54)]
	public void VerifyScrollViewWithOrientationNeither()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(OrientationNeither);
		App.Tap(OrientationNeither);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement("ScrollViewControl");
		App.ScrollDown("ScrollViewControl", ScrollStrategy.Gesture, 0.99, 500);
		App.ScrollRight("ScrollViewControl", ScrollStrategy.Gesture, 0.99, 500);
		var scrollY = App.WaitForElement("ScrollYLabel").GetText();
		var scrollX = App.WaitForElement("ScrollXLabel").GetText();
		Assert.That(scrollX, Is.EqualTo("0"), "Scrolling Does not work when Orientation is Neither");
		Assert.That(scrollY, Is.EqualTo("0"), "Scrolling Does not work when Orientation is Neither");
	}

#if TEST_FAILS_ON_IOS && TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_WINDOWS
	// Issue Link for Windows: https://github.com/dotnet/maui/issues/7766
	// Issue Link for iOS: https://github.com/dotnet/maui/issues/30158
	// Issue Link for Mac Catalyst: https://github.com/dotnet/maui/issues/7767
	[Test, Order(55)]
	public void VerifyScrollViewWithVerticalScrollBarVisibilityAlways()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(VerticalScrollBarVisibilityAlways);
		App.Tap(VerticalScrollBarVisibilityAlways);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToCenterPosition);
		App.Tap(ScrollToCenterPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(56)]
	public void VerifyScrollViewWithHorizontalScrollBarVisibilityAlways()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(HorizontalScrollBarVisibilityAlways);
		App.Tap(HorizontalScrollBarVisibilityAlways);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToStartPosition);
		App.Tap(ScrollToStartPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}
#endif

	[Test, Order(57)]
	public void VerifyScrollViewWithVerticalScrollBarVisibilityNever()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentLabel);
		App.Tap(ContentLabel);
		App.WaitForElement(VerticalScrollBarVisibilityNever);
		App.Tap(VerticalScrollBarVisibilityNever);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToStartPosition);
		App.Tap(ScrollToStartPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(58)]
	public void VerifyScrollViewWithHorizontalScrollBarVisibilityNever()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(HorizontalScrollBarVisibilityNever);
		App.Tap(HorizontalScrollBarVisibilityNever);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement(ScrollToStartPosition);
		App.Tap(ScrollToStartPosition);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

#if TEST_FAILS_ON_ANDROID && TEST_FAILS_ON_WINDOWS // Issue Link for Android : https://github.com/dotnet/maui/issues/13634 and Windows: https://github.com/dotnet/maui/issues/29805
	[Test, Order(59)]
	public void VerifyEditorIsScrolledInsideScrollView()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(ContentEditor);
		App.Tap(ContentEditor);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement("Editor1");
		App.ScrollDown("Editor1", ScrollStrategy.Gesture, 0.99, 500);
		App.WaitForElement("ScrollViewControl");
		var scrollY = App.WaitForElement("ScrollYLabel").GetText();
		Assert.That(scrollY, Is.EqualTo("0"));
	}
#endif

	[Test, Order(60)]
	public void VerifyScrollViewWithIsVisible()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(IsVisibleFalse);
		App.Tap(IsVisibleFalse);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForNoElement("ScrollViewControl");
	}

	[Test, Order(61)]
	public void VerifyScrollViewWithIsEnabled()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(IsEnabledFalse);
		App.Tap(IsEnabledFalse);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement("ScrollViewControl");
		App.ScrollDown("ScrollViewControl", ScrollStrategy.Gesture, 0.99, 500);
		var scrollY = App.WaitForElement("ScrollYLabel").GetText();
		Assert.That(scrollY, Is.EqualTo("0"), "Scrolling Does not work when IsEnabled is false");
	}


#if TEST_FAILS_ON_WINDOWS && TEST_FAILS_ON_IOS && TEST_FAILS_ON_CATALYST // Issue Link : https://github.com/dotnet/maui/issues/7767, https://github.com/dotnet/maui/issues/7766, https://github.com/dotnet/maui/issues/30158
#if TEST_FAILS_ON_CATALYST // Issue Link: https://github.com/dotnet/maui/issues/30095
	[Test, Order(62)]
	public void VerifyScrollViewWithRTL()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(FlowDirectionRTL);
		App.Tap(FlowDirectionRTL);
		App.WaitForElement(VerticalScrollBarVisibilityAlways);
		App.Tap(VerticalScrollBarVisibilityAlways);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(63)]
	public void VerifyScrollViewWithRTLAndGridContent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(FlowDirectionRTL);
		App.Tap(FlowDirectionRTL);
		App.WaitForElement(ContentGrid);
		App.Tap(ContentGrid);
		App.WaitForElement(VerticalScrollBarVisibilityAlways);
		App.Tap(VerticalScrollBarVisibilityAlways);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement("ScrollViewControl");
		// Use retryTimeout to allow layout/RTL changes to settle
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(64)]
	public void VerifyScrollViewWithRTLAndImageContent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(FlowDirectionRTL);
		App.Tap(FlowDirectionRTL);
		App.WaitForElement(ContentImage);
		App.Tap(ContentImage);
		App.WaitForElement(VerticalScrollBarVisibilityAlways);
		App.Tap(VerticalScrollBarVisibilityAlways);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(65)]
	public void VerifyScrollViewWithRTLAndAbsoluteLayout()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(FlowDirectionRTL);
		App.Tap(FlowDirectionRTL);
		App.WaitForElement(ContentAbsoluteLayout);
		App.Tap(ContentAbsoluteLayout);
		App.WaitForElement(VerticalScrollBarVisibilityAlways);
		App.Tap(VerticalScrollBarVisibilityAlways);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

#if TEST_FAILS_ON_WINDOWS // Issue Link: https://github.com/dotnet/maui/issues/29805
	[Test, Order(66)]
	public void VerifyScrollViewWithRTLAndEditor()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(FlowDirectionRTL);
		App.Tap(FlowDirectionRTL);
		App.WaitForElement(ContentEditor);
		App.Tap(ContentEditor);
		App.WaitForElement(VerticalScrollBarVisibilityAlways);
		App.Tap(VerticalScrollBarVisibilityAlways);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}
#endif
#endif

#if TEST_FAILS_ON_ANDROID // Issue Link: https://github.com/dotnet/maui/issues/30081
	[Test, Order(67)]
	public void VerifyScrollViewWithRTLWhenOrientationBoth()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(OrientationBoth);
		App.Tap(OrientationBoth);
		App.WaitForElement(FlowDirectionRTL);
		App.Tap(FlowDirectionRTL);
		App.WaitForElement(VerticalScrollBarVisibilityAlways);
		App.Tap(VerticalScrollBarVisibilityAlways);
		App.WaitForElement(HorizontalScrollBarVisibilityAlways);
		App.Tap(HorizontalScrollBarVisibilityAlways);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}
#endif

#if TEST_FAILS_ON_ANDROID && TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_IOS// Issue Link for Android: https://github.com/dotnet/maui/issues/30081 and Issue Link For iOS: https://github.com/dotnet/maui/issues/30070
	[Test, Order(68)]
	public void VerifyScrollViewWithRTLWhenHorizontalOrientation()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(FlowDirectionRTL);
		App.Tap(FlowDirectionRTL);
		App.WaitForElement(HorizontalScrollBarVisibilityAlways);
		App.Tap(HorizontalScrollBarVisibilityAlways);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(69)]
	public void VerifyScrollViewWithRTLWhenHorizontalOrientationAndImageContent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(FlowDirectionRTL);
		App.Tap(FlowDirectionRTL);
		App.WaitForElement(ContentImage);
		App.Tap(ContentImage);
		App.WaitForElement(HorizontalScrollBarVisibilityAlways);
		App.Tap(HorizontalScrollBarVisibilityAlways);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(70)]
	public void VerifyScrollViewWithRTLWhenHorizontalOrientationAndGridContent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(FlowDirectionRTL);
		App.Tap(FlowDirectionRTL);
		App.WaitForElement(ContentGrid);
		App.Tap(ContentGrid);
		App.WaitForElement(HorizontalScrollBarVisibilityAlways);
		App.Tap(HorizontalScrollBarVisibilityAlways);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(71)]
	public void VerifyScrollViewWithRTLWhenHorizontalOrientationAndHorizontalLayoutContent()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(FlowDirectionRTL);
		App.Tap(FlowDirectionRTL);
		App.WaitForElement(ContentHorizontalStackLayout);
		App.Tap(ContentHorizontalStackLayout);
		App.WaitForElement(HorizontalScrollBarVisibilityAlways);
		App.Tap(HorizontalScrollBarVisibilityAlways);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(72)]
	public void VerifyScrollViewWithRTLWhenHorizontalOrientationLAndAbsoluteLayout()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(FlowDirectionRTL);
		App.Tap(FlowDirectionRTL);
		App.WaitForElement(ContentAbsoluteLayout);
		App.Tap(ContentAbsoluteLayout);
		App.WaitForElement(HorizontalScrollBarVisibilityAlways);
		App.Tap(HorizontalScrollBarVisibilityAlways);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

#if TEST_FAILS_ON_WINDOWS // Issue Link: https://github.com/dotnet/maui/issues/29805
	[Test, Order(73)]
	public void VerifyScrollViewWithRTLWhenHorizontalOrientationAndContentEditor()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(OrientationHorizontal);
		App.Tap(OrientationHorizontal);
		App.WaitForElement(FlowDirectionRTL);
		App.Tap(FlowDirectionRTL);
		App.WaitForElement(ContentEditor);
		App.Tap(ContentEditor);
		App.WaitForElement(HorizontalScrollBarVisibilityAlways);
		App.Tap(HorizontalScrollBarVisibilityAlways);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElement("ScrollViewControl");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}
#endif
#endif
#endif

	public static IEnumerable<TestCaseData> ScrollView_ElementTestCases()
	{
		var contents = new (string AutomationId, string ElementName)[]
		{
			(ContentLabel, "Label"),
			(ContentImage, "Image"),
			(ContentGrid, "Grid"),
			(ContentVerticalStackLayout, "VerticalStackLayout"),
			(ContentHorizontalStackLayout, "HorizontalStackLayout"),
			(ContentAbsoluteLayout, "AbsoluteLayout")
		};
		var positions = new (string AutomationId, string Position)[]
		{
			(ScrollToStartPosition, "Start"),
			(ScrollToCenterPosition, "Center"),
			(ScrollToEndPosition, "End"),
			(ScrollToMakeVisiblePosition, "MakeVisible")
		};

		foreach (var content in contents)
		{
			foreach (var position in positions)
			{
				yield return new TestCaseData(content.AutomationId, content.ElementName, position.AutomationId, position.Position);
			}
		}
	}

	[Test, Order(81)]
	[TestCaseSource(nameof(ScrollView_ElementTestCases))]
	public void ScrollView_ScrollToRequested_Element_IsCorrect_For_All_Content(
		string contentAutomationId,
		string expectedElementName,
		string positionAutomationId,
		string expectedPosition)
	{
		ConfigureScrollView(contentAutomationId, OrientationVertical);
		App.WaitForElement(positionAutomationId);
		App.Tap(positionAutomationId);

		Assert.That(() => App.FindElement("ScrollToRequestedLabel").GetText(), Is.EqualTo("Raised").After(5000, 100));
		Assert.That(App.FindElement("ScrollElementLabel").GetText(), Is.EqualTo(expectedElementName));
		Assert.That(App.FindElement("RequestedPositionLabel").GetText(), Is.EqualTo(expectedPosition));
		Assert.That(App.FindElement("ScrollModeLabel").GetText(), Is.EqualTo("Element"));
		Assert.That(App.FindElement("RequestedAnimateLabel").GetText(), Is.EqualTo("True"));
		Assert.That(ReadScrollOffset("RequestedScrollXLabel"), Is.Zero);
		Assert.That(ReadScrollOffset("RequestedScrollYLabel"), Is.Zero);
	}

	[Test, Order(82)]
	public void ScrollView_ScrollToPixel_Vertical_Updates_RequestedY_And_ScrollY()
	{
		ScrollToPixelAndAssertOffsets(0, 300);
	}

	[Test, Order(83)]
	public void ScrollView_ScrollToPixel_Horizontal_Updates_RequestedX_And_ScrollX()
	{
		ConfigureScrollView(ContentHorizontalStackLayout, OrientationHorizontal);
		ScrollToPixelAndAssertOffsets(150, 0);
	}

	public static IEnumerable<TestCaseData> ScrollView_OrientationAndScrollBarTestCases()
	{
		var scenarios = new (string Orientation, string Content, double X, double Y)[]
		{
			(OrientationVertical, ContentVerticalStackLayout, 0, 300),
			(OrientationHorizontal, ContentHorizontalStackLayout, 150, 0),
			(OrientationBoth, ContentVerticalStackLayout, 0, 300),
			(OrientationBoth, ContentHorizontalStackLayout, 150, 0),
			(OrientationBoth, ContentImage, 150, 300),
			(OrientationNeither, ContentVerticalStackLayout, 0, 0)
		};
		string[] visibilities = { "Default", "Always", "Never" };

		foreach (var scenario in scenarios)
		{
			foreach (var horizontal in visibilities)
			{
				foreach (var vertical in visibilities)
				{
					yield return new TestCaseData(scenario.Content, scenario.Orientation,
						$"HorizontalSB{horizontal}", $"VerticalSB{vertical}", scenario.X, scenario.Y);
				}
			}
		}
	}

	[Test, Order(84)]
	[TestCaseSource(nameof(ScrollView_OrientationAndScrollBarTestCases))]
	public void VerifyScrollToPixelWorksWithOrientationAndScrollBarSettings(
		string contentAutomationId, string orientationAutomationId,
		string horizontalScrollBarAutomationId, string verticalScrollBarAutomationId,
		double expectedX, double expectedY)
	{
		ConfigureScrollView(contentAutomationId, orientationAutomationId,
			horizontalScrollBarAutomationId, verticalScrollBarAutomationId);
		ScrollToPixelAndAssertOffsets(expectedX, expectedY,
			expectRequest: orientationAutomationId != OrientationNeither);
	}

	[Test]
	public void ReopeningOptionsResetsConfigurationOffsetsAndDiagnostics()
	{
		ConfigureScrollView(ContentImage, OrientationBoth,
			HorizontalScrollBarVisibilityAlways, VerticalScrollBarVisibilityAlways);
		ScrollToPixelAndAssertOffsets(150, 300);

		for (var reset = 0; reset < 2; reset++)
		{
			ResetScrollView();
			Assert.That(ReadScrollOffset("RequestedScrollXLabel"), Is.Zero);
			Assert.That(ReadScrollOffset("RequestedScrollYLabel"), Is.Zero);
			Assert.That(App.WaitForElement("RequestedAnimateLabel").GetText(), Is.EqualTo("False"));
			ScrollToPixelAndAssertOffsets(0, 300);
		}

		App.WaitForElement(ScrollToStartPosition);
		App.Tap(ScrollToStartPosition);
		Assert.That(() => App.WaitForElement("ScrollElementLabel").GetText(),
			Is.EqualTo("Label").After(5000, 100));
		Assert.That(() => ReadScrollOffset("ScrollYLabel"), Is.Zero.Within(1).After(5000, 100));
	}

	[TestCase(IsVisibleFalse)]
	[TestCase(IsEnabledFalse)]
	public void ReopeningOptionsRestoresVisibilityAndUserScrolling(string optionAutomationId)
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(optionAutomationId);
		App.Tap(optionAutomationId);
		App.WaitForElement(Apply);
		App.Tap(Apply);

		if (optionAutomationId == IsVisibleFalse)
		{
			App.WaitForNoElement("ScrollViewControl");
		}
		else
		{
			App.WaitForElementTillPageNavigationSettled("ScrollViewControl");
			App.ScrollDown("ScrollViewControl", ScrollStrategy.Gesture, 0.99, 500);
			Assert.That(ReadScrollOffset("ScrollYLabel"), Is.Zero);
		}

		ResetScrollView();
		App.ScrollDown("ScrollViewControl", ScrollStrategy.Gesture, 0.99, 500);
		Assert.That(() => ReadScrollOffset("ScrollYLabel"), Is.GreaterThan(0).After(5000, 100));
	}

	[Test]
	public void RepeatedScrollRequestsMoveBetweenElementAndPixelTargets()
	{
		ConfigureScrollView(ContentImage, OrientationBoth);

		for (var scroll = 0; scroll < 2; scroll++)
		{
			ScrollToPixelAndAssertOffsets(150, 300);
			App.WaitForElement(ScrollToStartPosition);
			App.Tap(ScrollToStartPosition);

			Assert.That(() => App.WaitForElement("ScrollModeLabel").GetText(),
				Is.EqualTo("Element").After(5000, 100));
			Assert.That(App.WaitForElement("RequestedPositionLabel").GetText(), Is.EqualTo("Start"));
			Assert.That(() => ReadScrollOffset("ScrollXLabel"), Is.Zero.Within(1).After(5000, 100));
			Assert.That(() => ReadScrollOffset("ScrollYLabel"), Is.Zero.Within(1).After(5000, 100));
		}
	}

	private void ResetScrollView()
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		App.WaitForElement(Apply);
		App.Tap(Apply);
		App.WaitForElementTillPageNavigationSettled("ScrollViewControl");
		Assert.That(() => App.WaitForElement("ScrollToRequestedLabel").GetText(),
			Is.EqualTo("Not Raised").After(5000, 100));
		Assert.That(() => ReadScrollOffset("ScrollXLabel"), Is.Zero.Within(1).After(5000, 100));
		Assert.That(() => ReadScrollOffset("ScrollYLabel"), Is.Zero.Within(1).After(5000, 100));
	}

	private void ScrollToPixelAndAssertOffsets(double expectedX, double expectedY, bool expectRequest = true)
	{
		App.WaitForElement("ScrollToPixelButton");
		App.Tap("ScrollToPixelButton");

		Assert.That(() => ReadScrollOffset("ScrollXLabel"), Is.EqualTo(expectedX).Within(1).After(5000, 100));
		Assert.That(() => ReadScrollOffset("ScrollYLabel"), Is.EqualTo(expectedY).Within(1).After(5000, 100));
		Assert.That(() => App.WaitForElement("ScrollToRequestedLabel").GetText(),
			Is.EqualTo(expectRequest ? "Raised" : "Not Raised").After(5000, 100));

		if (!expectRequest)
			return;

		Assert.That(App.WaitForElement("ScrollModeLabel").GetText(), Is.EqualTo("Position"));
		Assert.That(App.WaitForElement("RequestedAnimateLabel").GetText(), Is.EqualTo("True"));
		Assert.That(ReadScrollOffset("RequestedScrollXLabel"), Is.EqualTo(150));
		Assert.That(ReadScrollOffset("RequestedScrollYLabel"), Is.EqualTo(300));
	}

	private void ConfigureScrollView(string contentAutomationId, string orientationAutomationId,
		string horizontalScrollBarAutomationId = HorizontalScrollBarVisibilityNever,
		string verticalScrollBarAutomationId = VerticalScrollBarVisibilityNever)
	{
		App.WaitForElement(Options);
		App.Tap(Options);
		foreach (var automationId in new[]
		{
			contentAutomationId, orientationAutomationId,
			horizontalScrollBarAutomationId, verticalScrollBarAutomationId, Apply
		})
		{
			App.WaitForElement(automationId);
			App.Tap(automationId);
		}
		App.WaitForElementTillPageNavigationSettled("ScrollViewControl");
		Assert.That(() => App.WaitForElement("ScrollToRequestedLabel").GetText(),
			Is.EqualTo("Not Raised").After(5000, 100));
	}

	private double ReadScrollOffset(string automationId) =>
		double.Parse(App.WaitForElement(automationId).GetText()
			?? throw new InvalidOperationException($"No scroll offset text for {automationId}."), CultureInfo.CurrentCulture);
}
