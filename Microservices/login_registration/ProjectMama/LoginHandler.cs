using System;

using MySql.Data.MySqlClient;

namespace ProjectMama
{
    public class LoginHandler : MySqlConnectionHandler
    {
        static string loginSQLCMD = "SELECT * FROM users WHERE (name='{0}' OR mail='{0}') AND password='{1}';";

        public bool checkLoginRequest(string name, string password)
        {
            bool result = false;
            MySqlCommand cmd = new MySqlCommand(String.Format(loginSQLCMD, name, password), connection);
            MySqlDataReader mySqlDataReader = cmd.ExecuteReader();

            if (mySqlDataReader.Read())
                result = true;

            return result;
        }
    }
}