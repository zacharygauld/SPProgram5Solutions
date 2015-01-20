using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            // call DigitalRoot() twice
            Console.WriteLine(DigitalRoot("31337"));
            Console.WriteLine();
            Console.WriteLine(DigitalRoot("45734"));

            Console.ReadKey();
        }

        /// <summary>
        /// Figures out the digital root of a number
        /// </summary>
        /// <param name="rootThis">Number to find digital root of</param>
        /// <returns>Returns the digital root</returns>
        static int DigitalRoot (string rootThis)
        {
            // keep track of the total, the current number, and the next number
            int total = 0;
            int firstNumber = 0;
            int nextNumber = 0;

            // output the number that we're trying to find the digital root of
            Console.WriteLine(rootThis);

            // loop while the total is more than 9; the loop will always execute at least once
            do
            {
                // reset the total every loop around
                total = 0;
                // loop to go through each number in the string and adds them up
                for (int i = 0; i < rootThis.Length; i++)
                {
                    // if i is 0, make firstNumber whatever is held in rootThis[0]
                    if (i == 0)
                    {
                        firstNumber = int.Parse(rootThis[i].ToString());
                        // add firstNumber to the total
                        total += firstNumber;
                    }
                    // check to see if there's a next index
                    if (i + 1 < rootThis.Length)
                        // if there is another index, make nextNumber equal to the content of the next index
                        nextNumber = int.Parse(rootThis[i + 1].ToString());
                    else
                        // there isn't another index, so the next number will be 0
                        nextNumber = 0;
                    // add nextNumber to the total
                    total +=  nextNumber;
                }
                // make rootThis equal the total
                // the do-while loop will execute again if the total is more than 9
                rootThis = total.ToString();
            }
            while (total > 9);

            // return the total
            return total;
        }

        static int DigitalRootWithRecursion(string rootThis)
        {
            if (int.Parse(rootThis) < 10)
                return int.Parse(rootThis);
            else
            {
                return DigitalRootWithRecursion(rootThis.Sum(x => int.Parse(x.ToString())).ToString());
            }
        }
    }
}
