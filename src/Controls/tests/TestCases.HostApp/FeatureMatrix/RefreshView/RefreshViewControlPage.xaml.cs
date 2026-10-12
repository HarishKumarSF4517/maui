namespace Maui.Controls.Sample;

public class RefreshViewControlPage : NavigationPage
{
	private RefreshViewViewModel _viewModel;

	public RefreshViewControlPage()
	{
		_viewModel = new RefreshViewViewModel();
#if ANDROID
			BarTextColor = Colors.White;
#endif
		PushAsync(new RefreshViewControlMainPage(_viewModel));
	}
}

public partial class RefreshViewControlMainPage : ContentPage
{
	private RefreshViewViewModel _viewModel;
	private RefreshView _currentRefreshView;

	public RefreshViewControlMainPage(RefreshViewViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;
		_currentRefreshView = RefreshView;
		SetRefreshViewValueBindings();
	}

	private async void NavigateToOptionsPage_Clicked(object sender, EventArgs e)
	{
		_viewModel.ResetToDefaults();
		SetScrollViewContent();
		await Navigation.PushAsync(new RefreshViewOptionsPage(_viewModel));
	}

	private void SetScrollViewContent()
	{
		if (ReferenceEquals(_currentRefreshView, RefreshView))
			return;

		RefreshViewContainer.Children.Clear();
		RefreshViewContainer.Children.Add(RefreshView);
		_currentRefreshView = RefreshView;
		SetRefreshViewValueBindings();
	}

	private void SetCollectionViewContent()
	{
		if (_currentRefreshView.Content is CollectionView)
			return;

		var collectionViewContent = new CollectionView
		{
			ItemsSource = new List<string>
			{
				"Item 1", "Item 2", "Item 3", "Item 4", "Item 5",
				"Item 6", "Item 7", "Item 8", "Item 9", "Item 10"
			},
			ItemTemplate = new DataTemplate(() =>
			{
				var label = new Label
				{
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
					FontSize = 16,
					Padding = new Thickness(10)
				};
				label.SetBinding(Label.TextProperty, ".");
				return label;
			})
		};

		var refreshView = new RefreshView
		{
			AutomationId = "RefreshView",
			Content = collectionViewContent
		};

		refreshView.Refreshing += OnRefreshViewRefreshing;
		refreshView.SetBinding(RefreshView.CommandProperty, "Command");
		refreshView.SetBinding(RefreshView.CommandParameterProperty, "CommandParameter");
		refreshView.SetBinding(RefreshView.FlowDirectionProperty, "FlowDirection");
		refreshView.SetBinding(RefreshView.IsEnabledProperty, "IsEnabled");
		refreshView.SetBinding(RefreshView.IsRefreshEnabledProperty, "IsRefreshEnabled");
		refreshView.SetBinding(RefreshView.IsVisibleProperty, "IsVisible");
		refreshView.SetBinding(RefreshView.IsRefreshingProperty, "IsRefreshing");
		refreshView.SetBinding(RefreshView.RefreshColorProperty, "RefreshColor");
		refreshView.SetBinding(RefreshView.ShadowProperty, "Shadow");

		RefreshViewContainer.Children.Clear();
		RefreshViewContainer.Children.Add(refreshView);
		_currentRefreshView = refreshView;
		SetRefreshViewValueBindings();
	}

	private void SetRefreshViewValueBindings()
	{
		IsRefreshingValueLabel.SetBinding(Label.TextProperty, new Binding(nameof(RefreshView.IsRefreshing), source: _currentRefreshView));
		IsRefreshEnabledValueLabel.SetBinding(Label.TextProperty, new Binding(nameof(RefreshView.IsRefreshEnabled), source: _currentRefreshView));
	}

	private void OnScrollViewContentClicked(object sender, EventArgs e)
	{
		SetScrollViewContent();
	}

	private void OnCollectionViewContentClicked(object sender, EventArgs e)
	{
		SetCollectionViewContent();
	}

	private void OnRefreshViewRefreshing(object sender, EventArgs e)
	{
		if (BindingContext is RefreshViewViewModel vm)
		{
			vm.RefreshEventStatusText = "Raised";
		}
	}
}
