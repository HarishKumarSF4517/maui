using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Maui.Controls.Sample;

public class DatePickerViewModel : INotifyPropertyChanged
{
	private double _characterSpacing = 0.0d;
	private DateTime _date = DateTime.ParseExact("12/24/2025", "MM/dd/yyyy", System.Globalization.CultureInfo.CurrentCulture);
	private FlowDirection _flowDirection = FlowDirection.LeftToRight;
	private FontAttributes _fontAttributes = FontAttributes.None;
	private string _fontFamily = null;
	private double _fontSize = 0d;
	private bool _fontAutoScalingEnabled = true;
	private string _format = "d";
	private bool _isEnabled = true;
	private bool _isVisible = true;
	private bool _isOpen = false;
	private DateTime _minDate = DateTime.ParseExact("12/24/2025", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
	private DateTime _maxDate = DateTime.ParseExact("12/24/2027", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
	private Shadow _shadow;
	private Color _textColor = Colors.Black;
	private Brush _background;
	private CultureInfo _culture;

	public double CharacterSpacing
	{
		get => _characterSpacing;
		set
		{
			if (_characterSpacing != value)
			{
				_characterSpacing = value;
				OnPropertyChanged();
			}
		}
	}

	public DateTime Date
	{
		get => _date;
		set
		{
			if (_date != value)
			{
				_date = value;
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

	public FontAttributes FontAttributes
	{
		get => _fontAttributes;
		set
		{
			if (_fontAttributes != value)
			{
				_fontAttributes = value;
				OnPropertyChanged();
			}
		}
	}

	public string FontFamily
	{
		get => _fontFamily;
		set
		{
			if (_fontFamily != value)
			{
				_fontFamily = value;
				OnPropertyChanged();
			}
		}
	}

	public double FontSize
	{
		get => _fontSize;
		set
		{
			if (_fontSize != value)
			{
				_fontSize = value;
				OnPropertyChanged();
			}
		}
	}

	public string Format
	{
		get => _format;
		set
		{
			if (_format != value)
			{
				_format = value;
				OnPropertyChanged();
			}
		}
	}

	public bool FontAutoScalingEnabled
	{
		get => _fontAutoScalingEnabled;
		set
		{
			if (_fontAutoScalingEnabled != value)
			{
				_fontAutoScalingEnabled = value;
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

	public bool IsOpen
	{
		get => _isOpen;
		set
		{
			if (_isOpen != value)
			{
				_isOpen = value;
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

	public DateTime MaximumDate
	{
		get => _maxDate;
		set
		{
			if (_maxDate != value)
			{
				_maxDate = value;
				OnPropertyChanged();
			}
		}
	}

	public DateTime MinimumDate
	{
		get => _minDate;
		set
		{
			if (_minDate != value)
			{
				_minDate = value;
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

	public Color TextColor
	{
		get => _textColor;
		set
		{
			if (_textColor != value)
			{
				_textColor = value;
				OnPropertyChanged();
			}
		}
	}

	public Brush Background
	{
		get => _background;
		set
		{
			if (_background != value)
			{
				_background = value;
				OnPropertyChanged();
			}
		}
	}

	public CultureInfo Culture
	{
		get => _culture;
		set
		{
			if (_culture != value)
			{
				_culture = value;
				OnPropertyChanged();
			}
		}
	}

	public DatePickerViewModel()
	{
		Culture = new CultureInfo("en-US");
	}

	public void ResetToDefaults()
	{
		CharacterSpacing = 0.0d;
		Date = new DateTime(2025, 12, 24);
		FlowDirection = FlowDirection.LeftToRight;
		FontAttributes = FontAttributes.None;
		FontFamily = null;
		FontSize = 0d;
		FontAutoScalingEnabled = true;
		Format = "d";
		IsEnabled = true;
		IsVisible = true;
		IsOpen = false;
		MinimumDate = new DateTime(2025, 12, 24);
		MaximumDate = new DateTime(2027, 12, 24);
		Shadow = null;
		TextColor = Colors.Black;
		Background = null;
		Culture = new CultureInfo("en-US");
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
