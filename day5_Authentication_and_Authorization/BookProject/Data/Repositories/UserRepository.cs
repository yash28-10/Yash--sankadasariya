using BookProject.Data.Repositories.IRepository;
using BookProject.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookProject.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

  

        public List<User> GetAllUsersFromDatabase()
        {
            List<User> users = new List<User>();
            var dataList = _context.Users.ToList();
            dataList.ForEach(user => users.Add(new User()
            {
                UserId = user.UserId,
                Username = user.Username,
                Password = user.Password,
                RoleId = user.RoleId,
                Role = _context.Roles.Where(d => d.RoleId.Equals(user.RoleId)).FirstOrDefault()
            }));

            return users;
        }

        public ActionResult<User> GetUserById(int id)
        {
             
            var dataList = _context.Users.SingleOrDefault(u => u.UserId == id);
           if(dataList == null)
            {
                return null;
            }
            var user = new User()
            {
                UserId = dataList.UserId,
                Username = dataList.Username,
                Password = dataList.Password,
                RoleId = dataList.RoleId,
                Role = _context.Roles.Where(d => d.RoleId.Equals(dataList.RoleId)).FirstOrDefault()
            };

            return user;
        }

        public void AddUser(User user)
        {
         
            User dbTable = new User();

            dbTable.Username = user.Username;
            dbTable.UserId = user.UserId;
            dbTable.Password = user.Password;
            dbTable.RoleId = user.RoleId;
            dbTable.Role = _context.Roles.Find(user.RoleId);

            _context.Users.Add(dbTable);

            _context.SaveChanges();
        }

        // New Methods
        public List<User> GetUsersOrderedByUsername()
        {

            List<User> users = new List<User>();
            var dataList = _context.Users.OrderBy(u => u.Username).ToList();
            dataList.ForEach(user => users.Add(new User()
            {
                UserId = user.UserId,
                Username = user.Username,
                Password = user.Password,
                RoleId = user.RoleId,
                Role = _context.Roles.Where(d => d.RoleId.Equals(user.RoleId)).FirstOrDefault()
            }));

            return users;
             
        }

        public List<IGrouping<string, User>> GetUsersGroupedByRole()
        {
            return _context.Users.GroupBy(u => u.Role.RoleName).ToList();
        }

        public List<UserRoleDto> GetUsersWithRoles()
        {
            var usersWithRoles = from user in _context.Users
                                 join role in _context.Roles
                                 on user.RoleId equals role.RoleId
                                 select new UserRoleDto
                                 {  
                                     Id = user.UserId,
                                     Username = user.Username,
                                     RoleName = role.RoleName
                                 };
            return usersWithRoles.ToList();
        }
    }
}