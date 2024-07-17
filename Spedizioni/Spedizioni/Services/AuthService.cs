using System;
using System.Data.SqlClient;
using Spedizioni.Models;

namespace Spedizioni.Services
{
    public class AuthService : IAuthService
    {
        private string connectionString;
        private const string Login_Command = "SELECT UserName FROM Auth WHERE UserName = @UserName AND Password = @Password";

        public AuthService(IConfiguration config)
        {
            connectionString = config.GetConnectionString("AuthDb")!;
        }

        public ApplicationUser Login(string username, string password)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(Login_Command, conn);
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@Password", password);


                using var r = cmd.ExecuteReader();
                if (r.Read())
                {
                    Console.WriteLine("User authenticated successfully.");
                    return new ApplicationUser { UserName = username, Password = password };
                }
                else
                {
                    Console.WriteLine("User authentication failed.");
                }
            }
            catch (Exception ex)
            {

            }

            return null;
        }


    }
}
