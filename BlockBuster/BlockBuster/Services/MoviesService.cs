using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;

namespace BlockBuster
{
	public static class MoviesService
	{
		const string baseUrl = "http://api.themoviedb.org/3/";
		const string apiKey = "ab41356b33d100ec61e6c098ecc92140";

		public static async Task<IList<Movie>> GetTopRatedAsync()
		{
			var resp = await baseUrl.AppendPathSegment("movie/top_rated")
				.SetQueryParams(new
				{
					api_key = apiKey
				}).GetJsonAsync<PagedResponse<List<Movie>>>();

			var repo = new MovieRepository();
			foreach (var movie in resp.Results)
				repo.Save(movie);

			return resp.Results;
		}

		public static Movie FindByBarcode(string barCode)
		{
			var repo = new MovieRepository();
			return repo.Find(barCode);
		}
	}

	public class PagedResponse<T>
	{
		[JsonProperty("page")]
		public int Page { get; set; }

		[JsonProperty("results")]
		public T Results { get; set; }
	}

}
