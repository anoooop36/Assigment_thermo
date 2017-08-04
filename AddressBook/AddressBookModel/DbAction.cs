using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model
{
    public static class DbAction
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


            //Create user table
            conn.ExecuteNonQuery(@"
                CREATE TABLE IF NOT EXISTS [AddressBookModel] (
                    [EmployeeId] INTEGER PRIMARY KEY AUTOINCREMENT,
                    [Name] NVARCHAR(128) NOT NULL,
                    [Address] NVARCHAR(128) NOT NULL,
                    [PhoneNo] NVARCHAR(128) NOT NULL,
                    [ImagePath] NVARCHAR(128)
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
            try
            {
                connection.Execute(commandText, emp);
            }
            catch (Exception)
            {

                Console.WriteLine("Employee id already exists");
            }
        }



        public static void SaveNewEmp(this AddressBookModel emp)
        {
            conn.ExecuteNonQuery(@"
            INSERT INTO AddressBookModel (EmployeeId, Name, Address, PhoneNo, ImagePath)
            VALUES (@EmployeeId, @Name, @Address, @PhoneNo, @ImagePath)", emp);
           
        }

        public static bool ExistsInDb(this AddressBookModel emp)
        {
            var rows = conn.Query(string.Format(
                "SELECT COUNT(1) as 'Count' FROM AddressBookModel WHERE EmployeeId = '{0}'",
                emp.EmployeeId));

            return (int)rows.First().Count > 0;
        }

        public static bool DeleteOnId(this AddressBookModel emp)
        {
            if (ExistsInDb(emp))
            {
                var count = conn.Query(string.Format("DELETE FROM AddressBookModel WHERE EmployeeId = '{0}'", emp.EmployeeId));
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


        //public static bool UpdateEmpInfoOnUname(this Employee emp)
        //{
        //    if (ExistsInDb(emp))
        //    {
        //        var count = conn.Query(string.Format("UPDATE Employee SET Email = '{1}', Password = '{2}' WHERE Username = '{0}'", emp.Username, emp.Email, emp.Password));
        //        if (count != null)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //    public static void Display()
        //    {

        //        using (SQLiteConnection connect = new SQLiteConnection(@"Data Source= ./EmpTable.sqlite"))
        //        {
        //            connect.Open();
        //            using (SQLiteCommand fmd = connect.CreateCommand())
        //            {
        //                fmd.CommandText = @"SELECT * FROM Employee";
        //                SQLiteDataReader r = fmd.ExecuteReader();
        //                String str = String.Format("\n{0,-15} {1,-20} {2,20}\n", "Username", "Email", "Password");
        //                Console.WriteLine(str);
        //                while (r.Read())
        //                {
        //                    string uname = (string)r["Username"];
        //                    string email = (string)r["Email"];
        //                    string pass = (string)r["Password"];
        //                    String s = String.Format("{0,-15} {1,-20} {2,20}", uname, email, pass);
        //                    Console.WriteLine(s);
        //                }

        //                connect.Close();

        //            }

        //            //List<Employee> res = connect.Query<List<Employee>>(
        //            //    @"SELECT *
        //            //    FROM Employee");
        //            //foreach (Employee result in res)
        //            //{
        //            //    String s = String.Format("{0,-15} {1,-20} {2,20}", result.Username, result.Email, result.Password);
        //            //    Console.WriteLine(s);
        //            //}
        //        }

        //    }

        public static List<AddressBookModel> GetAllEmployee()
        {
            List<AddressBookModel> models= new List < AddressBookModel >();

            using (var db = new SQLiteConnection(@"Data Source= ./EmpTable.sqlite"))
            {
                models = db.Query<AddressBookModel>(
                                @"SELECT *
                                FROM AddressBookModel").DefaultIfEmpty().ToList();

            }

            return models;
        }
    }
}
