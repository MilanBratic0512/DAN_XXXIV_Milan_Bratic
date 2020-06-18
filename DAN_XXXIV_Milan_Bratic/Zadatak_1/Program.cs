using System;
using System.Threading;

namespace Zadatak_1
{
    class Program
    {
        static int bank = 10000;
        static Random rnd = new Random();
        static readonly object locker = new object();

        /// <summary>
        /// method for raise money from the bank
        /// </summary>
        /// <param name="name">client name</param>
        static void ATM(string name)
        {
            lock (locker)
            {
                Console.WriteLine("------------------------------------------");
                //random generated money
                int money = rnd.Next(100, 10000);
                Console.WriteLine("The {0} client are trying raise {1} dinars", name, money);
                
                if (bank < money)
                {
                    Console.WriteLine("Sorry {0} there's no money in the bank", name);
                    return;
                }
                bank -= money;
                if (bank < 0)
                {
                    return;
                }
                Console.WriteLine("Successfully raised money");
                Console.WriteLine("{0} dinars left in the bank", bank);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("How many people want to withdraw money from ATM one");
            //validation
            string input = null;
            uint atmOne = 0;
            do
            {
                input = Console.ReadLine();
                if (!uint.TryParse(input, out atmOne))
                {
                    Console.WriteLine("Wrong input!");
                }
            } while (!uint.TryParse(input, out atmOne));
            Console.WriteLine("How many people want to withdraw money from ATM two");
            //validation
            string input2 = null;
            uint atmTwo = 0;
            do
            {
                input2 = Console.ReadLine();
                if (!uint.TryParse(input2, out atmTwo))
                {
                    Console.WriteLine("Wrong input!");
                }
            } while (!uint.TryParse(input2, out atmTwo));
            //array of threads, represent total number of client
            Thread[] clients = new Thread[atmOne + atmTwo];
            for (int i = 0; i < clients.Length; i++)
            {
                //generated client name
                string name = "client " + i + 1;
                //created thread
                clients[i] = new Thread(() => ATM(name));
                //start thread
                clients[i].Start();
            }
            Console.ReadLine();
        }

        
    }
}