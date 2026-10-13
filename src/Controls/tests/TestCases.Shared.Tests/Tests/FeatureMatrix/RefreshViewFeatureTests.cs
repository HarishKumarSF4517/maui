using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests;

[Category(UITestCategories.RefreshView)]
public class RefreshViewFeatureTests : _GalleryUITest
{
	public const string RefreshViewFeatureMatrix = "RefreshView Feature Matrix";
	public override string GalleryPageName => RefreshViewFeatureMatrix;

	public RefreshViewFeatureTests(TestDevice device)
		: base(device)
	{
	}

	[Test, Order(1)]
	public void RefreshView_ValidateDefaultValues_VerifyLabels()
	{
		App.WaitForElement("Options");
		Assert.That(App.FindElement("IsRefreshingValueLabel").GetText(), Is.EqualTo("False"));
		Assert.That(App.FindElement("IsEnabledValueLabel").GetText(), Is.EqualTo("True"));
		Assert.That(App.FindElement("IsRefreshEnabledValueLabel").GetText(), Is.EqualTo("True"));
		Assert.That(App.FindElement("IsVisibleValueLabel").GetText(), Is.EqualTo("True"));
		Assert.That(App.FindElement("RefreshStatusLabel").GetText(), Is.EqualTo("None"));
	}

#if TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_WINDOWS // In Appium PullToRefresh is not supported on Catalyst and Windows

	[Test, Order(2)]
	public void RefreshView_InsideScrollView_VerifyScrollAndRefresh()
	{
		App.WaitForElement("RefreshView");
		App.WaitForElement("ScrollViewContentButton");
		App.Tap("ScrollViewContentButton");
		App.WaitForElement("RefreshView");
		App.ScrollUp("RefreshView");
		WaitForRefreshStatus("Refresh completed: Orange");
		Assert.That(App.FindElement("RefreshStatusLabel").GetText(), Is.Not.EqualTo("None"));
	}

	[Test, Order(3)]
	public void RefreshView_InsideCollectionView_VerifyRefresh()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("RefreshView");
		App.WaitForElement("CollectionViewContentButton");
		App.Tap("CollectionViewContentButton");
		App.WaitForElement("RefreshView");
		App.ScrollUp("RefreshView");
		WaitForRefreshStatus("Refresh completed: Orange");
		Assert.That(App.FindElement("RefreshStatusLabel").GetText(), Is.Not.EqualTo("None"));
	}

	[Test, Order(4)]
	public void RefreshView_SetCommandParameterTrue_VerifyCommandParameter()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("CommandRedButton");
		App.Tap("CommandRedButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("RefreshView");
		App.ScrollUp("RefreshView");
		WaitForRefreshStatus("Refresh completed: Red");

		// Confirms the "Red" parameter actually reached the Command, not just that a refresh happened.
		Assert.That(App.FindElement("RefreshStatusLabel").GetText(), Does.Contain("Red"));
	}

	[Test, Order(5)]
	public void RefreshView_SetCommandParameterGreen_VerifyCommandParameter()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("CommandGreenButton");
		App.Tap("CommandGreenButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("RefreshView");
		App.ScrollUp("RefreshView");
		WaitForRefreshStatus("Refresh completed: Green");

		// Green is the other CommandParameter value that also drives BoxViewColor in the
		// Command callback; verify it is threaded through distinctly from "Red".
		Assert.That(App.FindElement("RefreshStatusLabel").GetText(), Does.Contain("Green"));
	}

	[Test, Order(6)]
	public void RefreshView_SetIsEnabled_VerifyEnabledState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsEnabledFalseButton");
		App.Tap("IsEnabledFalseButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("RefreshView");
		App.ScrollUp("RefreshView");
		Assert.That(App.FindElement("RefreshStatusLabel").GetText(), Is.EqualTo("None"));
	}

	[Test, Order(7)]
	public void RefreshView_SetRefreshColorBlue_VerifyPropertyValue()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("RefreshColorBlueRadio");
		App.Tap("RefreshColorBlueRadio");
		App.WaitForElement("IsRefreshingTrueRadioButton");
		App.Tap("IsRefreshingTrueRadioButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("RefreshView");
		Assert.That(
			App.WaitForTextToBePresentInElement("RefreshColorValueLabel", "#0000FF", timeout: TimeSpan.FromSeconds(5)),
			Is.True,
			"RefreshView did not receive the configured blue RefreshColor.");
		Assert.That(App.FindElement("RefreshColorValueLabel").GetText(), Is.EqualTo("#0000FF"));
		WaitForRefreshStatus("Refresh Started: Orange");
		Assert.That(App.FindElement("RefreshStatusLabel").GetText(), Is.Not.EqualTo("None"));
		Assert.That(App.FindElement("IsRefreshingValueLabel").GetText(), Is.EqualTo("True"));
	}

	[Test, Order(8)]
	public void RefreshView_SetFlowDirectionRightToLeft_VerifyFlowDirection()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("FlowDirectionRTL");
		App.Tap("FlowDirectionRTL");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("RefreshView");
		App.ScrollUp("RefreshView");
		WaitForRefreshStatus("Refresh completed: Orange");
		Assert.That(App.FindElement("RefreshStatusLabel").GetText(), Is.Not.EqualTo("None"));
	}
#endif

	[Test, Order(9)]
	public void RefreshView_SetIsVisible_VerifyVisibilityState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsVisibleFalseButton");
		App.Tap("IsVisibleFalseButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForNoElement("RefreshView");
	}

#if TEST_FAILS_ON_WINDOWS // Issue Link - https://github.com/dotnet/maui/issues/30535

	[Test, Order(10)]
	public void RefreshView_SetIsRefreshingAndScrollView_VerifyStatusChanges()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsRefreshingTrueRadioButton");
		App.Tap("IsRefreshingTrueRadioButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("RefreshView");
		App.WaitForElement("ScrollViewContentButton");
		App.Tap("ScrollViewContentButton");
		Assert.That(App.FindElement("IsRefreshingValueLabel").GetText(), Is.EqualTo("True"));
	}

	[Test, Order(11)]
	public void RefreshView_SetIsRefreshingAndCollectionView_VerifyStatusChanges()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsRefreshingTrueRadioButton");
		App.Tap("IsRefreshingTrueRadioButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("RefreshView");
		App.WaitForElement("CollectionViewContentButton");
		App.Tap("CollectionViewContentButton");
		Assert.That(App.FindElement("IsRefreshingValueLabel").GetText(), Is.EqualTo("True"));
	}

	[Test, Order(12)]
	public void RefreshView_SetRefreshColorRedAndIsRefreshing_VerifyPropertyValue()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsRefreshingTrueRadioButton");
		App.Tap("IsRefreshingTrueRadioButton");
		App.WaitForElement("RefreshColorRedRadio");
		App.Tap("RefreshColorRedRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("RefreshView");
		Assert.That(
			App.WaitForTextToBePresentInElement("RefreshColorValueLabel", "#FF0000", timeout: TimeSpan.FromSeconds(5)),
			Is.True,
			"RefreshView did not receive the configured red RefreshColor.");
		Assert.That(App.FindElement("RefreshColorValueLabel").GetText(), Is.EqualTo("#FF0000"));
		WaitForRefreshStatus("Refresh Started: Orange");
		Assert.That(App.FindElement("IsRefreshingValueLabel").GetText(), Is.EqualTo("True"));
	}
#endif

#if TEST_FAILS_ON_WINDOWS // Issue Link - https://github.com/dotnet/maui/issues/29812

	[Test, Order(13)]
	public void RefreshView_SetShadow_VerifyShadowApplied()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ShadowTrueButton");
		App.Tap("ShadowTrueButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("RefreshView");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(14)]
	public void RefreshView_SetShadowWithCollectionView_VerifyShadowApplied()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ShadowTrueButton");
		App.Tap("ShadowTrueButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("RefreshView");
		App.WaitForElement("CollectionViewContentButton");
		App.Tap("CollectionViewContentButton");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}
#endif

#if TEST_FAILS_ON_WINDOWS && TEST_FAILS_ON_CATALYST // In Appium PullToRefresh is not supported on Catalyst and Windows

	[Test, Order(15)]
	public void RefreshView_RefreshingEvent_DefaultState_NotRaised()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("RefreshView");

		Assert.That(App.FindElement("RefreshingEventLabel").GetText(), Is.EqualTo("Not Raised"));
	}

	[Test, Order(16)]
	public void RefreshView_RefreshingEvent_IsRaised()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("RefreshView");

		Assert.That(App.FindElement("RefreshingEventLabel").GetText(), Is.EqualTo("Not Raised"));

		App.ScrollUp("RefreshView");

		Assert.That(
			App.WaitForTextToBePresentInElement("RefreshingEventLabel", "Raised", timeout: TimeSpan.FromSeconds(5)),
			Is.True,
			"Pull-to-refresh did not raise the Refreshing event.");

		Assert.That(App.FindElement("RefreshingEventLabel").GetText(), Is.EqualTo("Raised"));
		WaitForRefreshStatus("Refresh completed: Orange");
	}

	[Test, Order(17)]
	public void RefreshView_Disabled_DoesNotRaiseRefreshingEvent()
	{
		App.WaitForElement("Options");
		App.Tap("Options");

		App.WaitForElement("IsEnabledFalseButton");
		App.Tap("IsEnabledFalseButton");

		App.WaitForElement("Apply");
		App.Tap("Apply");

		App.WaitForElement("RefreshView");

		App.ScrollUp("RefreshView");

		Assert.That(App.FindElement("RefreshingEventLabel").GetText(), Is.EqualTo("Not Raised"));
	}

	[Test, Order(18)]
	public void RefreshView_CollectionViewInteraction_ThenPull_RaisesRefreshingEvent()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("Apply");
		App.Tap("Apply");

		App.WaitForElement("RefreshView");
		App.WaitForElement("CollectionViewContentButton");

		Assert.That(App.FindElement("RefreshingEventLabel").GetText(), Is.EqualTo("Not Raised"));

		App.Tap("CollectionViewContentButton");

		Assert.That(App.FindElement("RefreshingEventLabel").GetText(), Is.EqualTo("Not Raised"));

		App.ScrollUp("RefreshView");

		Assert.That(
			App.WaitForTextToBePresentInElement("RefreshingEventLabel", "Raised", timeout: TimeSpan.FromSeconds(5)),
			Is.True,
			"Pull-to-refresh did not raise the Refreshing event.");

		Assert.That(App.FindElement("RefreshingEventLabel").GetText(), Is.EqualTo("Raised"));
		WaitForRefreshStatus("Refresh completed: Orange");
	}

	[Test, Order(19)]
	public void RefreshView_CommandNull_PullToRefresh_RaisesEventButDoesNotExecuteCommand()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("CommandNullButton");
		App.Tap("CommandNullButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("RefreshView");

		App.ScrollUp("RefreshView");

		// The Refreshing event always fires on pull-to-refresh, even when Command is null.
		Assert.That(
			App.WaitForTextToBePresentInElement("RefreshingEventLabel", "Raised", timeout: TimeSpan.FromSeconds(5)),
			Is.True,
			"Pull-to-refresh did not raise the Refreshing event when Command was null.");
		Assert.That(App.FindElement("RefreshingEventLabel").GetText(), Is.EqualTo("Raised"));

		// RefreshStatusLabel is only updated by the Command, so it stays "None" when Command is null.
		Assert.That(App.FindElement("RefreshStatusLabel").GetText(), Is.EqualTo("None"));
	}

	[Test, Order(20)]
	public void RefreshView_CommandCanExecuteFalse_PullToRefresh_IsIgnored()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("CanExecuteFalseButton");
		App.Tap("CanExecuteFalseButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("RefreshView");

		App.ScrollUp("RefreshView");

		// When CanExecute reports false, IsRefreshEnabled is coerced to false and the pull
		// gesture should be ignored entirely.
		Assert.That(App.FindElement("IsRefreshEnabledValueLabel").GetText(), Is.EqualTo("False"));
		Assert.That(App.FindElement("RefreshingEventLabel").GetText(), Is.EqualTo("Not Raised"));
		Assert.That(App.FindElement("RefreshStatusLabel").GetText(), Is.EqualTo("None"));
	}

#endif

	[Test, Order(21)]
	public void RefreshView_Disabled_SetIsRefreshingTrue_IsCoercedToFalse()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsEnabledFalseButton");
		App.Tap("IsEnabledFalseButton");
		App.WaitForElement("IsRefreshingTrueRadioButton");
		App.Tap("IsRefreshingTrueRadioButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("Options");
		App.ScrollUp("RefreshView");

		// IsRefreshing is coerced back to false because IsEnabled is false.
		Assert.That(App.FindElement("IsRefreshingValueLabel").GetText(), Is.EqualTo("False"));
	}

	[Test, Order(22)]
	public void RefreshView_IsRefreshEnabledFalse_SetIsRefreshingTrue_IsCoercedToFalse()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsRefreshEnabledFalseButton");
		App.Tap("IsRefreshEnabledFalseButton");
		App.WaitForElement("IsRefreshingTrueRadioButton");
		App.Tap("IsRefreshingTrueRadioButton");

		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("Options");
		App.ScrollUp("RefreshView");

		Assert.That(App.FindElement("IsRefreshEnabledValueLabel").GetText(), Is.EqualTo("False"));
		Assert.That(App.FindElement("IsRefreshingValueLabel").GetText(), Is.EqualTo("False"));
		Assert.That(App.FindElement("IsEnabledValueLabel").GetText(), Is.EqualTo("True"));
	}

	[Test, Order(23)]
	public void RefreshView_NullCommandParameter_ExecutesCommandWithoutException()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("CommandParameterNullButton");
		App.Tap("CommandParameterNullButton");
		App.WaitForElement("IsRefreshingTrueRadioButton");
		App.Tap("IsRefreshingTrueRadioButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElementTillPageNavigationSettled("Options");

		WaitForRefreshStatus("Refresh Started: null");
		Assert.That(App.FindElement("RefreshStatusLabel").GetText(), Does.Contain("null"));
		Assert.That(App.FindElement("IsRefreshingValueLabel").GetText(), Is.EqualTo("True"));
	}

#if TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_WINDOWS

	[Test, Order(24)]
	public void RefreshView_IsRefreshEnabledFalse_ContentRemainsInteractiveAndPullIsIgnored()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsRefreshEnabledFalseButton");
		App.Tap("IsRefreshEnabledFalseButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");

		Assert.That(App.FindElement("IsRefreshEnabledValueLabel").GetText(), Is.EqualTo("False"));
		App.Tap("BoxContent");
		Assert.That(
			App.WaitForTextToBePresentInElement("ContentInteractionStatusLabel", "Tapped", timeout: TimeSpan.FromSeconds(5)),
			Is.True,
			"Child content should remain interactive while pull-to-refresh is disabled.");

		App.ScrollUp("RefreshView");

		Assert.That(App.FindElement("IsRefreshEnabledValueLabel").GetText(), Is.EqualTo("False"));
		Assert.That(App.FindElement("RefreshingEventLabel").GetText(), Is.EqualTo("Not Raised"));
		Assert.That(App.FindElement("RefreshStatusLabel").GetText(), Is.EqualTo("None"));
	}

	[Test, Order(25)]
	public void RefreshView_IsRefreshEnabled_Reenabled_AllowsRefresh()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsRefreshEnabledFalseButton");
		App.Tap("IsRefreshEnabledFalseButton");
		App.WaitForElement("IsRefreshEnabledTrueButton");
		App.Tap("IsRefreshEnabledTrueButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");

		Assert.That(App.FindElement("IsRefreshEnabledValueLabel").GetText(), Is.EqualTo("True"));
		App.ScrollUp("RefreshView");
		WaitForRefreshStatus("Refresh completed: Orange");
	}

	[Test, Order(26)]
	public void RefreshView_CommandCanExecute_Reenabled_AllowsRefresh()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("CanExecuteFalseButton");
		App.Tap("CanExecuteFalseButton");
		App.WaitForElement("CanExecuteTrueButton");
		App.Tap("CanExecuteTrueButton");
		App.WaitForElement("Apply");
		App.Tap("Apply");

		Assert.That(App.FindElement("IsRefreshEnabledValueLabel").GetText(), Is.EqualTo("True"));
		App.ScrollUp("RefreshView");
		WaitForRefreshStatus("Refresh completed: Orange");
	}

	[Test, Order(27)]
	public void RefreshView_RepeatedPullToRefresh_CompletesEachRefresh()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("RefreshView");

		App.ScrollUp("RefreshView");
		WaitForRefreshStatus("Refresh completed: Orange");
		Assert.That(App.FindElement("IsRefreshingValueLabel").GetText(), Is.EqualTo("False"));

		App.ScrollUp("RefreshView");
		WaitForRefreshStatus("Refresh completed: Orange");
		Assert.That(App.FindElement("IsRefreshingValueLabel").GetText(), Is.EqualTo("False"));
	}

#endif

	private void WaitForRefreshStatus(string expectedText)
	{
		Assert.That(
			App.WaitForTextToBePresentInElement("RefreshStatusLabel", expectedText, timeout: TimeSpan.FromSeconds(5)),
			Is.True,
			$"Timed out waiting for refresh status '{expectedText}'.");
	}
}
