using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Maui.Controls.Sample;

public class RefreshViewViewModel : INotifyPropertyChanged
{
	private ICommand _command;
	private object _commandParameter = "Orange";
	private bool _continue = false;
	private FlowDirection _flowDirection = FlowDirection.LeftToRight;
	private bool _isEnabled = true;
	private bool _isRefreshEnabled = true;
	private bool _isVisible = true;
	private bool _isRefreshing = false;
	private Color _refreshColor = Colors.Black;
	private Color _boxViewColor = Colors.Orange;
	private Shadow _shadow = null;
	private string _refreshStatusText = "None";
	private bool _canExecuteCommand = true;

	public event PropertyChangedEventHandler PropertyChanged;

	// Keeps a reference to the original Command so it can be restored after testing the
	// "Command == null" scenario, since setting Command back to a brand new instance would
	// also reset any CanExecute state already configured on it.
	public ICommand DefaultCommand { get; }

	public RefreshViewViewModel()
	{
		DefaultCommand = new Command(async (parameter) =>
		{
			var parameterText = parameter?.ToString() ?? "null";
			RefreshStatusText = $"Refresh Started: {parameterText}";
			if (parameterText == "Red" || parameterText == "Green")
			{
				BoxViewColor = parameterText == "Red" ? Colors.Red : Colors.Green;
			}
			if (!Continue)
			{
				await Task.Delay(2000);
				IsRefreshing = false;
				RefreshStatusText = $"Refresh completed: {parameterText}";
			}
		}, (parameter) => CanExecuteCommand);

		Command = DefaultCommand;
	}

	public void ResetToDefaults()
	{
		Continue = false;
		IsRefreshing = false;
		IsEnabled = true;
		IsVisible = true;
		FlowDirection = FlowDirection.LeftToRight;
		RefreshColor = Colors.Black;
		BoxViewColor = Colors.Orange;
		Shadow = null;
		CommandParameter = "Orange";
		Command = DefaultCommand;
		CanExecuteCommand = true;
		IsRefreshEnabled = true;
		RefreshStatusText = "None";
		RefreshEventStatusText = "Not Raised";
	}

	// Controls whether DefaultCommand.CanExecute reports true or false, so tests can verify
	// that RefreshView becomes non-interactive when its bound Command cannot execute.
	public bool CanExecuteCommand
	{
		get => _canExecuteCommand;
		set
		{
			if (_canExecuteCommand != value)
			{
				_canExecuteCommand = value;
				OnPropertyChanged();

				if (DefaultCommand is Command cmd)
					cmd.ChangeCanExecute();
			}
		}
	}

	public ICommand Command
	{
		get => _command;
		set
		{
			if (_command != value)
			{
				_command = value;
				OnPropertyChanged();
			}
		}
	}

	public object CommandParameter
	{
		get => _commandParameter;
		set
		{
			if (_commandParameter != value)
			{
				_commandParameter = value;
				OnPropertyChanged();

				if (Command is Command cmd)
					cmd.ChangeCanExecute();
			}
		}
	}

	public bool Continue
	{
		get => _continue;
		set
		{
			if (_continue != value)
			{
				_continue = value;
				OnPropertyChanged();
			}
		}
	}

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

	public bool IsEnabled
	{
		get => _isEnabled;
		set
		{
			if (_isEnabled != value)
			{
				_isEnabled = value;
				OnPropertyChanged();
			}
		}
	}

	public bool IsRefreshEnabled
	{
		get => _isRefreshEnabled;
		set
		{
			if (_isRefreshEnabled != value)
			{
				_isRefreshEnabled = value;
				OnPropertyChanged();
			}
		}
	}

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

	public bool IsRefreshing
	{
		get => _isRefreshing;
		set
		{
			if (_isRefreshing != value)
			{
				_isRefreshing = value;
				OnPropertyChanged();
			}
		}
	}

	public Color RefreshColor
	{
		get => _refreshColor;
		set
		{
			if (_refreshColor != value)
			{
				_refreshColor = value;
				OnPropertyChanged();
			}
		}
	}

	public Color BoxViewColor
	{
		get => _boxViewColor;
		set
		{
			if (_boxViewColor != value)
			{
				_boxViewColor = value;
				OnPropertyChanged();
			}
		}
	}

	public Shadow Shadow
	{
		get => _shadow;
		set
		{
			if (_shadow != value)
			{
				_shadow = value;
				OnPropertyChanged();
			}
		}
	}

	public string RefreshStatusText
	{
		get => _refreshStatusText;
		set
		{
			if (_refreshStatusText != value)
			{
				_refreshStatusText = value;
				OnPropertyChanged();
			}
		}
	}

	private string _refreshEventStatusText = "Not Raised";

	public string RefreshEventStatusText
	{
		get => _refreshEventStatusText;
		set
		{
			if (_refreshEventStatusText != value)
			{
				_refreshEventStatusText = value;
				OnPropertyChanged();
			}
		}
	}

	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
