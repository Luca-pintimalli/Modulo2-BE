using System;
namespace Spedizioni.Models
{
	public class ApplicationUser
	{
        public int Id { get; set; }

        public required string UserName { get; set; }

        public required string Password { get; set; }

        public IEnumerable<string> Roles { get; set; }

    }
}

