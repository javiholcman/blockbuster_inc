using System;
using System.Linq;
using BlockBuster;

namespace BlockBuster
{
	public class UserRepository : SqliteRepository <User, string>
	{
		public UserRepository()
		{
		}

		public User GetLoggedUser()
		{
			return FindAllWhere(p => p.IsLogged == true).FirstOrDefault();
		}
	}
}
