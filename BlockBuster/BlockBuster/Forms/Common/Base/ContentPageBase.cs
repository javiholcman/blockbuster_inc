using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BlockBuster
{
	public class ContentPageBase : ContentPage
	{
		public ContentPageBase()
		{
			base.SetBinding(Page.IsBusyProperty, new Binding("IsBusy", 0, null, null, null, null));
			NavigationPage.SetBackButtonTitle(this, "");
		}

		public ViewModelBase ViewModel 
		{
			get 
			{
				return BindingContext as ViewModelBase;
			}
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();
			if (ViewModel != null)
			{
				ViewModel.NavigateToDelegate += NavigateTo;
				ViewModel.ResultSetted += ResultSetted;
			}
			else 
			{
				ViewModel.NavigateToDelegate -= NavigateTo;
			}
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			ViewModel?.OnViewAppearing();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			ViewModel?.OnViewDisappearing();
		}

		public virtual void NavigateTo(Type viewModelType, Dictionary<string, object> args)
		{
			var page = ViewsManager.CreateView (viewModelType);

			if (page is ContentPageBase)
				((ContentPageBase)page).ViewModel.InputArgs = args;
			
			Navigation.PushAsync(page, true);
		}

		protected override void OnPropertyChanged(string propertyName = null)
		{
			base.OnPropertyChanged(propertyName);

			if (propertyName == nameof(IsBusy))
			{
				if (IsBusy) 
					Acr.UserDialogs.UserDialogs.Instance.ShowLoading(string.Empty, Acr.UserDialogs.MaskType.Black);
				else 
					Acr.UserDialogs.UserDialogs.Instance.HideLoading();
			}
		}

		public virtual void ResultSetted(IList<ViewModelResult> results)
		{
			if (results.Count == 0)
				return;

			if (results.Count == 1)
			{
				var result = results[0];
				if (result is ErrorResult || result is FieldErrorResult)
					DisplayAlert("Error", result.Message, "Ok");

				if (result is SuccessResult)
					DisplayAlert("Ok", result.Message, "Ok");
			}
			else 
			{
				string message = "";
				foreach (var result in results)
					message += result.Message + "\n";

				if (!string.IsNullOrEmpty(message))
					message = message.Substring(0, message.Length - 1);
				
				DisplayAlert("Result", message, "Ok");
			}
		}
	}
}
