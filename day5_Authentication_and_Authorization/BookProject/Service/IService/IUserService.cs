using BookProject.Models;

namespace BookProject.Service.IService
{
    public interface IUserService
    {
        NewUser Authenticate(string username, string password);

        IEnumerable<NewUser> GetAll();
    }
}
