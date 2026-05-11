using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests;

[Category(UITestCategories.Stepper)]
public class StepperFeatureTests : _GalleryUITest
{
	public const string StepperFeatureMatrix = "Stepper Feature Matrix";

	public override string GalleryPageName => StepperFeatureMatrix;

	public StepperFeatureTests(TestDevice device)
		: base(device)
	{
	}

	[Test, Order(1)]
	public void Stepper_ValidateDefaultValues_VerifyLabels()
	{
		App.WaitForElement("Options");
		Assert.That(App.FindElement("MinimumLabel").GetText(), Is.EqualTo("0.00"));
		Assert.That(App.FindElement("MaximumLabel").GetText(), Is.EqualTo("10.00"));
		Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("0.00"));
		Assert.That(App.FindElement("IncrementLabel").GetText(), Is.EqualTo("1.00"));
	}

	[Test, Order(2)]
	public void Stepper_ValueChangedEvent_IsRaised()
	{
		App.WaitForElement("Options");

		Assert.That(
			App.FindElement("ValueChangedEventLabel").GetText(),
			Is.EqualTo("Not Raised")
		);
		App.IncreaseStepper("StepperControl");

		Assert.That(
			App.FindElement("ValueChangedEventLabel").GetText(),
			Is.EqualTo("Raised")
		);
	}

	[Test, Order(3)]
	public void Stepper_SetMinimumValue_VerifyMinimumLabel()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("MinimumEntry");
		App.EnterText("MinimumEntry", "2");
		App.PressEnter();
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		Assert.That(App.FindElement("MinimumLabel").GetText(), Is.EqualTo("2.00"));
	}

	[Test, Order(4)]
	public void Stepper_SetMaximumValue_VerifyMaximumLabel()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("MaximumEntry");
		App.EnterText("MaximumEntry", "20");
		App.PressEnter();
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		Assert.That(App.FindElement("MaximumLabel").GetText(), Is.EqualTo("20.00"));
	}

	[Test, Order(5)]
	public void Stepper_SetValueWithinRange_VerifyValueLabel()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ValueEntry");
		App.EnterText("ValueEntry", "5");
		App.PressEnter();
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("5.00"));
	}

	[Test, Order(6)]
	public void Stepper_SetValueExceedsMaximum()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("MaximumEntry");
		App.ClearText("MaximumEntry");
		App.EnterText("MaximumEntry", "100");
		App.PressEnter();
		App.ClearText("ValueEntry");
		App.EnterText("ValueEntry", "200");
		App.PressEnter();
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("100.00"));
	}

#if TEST_FAILS_ON_ANDROID && TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_IOS && TEST_FAILS_ON_WINDOWS
// Related Issue Link : https://github.com/dotnet/maui/issues/12243
        [Test, Order(7)]
        public void Stepper_SetValueBelowMinimum()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("MinimumEntry");
            App.ClearText("MinimumEntry");
            App.EnterText("MinimumEntry", "10");
            App.PressEnter();
            App.ClearText("ValueEntry");
            App.EnterText("ValueEntry", "5");
            App.PressEnter();
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("Options");
            Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("10.00"));
        }

        [Test, Order(8)]
        public void Stepper_MinimumExceedsMaximum_SetsMinimumToMaximum()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("MinimumEntry");
            App.ClearText("MinimumEntry");
            App.EnterText("MinimumEntry", "50");
            App.PressEnter();
            App.ClearText("MaximumEntry");
            App.EnterText("MaximumEntry", "25");
            App.PressEnter();
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("Options");
            Assert.That(App.FindElement("MinimumLabel").GetText(), Is.EqualTo("50.00"));
            Assert.That(App.FindElement("MaximumLabel").GetText(), Is.EqualTo("50.00"));
        }
#endif

	[Test, Order(9)]
	public void Stepper_SetEnabledStateToFalse_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsEnabledFalseRadio");
		App.Tap("IsEnabledFalseRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		App.IncreaseStepper("StepperControl");
		Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("0.00"));
	}

	[Test, Order(10)]
	public void Stepper_SetVisibilityToFalse_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsVisibleFalseRadio");
		App.Tap("IsVisibleFalseRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		App.WaitForNoElement("StepperControl");
	}

	[Test, Order(11)]
	public void Stepper_ChangeFlowDirection_RTL_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("FlowDirectionRTLRadio");
		App.Tap("FlowDirectionRTLRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}

	[Test, Order(12)]
	public void Stepper_AtMinimumValue_DecrementButtonDisabled()
	{
		App.WaitForElement("Options");
		App.Tap("Options");

		App.WaitForElement("MinimumEntry");
		App.ClearText("MinimumEntry");
		App.EnterText("MinimumEntry", "10");
		App.PressEnter();

		App.WaitForElement("ValueEntry");
		App.ClearText("ValueEntry");
		App.EnterText("ValueEntry", "10");
		App.PressEnter();

		App.WaitForElement("Apply");
		App.Tap("Apply");

		App.WaitForElement("Options");

		var currentValue = App.FindElement("ValueLabel").GetText();
		Assert.That(currentValue, Is.EqualTo("10.00"));

		App.DecreaseStepper("StepperControl");

		var newValue = App.FindElement("ValueLabel").GetText();
		Assert.That(newValue, Is.EqualTo("10.00"));
	}

	[Test, Order(13)]
	public void Stepper_AtMaximumValue_IncrementButtonDisabled()
	{
		App.WaitForElement("Options");
		App.Tap("Options");

		App.WaitForElement("MaximumEntry");
		App.ClearText("MaximumEntry");
		App.EnterText("MaximumEntry", "10");
		App.PressEnter();

		App.WaitForElement("ValueEntry");
		App.ClearText("ValueEntry");
		App.EnterText("ValueEntry", "10");
		App.PressEnter();

		App.WaitForElement("Apply");
		App.Tap("Apply");

		App.WaitForElement("Options");

		var currentValue = App.FindElement("ValueLabel").GetText();
		Assert.That(currentValue, Is.EqualTo("10.00"));

		App.IncreaseStepper("StepperControl");

		var newValue = App.FindElement("ValueLabel").GetText();
		Assert.That(newValue, Is.EqualTo("10.00"));
	}

	[Test, Order(14)]
	public void Stepper_SetIncrementAndVerifyValueChange()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IncrementEntry");
		App.EnterText("IncrementEntry", "5");
		App.PressEnter();
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		App.IncreaseStepper("StepperControl");
		Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("5.00"));
		App.IncreaseStepper("StepperControl");
		Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("10.00"));
	}


	[Test, Order(15)]
	public void Stepper_NavigationToOptions_ResetsToDefaultValues()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("MinimumEntry");
		App.EnterText("MinimumEntry", "10");
		App.PressEnter();
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		Assert.That(App.FindElement("MinimumLabel").GetText(), Is.EqualTo("0.00"));
		Assert.That(App.FindElement("MaximumLabel").GetText(), Is.EqualTo("10.00"));
		Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("0.00"));
	}

#if TEST_FAILS_ON_WINDOWS // Related Issue Link : https://github.com/dotnet/maui/issues/29740
	[Test, Order(16)]
	public void Stepper_IncrementDoesNotExceedMaximum()
	{
		if (App is AppiumIOSApp iosApp && HelperExtensions.IsIOS26OrHigher(iosApp))
		{
			Assert.Ignore("Ignored due to Stepper Increment issue in iOS 26."); // Issue Link: https://github.com/dotnet/maui/issues/33769
		}
		App.WaitForElement("Options");
		App.Tap("Options");

		App.WaitForElement("MaximumEntry");
		App.ClearText("MaximumEntry");
		App.EnterText("MaximumEntry", "10");
		App.PressEnter();

		App.WaitForElement("IncrementEntry");
		App.ClearText("IncrementEntry");
		App.EnterText("IncrementEntry", "3");
		App.PressEnter();

		App.WaitForElement("Apply");
		App.Tap("Apply");

		App.WaitForElement("Options");

		App.IncreaseStepper("StepperControl");
		App.IncreaseStepper("StepperControl");
		App.IncreaseStepper("StepperControl");
		App.IncreaseStepper("StepperControl");

		var currentValue = App.FindElement("ValueLabel").GetText();
		Assert.That(currentValue, Is.EqualTo("10.00"));
	}
#endif

	[Test, Order(17)]
	public void Stepper_DecrementDoesNotGoBelowMinimum()
	{
		App.WaitForElement("Options");
		App.Tap("Options");

		App.WaitForElement("MinimumEntry");
		App.ClearText("MinimumEntry");
		App.EnterText("MinimumEntry", "0");
		App.PressEnter();

		App.WaitForElement("IncrementEntry");
		App.ClearText("IncrementEntry");
		App.EnterText("IncrementEntry", "2");
		App.PressEnter();

		App.WaitForElement("ValueEntry");
		App.ClearText("ValueEntry");
		App.EnterText("ValueEntry", "2");
		App.PressEnter();

		App.WaitForElement("Apply");
		App.Tap("Apply");

		App.WaitForElement("Options");

		App.DecreaseStepper("StepperControl");
		App.DecreaseStepper("StepperControl");

		var currentValue = App.FindElement("ValueLabel").GetText();
		Assert.That(currentValue, Is.EqualTo("0.00"));
	}

	[Test, Order(18)]
	public void Stepper_ValueChanged_ShouldFire_WhenValueIsClampedToMinimum()
	{
		App.WaitForElement("Options");
		App.Tap("Options");

		App.WaitForElement("MinimumEntry");
		App.ClearText("MinimumEntry");
		App.EnterText("MinimumEntry", "5");
		App.PressEnter();

		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");

		Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("5.00"));
		Assert.That(App.FindElement("ValueChangedEventLabel").GetText(), Is.EqualTo("Raised"));
	}

	[Test, Order(19)]
	public void Stepper_ValueChanged_ShouldFire_WhenValueIsClampedToMaximum()
	{
		App.WaitForElement("Options");
		App.Tap("Options");

		App.WaitForElement("MaximumEntry");
		App.ClearText("MaximumEntry");
		App.EnterText("MaximumEntry", "10");
		App.PressEnter();

		App.WaitForElement("ValueEntry");
		App.ClearText("ValueEntry");
		App.EnterText("ValueEntry", "50");
		App.PressEnter();

		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");

		Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("10.00"));
		Assert.That(App.FindElement("ValueChangedEventLabel").GetText(), Is.EqualTo("Raised"));
	}

	[Test, Order(20)]
	public void Stepper_ValueChanged_Arguments_NotRaised_WhenDisabled()
	{
		App.WaitForElement("Options");

		App.Tap("Options");
		App.WaitForElement("IsEnabledFalseRadio");
		App.Tap("IsEnabledFalseRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");

		App.WaitForElement("Options");

		App.IncreaseStepper("StepperControl");

		Assert.That(App.FindElement("ValueChangedEventLabel").GetText(), Is.EqualTo("Not Raised"));
	}


	[Test, Order(21)]
	public void Stepper_ValueChanged_Arguments_FirstChange()
	{
		App.WaitForElement("Options");
		App.Tap("Options");

		App.WaitForElement("Apply");
		App.Tap("Apply");

		Assert.That(App.FindElement("ValueChangedEventLabel").GetText(), Is.EqualTo("Not Raised"));

		App.IncreaseStepper("StepperControl");

		Assert.That(App.FindElement("ValueChangedEventLabel").GetText(), Is.EqualTo("Raised"));

		Assert.That(App.FindElement("OldValueLabel").GetText(), Is.EqualTo("0.00"));
		Assert.That(App.FindElement("NewValueLabel").GetText(), Is.EqualTo("1.00"));
	}

	[Test, Order(22)]
	public void Stepper_ValueChanged_Arguments_SecondChange()
	{
		App.WaitForElement("Options");
		App.Tap("Options");

		App.WaitForElement("Apply");
		App.Tap("Apply");

		App.IncreaseStepper("StepperControl");
		App.IncreaseStepper("StepperControl");

		Assert.That(App.FindElement("OldValueLabel").GetText(), Is.EqualTo("1.00"));
		Assert.That(App.FindElement("NewValueLabel").GetText(), Is.EqualTo("2.00"));
	}

	[Test, Order(23)]
	public void Stepper_ValueChanged_Arguments_WhenValueChangedFromOptions()
	{
		App.WaitForElement("Options");
		App.Tap("Options");

		App.WaitForElement("Apply");
		App.Tap("Apply");

		Assert.That(
			App.FindElement("ValueChangedEventLabel").GetText(),
			Is.EqualTo("Not Raised")
		);

		App.Tap("Options");
		App.WaitForElement("ValueEntry");

		App.ClearText("ValueEntry");
		App.EnterText("ValueEntry", "5");
		App.PressEnter();

		App.WaitForElement("Apply");
		App.Tap("Apply");

		App.WaitForElement("Options");

		Assert.That(
			App.FindElement("ValueChangedEventLabel").GetText(),
			Is.EqualTo("Raised")
		);

		Assert.That(
			App.FindElement("OldValueLabel").GetText(),
			Is.EqualTo("0.00")
		);

		Assert.That(
			App.FindElement("NewValueLabel").GetText(),
			Is.EqualTo("5.00")
		);
	}

	[Test, Order(24)]
	public void Stepper_ValueChanged_Arguments_WhenDecrementing()
	{
		App.WaitForElement("Options");
		App.Tap("Options");

		App.WaitForElement("ValueEntry");
		App.ClearText("ValueEntry");
		App.EnterText("ValueEntry", "5");
		App.PressEnter();

		App.WaitForElement("Apply");
		App.Tap("Apply");

		App.WaitForElement("Options");

		App.DecreaseStepper("StepperControl");

		Assert.That(App.FindElement("ValueChangedEventLabel").GetText(), Is.EqualTo("Raised"));
		Assert.That(App.FindElement("OldValueLabel").GetText(), Is.EqualTo("5.00"));
		Assert.That(App.FindElement("NewValueLabel").GetText(), Is.EqualTo("4.00"));
	}

	[Test, Order(25)]
	public void Stepper_FractionalIncrement_VerifyValueChange()
	{
		App.WaitForElement("Options");
		App.Tap("Options");

		App.WaitForElement("IncrementEntry");
		App.ClearText("IncrementEntry");
		App.EnterText("IncrementEntry", "0.5");
		App.PressEnter();

		App.WaitForElement("Apply");
		App.Tap("Apply");

		App.WaitForElement("Options");

		App.IncreaseStepper("StepperControl");
		Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("0.50"));

		App.IncreaseStepper("StepperControl");
		Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("1.00"));
	}

	[Test, Order(26)]
	public void Stepper_NegativeRange_VerifyValueChange()
	{
		App.WaitForElement("Options");
		App.Tap("Options");

		App.WaitForElement("MaximumEntry");
		App.ClearText("MaximumEntry");
		App.EnterText("MaximumEntry", "-1");
		App.PressEnter();

		App.WaitForElement("MinimumEntry");
		App.ClearText("MinimumEntry");
		App.EnterText("MinimumEntry", "-10");
		App.PressEnter();

		App.WaitForElement("ValueEntry");
		App.ClearText("ValueEntry");
		App.EnterText("ValueEntry", "-10");
		App.PressEnter();

		App.WaitForElement("Apply");
		App.Tap("Apply");

		App.WaitForElement("Options");

		Assert.That(App.FindElement("MinimumLabel").GetText(), Is.EqualTo("-10.00"));
		Assert.That(App.FindElement("MaximumLabel").GetText(), Is.EqualTo("-1.00"));
		Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("-10.00"));

		App.IncreaseStepper("StepperControl");
		Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("-9.00"));
	}

	[Test, Order(27)]
	public void Stepper_SetIncrementAndVerifyIncrementLabel()
	{
		App.WaitForElement("Options");
		App.Tap("Options");

		App.WaitForElement("IncrementEntry");
		App.ClearText("IncrementEntry");
		App.EnterText("IncrementEntry", "3");
		App.PressEnter();

		App.WaitForElement("Apply");
		App.Tap("Apply");

		App.WaitForElement("Options");
		Assert.That(App.FindElement("IncrementLabel").GetText(), Is.EqualTo("3.00"));
	}

	[Test, Order(28)]
	public void Stepper_SetVisibilityToTrue_AfterFalse_VerifyReappears()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsVisibleFalseRadio");
		App.Tap("IsVisibleFalseRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");

		App.WaitForElement("Options");
		App.WaitForNoElement("StepperControl");

		App.Tap("Options");
		App.WaitForElement("IsVisibleTrueRadio");
		App.Tap("IsVisibleTrueRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");

		App.WaitForElement("Options");
		App.WaitForElement("StepperControl");
	}

	[Test, Order(29)]
	public void Stepper_SetEnabledStateToTrue_AfterFalse_VerifyCanIncrement()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsEnabledFalseRadio");
		App.Tap("IsEnabledFalseRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");

		App.WaitForElement("Options");
		App.IncreaseStepper("StepperControl");
		Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("0.00"));

		App.Tap("Options");
		App.WaitForElement("IsEnabledTrueRadio");
		App.Tap("IsEnabledTrueRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");

		App.WaitForElement("Options");
		App.IncreaseStepper("StepperControl");
		Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("1.00"));
	}

	[Test, Order(30)]
	public void Stepper_ValueChanged_OldNewValues_WhenClampedToMinimum()
	{
		App.WaitForElement("Options");
		App.Tap("Options");

		// Set Value to 3, then raise Minimum above it — Stepper clamps Value to 5
		App.WaitForElement("ValueEntry");
		App.ClearText("ValueEntry");
		App.EnterText("ValueEntry", "3");
		App.PressEnter();

		App.WaitForElement("MinimumEntry");
		App.ClearText("MinimumEntry");
		App.EnterText("MinimumEntry", "5");
		App.PressEnter();

		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");

		Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("5.00"));
		Assert.That(App.FindElement("ValueChangedEventLabel").GetText(), Is.EqualTo("Raised"));
		Assert.That(App.FindElement("OldValueLabel").GetText(), Is.EqualTo("3.00"));
		Assert.That(App.FindElement("NewValueLabel").GetText(), Is.EqualTo("5.00"));
	}

	[Test, Order(31)]
	public void Stepper_ValueChanged_OldNewValues_WhenClampedToMaximum()
	{
		App.WaitForElement("Options");
		App.Tap("Options");

		// Set Value to 8, then lower Maximum below it — Stepper clamps Value to 5
		App.WaitForElement("ValueEntry");
		App.ClearText("ValueEntry");
		App.EnterText("ValueEntry", "8");
		App.PressEnter();

		App.WaitForElement("MaximumEntry");
		App.ClearText("MaximumEntry");
		App.EnterText("MaximumEntry", "5");
		App.PressEnter();

		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");

		Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("5.00"));
		Assert.That(App.FindElement("ValueChangedEventLabel").GetText(), Is.EqualTo("Raised"));
		Assert.That(App.FindElement("OldValueLabel").GetText(), Is.EqualTo("8.00"));
		Assert.That(App.FindElement("NewValueLabel").GetText(), Is.EqualTo("5.00"));
	}
}
