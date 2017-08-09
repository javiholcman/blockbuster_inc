using System;
using System.Threading.Tasks;

namespace BlockBuster
{
    public static class AuthenticationService
    {
        static User _loggedUser;
        public static User LoggedUser
        {
            get
            {
                if (_loggedUser == null)
                {
                    var userRepo = new UserRepository();
                    _loggedUser = userRepo.GetLoggedUser();
                }
                return _loggedUser;
            }
        }


        public static async Task<User> LoginAsync(string username, string password)
        {
            return await Task.Run(async () =>
            {
                await Task.Delay(2000);

                if (username.ToLower() == "user1" && password.ToLower() == "123")
                {
                    var user = new User { Id = "1", FirstName = "Bruce", LastName = "Wayne", Username = "user1", Email = "bruce@batman.com" };
                    var userRepo = new UserRepository();
                    user.IsLogged = true;
                    userRepo.Save(user);
                    return user;
                }
                return null;
            });
        }

        public static async Task<User> SignupAsync(string username, string firstName, string lastName, string email, string password)
        {
            return await Task.Run(async () =>
            {
                await Task.Delay(2000);

                return new User { Id = "84737f31", FirstName = firstName, LastName = lastName, Username = username, Email = email };
            });
        }

        public static void Logout()
        {
            var userRepo = new UserRepository();

            var user = LoggedUser;
            user.IsLogged = false;
            userRepo.Save(user);
        }
    }
}
