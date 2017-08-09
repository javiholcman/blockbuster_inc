using System;
using System.Collections.Generic;
using Plugin.Media;
using Xamarin.Forms;

namespace BlockBuster
{
	public partial class ProfilePage : ContentPageBase
	{
		public ProfilePage()
		{
			InitializeComponent();
		}

		public override void NavigateTo(Type viewModelType, Dictionary<string, object> args)
		{
			if (viewModelType == typeof(LoginViewModel))
			{
				App.Current.MainPage = new NavigationPage(ViewsManager.CreateView(viewModelType));
			}
			else
			{
				base.NavigateTo(viewModelType, args);
			}
		}

		async void BtnPhoto_Clicked(object sender, System.EventArgs e)
		{
			await CrossMedia.Current.Initialize();

			if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
			{
				await DisplayAlert("No Camera", ":( No camera available.", "OK");
				return;
			}

			var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
			{
				Directory = "Sample",
				Name = "test.jpg"
			});

			if (file == null)
				return;

			ImgPhoto.Source = ImageSource.FromStream(() =>
			{
				var stream = file.GetStream();
				file.Dispose();
				return stream;
			});
		}
	}
}
