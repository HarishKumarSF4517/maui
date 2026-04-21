using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace Maui.Controls.Sample;

public class TitleBarViewModel : INotifyPropertyChanged
{
	private IView _titleBarContent;
	private string _title;
	private string _subtitle;
	private IView _trailingContent;
	private Color _foregroundColor = Colors.Black;
	private ImageSource _icon;

	public IView TitleBarContent
	{
		get => _titleBarContent;
		set
		{
			if (_titleBarContent != value)
			{
				_titleBarContent = value;
				OnPropertyChanged();
			}
		}
	}

	private bool _isTitleBarContentVisible = false;
	public bool IsTitleBarContentVisible
	{
		get => _isTitleBarContentVisible;
		set
		{
			if (_isTitleBarContentVisible != value)
			{
				_isTitleBarContentVisible = value;
				OnPropertyChanged();

				// Deselect content-type radio buttons and clear content only when disabling
				if (!_isTitleBarContentVisible)
				{
					IsSearchBarChecked = false;
					IsHorizontalStackLayoutChecked = false;
					IsGridWithProgressBarChecked = false;
					TitleBarContent = null;
				}
			}
		}
	}

	private bool _isSearchBarChecked = false;
	public bool IsSearchBarChecked
	{
		get => _isSearchBarChecked;
		set
		{
			if (_isSearchBarChecked != value)
			{
				_isSearchBarChecked = value;
				OnPropertyChanged();
			}
		}
	}

	private bool _isHorizontalStackLayoutChecked = false;
	public bool IsHorizontalStackLayoutChecked
	{
		get => _isHorizontalStackLayoutChecked;
		set
		{
			if (_isHorizontalStackLayoutChecked != value)
			{
				_isHorizontalStackLayoutChecked = value;
				OnPropertyChanged();
			}
		}
	}

	private bool _isGridWithProgressBarChecked = false;
	public bool IsGridWithProgressBarChecked
	{
		get => _isGridWithProgressBarChecked;
		set
		{
			if (_isGridWithProgressBarChecked != value)
			{
				_isGridWithProgressBarChecked = value;
				OnPropertyChanged();
			}
		}
	}

	public void SetSearchBarContent()
	{
		if (IsTitleBarContentVisible)
		{
			TitleBarContent = new SearchBar
			{
				Placeholder = "Search",
				PlaceholderColor = Colors.White,
				BackgroundColor = Colors.LightGray,
				MaximumWidthRequest = 300,
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.Center
			};
		}
	}

	public void SetHorizontalStackLayoutContent()
	{
		if (IsTitleBarContentVisible)
		{
			TitleBarContent = new HorizontalStackLayout
			{
				HorizontalOptions = LayoutOptions.Center,
				Children =
					{
						new Label { Text = "Label 1", TextColor = Colors.White, VerticalOptions = LayoutOptions.Center },
						new Label { Text = "Label 2", TextColor = Colors.White, VerticalOptions = LayoutOptions.Center }
					}
			};
		}
	}

	public void SetGridWithProgressBar()
	{
		if (IsTitleBarContentVisible)
		{
			TitleBarContent = new Grid
			{
				Children =
					{
						new ProgressBar
						{
							Margin=10,
							Progress = 0.5,
							BackgroundColor = Colors.LightGray,
							ProgressColor = Colors.White,
							HorizontalOptions = LayoutOptions.Fill,
							VerticalOptions = LayoutOptions.Center
						}
					}
			};
		}
	}

	public string Title
	{
		get => _title;
		set
		{
			if (_title != value)
			{
				_title = value;
				OnPropertyChanged();
			}
		}
	}

	public string Subtitle
	{
		get => _subtitle;
		set
		{
			if (_subtitle != value)
			{
				_subtitle = value;
				OnPropertyChanged();
			}
		}
	}

	public Color ForegroundColor
	{
		get => _foregroundColor;
		set
		{
			if (_foregroundColor != value)
			{
				_foregroundColor = value;
				OnPropertyChanged();
			}
		}
	}

	public ImageSource Icon
	{
		get => _icon;
		set
		{
			if (_icon != value)
			{
				_icon = value;
				OnPropertyChanged();
			}
		}
	}

	private Color _color = Color.FromArgb("#6600ff");
	public Color Color
	{
		get => _color;
		set
		{
			if (_color != value)
			{
				_color = value;
				OnPropertyChanged();
			}
		}
	}

	private bool _isRedChecked = false;
	public bool IsRedChecked
	{
		get => _isRedChecked;
		set
		{
			if (_isRedChecked != value)
			{
				_isRedChecked = value;
				OnPropertyChanged();
				if (value && ShowBackgroundColor)
					Color = Colors.Red;
			}
		}
	}

	private bool _isOrangeChecked = false;
	public bool IsOrangeChecked
	{
		get => _isOrangeChecked;
		set
		{
			if (_isOrangeChecked != value)
			{
				_isOrangeChecked = value;
				OnPropertyChanged();
				if (value && ShowBackgroundColor)
					Color = Colors.Orange;
			}
		}
	}

	private bool _isVisible = true;
	public bool IsVisible
	{
		get => _isVisible;
		set
		{
			if (_isVisible != value)
			{
				_isVisible = value;
				OnPropertyChanged();
			}
		}
	}

	private FlowDirection _flowDirection = FlowDirection.LeftToRight;
	public FlowDirection FlowDirection
	{
		get => _flowDirection;
		set
		{
			if (_flowDirection != value)
			{
				_flowDirection = value;
				OnPropertyChanged();
			}
		}
	}

	private bool _showLeadingContent = false;
	public bool ShowLeadingContent
	{
		get => _showLeadingContent;
		set
		{
			if (_showLeadingContent != value)
			{
				_showLeadingContent = value;
				OnPropertyChanged();

				LeadingContent = _showLeadingContent ? new Image
				{
					Source = "dotnet_bot.png",
					HeightRequest = 60,
					Margin = 10,
					VerticalOptions = LayoutOptions.Center
				} : null;
			}
		}
	}

	private IView _leadingContent;
	public IView LeadingContent
	{
		get => _leadingContent;
		set
		{
			if (_leadingContent != value)
			{
				_leadingContent = value;
				OnPropertyChanged();
			}
		}
	}

	public IView TrailingContent
	{
		get => _trailingContent;
		set
		{
			if (_trailingContent != value)
			{
				_trailingContent = value;
				OnPropertyChanged();
			}
		}
	}

	private bool _showTrailingContent = false;
	public bool ShowTrailingContent
	{
		get => _showTrailingContent;
		set
		{
			if (_showTrailingContent != value)
			{
				_showTrailingContent = value;
				OnPropertyChanged();

				TrailingContent = _showTrailingContent ? new ImageButton
				{
					Source = "avatar.png",
					CornerRadius = 5,
					Margin = 10,
					HeightRequest = 60,
				} : null;
			}
		}
	}

	private bool _showTitle = false;
	public bool ShowTitle
	{
		get => _showTitle;
		set
		{
			if (_showTitle != value)
			{
				_showTitle = value;
				Title = _showTitle ? "My MAUI App" : null;
				OnPropertyChanged();
			}
		}
	}

	private bool _showSubtitle = false;
	public bool ShowSubtitle
	{
		get => _showSubtitle;
		set
		{
			if (_showSubtitle != value)
			{
				_showSubtitle = value;
				Subtitle = _showSubtitle ? "Demo TitleBar Integration" : null;
				OnPropertyChanged();
			}
		}
	}

	private bool _showForegroundColor = false;
	public bool ShowForegroundColor
	{
		get => _showForegroundColor;
		set
		{
			if (_showForegroundColor != value)
			{
				_showForegroundColor = value;
				OnPropertyChanged();
				// Reset foreground to default black whenever the toggle changes
				ForegroundColor = Colors.Black;
				IsWhiteForegroundChecked = false;
			}
		}
	}

	private bool _isWhiteForegroundChecked = false;
	public bool IsWhiteForegroundChecked
	{
		get => _isWhiteForegroundChecked;
		set
		{
			if (_isWhiteForegroundChecked != value)
			{
				_isWhiteForegroundChecked = value;
				OnPropertyChanged();
				if (value && ShowForegroundColor)
					ForegroundColor = Colors.White;
			}
		}
	}

	private bool _showIcon = false;
	public bool ShowIcon
	{
		get => _showIcon;
		set
		{
			if (_showIcon != value)
			{
				_showIcon = value;
				OnPropertyChanged();
				Icon = _showIcon ? ImageSource.FromFile("green.png") : null;
			}
		}
	}

	private bool _showBackgroundColor = false;
	public bool ShowBackgroundColor
	{
		get => _showBackgroundColor;
		set
		{
			if (_showBackgroundColor != value)
			{
				_showBackgroundColor = value;
				OnPropertyChanged();
				// Reset to the default purple whenever the toggle changes; color radio
				// buttons then override this when ShowBackgroundColor is true.
				Color = Color.FromArgb("#6600ff");
				IsOrangeChecked = false;
				IsRedChecked = false;
			}
		}
	}

	private bool _isSmallHeightChecked = false;
	public bool IsSmallHeightChecked
	{
		get => _isSmallHeightChecked;
		set
		{
			if (_isSmallHeightChecked != value)
			{
				_isSmallHeightChecked = value;
				OnPropertyChanged();
				if (value)
				{
					HeightRequest = 48;
					IsLargeHeightChecked = false;
				}
			}
		}
	}

	private bool _isLargeHeightChecked = false;
	public bool IsLargeHeightChecked
	{
		get => _isLargeHeightChecked;
		set
		{
			if (_isLargeHeightChecked != value)
			{
				_isLargeHeightChecked = value;
				OnPropertyChanged();
				if (value)
				{
					HeightRequest = 80;
					IsSmallHeightChecked = false;
				}
			}
		}
	}

	private double _heightRequest = 60;
	public double HeightRequest
	{
		get => _heightRequest;
		set
		{
			if (_heightRequest != value)
			{
				_heightRequest = value;
				OnPropertyChanged();
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;
	protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
