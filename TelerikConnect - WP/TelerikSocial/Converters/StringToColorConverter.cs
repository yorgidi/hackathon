using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;

namespace TelerikSocial.Converters
{
	public class StringToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return new SolidColorBrush(ColorFromString((string)value));
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		private static Color ColorFromString(string hexString)
		{
			byte a = 0;
			byte r = 0;
			byte g = 0;
			byte b = 0;
			if (hexString.StartsWith("#"))
			{
				hexString = hexString.Substring(1, 8);
			}
			a = System.Convert.ToByte(Int32.Parse(hexString.Substring(0, 2), NumberStyles.AllowHexSpecifier));
			r = System.Convert.ToByte(Int32.Parse(hexString.Substring(2, 2), NumberStyles.AllowHexSpecifier));
			g = System.Convert.ToByte(Int32.Parse(hexString.Substring(4, 2), NumberStyles.AllowHexSpecifier));
			b = System.Convert.ToByte(Int32.Parse(hexString.Substring(6, 2), NumberStyles.AllowHexSpecifier));
			return Color.FromArgb(a, r, g, b);
		}
	}
}