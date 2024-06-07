using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookProject.Models
{
    public class NewUser
    {
        public string UserName { get; set; }

        public string Password { get; set; }
                      
        public string Role { get; set; }
    }
}
