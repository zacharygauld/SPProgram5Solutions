using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TextPrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            TextPrinter(100, "Hello world");         
            Console.ReadKey();
        }

        static void TextPrinter (int interval, string input)
        {
            foreach (char character in input)
            {
                Console.Write(character);
                Thread.Sleep(interval);                
            }
        }
    }
}
