using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace BookProject.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
        public int RoleId { get; set; }

        [NotMapped]
        public Role Role { get; set; }
    }
}
