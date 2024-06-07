﻿using System.ComponentModel.DataAnnotations;

namespace BookProject.Models
{
    public class Role
    {
    
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public ICollection<User> Users { get; set; }




    }
}
