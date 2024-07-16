using System;
using Spedizioni.Models;

namespace Spedizioni.Services
{
    public class AuthService : IAuthService
    {
        public ApplicationUser Login(string username, string password)
        {
            if (username == password)
                return new ApplicationUser { Password = password, UserName = username };
            throw new Exception("Utente non autenticato");
        }
    }
}

