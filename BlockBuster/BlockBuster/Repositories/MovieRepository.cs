using System;
using System.Collections.Generic;

namespace BlockBuster
{
	public class MovieRepository : SqliteRepository<Movie, string>
	{
		public MovieRepository()
		{
		}
	}
}
