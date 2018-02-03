using System;
using System.Collections;
using MySql.Data.MySqlClient;

namespace ProjectMama
{
    class MySQL_connection
    {
        // public properties
        public bool connected { get; private set; }
        public string connectionString { get; set; }

        // private fields
        private MySqlConnection connection;

        // constructor
        public MySQL_connection(string connectionString)
        {
            this.connectionString = connectionString;
            try
            {
                connection = new MySqlConnection(this.connectionString);
                connection.Open();
                connected = true;
            }
            catch (Exception e)
            {
                connected = false;
                Console.Error.WriteLine("Error connecting to database.");
            }
        }

        // destructor
        ~MySQL_connection ()
        {
            if (connected)
                connection.Close();
        }

        // INSERTY

        public void insertUzytkownika(User uzytkownik)
        {
            MySqlCommand command1 = new MySqlCommand("INSERT INTO users(name, mail, password) VALUES(@name, @mail, @password)", connection);
            command1.Parameters.AddWithValue("@name", uzytkownik.name);
            command1.Parameters.AddWithValue("@mail", uzytkownik.mail);
            command1.Parameters.AddWithValue("@password", uzytkownik.password);
            command1.ExecuteNonQuery();
        }
        public void insertZadania(Task zadanie) { 

            MySqlCommand command1 = new MySqlCommand("INSERT INTO tasks(author_id, name, description) VALUES(@user_id, @name, @description)", connection);
            command1.Parameters.AddWithValue("@user_id",zadanie.author_id);
            command1.Parameters.AddWithValue("@name",zadanie.name);
		    command1.Parameters.AddWithValue("@description",zadanie.description);
            command1.ExecuteNonQuery();
        }
        public void insertKatgorie(Category kategoria)
        {
            MySqlCommand command1 = new MySqlCommand("INSERT INTO categories(name) VALUES(@name)", connection);
            command1.Parameters.AddWithValue("@name", kategoria.name);
            command1.ExecuteNonQuery();
        }
        public void insertZadaniaKategori(Category kategoria, Task zadanie) { 

            MySqlCommand command1 = new MySqlCommand("INSERT INTO tasks_categories VALUES(@tid,@cid)", connection); 
            command1.Parameters.AddWithValue("@tid",zadanie.id);
		    command1.Parameters.AddWithValue("@tid",kategoria.id);
            command1.ExecuteNonQuery();
        }
        public void insertKategoriUzytkownika(Category kategoria, User uzytkownik)
        {
            MySqlCommand command1 = new MySqlCommand("INSERT INTO category_user VALUES(@uid,@cid)", connection);
            command1.Parameters.AddWithValue("@uid", uzytkownik.id);
            command1.Parameters.AddWithValue("@cid", kategoria.id);
            command1.ExecuteNonQuery();
        }

        // UPDATY
        public void updateZadania(Task zadanie)
        {
            MySqlCommand command1 = new MySqlCommand("update tasks set state=@state)", connection);
            command1.Parameters.AddWithValue("@state", zadanie.state);
            command1.ExecuteNonQuery();
        }
        // SELECT
        public void selectAllUser(User uzytkownik)
        {
            using (MySqlCommand cmd = new MySqlCommand("select name, mail, password from users" , connection))
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
        public void selectAllCategory()
        {
            using (MySqlCommand cmd = new MySqlCommand("select name from categories", connection))
            {
                MySqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    ArrayList nameCategory = new ArrayList();
                    while (rdr.Read())
                    {
                        try
                        {
                            nameCategory.Add(rdr["name"]);
                        }
                        catch (Exception) { Console.WriteLine("Wynik zapytania popsuty, trzeba cos"); }
                    }
                    for (int i = 0; i < nameCategory.Count; i++)
                        Console.WriteLine("{0}", nameCategory[i]);
                }
                rdr.Close();
            }
        }
        public void selectAllTasks()
        {
            using (MySqlCommand cmd = new MySqlCommand("select author_id, name, description, state from tasks", connection))
            {
                MySqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    ArrayList nameTasks = new ArrayList();
                    while (rdr.Read())
                    {
                        try
                        {
                            nameTasks.Add(rdr["author_id"]+ "author_id");
                            nameTasks.Add(rdr["name"]);
                            nameTasks.Add(rdr["description"]);
                            nameTasks.Add(rdr["state"]);
                        }
                        catch (Exception) { Console.WriteLine("Wynik zapytania popsuty, trzeba cos"); }
                    }
                    for (int i = 0; i < nameTasks.Count; i++)
                        Console.WriteLine("{0}", nameTasks[i]);
                }
                rdr.Close();
            }
        }
        public void selectAllTaskCategories()
        {
            using (MySqlCommand cmd = new MySqlCommand("select tid, cid from tasks_categories", connection))
            {
                MySqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    ArrayList nameTasksCategories = new ArrayList();
                    while (rdr.Read())
                    {
                        try
                        {
                            nameTasksCategories.Add(rdr["tid"]+ " tid");
                            nameTasksCategories.Add(rdr["cid"]+ " cid");
                        }
                        catch (Exception) { Console.WriteLine("Wynik zapytania popsuty, trzeba cos"); }
                    }
                    for (int i = 0; i < nameTasksCategories.Count; i++)
                        Console.WriteLine("{0}", nameTasksCategories[i]);
                }
                rdr.Close();
            }
        }
        public void selectAllUsersCategories()
        {
            using (MySqlCommand cmd = new MySqlCommand("select uid, cid from users_categories", connection))
            {
                MySqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    ArrayList nameTasksCategories = new ArrayList();
                    while (rdr.Read())
                    {
                        try
                        {
                            nameTasksCategories.Add(rdr["uid"]+ " uid");
                            nameTasksCategories.Add(rdr["cid"] + " cid");
                        }
                        catch (Exception) { Console.WriteLine("Wynik zapytania popsuty, trzeba cos"); }
                    }
                    for (int i = 0; i < nameTasksCategories.Count; i++)
                        Console.WriteLine("{0}", nameTasksCategories[i]);
                }
                rdr.Close();
            }
        }
    }
}
