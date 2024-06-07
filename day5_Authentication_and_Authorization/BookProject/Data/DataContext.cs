﻿using BookProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BookProject.Data
{
    public class DataContext : DbContext
    {
         
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
          
        }
         
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
