using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            // FizzBuzz
            Console.WriteLine("FizzBuzz!");
            // loop from 0 to 20, passing on each number to FizzBuzz()
            for (int i = 0; i <= 20; i++)
                FizzBuzz(i);

            // add a line break just to keep things clean
            Console.WriteLine();

            // LetterCounter
            Console.WriteLine("LetterCounter!");
            LetterCounter('i', "I love biscuits and gravy. It's the best breakfast ever.");
            LetterCounter('n', "Never gonna give you up. Never gonna let you down.");
            LetterCounter('s', "Sally sells seashells down by the seashore. She's from Sussex.");

            // prevent console window from closing right away
            Console.ReadKey();
        }

        /// <summary>
        /// Checks to see if number is divisible by eiter 3 or 5
        /// </summary>
        /// <param name="number">Number to check divisibility</param>
        static void FizzBuzz (int number)
        {
            if (number % 5 == 0 && number % 3 == 0)
                Console.WriteLine("FizzBuzz");
            else if (number % 5 == 0)
                Console.WriteLine("Fizz");
            else if (number % 3 == 0)
                Console.WriteLine("Buzz");
            else
                Console.WriteLine(number);
        }

        /// <summary>
        /// Counts the number of letters in a string
        /// </summary>
        /// <param name="letter">Letter to check</param>
        /// <param name="inString">String to check the letter in</param>
        static void LetterCounter (char letter, string inString)
        {
            // create variables to keep track of the stats we want to check
            int upperCase = 0;
            int lowerCase = 0;
            int letters = 0;
            // loop through each character in the string
            foreach (char c in inString)
            {
                // if the current character is an uppercase letter, increment upperCase
                if (c.ToString() == letter.ToString().ToUpper())
                    upperCase++;
                    // if the current character is a lowercase letter, increment lowerCase
                else if (c.ToString() == letter.ToString().ToLower())
                    lowerCase++;

                // increment letters if the current character is the letter we want
                if (c.ToString() == letter.ToString().ToUpper() || c.ToString() == letter.ToString().ToLower())
                    letters++;
            }

            // output stats
            Console.WriteLine("Input: {0}", inString);
            Console.WriteLine("Number of lowercase {0}s found: {1}", letter.ToString().ToUpper(), lowerCase);
            Console.WriteLine("Number of UPPERCASE {0}s found: {1}", letter.ToString().ToUpper(), upperCase);
            Console.WriteLine("Total number of {0}s found: {1}\n", letter.ToString().ToUpper(), letters);
        }
    }
}
