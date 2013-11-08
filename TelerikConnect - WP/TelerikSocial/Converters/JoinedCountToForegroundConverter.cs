using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace TelerikSocial.Converters
{
	public class JoinedCountToForegroundConverter : DependencyObject, IValueConverter
	{
		private static readonly SolidColorBrush greenBrush = new SolidColorBrush(Color.FromArgb(160, 141, 226, 141));
		private static readonly SolidColorBrush whiteBrush = new SolidColorBrush(Colors.White);

		public static readonly DependencyProperty MaxValueProperty =
			DependencyProperty.Register("MaxValue", typeof(int), typeof(JoinedCountToForegroundConverter), new PropertyMetadata(null));

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

			return intValue == this.MaxValue ? greenBrush : whiteBrush;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			// TODO: Implement this method
			throw new NotImplementedException();
		}
	}
}