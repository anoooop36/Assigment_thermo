using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace UnitTestingSample
{
    class Program
    {

        static int add(int a, int b) {
            return a + b;
        }

        static int multiply(int c, int d) {
            return c * d;
        }

        static int sustract(int e, int f) {
            return e - f;
        }

        static float division(int a, int v) {
            Debug.Assert(v != 0, "Divisor can't be 0 !");
            return a / v;
        }

        static void Main(string[] args)
        {
            int a = 3, b = 3, c = 4, d = 5, e = 6, f = 1;
            
            int total = add(a,b);
            Debug.Assert(total == 5, "Not Added Correctly!");

            Debug.Assert(multiply(c, d) == 20, "Not multiplied correctly!");
            Debug.Assert(sustract(e, f) == 5, "Nod substracted correctly!");
            division(a,0);
            Console.ReadKey();
        }
    }
}
