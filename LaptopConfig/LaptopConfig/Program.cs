using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopConfig
{
  
    class User
    {
        public static void Main()
        {
            // maintaing list of items
            Console.WriteLine("Enter each component details :\n1)Processor");
            Console.Write("  Enter total no of processors are: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Processor[] processorArray = new Processor[n];

            while (n > 0)
            {
                Processor pro = new Processor();
                Console.WriteLine("Enter details of processor" + n);
                Console.Write("Clock speed: ");
                pro.ClockSpeed = Convert.ToDouble(Console.ReadLine());
                Console.Write("Price: ");
                pro.Price = Convert.ToInt32(Console.ReadLine());
                Console.Write("Brand: ");
                pro.Brand = Console.ReadLine();
                Console.Write("Rating: ");
                pro.Rating = Convert.ToInt32(Console.ReadLine());
                Console.Write("System Type: ");
                pro.SystemType = Convert.ToInt32(Console.ReadLine());
                processorArray[n - 1] = pro;
                n--;
            }

            Console.Write("\n\n2)Ram\nEnter total no of RAMs are: ");
            n = Convert.ToInt32(Console.ReadLine());
            Ram[] ramArray = new Ram[n];

            while (n > 0)
            {
                Ram pro = new Ram();
                Console.WriteLine("Enter details of Ram" + n);
                Console.Write("Ram Size: ");
                pro.Size = Convert.ToInt32(Console.ReadLine());
                Console.Write("Price: ");
                pro.Price = Convert.ToInt32(Console.ReadLine());
                Console.Write("Brand: ");
                pro.Brand = Console.ReadLine();
                Console.Write("Rating: ");
                pro.Rating = Convert.ToInt32(Console.ReadLine());
                ramArray[n - 1] = pro;
                n--;
            }

            Console.Write("\n\n3)Memory\nEnter total no of Memorys are: ");
            n = Convert.ToInt32(Console.ReadLine());
            Memory[] memoryArray = new Memory[n];

            while (n > 0)
            {
                Memory pro = new Memory();
                Console.WriteLine("Enter details of Memory" + n);
                Console.Write("Memory Size: ");
                pro.Size = Convert.ToInt32(Console.ReadLine());
                Console.Write("Price: ");
                pro.Price = Convert.ToInt32(Console.ReadLine());
                Console.Write("Brand: ");
                pro.Brand = Console.ReadLine();
                Console.Write("Rating: ");
                pro.Rating = Convert.ToInt32(Console.ReadLine());
                memoryArray[n - 1] = pro;
                n--;
            }

            Console.Write("\n\n4)Screen\nEnter total no of Screens are: ");
            n = Convert.ToInt32(Console.ReadLine());
            Screen[] screenArray = new Screen[n];

            while (n > 0)
            {
                Screen pro = new Screen();
                Console.WriteLine("Enter details of Screen" + n);
                Console.Write("Screen Type: ");
                pro.TypeOfScreen = Console.ReadLine();
                Console.Write("Price: ");
                pro.Price = Convert.ToInt32(Console.ReadLine());
                Console.Write("Brand: ");
                pro.Brand = Console.ReadLine();
                Console.Write("Rating: ");
                pro.Rating = Convert.ToInt32(Console.ReadLine());
                screenArray[n - 1] = pro;
                n--;
            }



            int budget;

            Console.WriteLine("\n\nTaking input from user\n1)Enter your Budget");
            budget = Convert.ToInt32(Console.ReadLine());

            //// Search for best configuration
            Array.Sort(processorArray, delegate (Processor x, Processor y) { return x.ClockSpeed.CompareTo(y.ClockSpeed); });
            Array.Reverse(processorArray);
            Array.Sort(ramArray, delegate (Ram x, Ram y) { return x.Size.CompareTo(y.Size); });
            Array.Reverse(ramArray);
            Array.Sort(memoryArray, delegate (Memory x, Memory y) { return x.Size.CompareTo(y.Size); });
            Array.Reverse(memoryArray);
            Array.Sort(screenArray, delegate (Screen x, Screen y) { return x.Rating.CompareTo(y.Rating); });
            Array.Reverse(screenArray);
            

            //Results
            Console.WriteLine("\n\nResults:");
            int flag = 0;
            foreach (Processor storedProcessor in processorArray)
            {
                foreach (Ram storedRam in ramArray)
                {
                    foreach (Memory storedMemory in memoryArray)
                    {
                        foreach (Screen storedScreen in screenArray)
                        {
                            if (storedProcessor.Price + storedMemory.Price + storedRam.Price + storedScreen.Price <= budget) {
                                Console.WriteLine("1)Processor : Price " + storedProcessor.Price + ", Brand: " + storedProcessor.Brand + ", Clock Speed: " + storedProcessor.ClockSpeed);
                                Console.WriteLine("2) Ram : Price " + storedRam.Price + ", Brand: " + storedRam.Brand + ", Size: " + storedRam.Size);
                                Console.WriteLine("3) Memory : Price " + storedMemory.Price + ", Brand: " + storedMemory.Brand + ", Size: " + storedMemory.Size);
                                Console.WriteLine("4) Screen : Price " + storedScreen.Price + ", Brand: " + storedScreen.Brand + ", Screen type: " + storedScreen.TypeOfScreen);
                                flag = 1;
                                break;
                            }
                        }
                        if (flag == 1)
                            break;


                    }
                    if (flag == 1)
                        break;

                }
                if (flag == 1)
                    break;
                
                
            }
            
            if(flag==0)
                Console.WriteLine("No configuration found! please increase budget");

            Console.ReadKey();
        }
    }

}
