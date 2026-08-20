using System.Globalization;

namespace Maui.Controls.Sample;

public class DatePickerControlPage : NavigationPage
{
	private DatePickerViewModel _viewModel;
	public DatePickerControlPage()
	{
		_viewModel = new DatePickerViewModel();
		PushAsync(new DatePickerMainControlPage(_viewModel));
	}
}

public partial class DatePickerMainControlPage : ContentPage
{
	private DatePickerViewModel _viewModel;
	private int _openedCount;
	private int _closedCount;

	public DatePickerMainControlPage(DatePickerViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;

		// Display initial culture formatting information
		DisplayCultureSpecificDate(_viewModel.Date, _viewModel.Culture);
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		// Refresh culture display when returning to the page
		DisplayCultureSpecificDate(_viewModel.Date, _viewModel.Culture);
	}

	private async void NavigateToOptionsPage_Clicked(object sender, EventArgs e)
	{
		_viewModel.ResetToDefaults();
		ResetEventState();
		await Navigation.PushAsync(new DatePickerOptionsPage(_viewModel));
	}

	private void ResetEventState()
	{
		_openedCount = 0;
		_closedCount = 0;
		OpenedCountLabel.Text = "Opened: 0";
		ClosedCountLabel.Text = "Closed: 0";
	}

	private void DisplayCultureSpecificDate(DateTime date, CultureInfo culture)
	{
		if (culture != null)
		{
			// Apply the culture to the current thread
			Thread.CurrentThread.CurrentCulture = culture;
			Thread.CurrentThread.CurrentUICulture = culture;

			// Set default culture for new threads
			CultureInfo.DefaultThreadCurrentCulture = culture;
			CultureInfo.DefaultThreadCurrentUICulture = culture;
		}

		CultureFormatLabel.Text = $"Culture: {culture.Name}, Date: {date.ToString(culture)}";
	}

	public void OnDateSelected(object sender, DateChangedEventArgs e)
	{
		if (e.OldDate.Value.Date != DateTime.Now.Date && e.NewDate != e.OldDate)
		{
			OldDateSelectedLabel.Text = e.OldDate.ToString();
			NewDateSelectedLabel.Text = e.NewDate.ToString();
		}
	}

	public void OnOpened(object sender, DatePickerOpenedEventArgs e)
	{
		DropdownStateLabel.Text = "Opened";
		OpenedCountLabel.Text = $"Opened: {++_openedCount}";
	}

	public void OnClosed(object sender, DatePickerClosedEventArgs e)
	{
		DropdownStateLabel.Text = "Closed";
		ClosedCountLabel.Text = $"Closed: {++_closedCount}";
	}

	private void OpenDatePickerButton_Clicked(object sender, EventArgs e)
	{
		_viewModel.IsOpen = true;
	}

	private void CloseDatePickerButton_Clicked(object sender, EventArgs e)
	{
		_viewModel.IsOpen = false;
	}

	private void FocusDatePickerButton_Clicked(object sender, EventArgs e)
	{
		DatePickerControl.Focus();
	}

	private void UnfocusDatePickerButton_Clicked(object sender, EventArgs e)
	{
		DatePickerControl.Unfocus();
	}
}
