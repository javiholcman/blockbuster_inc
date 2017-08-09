using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;

namespace BlockBuster
{
	public partial class CartPage : ContentPageBase
	{
		public CartPage()
		{
			InitializeComponent();
		}

		void BtnRemove_Clicked(object sender, System.EventArgs e)
		{
			var viewModel = ViewModel as CartViewModel;
			viewModel.RemoveItemCommand.Execute((sender as Button).CommandParameter);
		}
	}

	public class InvertConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return !(bool)value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
