using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 30; i++)
            {
                FizzBuzz(i);
            }

            Console.ReadKey();
        }

        static void FizzBuzz (int x)
        {
            if (x % 3 == 0 && x % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (x % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (x % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
                Console.WriteLine(x);
        }
    }
}
