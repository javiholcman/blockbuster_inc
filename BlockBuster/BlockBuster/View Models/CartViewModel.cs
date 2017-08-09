using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BlockBuster
{
	public class CartViewModel : ViewModelBase
	{
		public CartViewModel()
		{
		}

		ObservableCollection<Movie> _movies;
		public ObservableCollection<Movie> Movies
		{
			get { return _movies; }
			set { SetProperty(ref _movies, value); }
		}

		decimal _subtotal;
		public decimal Subtotal
		{
			get { return _subtotal; }
			set { SetProperty(ref _subtotal, value); }
		}

		bool _isEmpty;
		public bool IsEmpty
		{
			get { return _isEmpty; }
			set { SetProperty(ref _isEmpty, value); }
		}

		ICommand _removeItemCommand;
		public ICommand RemoveItemCommand 
		{
			get {
				return _removeItemCommand ?? (_removeItemCommand = new Command <Movie> ((m) => RemoveItem(m)));
			}
		}

		ICommand _sendCartCommand;
		public ICommand SendCartCommand
		{
			get
			{
				return _sendCartCommand ?? (_sendCartCommand = new Command(() => SendCart()));
			}
		}

		public override void OnViewAppearing()
		{
			base.OnViewAppearing();

			var movies = CartService.GetMoviesInCart();
			Movies = new ObservableCollection<Movie>(movies);
			Refresh();
		}

		void RemoveItem(Movie movie)
		{
			CartService.RemoveFromCart(movie.Id);
			Movies.Remove(movie);
			Refresh();
		}

		void Refresh()
		{
			IsEmpty = Movies.Count == 0;

			decimal subtotal = 0;
			foreach (var movie in Movies)
				subtotal += movie.Price;
			Subtotal = subtotal;
		}

		async void SendCart()
		{
			try
			{
				IsBusy = true;
				await CartService.SendCartAsync();
				Movies.Clear();
				Refresh();
				IsBusy = false;
			}
			catch (Exception ex)
			{
				ExceptionsManager.Manage(this, ex);
			}
		}
	}
}
