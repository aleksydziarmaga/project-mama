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

            string REST="3";
            baza.getSetConnectionString = connectionString;
            if (baza.polaczenie()){
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                switch (REST)
                {
                    case ("3"):
                        {
                            break;
                        }
                    default: { break; }
                }
                
                try
                {
                    Console.WriteLine("ALL USERS ======ALL USERS======== ALL USERS");
                    baza.selectAllUser(conn, uzytkownik);
                    Console.WriteLine("ALL CATEGORY===========ALL CATEGORY===============ALL CATEGORY");
                    baza.selectAllCategory(conn);
                    Console.WriteLine("AllTasks==========AllTasks================AllTasks");
                    baza.selectAllTasks(conn);
                    Console.WriteLine("AllTaskCategories=============AllTaskCategories==========AllTaskCategories");
                    baza.selectAllTaskCategories(conn);
                    Console.WriteLine("AllUsersCategories========AllUsersCategories=============AllUsersCategories");
                    baza.selectAllUsersCategories(conn);
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
