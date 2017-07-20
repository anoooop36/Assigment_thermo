using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader myReader = new StreamReader("Values.txt");
            string myString = "";
            while (myString != null) {
                myString = myReader.ReadLine();
                if (myString!=null) {
                    Console.WriteLine(myString);
                }
            }
            myReader.Close();
            Console.ReadKey();
        }
    }
}
