using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BlockBuster
{
	public partial class LoginPage : ContentPageBase
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		public override void NavigateTo(Type viewModelType, Dictionary<string, object> args)
		{
			if (viewModelType == typeof(MainMenuViewModel))
			{
				App.Current.MainPage = new MainMenuPage();
			}
			else
			{
				base.NavigateTo(viewModelType, args);
			}
		}
	}
}
