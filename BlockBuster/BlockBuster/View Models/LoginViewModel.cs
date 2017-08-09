using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BlockBuster
{
	public class LoginViewModel : ViewModelBase
	{
	 	string _Username;
		public string Username
		{
			get { return _Username; }
			set
			{
				SetProperty(ref _Username, value);
			}
		}

		string _password;
		public string Password
		{
			get { return _password; }
			set { SetProperty(ref _password, value); }
		}

		ICommand _loginCommand;
		public ICommand LoginCommand
		{
			get
			{
				return _loginCommand ?? (_loginCommand = new Command(async () => await Login()));
			}
		}

		ICommand _signupCommand;
		public ICommand SignupCommand
		{
			get
			{
				return _signupCommand ?? (_signupCommand = new Command(() => Signup()));
			}
		}

		public LoginViewModel()
		{
				
		}

		async Task Login()
		{
			if (IsBusy)
				return;

			try
			{
				var results = Validate();
				if (results.Count > 0)
				{
					SetResults(results);
					return;
				}

				IsBusy = true;
				var user = await AuthenticationService.LoginAsync(Username, Password);
				IsBusy = false;

				if (user == null)
				{
					IsBusy = false;
					SetResult(new ErrorResult(Localize("Usuario o contraseña incorrectos")));
					return;
				}

				NavigateTo<MainMenuViewModel>();

			}
			catch (Exception ex)
			{
				ExceptionsManager.Manage(this, ex);
			}
			finally
			{
				IsBusy = false;
			}
		}

		void Signup()
		{
			NavigateTo<SignupViewModel>();
		}

		private List<ViewModelResult> Validate()
		{
			var results = new List<ViewModelResult>();

			if (string.IsNullOrEmpty(Username))
			{
				results.Add(new FieldErrorResult(Localize("Username"), Localize("is required")));
			}
			else
			{
				/*
				var IMDIsValud = User.IMDIsValid(IMDNumber);
				if (!IMDIsValud)
				{
					results.Add(new FieldErrorResult(Localize("IMD Number"), Localize("is invalid")));
				}*/
			}

			if (string.IsNullOrEmpty(Password))
			{
				results.Add(new FieldErrorResult(Localize("Password"), Localize("is required")));
			}

			return results;
		}
	}
}
