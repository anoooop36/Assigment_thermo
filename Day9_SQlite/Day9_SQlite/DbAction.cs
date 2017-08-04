using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9_SQlite
{
    static class DbAction
    {
        private static SQLiteConnection conn;

        public static void CreateAndOpenDb()
        {
            var dbFilePath = "./EmpTable.sqlite";

            if (!File.Exists(dbFilePath))
            {
                SQLiteConnection.CreateFile(dbFilePath);
            }

            conn = new SQLiteConnection(string.Format(
                "Data Source={0};Version=3;", dbFilePath));
            conn.Open();
        }

        public static void SeedDatabase()
        {
            // Create user table
            conn.ExecuteNonQuery(@"
                CREATE TABLE IF NOT EXISTS [Employee] (
                    [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    [Username] NVARCHAR(128) NOT NULL,
                    [Email] NVARCHAR(128) NOT NULL,
                    [Password] NVARCHAR(128) NOT NULL,
                    [DateCreated] TIMESTAMP DEFAULT CURRENT_TIMESTAMP
            )");
        }


        public static void ExecuteNonQuery(this SQLiteConnection connection, string commandText, object emp = null)
        {
            if (connection == null)
            {
                throw new NullReferenceException("Please provide a connection");
            }

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            connection.Execute(commandText, emp);
        }



        public static void SaveNewEmp(this Employee emp)
        {
            conn.ExecuteNonQuery(@"
            INSERT INTO Employee (Username, Email, Password)
            VALUES (@Username, @Email, @Password)", emp);
        }

        public static bool ExistsInDb(this Employee emp)
        {
            var rows = conn.Query(string.Format(
                "SELECT COUNT(1) as 'Count' FROM Employee WHERE Username = '{0}'",
                emp.Username));

            return (int)rows.First().Count > 0;
        }

        public static bool DeleteOnUname(this Employee emp)
        {
            if (ExistsInDb(emp))
            {
                var count = conn.Query(string.Format("DELETE FROM Employee WHERE Username = '{0}'", emp.Username));
                if (count != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public static bool UpdateEmpInfoOnUname(this Employee emp)
        {
            if (ExistsInDb(emp))
            {
                var count = conn.Query(string.Format("UPDATE Employee SET Email = '{1}', Password = '{2}' WHERE Username = '{0}'", emp.Username, emp.Email, emp.Password));
                if (count != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static void Display()
        {

            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source= ./EmpTable.sqlite"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT * FROM Employee";
                    SQLiteDataReader r = fmd.ExecuteReader();
                    String str = String.Format("\n{0,-15} {1,-20} {2,20}\n", "Username", "Email", "Password");
                    Console.WriteLine(str);
                    while (r.Read())
                    {
                        string uname = (string)r["Username"];
                        string email = (string)r["Email"];
                        string pass = (string)r["Password"];
                        String s = String.Format("{0,-15} {1,-20} {2,20}", uname, email, pass);
                        Console.WriteLine(s);
                    }

                    connect.Close();

                }

                //List<Employee> res = connect.Query<List<Employee>>(
                //    @"SELECT *
                //    FROM Employee");
                //foreach (Employee result in res)
                //{
                //    String s = String.Format("{0,-15} {1,-20} {2,20}", result.Username, result.Email, result.Password);
                //    Console.WriteLine(s);
                //}
            }

        }


    }
}