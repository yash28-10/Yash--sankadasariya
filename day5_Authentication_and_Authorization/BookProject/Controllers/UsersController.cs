﻿using BookProject.Data.Repositories.IRepository;
using BookProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
 
        [HttpGet("all-from-database")]
        public ActionResult<List<User>> GetAllUsersFromDatabase()
        {
            return _userRepository.GetAllUsersFromDatabase();
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public ActionResult<List<User>> AddUser(User user)
        {
            _userRepository.AddUser(user);
            return _userRepository.GetAllUsersFromDatabase();
        }

        [HttpGet("ordered-by-username")]
        public ActionResult<List<User>> GetUsersOrderedByUsername()
        {
            return _userRepository.GetUsersOrderedByUsername();
        }

        [HttpGet("users-with-role")]
        public List<UserRoleDto> GetUsersGroupedByRole()
        {
            return _userRepository.GetUsersWithRoles();
        }

    }
}
