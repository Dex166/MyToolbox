using System;
using System.Globalization;
using System.Windows.Data;

namespace UserControls
{
	internal class ButtonConverter : IValueConverter
	{

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			double x = ((double)value - (double)34) / 2;
			//Thickness myThickness = new()
			//{
			//	Bottom = x,
			//	Left = x,
			//	Right = x,
			//	Top = x
			//};
			return x;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
