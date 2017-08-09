using System;
using Xamarin.Forms;

namespace BlockBuster
{
	public class MainMenuPage : TabbedPage
	{
		public MainMenuPage()
		{
			Children.Add(new NavigationPage(ViewsManager.CreateView<HomeViewModel>())
			{
				Icon = "tab_home",
				Title = (Device.RuntimePlatform == Device.Android ? "" : "Home")
			});

			Children.Add(new NavigationPage(ViewsManager.CreateView<CartViewModel>())
			{
				Icon = "tab_cart",
				Title = (Device.RuntimePlatform == Device.Android ? "" : "Carrito")
			});

			Children.Add(new NavigationPage(ViewsManager.CreateView<RentViewModel>())
			{
				Icon = "tab_rent",
				Title = (Device.RuntimePlatform == Device.Android ? "" : "Escanear")
			});

			Children.Add(new NavigationPage(ViewsManager.CreateView<ProfileViewModel>())
			{
				Icon = "tab_profile",
				Title = (Device.RuntimePlatform == Device.Android ? "" : "Perfil")
			});

		}

	}
}
