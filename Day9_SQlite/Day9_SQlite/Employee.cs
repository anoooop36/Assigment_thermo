using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9_SQlite
{
    class Employee
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }

        void InsertInDB() {
            Console.Write("Insert User\nEnter total no of users to be inserted: ");
            int n = int.Parse(Console.ReadLine());
            int i = 1;
            while (n > 0)
            {
                Console.WriteLine("\n\nEnter details of Employee " + i++ + "\n");
                Console.Write("User Name: ");
                string uname = Console.ReadLine();
                Console.Write("email: ");
                string email = Console.ReadLine();
                Console.Write("Password: ");
                string pass = Console.ReadLine();
                var emp = new Employee
                {
                    Username = uname,
                    Email = email,
                    Password = pass
                };

                if (!DbAction.ExistsInDb(emp))
                {
                    DbAction.SaveNewEmp(emp);
                }
                n--;
            }
        }

        void deleteOnUserName(Employee emp) {
            Console.Write("\nGive employee username to be deleted: ");
            string str = Console.ReadLine();
            emp.Username = str;
            if (DbAction.DeleteOnUname(emp)) {
                Console.WriteLine("Deleted Successfully !");
            }
            else
            {
                Console.WriteLine("Username not found !");
            }
        }

        void updateEmpInfoOnUname(Employee emp) {
            Console.Write("\nGive employee Username whoes info to be updated: ");
            string uname = Console.ReadLine();
            emp.Username = uname;
            Console.Write("Give new email: ");
            string email = Console.ReadLine();
            emp.Email = email;
            Console.Write("Give new Password: ");
            emp.Password = Console.ReadLine();
            if (DbAction.UpdateEmpInfoOnUname(emp))
            {
                Console.WriteLine("Updated Successfully !");
            }
            else
            {
                Console.WriteLine("Updation failed !");
            }
        }

        public static void Main() {
            DbAction.CreateAndOpenDb();
            DbAction.SeedDatabase();
            Employee emp = new Employee();
            //emp.InsertInDB();
            //emp.deleteOnUserName(emp);
            //emp.updateEmpInfoOnUname(emp);
            while (true)
            {
                Console.WriteLine("\n\nEnter number corresponding to operation you want to perform\n1)Insertion\n2)Deletion\n3)Updation\n4)Show Details");
                int i = int.Parse(Console.ReadLine());
                switch (i)
                {
                    case 1: emp.InsertInDB();
                        break;
                    case 2: emp.deleteOnUserName(emp);
                        break;
                    case 3: emp.updateEmpInfoOnUname(emp);
                        break;
                    case 4:
                        DbAction.Display();
                        break;
                    default:
                        break;
                }
            }

            Console.ReadKey();
        }

    }

}


