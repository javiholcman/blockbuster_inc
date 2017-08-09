using System;
using System.Collections.Generic;
using System.Linq;

namespace BlockBuster
{
	public class CartItemRepository : SqliteRepository<CartItem, string>
	{
		public CartItemRepository()
		{
		}

		public CartItem Find(string userId, string movieId)
		{
			return FindAllWhere(p => p.MovieId == movieId && p.UserId == userId).FirstOrDefault();
		}

		public IList<CartItem> FindAll(string userId)
		{
			return FindAllWhere(p => p.UserId == userId);
		}
	}
}
