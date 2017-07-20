using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = { 9,15,11,91,63,14};

            int length = array.Length;

            for (int i = 1; i < length; i++) {

                int j = i - 1;
                int temp = array[i];

                while (j>=0 && temp < array[j]) {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = temp;
                Console.Write("iteration {0} : ",i);

                foreach (var x in array)
                {
                    Console.Write("{0}, ", x);
                }

                Console.WriteLine();
            }

            
            Console.ReadKey();
        }
    }
}
