using System;
using Newtonsoft.Json;
using SQLite.Net.Attributes;

namespace BlockBuster
{
	public class Movie
	{
		[PrimaryKey]
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("poster_path")]
		public string PosterPath { get; set; }

		public string PosterUrl
		{
			get
			{
				// should be getted from config api
				return "https://image.tmdb.org/t/p/w500/" + PosterPath;
			}
		}

		[JsonProperty("adult")]
		public bool Adult { get; set; }

		[JsonProperty("overview")]
		public string Overview { get; set; }

		[JsonProperty("release_date")]
		public DateTime ReleaseDate { get; set; }

		[JsonProperty("backdrop_path")]
		public string BackDropPath { get; set; }

		public string BackDropUrl
		{
			get
			{
				// should be getted from config api
				return "https://image.tmdb.org/t/p/w500/" + BackDropPath;
			}
		}

		[JsonProperty("popularity")]
		public string Popularity { get; set; }

		[JsonProperty("vote_average")]
		public float VoteAverage { get; set; }

		[JsonProperty("vote_count")]
		public string Votes { get; set; }

		public decimal Price { get; set; } = 120;

		public Movie()
		{
		}
	}
}
