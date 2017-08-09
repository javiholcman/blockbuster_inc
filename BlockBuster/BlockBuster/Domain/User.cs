using System;
using SQLite.Net.Attributes;

namespace BlockBuster
{
	public class User
	{
		[PrimaryKey]
		public string Id { get; set; }

		public string Username { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }

		public bool IsLogged { get; set; }

		public string FullName
		{
			get
			{
				return FirstName + " " + LastName;
			}
		}

		public User()
		{
		}
	}
}
