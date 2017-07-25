using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace ConsoleApp3
{
    
    class Program
    {
        static void insertion(IMongoCollection<Person> collection) {
            string fName, lName;
            Console.Write("Give First Name: ");
            fName = Console.ReadLine();
            Console.Write("Give Last Name: ");
            lName = Console.ReadLine();
            Console.Write("Enter age: ");
            int age = Int32.Parse(Console.ReadLine());

            Person p = new Person
            {
                Id = ObjectId.GenerateNewId(),
                FirstName = fName,
                LastName = lName,
                Age = age
            };

            collection.InsertOne(p);

        }



        static void updation(IMongoCollection<Person> collection) {
            Console.Write("Enter Name of employee to be updated: ");
            string name = Console.ReadLine();
            Console.Write("Enter new Last name: ");
            string lName = Console.ReadLine();
            Console.Write("Enter new Age: ");
            int age = Int32.Parse(Console.ReadLine());
            var filter = Builders<Person>.Filter.Eq(s => s.FirstName, name);
            var update = Builders<Person>.Update.Set(s => s.LastName, lName).Set(s=>s.Age,age);
            var result = collection.UpdateOne(filter, update);

            //var query = Query.EQ("FirstName", name);
            //var filter = Filt
            //var update = Update.Set("LastName", lName).Set("Age",age);  
            //collection.UpdateOne();
        }

        static void deletion(IMongoCollection<Person> collection) {
            Console.Write("Enter Name of employee to be deleted: ");
            string name = Console.ReadLine();
            //var query2 = Query.EQ("FirstName", name);
            var filter = Builders<Person>.Filter.Eq(s => s.FirstName, name);
            collection.DeleteMany(filter);

        }

        static void showDb(IMongoCollection<Person> collection) {
            
            var list = collection.Find(_ => true).ToList();
            string str = string.Format("{0,-15 } {1,-5}","Name","Age");
            Console.WriteLine("\n"+str+"\n");
            foreach(Person p in list){
                string str1 = string.Format("{0,-15 } {1,-5}", p.FirstName + " " + p.LastName, p.Age);
                Console.WriteLine(str1);
            }
        }



        static void Main(string[] args)
        {
          MongoClient client = new MongoClient("mongodb://127.0.0.1:27017");
            var db = client.GetDatabase("MyDatabase");
            var collection = db.GetCollection<Person>("employees");

            while (true)
            {
                Console.WriteLine("\n\nEnter number corresponding to choices\n1)Insertion\n2)Updation\n3)Deletion\n4)Show DB\n");
                int choice=Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: insertion(collection);
                        break;
                    case 2: updation(collection);
                        break;
                    case 3: deletion(collection);
                        break;
                    case 4: showDb(collection);
                        break;
                    default:
                        break;
                }
            }

            Console.ReadKey();

        }
    }
}
