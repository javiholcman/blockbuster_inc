using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BlockBuster
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			LoadDataBase();
			RegisterPages();

			if (AuthenticationService.LoggedUser == null)
				MainPage = new NavigationPage(ViewsManager.CreateView<LoginViewModel>());
			else
				MainPage = new MainMenuPage();
			
		}

		void LoadDataBase()
		{
			DBContext.Add("db.sqlite", new List<Type>()
			{
				typeof(User),
				typeof(CartItem),
				typeof(Movie)
			});
		}

		void RegisterPages()
		{
			ViewsManager.Register<LoginViewModel, LoginPage>();
			ViewsManager.Register<SignupViewModel, SignupPage>();
			ViewsManager.Register<MainMenuViewModel, MainMenuPage>();
			ViewsManager.Register<HomeViewModel, HomePage>();
			ViewsManager.Register<MovieDetailViewModel, MovieDetailPage>();
			ViewsManager.Register<CartViewModel, CartPage>();
			ViewsManager.Register<RentViewModel, RentPage>();
			ViewsManager.Register<ProfileViewModel, ProfilePage>();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

	}
}
