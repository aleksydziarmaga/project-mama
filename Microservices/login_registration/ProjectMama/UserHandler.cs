using System;
using System.Collections;

using MySql.Data.MySqlClient;

namespace ProjectMama
{
    public class UserHandler : MySqlConnectionHandler
    {
        static string getUsersSQLCMD = "SELECT * FROM users;";
        static string getUserByIdSQLCMD = "SELECT * FROM users WHERE id={0};";
        static string saveUserSQLCMD = "INSERT INTO users(name,mail,password) VALUES ('{0}','{1}',{2});";
        static string updateUserSQLCMD = "UPDATE users SET name='{1}',mail='{2}',password={3} WHERE id={0};";
        static string deleteUserByIdSQLCMD = "DELETE FROM users WHERE id={0};";

        public ArrayList getUsers()
        {
            MySqlCommand cmd = new MySqlCommand(getUsersSQLCMD, connection);
            MySqlDataReader mySqlDataReader = cmd.ExecuteReader();

            ArrayList result = new ArrayList();

            while (mySqlDataReader.Read())
            {
                User user = new User();

                user.id = mySqlDataReader.GetUInt32(0);
                user.name = mySqlDataReader.GetString(1);
                user.mail = mySqlDataReader.GetString(2);
                user.password = mySqlDataReader.GetString(3);

                result.Add(user);
            }

            return result;
        }

        public User getUser(uint id)
        {
            MySqlCommand cmd = new MySqlCommand(String.Format(getUserByIdSQLCMD, id), connection);
            MySqlDataReader mySqlDataReader = cmd.ExecuteReader();

            User result = null;

            if (mySqlDataReader.Read())
            {
                result = new User();

                result.id = mySqlDataReader.GetUInt32(0);
                result.name = mySqlDataReader.GetString(1);
                result.mail = mySqlDataReader.GetString(2);
                result.password = mySqlDataReader.GetString(3);
            }

            return result;
        }

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

        public bool updateUser(uint id, User person)
        {
            MySqlCommand cmd;
            MySqlDataReader mySqlDataReader;

            cmd = new MySqlCommand(String.Format(getUserByIdSQLCMD, id), connection);
            mySqlDataReader = cmd.ExecuteReader();

            if (mySqlDataReader.Read())
            {
                mySqlDataReader.Close();

                cmd = new MySqlCommand(
                String.Format(
                    updateUserSQLCMD,
                    id,
                    person.name,
                    person.mail,
                    person.password
                    ),
                connection
                );
                cmd.ExecuteNonQuery();

                return true;
            }
            else
                return false;
        }

        public bool deleteUser(uint id)
        {
            MySqlCommand cmd;
            MySqlDataReader mySqlDataReader;

            cmd = new MySqlCommand(String.Format(getUserByIdSQLCMD, id), connection);
            mySqlDataReader = cmd.ExecuteReader();

            if (mySqlDataReader.Read())
            {
                mySqlDataReader.Close();

                cmd = new MySqlCommand(String.Format(deleteUserByIdSQLCMD, id), connection);
                cmd.ExecuteNonQuery();

                return true;
            }
            else
                return false;
        }
    }
}