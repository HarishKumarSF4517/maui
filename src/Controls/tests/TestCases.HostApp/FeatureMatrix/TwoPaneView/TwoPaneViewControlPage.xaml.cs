using System;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample;

public class TwoPaneViewControlPage : NavigationPage
{
	private TwoPaneViewViewModel _viewModel;
	public TwoPaneViewControlPage()
	{
		_viewModel = new TwoPaneViewViewModel();
		PushAsync(new TwoPaneViewControlMainPage(_viewModel));
	}
}
public partial class TwoPaneViewControlMainPage : ContentPage
{
	private TwoPaneViewViewModel _viewModel;
	public TwoPaneViewControlMainPage(TwoPaneViewViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

		// Sync mode and re-subscribe (unsubscribed in OnDisappearing when Options page is pushed)
		_viewModel.CurrentTwoPaneMode = MyTwoPaneView.Mode;
		MyTwoPaneView.ModeChanged += OnTwoPaneViewModeChanged;
	}

	protected override void OnDisappearing()
	{
		base.OnDisappearing();

		// Unsubscribe to prevent duplicate handlers on re-appear
		MyTwoPaneView.ModeChanged -= OnTwoPaneViewModeChanged;
	}

	private void OnTwoPaneViewModeChanged(object sender, EventArgs e)
	{
		if (sender is Microsoft.Maui.Controls.Foldable.TwoPaneView twoPaneView)
		{
			_viewModel.CurrentTwoPaneMode = twoPaneView.Mode;
		}
	}

	private async void NavigateToOptionsPage_Clicked(object sender, EventArgs e)
	{
		_viewModel.ResetToDefaults();
		await Navigation.PushAsync(new TwoPaneViewOptionsPage(_viewModel));
	}
}
