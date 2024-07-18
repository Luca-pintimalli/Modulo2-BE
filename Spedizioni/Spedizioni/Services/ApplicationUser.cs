using System.Collections.Generic;

namespace Spedizioni.Models
{
    public class ApplicationUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; } 
        public List<string> Roles { get; set; } = new List<string>();
    }
}


