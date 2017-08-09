using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace BlockBuster
{
	public static class CartService
	{
		static MobileServiceClient _azureClient = new MobileServiceClient(Constants.AzureURL);

		public static void AddToCart(string movieId, decimal price)
		{
			var cartRepo = new CartItemRepository();
			var cartItem = new CartItem 
			{ 
				Id = Guid.NewGuid().ToString(),  
				MovieId = movieId,
				UserId = AuthenticationService.LoggedUser.Id,
				Price = price
			};
			cartRepo.Save(cartItem);
		}

		public static void RemoveFromCart(string movieId)
		{
			var cartRepo = new CartItemRepository();
			var cartItem = cartRepo.Find(AuthenticationService.LoggedUser.Id, movieId);
			if (cartItem != null) 
				cartRepo.Delete(cartItem);
		}

		public static bool HasMovieOnCart(string movieId)
		{
			var cartRepo = new CartItemRepository();
			var cartItem = cartRepo.Find(AuthenticationService.LoggedUser.Id, movieId);
			return cartItem != null;
		}

		public static List<Movie> GetMoviesInCart()
		{
			var moviesRepo = new MovieRepository();
			var cartItemRepo = new CartItemRepository();

			var movies = new List<Movie>();
			var items = cartItemRepo.FindAll(AuthenticationService.LoggedUser.Id);
			foreach (var item in items)
			{
				var movie = moviesRepo.Find(item.MovieId);
				movies.Add(movie);
			}
			return movies;
		}

		public static async Task SendCartAsync()
		{
			var table = _azureClient.GetTable<CartItem>();

			var cartItemRepo = new CartItemRepository();
			var items = cartItemRepo.FindAll(AuthenticationService.LoggedUser.Id);
			foreach (var item in items)
			{
				await table.InsertAsync(item);
				cartItemRepo.Delete(item);
			}
		}

		public static async Task<List<CartItem>> GetCartItemsAsync()
		{
			var table = _azureClient.GetTable<CartItem>();

			IEnumerable<CartItem> items = await table
				//.Where(CartItem => CartItem.Id == "1123")
				.ToEnumerableAsync();

			return new List<CartItem>(items);
		}
	}
}
