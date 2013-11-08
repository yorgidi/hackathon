using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace TelerikSocial.Converters
{
	public class IntToFontWeightConverter : DependencyObject, IValueConverter
	{
		public static readonly DependencyProperty MaxValueProperty =
			DependencyProperty.Register("MaxValue", typeof(int), typeof(IntToFontWeightConverter), new PropertyMetadata(null));

		public int MaxValue
		{
			get
			{
				return (int)this.GetValue(MaxValueProperty);
			}
			set
			{
				this.SetValue(MaxValueProperty, value);
			}
		}

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var intValue = (int)value;

			return intValue == this.MaxValue ? FontWeights.ExtraBold : FontWeights.ExtraLight;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			// TODO: Implement this method
			throw new NotImplementedException();
		}
	}
}