using System;
using System.Windows.Input;

namespace BlockBuster
{
	public class RentViewModel : ViewModelBase
	{
		ICommand _searchByBarcodeCommand;
		public ICommand SearchByBarcodeCommand
		{
			get
			{
				return _searchByBarcodeCommand ?? (_searchByBarcodeCommand = new Command <string>((p) => SearchByBarcode(p)));
			}
		}

		public RentViewModel()
		{
		}

		void SearchByBarcode(string barCode)
		{
			var movie = MoviesService.FindByBarcode(barCode);
			if (movie == null)
			{
				SetResult(new ErrorResult("No se ha encontrado la pelicula"));
				return;
			}

			if (CartService.HasMovieOnCart(movie.Id))
			{
				SetResult(new ErrorResult("Ya tiene esa pelicula en su carrito"));
				return;
			}

			CartService.AddToCart(movie.Id, movie.Price);
			SetResult(new SuccessResult("Se ha agregado la pelicula correctamente"));
		}
	}
}
