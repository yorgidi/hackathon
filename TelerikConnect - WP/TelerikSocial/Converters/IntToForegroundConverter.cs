using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;

namespace TelerikSocial.Converters
{
	public class IntToForegroundConverter : IValueConverter
	{
		private static readonly SolidColorBrush redBrush = new SolidColorBrush(Color.FromArgb(160, 214, 92, 51));
		private static readonly SolidColorBrush yellowBrush = new SolidColorBrush(Color.FromArgb(200, 255, 255, 100));
		private static readonly SolidColorBrush greenBrush = new SolidColorBrush(Color.FromArgb(160, 141, 226, 141));

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var intValue = (int)value;
			var maxValue = System.Convert.ToInt32(parameter);
			if (intValue < maxValue / 10)
			{
				return redBrush;
			}
			else if (intValue < maxValue / 2)
			{
				return yellowBrush;
			}
			else
			{
				return greenBrush;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}