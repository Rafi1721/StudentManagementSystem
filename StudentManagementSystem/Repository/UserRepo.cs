using MySql.Data.MySqlClient;
using StudentManagementSystem.Model;
using StudentManagementSystem.Repository.Interface;
using System.Data;

namespace StudentManagementSystem.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly ILogger<UserRepo> logger;
        private IConfiguration _Configuration;
        public UserRepo(IConfiguration configuration, ILogger<UserRepo> logger)
        {
            this.logger = logger;
            _Configuration = configuration;
        }

        public int Loginrepo(string username, string password)
        {
            try
            {
                var conStr = this._Configuration.GetConnectionString("Default");
                var con = new MySqlConnection(conStr);
                var cmd = new MySqlCommand("Login_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_username", username);
                cmd.Parameters.AddWithValue("_password", password);
                int result = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();
                return result;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return -1;
            }
        }
            public int Registerrepo(string username, string password)
            {


                try
                {
                    var conStr = this._Configuration.GetConnectionString("Default");
                    var con = new MySqlConnection(conStr);
                    var cmd = new MySqlCommand("Register_SP", con);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_username", username);
                    cmd.Parameters.AddWithValue("_password", password);
                    int result = Convert.ToInt32(cmd.ExecuteScalar());

                    con.Close();
                    return result;
                }
                catch (Exception e)
                {
                    logger.LogError(e.Message);
                    return -1;
                }

            }
        }
    }

