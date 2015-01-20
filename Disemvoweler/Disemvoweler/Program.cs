using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disemvoweler
{
    class Program
    {
        static void Main(string[] args)
        {
            // call the Disemvoweler function multiple times with different parameters for each
            Disemvoweler("Nickleback is my favorite band. Their songwriting can't be beat!");
            Disemvoweler("How many bears could bear grylls grill if bear grylls could grill bears?");
            Disemvoweler("I'm a code ninja, baby. I make the functions and I make the calls.");

            // prevent the console from closing right away
            Console.ReadKey();
        }

        /// <summary>
        /// "Disemvowel" strings and print out the result of the disemvowled sentence as well as print out the vowels removed, in order
        /// </summary>
        /// <param name="input">String to "disemvowel"</param>
        static void Disemvoweler (string input)
        {
            // create two StringBuilders to hold the new disemvoweledString and vowelsOnly
            StringBuilder disemvoweledString = new StringBuilder();
            StringBuilder vowelsOnly = new StringBuilder();
            
            // loop through each character in the input string
            foreach (char letter in input.ToUpper())
            {
                // if the current letter being checked contains a vowel, add the letter to vowelsOnly
                if ("AEIOU".Contains(letter.ToString()))
                {
                    vowelsOnly.Append(letter);
                }
                    // if the current letter being checked contains a consonant, add the letter to disemvoweledString
                else if ("BCDFGHJKLMNPQRSTVWXYZ".Contains(letter.ToString()))
                {
                    disemvoweledString.Append(letter);
                }
            }
            // output the original string, the new disemvoweled string, and a string with the vowels that were removed in order
            Console.WriteLine("Original: {0}", input.ToUpper());
            Console.WriteLine("Disemvoweled: {0}", disemvoweledString);
            Console.WriteLine("Removed vowels: {0}\n", vowelsOnly);
        }
    }
}
