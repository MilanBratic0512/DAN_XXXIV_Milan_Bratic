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
            int atmOne = int.Parse(Console.ReadLine());
            Console.WriteLine("How many people want to withdraw money from ATM two");
            int atmTwo = int.Parse(Console.ReadLine());

            Thread[] clients = new Thread[atmOne + atmTwo];
            for (int i = 0; i < clients.Length; i++)
            {
                string name = "client " + i + 1;
                clients[i] = new Thread(() => ATM(name));
                clients[i].Start();
            }
            Console.ReadLine();
        }
    }
}