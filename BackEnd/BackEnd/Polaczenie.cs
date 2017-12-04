﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BackEnd
{
    class Polaczenie
    {
        private string connectionString;

        public string getSetConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        public bool polaczenie(string connectionString)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("\n \n blad polaczenia {0}" + e);
                return false;
            }
        }

        // INSERTY

        public void insertUzytkownika(MySqlConnection conn, User uzytkownik)
        {
            MySqlCommand command1 = new MySqlCommand("INSERT INTO users(name, mail, password) VALUES(@name, @mail, @password)", conn);
            command1.Parameters.AddWithValue("@name", uzytkownik.getSetName);
            command1.Parameters.AddWithValue("@mail", uzytkownik.getSetMail);
            command1.Parameters.AddWithValue("@password", uzytkownik.getSetPassword);
            command1.ExecuteNonQuery();
        }
        public void insertZadania(MySqlConnection conn, Task zadanie) { 

            MySqlCommand command1 = new MySqlCommand("INSERT INTO tasks(author_id, name, description) VALUES(@user_id, @name, @description)", conn);
            command1.Parameters.AddWithValue("@user_id",zadanie.getSetAuthorId);
            command1.Parameters.AddWithValue("@name",zadanie.getSetName);
		    command1.Parameters.AddWithValue("@description",zadanie.getSetDescription);
            command1.ExecuteNonQuery();
        }
        public void insertKatgorie(MySqlConnection conn, Category kategoria)
        {
            MySqlCommand command1 = new MySqlCommand("INSERT INTO categories(name) VALUES(@name)", conn);
            command1.Parameters.AddWithValue("@name", kategoria.getSetName);
            command1.ExecuteNonQuery();
        }
        public void insertZadaniaKategori(MySqlConnection conn, Category kategoria, Task zadanie) { 

            MySqlCommand command1 = new MySqlCommand("INSERT INTO tasks_categories VALUES(@tid,@cid)", conn); 
            command1.Parameters.AddWithValue("@tid",zadanie.getSetId);
		    command1.Parameters.AddWithValue("@tid",kategoria.getSetId);
            command1.ExecuteNonQuery();
        }
        public void insertKategoriUzytkownika(MySqlConnection conn, Category kategoria, User uzytkownik)
        {
            MySqlCommand command1 = new MySqlCommand("INSERT INTO category_user VALUES(@uid,@cid)", conn);
            command1.Parameters.AddWithValue("@uid", uzytkownik.getSetId);
            command1.Parameters.AddWithValue("@cid", kategoria.getSetId);
            command1.ExecuteNonQuery();
        }

        // UPDATY
        public void updateZadania(MySqlConnection conn, Task zadanie)
        {
            MySqlCommand command1 = new MySqlCommand("update tasks set state=@state)", conn);
            command1.Parameters.AddWithValue("@state", zadanie.getSetState);
            command1.ExecuteNonQuery();
        }
        // SELECT
        public void selectAllUser(MySqlConnection conn)
        {
            using (MySqlCommand cmd = new MySqlCommand("select * from users" , conn))
            {
                MySqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    ArrayList name = new ArrayList();
                    while (rdr.Read())
                    {
                        try
                        {
                            name.Add(rdr["name"]);
                            name.Add(rdr["mail"]);
                            name.Add(rdr["password"]);
                        }
                        catch (Exception) { Console.WriteLine("Wynik zapytania popsuty, trzeba cos"); }
                    }
                    for (int i = 0; i < name.Count; i++)
                        Console.WriteLine("{0}", name[i]);
                }
                rdr.Close();
            }
        }
    }
}