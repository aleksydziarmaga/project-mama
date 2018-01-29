using System;

using MySql.Data.MySqlClient;

namespace ProjectMama
{
    public class RegistrationHandler : MySqlConnectionHandler
    {
        static string saveUserSQLCMD = "INSERT INTO users(name,mail,password) VALUES ('{0}','{1}','{2}');";

        public uint saveUser(User user)
        {
            MySqlCommand cmd = new MySqlCommand(
                String.Format(
                    saveUserSQLCMD,
                    user.name,
                    user.mail,
                    user.password
                    ),
                connection
                );

            cmd.ExecuteNonQuery();

            return Convert.ToUInt32(cmd.LastInsertedId);
        }
    }
}