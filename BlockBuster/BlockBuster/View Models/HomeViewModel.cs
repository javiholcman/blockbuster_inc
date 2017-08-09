using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BlockBuster
{
	public class HomeViewModel : ViewModelBase
	{
		ObservableCollection<Movie> _topRatedMovies;
		public ObservableCollection<Movie> TopRatedMovies
		{
			get { return _topRatedMovies; }
			set { SetProperty(ref _topRatedMovies, value); }
		}

		Movie _selectedItem;
		public Movie SelectedItem
		{
			get { return _selectedItem; }
			set
			{
				_selectedItem = value;
				NavigateTo<MovieDetailViewModel>(new Dictionary<string, object>() { { "Movie", value } });
			}
		}

		public HomeViewModel()
		{
			
		}

		public override async void OnViewAppearing()
		{
			if (TopRatedMovies != null && TopRatedMovies.Count > 0)
				return;
			
			try
			{
				IsBusy = true;
				var movies = await MoviesService.GetTopRatedAsync();
				TopRatedMovies = new ObservableCollection<Movie>(movies);
				IsBusy = false;
			}
			catch (Exception ex)
			{
				ExceptionsManager.Manage(this, ex);
			}
		}

	}
}
