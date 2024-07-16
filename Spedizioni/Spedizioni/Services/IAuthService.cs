using System;
namespace Spedizioni.Models
{
	public interface IAuthService
	{

		ApplicationUser Login(string username, string password);
	}
}

