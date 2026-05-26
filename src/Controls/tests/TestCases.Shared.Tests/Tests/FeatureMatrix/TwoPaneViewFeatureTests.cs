using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests
{
	[Category(UITestCategories.Layout)]
	public class TwoPaneViewFeatureTests : _GalleryUITest
	{
		public const string TwoPaneViewFeatureMatrix = "TwoPaneView Feature Matrix";
		public override string GalleryPageName => TwoPaneViewFeatureMatrix;

		public TwoPaneViewFeatureTests(TestDevice device)
			: base(device)
		{
		}

		[Test, Order(1)]
		public void TwoPaneView_Pane1Priority()
		{
			App.WaitForElement("Options");
			App.Tap("Options");

			App.WaitForElement("TallModeSinglePaneRadio");
			App.Tap("TallModeSinglePaneRadio");

			App.WaitForElement("WideModeSinglePaneRadio");
			App.Tap("WideModeSinglePaneRadio");

			App.WaitForElement("Apply");
			App.Tap("Apply");

			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(2)]
		public void TwoPaneView_Pane2Priority()
		{
			App.WaitForElement("Options");
			App.Tap("Options");

			App.WaitForElement("TallModeSinglePaneRadio");
			App.Tap("TallModeSinglePaneRadio");

			App.WaitForElement("WideModeSinglePaneRadio");
			App.Tap("WideModeSinglePaneRadio");

			App.WaitForElement("PanePriorityPane2Radio");
			App.Tap("PanePriorityPane2Radio");

			App.WaitForElement("Apply");
			App.Tap("Apply");

			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}


		[Test, Order(3)]
		public void TwoPaneView_SinglePane_Pane1()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("TallModeSinglePaneRadio");
			App.Tap("TallModeSinglePaneRadio");

			App.WaitForElement("WideModeSinglePaneRadio");
			App.Tap("WideModeSinglePaneRadio");

			App.WaitForElement("Apply");
			App.Tap("Apply");

			Assert.That(App.WaitForElement("CurrentModeLabel").GetText(), Is.EqualTo("Tall Mode"),
				"CurrentModeLabel should display 'Tall Mode' when WideModeConfiguration is SinglePane");
		}


		[Test, Order(4)]
		public void TwoPaneView_SinglePane_Pane2()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("TallModeSinglePaneRadio");
			App.Tap("TallModeSinglePaneRadio");

			App.WaitForElement("WideModeSinglePaneRadio");
			App.Tap("WideModeSinglePaneRadio");

			App.WaitForElement("PanePriorityPane2Radio");
			App.Tap("PanePriorityPane2Radio");

			App.WaitForElement("Apply");
			App.Tap("Apply");

			Assert.That(App.WaitForElement("CurrentModeLabel").GetText(), Is.EqualTo("Tall Mode"),
				"CurrentModeLabel should display 'Tall Mode' when WideModeConfiguration is SinglePane");
		}


		[Test, Order(5)]
		public void TwoPaneView_IsWide_UsingRect()
		{
			App.WaitForElement("Options");
			App.Tap("Options");

			App.WaitForElement("Apply");
			App.Tap("Apply");

			var pane1X = App.WaitForElement("Pane1Label").GetRect().X;
			var pane2X = App.WaitForElement("Pane2Label").GetRect().X;

			Assert.That(pane2X, Is.GreaterThan(pane1X), "Pane2 should be to the right of Pane1 in Wide mode");
			Assert.That(App.WaitForElement("CurrentModeLabel").GetText(), Is.EqualTo("Wide Mode"), "CurrentModeLabel should display 'Wide Mode'");
		}

		[Test, Order(6)]
		public void TwoPaneView_IsTall_UsingRect()
		{
			App.WaitForElement("Options");
			App.Tap("Options");

			ChangeStepper("WideModeStepper");
			ChangeStepper("WideModeStepper");

			App.WaitForElement("Apply");
			App.Tap("Apply");

			var pane1Y = App.WaitForElement("Pane1Label").GetRect().Y;
			var pane2Y = App.WaitForElement("Pane2Label").GetRect().Y;

			Assert.That(pane2Y, Is.GreaterThan(pane1Y), "Pane2 should be below Pane1 in Tall mode");
			Assert.That(App.WaitForElement("CurrentModeLabel").GetText(), Is.EqualTo("Tall Mode"), "CurrentModeLabel should display 'Tall Mode'");
		}

		[Test, Order(7)]
		public void TwoPaneView_RTLFlowDirection()
		{
			App.WaitForElement("Options");
			App.Tap("Options");

			App.WaitForElement("FlowDirectionRTLCheckBox");
			App.Tap("FlowDirectionRTLCheckBox");

			App.WaitForElement("Apply");
			App.Tap("Apply");

			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}


		[Test, Order(8)]
		public void TwoPaneView_WithRTL_UsingRect()
		{
			App.WaitForElement("Options");
			App.Tap("Options");

			App.WaitForElement("FlowDirectionRTLCheckBox");
			App.Tap("FlowDirectionRTLCheckBox");

			App.WaitForElement("Apply");
			App.Tap("Apply");

			var pane1X = App.WaitForElement("Pane1Label").GetRect().X;
			var pane2X = App.WaitForElement("Pane2Label").GetRect().X;

			Assert.That(pane1X, Is.GreaterThan(pane2X), "Pane1 should be to the right of Pane2 in RTL Wide mode");
			Assert.That(App.WaitForElement("CurrentModeLabel").GetText(), Is.EqualTo("Wide Mode"), "CurrentModeLabel should display 'Wide Mode'");
		}

		[Test, Order(9)]
		public void TwoPaneView_Pane1SizeIncrease_WideMode()
		{
			App.WaitForElement("Options");
			App.Tap("Options");

			ChangeStepper("Pane1LengthStepper");
			ChangeStepper("Pane1LengthStepper");

			App.WaitForElement("Apply");
			App.Tap("Apply");

			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(10)]
		public void TwoPaneView_Pane2SizeIncrease_WideMode()
		{
			App.WaitForElement("Options");
			App.Tap("Options");

			ChangeStepper("Pane2LengthStepper");
			ChangeStepper("Pane2LengthStepper");

			App.WaitForElement("Apply");
			App.Tap("Apply");

			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(11)]
		public void TwoPaneView_Pane1SizeIncrease_TallMode()
		{
			App.WaitForElement("Options");
			App.Tap("Options");

			ChangeStepper("Pane1LengthStepper");
			ChangeStepper("Pane1LengthStepper");

			ChangeStepper("WideModeStepper");
			ChangeStepper("WideModeStepper");

			App.WaitForElement("Apply");
			App.Tap("Apply");

			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(12)]
		public void TwoPaneView_Pane2SizeIncrease_TallMode()
		{
			App.WaitForElement("Options");
			App.Tap("Options");

			ChangeStepper("Pane2LengthStepper");
			ChangeStepper("Pane2LengthStepper");

			ChangeStepper("WideModeStepper");
			ChangeStepper("WideModeStepper");

			App.WaitForElement("Apply");
			App.Tap("Apply");

			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(13)]
		public void TwoPaneView_WideMode()
		{
			App.WaitForElement("Options");
			App.Tap("Options");

			App.WaitForElement("Apply");
			App.Tap("Apply");

			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(14)]
		public void TwoPaneView_TallMode()
		{
			App.WaitForElement("Options");
			App.Tap("Options");

			ChangeStepper("WideModeStepper");
			ChangeStepper("WideModeStepper");

			App.WaitForElement("Apply");
			App.Tap("Apply");

			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(15)]
		public void TwoPaneView_IsShadowWithTallMode()
		{
			App.WaitForElement("Options");
			App.Tap("Options");

			App.WaitForElement("ShadowCheckBox");
			App.Tap("ShadowCheckBox");

			ChangeStepper("WideModeStepper");
			ChangeStepper("WideModeStepper");

			App.WaitForElement("Apply");
			App.Tap("Apply");

			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(16)]
		public void TwoPaneView_ShadowWithWideMode()
		{
			App.WaitForElement("Options");
			App.Tap("Options");

			App.WaitForElement("ShadowCheckBox");
			App.Tap("ShadowCheckBox");

			App.WaitForElement("Apply");
			App.Tap("Apply");

			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(17)]
		public void TwoPaneView_IsVisible()
		{
			App.WaitForElement("Options");
			App.Tap("Options");

			App.WaitForElement("VisibilityCheckBox");
			App.Tap("VisibilityCheckBox");

			App.WaitForElement("Apply");
			App.Tap("Apply");

			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(18)]
		public void TwoPaneView_Pane1SizeIncrease_WideModeWithShadow()
		{
			App.WaitForElement("Options");
			App.Tap("Options");

			App.WaitForElement("ShadowCheckBox");
			App.Tap("ShadowCheckBox");

			ChangeStepper("Pane1LengthStepper");
			ChangeStepper("Pane1LengthStepper");

			App.WaitForElement("Apply");
			App.Tap("Apply");

			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(19)]
		public void TwoPaneView_Pane2SizeIncrease_WideModeWithShadow()
		{
			App.WaitForElement("Options");
			App.Tap("Options");

			App.WaitForElement("ShadowCheckBox");
			App.Tap("ShadowCheckBox");

			ChangeStepper("Pane2LengthStepper");
			ChangeStepper("Pane2LengthStepper");

			App.WaitForElement("Apply");
			App.Tap("Apply");

			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(20)]
		public void TwoPaneView_Pane1SizeIncrease_TallModeWithShadow()
		{
			App.WaitForElement("Options");
			App.Tap("Options");

			App.WaitForElement("ShadowCheckBox");
			App.Tap("ShadowCheckBox");

			ChangeStepper("Pane1LengthStepper");
			ChangeStepper("Pane1LengthStepper");

			ChangeStepper("WideModeStepper");
			ChangeStepper("WideModeStepper");

			App.WaitForElement("Apply");
			App.Tap("Apply");

			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		[Test, Order(21)]
		public void TwoPaneView_Pane2SizeIncrease_TallModeWithShadow()
		{
			App.WaitForElement("Options");
			App.Tap("Options");

			App.WaitForElement("ShadowCheckBox");
			App.Tap("ShadowCheckBox");

			ChangeStepper("Pane2LengthStepper");
			ChangeStepper("Pane2LengthStepper");

			ChangeStepper("WideModeStepper");
			ChangeStepper("WideModeStepper");

			App.WaitForElement("Apply");
			App.Tap("Apply");

			VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
		}

		private void ChangeStepper(string stepperAutomationId)
		{
#if WINDOWS
			App.IncreaseStepper(stepperAutomationId);
#else
			App.WaitForElement(stepperAutomationId);
			App.IncreaseStepper(stepperAutomationId);
#endif
		}
	}
}
