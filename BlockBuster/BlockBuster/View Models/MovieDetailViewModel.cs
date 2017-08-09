using System;
using System.Windows.Input;

namespace BlockBuster
{
	public class MovieDetailViewModel : ViewModelBase
	{
		Movie _movie;
		public Movie Movie
		{
			get { return _movie; }
			set { SetProperty(ref _movie, value); }
		}

		bool _movieOnCart;
		public bool MovieOnCart
		{
			get { return _movieOnCart; }
			set { SetProperty(ref _movieOnCart, value); }
		}

		public MovieDetailViewModel()
		{
		}

		public override void OnViewAppearing()
		{
			base.OnViewAppearing();

			Movie = InputArgs["Movie"] as Movie;
			MovieOnCart = CartService.HasMovieOnCart(Movie.Id);
		}

		ICommand _addToCartCommand;
		public ICommand AddToCartCommand
		{
			get
			{
				return _addToCartCommand ?? (_addToCartCommand = new Command(() => AddToCart()));
			}
		}

		void AddToCart()
		{
			if (CartService.HasMovieOnCart(Movie.Id))
			{
				CartService.RemoveFromCart(Movie.Id);
				MovieOnCart = false;
			}
			else
			{
				CartService.AddToCart(Movie.Id, Movie.Price);
				MovieOnCart = true;
			}
		}

	}
}
