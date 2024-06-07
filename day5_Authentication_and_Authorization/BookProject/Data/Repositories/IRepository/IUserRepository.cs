using BookProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookProject.Data.Repositories.IRepository
{
    public interface IUserRepository
    { 
        List<User> GetAllUsersFromDatabase();
        ActionResult<User> GetUserById(int id);
        void AddUser(User user);
        List<User> GetUsersOrderedByUsername();
        List<IGrouping<string, User>> GetUsersGroupedByRole();
        List<UserRoleDto> GetUsersWithRoles();
    }
}
