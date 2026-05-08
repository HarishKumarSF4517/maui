namespace Maui.Controls.Sample;

public partial class TitleBarControlPage : ContentPage
{
	private TitleBarViewModel _viewModel;

	public TitleBarControlPage()
	{
		InitializeComponent();

		_viewModel = new TitleBarViewModel();
		BindingContext = _viewModel;

		Loaded += MainPage_Loaded;
	}

	private void MainPage_Loaded(object sender, EventArgs e)
	{
		// Setup TitleBar once the page is loaded and the Window is available
		SetupTitleBar();
	}

	private void SetupTitleBar()
	{
		var window = GetParentWindow();
		if (window == null)
			return;

		// Create a new TitleBar with the desired properties
		var titleBar = new Microsoft.Maui.Controls.TitleBar
		{
			Title = _viewModel.Title,
			Subtitle = _viewModel.Subtitle,
			BackgroundColor = _viewModel.Color,
			ForegroundColor = _viewModel.ForegroundColor,
			Icon = _viewModel.Icon,
			IsVisible = _viewModel.IsVisible,
			HeightRequest = _viewModel.HeightRequest
		};

		// Set content properties conditionally to avoid null reference issues
		if (_viewModel.TrailingContent != null)
			titleBar.TrailingContent = _viewModel.TrailingContent;

		if (_viewModel.LeadingContent != null)
			titleBar.LeadingContent = _viewModel.LeadingContent;

		if (_viewModel.TitleBarContent != null)
			titleBar.Content = _viewModel.TitleBarContent;

		titleBar.FlowDirection = _viewModel.FlowDirection;

		// Set up visual states for the TitleBar
		VisualStateManager.SetVisualStateGroups(titleBar, new VisualStateGroupList
		{
			new VisualStateGroup
			{
				Name = "TitleActiveStates",
				States =
				{
					new VisualState
					{
						Name = "TitleBarTitleActive",
						Setters = { new Setter { Property = Microsoft.Maui.Controls.TitleBar.ForegroundColorProperty, Value = Colors.White } }
					},
					new VisualState
					{
						Name = "TitleBarTitleInactive",
						Setters = { new Setter { Property = Microsoft.Maui.Controls.TitleBar.ForegroundColorProperty, Value = Colors.Black } }
					}
				}
			}
		});

		// Assign the new TitleBar to the window
		window.TitleBar = titleBar;
	}

	private void OnFlowDirectionCheckBoxChanged(object sender, CheckedChangedEventArgs e)
	{
		_viewModel.FlowDirection = e.Value ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
	}

	private void OnResetButtonClicked(object sender, EventArgs e)
	{
		_viewModel.ResetToDefaults();

		FlowDirectionRTLCheckBox.IsChecked = false;

		SetupTitleBar();
	}

	private void OnTitleBarContentChanged(object sender, CheckedChangedEventArgs e)
	{
		if (sender is RadioButton radioButton && e.Value)
		{
			switch (radioButton.Value?.ToString())
			{
				case "SearchBar":
					_viewModel.SetSearchBarContent();
					break;

				case "HorizontalStackLayout":
					_viewModel.SetHorizontalStackLayoutContent();
					break;

				case "ProgressBar":
					_viewModel.SetGridWithProgressBar();
					break;
			}
		}
	}

	private void OnApplyButtonClicked(object sender, EventArgs e)
	{
		SetupTitleBar();
	}
}
