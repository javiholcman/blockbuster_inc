using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;

namespace BlockBuster
{
	public partial class MovieDetailPage : ContentPageBase
	{
		public MovieDetailPage()
		{
			InitializeComponent();
		}
	}

	public class MovieInCartConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool val = (bool)value;
			if (val)
				return "- del carrito";
			else
				return "+ al carrito";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
