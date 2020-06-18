using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class Program
    {
        static int bank = 10000;

        static void ATMOne()
        {

        }

        static void Main(string[] args)
        {
            Console.WriteLine("How many people want to withdraw money from ATM one");
            int atmOne = int.Parse(Console.ReadLine());
            Console.WriteLine("How many people want to withdraw money from ATM two");
            int atmTwo = int.Parse(Console.ReadLine());

            Thread[] threadsATMOne = new Thread[atmOne];
            Thread[] threadsATMTwo = new Thread[atmTwo];



        }
    }
}