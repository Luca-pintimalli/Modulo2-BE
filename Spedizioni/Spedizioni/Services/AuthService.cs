using System;
using System.Data.SqlClient;
using Spedizioni.Models;

namespace Spedizioni.Services
{
    public class AuthService : IAuthService
    {
        private string connectionString;
        private const string Login_Command = "SELECT UserId, UserName FROM Auth WHERE UserName = @UserName AND Password = @Password";
        private const string ROLES_COMMAND = "SELECT RoleName FROM Roles WHERE RoleID = @RoleID";

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
                    var u = new ApplicationUser { UserId = r.GetInt32(0), Password = password, UserName = username };
                    r.Close();
                    using var roleCmd = new SqlCommand(ROLES_COMMAND, conn);
                    roleCmd.Parameters.AddWithValue("@RoleID", u.RoleID);
                    using var re = roleCmd.ExecuteReader();
                    while (re.Read())
                    {
                        u.Roles.Add(r.GetString(0));
                    }
                    return u;
                }   
            }
                catch (Exception ex)
            {

            }

            return null;
        }


    }
}
