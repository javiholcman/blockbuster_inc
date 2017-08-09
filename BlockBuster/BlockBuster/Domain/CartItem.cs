using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using SQLite.Net.Attributes;

namespace BlockBuster
{
	public class CartItem
	{
		[PrimaryKey]
		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "userId")]
		public string UserId { get; set; }

		[JsonProperty(PropertyName = "movieId")]
		public string MovieId { get; set; }

		[JsonProperty(PropertyName = "price")]
		public decimal Price { get; set; }

		[Version]
		public string Version { get; set; }

		public CartItem()
		{
		}
	}
}
