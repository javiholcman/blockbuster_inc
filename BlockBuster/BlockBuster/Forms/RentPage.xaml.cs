using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BlockBuster
{
	public partial class RentPage : ContentPageBase
	{
		public RentPage()
		{
			InitializeComponent();
		}

		async void BtnScann_Clicked(object sender, System.EventArgs e)
		{
			try
			{
				bool scanned = true;
				var scanner = new ZXing.Mobile.MobileBarcodeScanner();

				Device.StartTimer(TimeSpan.FromSeconds(3), () =>
				{
					scanner.AutoFocus();
					return scanned;
				});

				var result = await scanner.Scan();
				Device.BeginInvokeOnMainThread(() =>
				{
					scanned = false;
					if (result != null)
					{
						var text = result.Text;
						(ViewModel as RentViewModel).SearchByBarcodeCommand.Execute(text);
					}
				});
			}
			catch (Exception ex)
			{
				// Handle exception
			}
		}
	}
}
