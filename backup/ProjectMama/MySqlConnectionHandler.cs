using System;

using MySql.Data.MySqlClient;

namespace ProjectMama
{
    public class MySqlConnectionHandler
    {
        public string ConnectionString
        {
            get { return connection.ConnectionString; }
            set { connection.ConnectionString = value; }
        }

        protected MySqlConnection connection;

        public MySqlConnectionHandler(string myConnectionString = "server=localhost;user id=root;database=mama;persistsecurityinfo=True")
        {
            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = myConnectionString;
                connection.Open();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Exception occured when tried to connect to database.");
                Console.Error.WriteLine(e.Message);
            }
        }
    }
}