using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BlockBuster
{
	public partial class SignupPage : ContentPageBase
	{
		public SignupPage()
		{
			InitializeComponent();
		}

		public override void NavigateTo(Type viewModelType, Dictionary<string, object> args)
		{
			if (viewModelType == typeof(LoginViewModel))
				Navigation.PopAsync();
			else
	 			base.NavigateTo(viewModelType, args);
		}
	}
}
