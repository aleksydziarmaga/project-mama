using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BackEnd
{

    class Program
    {



        static void Main(string[] args)
        {
            string connectionString = "server=localhost;user id=root;database=mama;persistsecurityinfo=True";
            Polaczenie baza = new Polaczenie();
            User uzytkownik = new User();
            Task zadanie = new Task();

            if (baza.polaczenie(connectionString)){
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                try
                {
                    // tutej funkcje ;) 
                }
                catch (Exception e) { Console.WriteLine(" wololo {0}", e); }
                finally
                {
                    conn.Close();
                }
            }

            Console.ReadKey();

        }
    }
}
