using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStackUnitTesting
{
    public class Program
    {
        public static void reverseStack(ref Stack<int> st, ref Stack<int> st1)
        {
            if (st.Count > 0)
            {
                int a = st.Pop();
                st1.Push(a);
                reverseStack(ref st, ref st1);
                
            }
        }

       static public void Main()
        {
            //Code
            Stack<int> st = new Stack<int>();
            Stack<int> st1 = new Stack<int>();

            String text = Console.ReadLine();
            String[] bits = text.Split(' ');
            int i = 0;
            while (i < bits.Length && bits[i] != null)
            {
                st.Push(int.Parse(bits[i]));
                i++;
            }
            reverseStack(ref st, ref st1);
            while (st1.Count > 0)
                Console.Write(st1.Pop() + " ");

        }
    }
}
