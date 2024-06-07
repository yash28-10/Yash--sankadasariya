using BookProject.Models;
using BookProject.Service.IService;

namespace BookProject.Service
{
    public class UserService : IUserService
    {
        public readonly List<NewUser> _users = new()
        {
            new NewUser { UserName = "admin", Password = "password", Role = "Admin" },
            new NewUser { UserName = "user", Password = "password", Role = "User" },
            new NewUser { UserName = "meet", Password = "mk123", Role = "User" }
        };

        public NewUser Authenticate(string username, string password)
        {
            return _users.SingleOrDefault(x => x.UserName == username && x.Password == password);
        }

        public IEnumerable<NewUser> GetAll()
        {
            return _users;
        }
    }
}