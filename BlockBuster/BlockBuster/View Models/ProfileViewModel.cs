using System;
using System.Windows.Input;

namespace BlockBuster
{
	public class ProfileViewModel : ViewModelBase
	{
		User _user;
		public User User
		{
			get { return _user; }
			set { SetProperty(ref _user, value); }
		}

		ICommand _logoutCommand;
		public ICommand LogoutCommand
		{
			get
			{
				return _logoutCommand ?? (_logoutCommand = new Command(() => Logout()));
			}
		}

		public ProfileViewModel()
		{
			User = AuthenticationService.LoggedUser;
		}

		void Logout()
		{
			AuthenticationService.Logout();
			NavigateTo<LoginViewModel>();
		}
	}
}
