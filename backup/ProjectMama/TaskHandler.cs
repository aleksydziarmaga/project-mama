using System;
using System.Collections;
using System.Globalization;
using System.Data.SqlTypes;

using MySql.Data.MySqlClient;

using ProjectMama.Models;

namespace ProjectMama
{
    public class TaskHandler : MySqlConnectionHandler
    {
        static string getTasksSQLCMD = "SELECT * FROM tasks;";
        static string getTaskByIdSQLCMD = "SELECT * FROM tasks WHERE id={0};";
        static string saveTaskSQLCMD = "INSERT INTO tasks(author_id,name,description,state) VALUES ({0},'{1}','{2}','{3}');";
        static string updateTaskSQLCMD = "UPDATE tasks SET author_id='{1}',name='{2}',description={3},state='{4}' WHERE id={0};";
        static string deleteTaskByIdSQLCMD = "DELETE FROM tasks WHERE id={0};";

        public ArrayList getTasks()
        {
            MySqlCommand cmd = new MySqlCommand(getTasksSQLCMD, connection);
            MySqlDataReader mySqlDataReader = cmd.ExecuteReader();

            ArrayList result = new ArrayList();

            while (mySqlDataReader.Read())
            {
                Task task = new Task();

                task.id = mySqlDataReader.GetUInt32(0);
                task.author_id = mySqlDataReader.GetUInt32(1);
                task.name = mySqlDataReader.GetString(2);

                try
                {
                    task.description = mySqlDataReader.GetString(3);
                }
                catch (SqlNullValueException e)
                {
                    task.description = "";
                }

                task.state = (Task.State)Enum.Parse(typeof(Task.State), mySqlDataReader.GetString(4));

                result.Add(task);
            }

            return result;
        }

        public Task getTask(uint id)
        {
            MySqlCommand cmd = new MySqlCommand(String.Format(getTaskByIdSQLCMD, id), connection);
            MySqlDataReader mySqlDataReader = cmd.ExecuteReader();

            Task result = null;

            if (mySqlDataReader.Read())
            {
                result = new Task();

                result.id = mySqlDataReader.GetUInt32(0);
                result.author_id = mySqlDataReader.GetUInt32(1);
                result.name = mySqlDataReader.GetString(2);

                try
                {
                    result.description = mySqlDataReader.GetString(3);
                }
                catch (SqlNullValueException e)
                {
                    result.description = "";
                }

                result.state = (Task.State)Enum.Parse(typeof(Task.State), mySqlDataReader.GetString(4));
            }

            return result;
        }

        public uint saveTask(Task task)
        {
            MySqlCommand cmd = new MySqlCommand(
                String.Format(
                    saveTaskSQLCMD,
                    task.author_id,
                    task.name,
                    task.description,//FIXME: make it handle null values
                    task.state
                    ),
                connection
                );

            cmd.ExecuteNonQuery();

            return Convert.ToUInt32(cmd.LastInsertedId);
        }

        public bool updateTask(uint id, Task person)
        {
            MySqlCommand cmd;
            MySqlDataReader mySqlDataReader;

            cmd = new MySqlCommand(String.Format(getTaskByIdSQLCMD, id), connection);
            mySqlDataReader = cmd.ExecuteReader();

            if (mySqlDataReader.Read())
            {
                mySqlDataReader.Close();

                cmd = new MySqlCommand(
                String.Format(
                    updateTaskSQLCMD,
                    id,
                    person.author_id,
                    person.name,
                    person.description,//FIXME: make it handle null values
                    person.state
                    ),
                connection
                );
                cmd.ExecuteNonQuery();

                return true;
            }
            else
                return false;
        }

        public bool deleteTask(uint id)
        {
            MySqlCommand cmd;
            MySqlDataReader mySqlDataReader;

            cmd = new MySqlCommand(String.Format(getTaskByIdSQLCMD, id), connection);
            mySqlDataReader = cmd.ExecuteReader();

            if (mySqlDataReader.Read())
            {
                mySqlDataReader.Close();

                cmd = new MySqlCommand(String.Format(deleteTaskByIdSQLCMD, id), connection);
                cmd.ExecuteNonQuery();

                return true;
            }
            else
                return false;
        }
    }
}