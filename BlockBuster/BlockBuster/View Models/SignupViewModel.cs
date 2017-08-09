using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BlockBuster
{
	public class SignupViewModel : ViewModelBase
	{
		string _username;
		public string Username
		{
			get { return _username; }
			set { SetProperty(ref _username, value); }
		}

		string _firstName;
		public string FirstName
		{
			get { return _firstName; }
			set { SetProperty(ref _firstName, value); }
		}

		string _lastName;
		public string LastName
		{
			get { return _lastName; }
			set { SetProperty(ref _lastName, value); }
		}

		string _email;
		public string Email
		{
			get { return _email; }
			set { SetProperty(ref _email, value); }
		}

		string _password;
		public string Password
		{
			get { return _password; }
			set { SetProperty(ref _password, value); }
		}

		string _rePassword;
		public string RePassword
		{
			get { return _rePassword; }
			set { SetProperty(ref _rePassword, value); }
		}

		ICommand _saveCommand;
		public ICommand SaveCommand
		{
			get
			{
				return _saveCommand ?? (_saveCommand = new Command(async () => await Save()));
			}
		}

		public SignupViewModel()
		{

		}

		async Task Save()
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
				await AuthenticationService.SignupAsync(Username, FirstName, LastName, Email, Password);
				IsBusy = false;

				NavigateTo<LoginViewModel>();
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

		List<ViewModelResult> Validate()
		{
			var results = new List<ViewModelResult>();

			if (string.IsNullOrEmpty(Username))
				results.Add(new FieldErrorResult(Localize("Username"), Localize("es requerido")));
			else if (Username.Length > 20)
				results.Add(new FieldErrorResult(Localize("Username"), Localize("es muy largo")));

			if (string.IsNullOrEmpty(FirstName))
				results.Add(new FieldErrorResult(Localize("Nombre"), Localize("es requerido")));
			else if (FirstName.Length > 20)
				results.Add(new FieldErrorResult(Localize("Nombre"), Localize("es muy largo")));

			if (string.IsNullOrEmpty(LastName))
				results.Add(new FieldErrorResult(Localize("Apellido"), Localize("es requerido")));
			else if (LastName.Length > 20)
				results.Add(new FieldErrorResult(Localize("Apellido"), Localize("es muy largo")));
			
			if (string.IsNullOrEmpty(Email))
				results.Add(new FieldErrorResult(Localize("Email"), Localize("es requerido")));
			else if (!Email.Contains("@") || !Email.Contains("."))
				results.Add(new FieldErrorResult(Localize("Email"), Localize("es invalido")));

			if (string.IsNullOrEmpty(Password))
				results.Add(new FieldErrorResult(Localize("Password"), Localize("es requerido")));

			if (string.IsNullOrEmpty(RePassword))
				results.Add(new FieldErrorResult(Localize("Confirmacion"), Localize("es requerido")));

			if (Password != RePassword)
				results.Add(new FieldErrorResult(Localize("Confirmacion"), Localize("no coinciden")));

			return results;
		}
	}
}
