using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = string.Empty;
            int result = 0;
            // declare a funtime list
            List<string> funtimeList = new List<string>() { "blueberry", "apple", "boisonberry", "pear", "strawberry" };

            // print out each ite in the funtime list ordered alphabetically
            Console.WriteLine(string.Join(", ", funtimeList.OrderBy(x => x)));
            Console.WriteLine();

            // write to the console only the items containing the word berry
            Console.WriteLine(string.Join(", ", funtimeList.Where(x => x.Contains("berry"))));

            // write all the non-berry items ordered by the length of the string
            Console.WriteLine(string.Join(", ", funtimeList.Where(x => !x.Contains("berry")).OrderBy(x => x.Length)));

            // write only the items that have 5 or more characters
            Console.WriteLine(string.Join(", ", funtimeList.Where(x => x.Length >= 5)));

            // write the total number of characters in the funtimeList to the console
            Console.WriteLine("Total number of chars: {0}", funtimeList.Sum(x => x.Length));

            // write the average number of characters in the funtimeList to the console
            Console.WriteLine("Average number of chars: {0}", funtimeList.Average(x => x.Length));

            // write to the console the number of vowels in each item in the funtimeList
            Console.WriteLine(string.Join("\n", funtimeList.Select(x => x + " has " + x.Count(y => "aeiou".Contains(y.ToString().ToLower())) + " vowels.")));

            // write to the console the number of characters in each item in the funtimeList
            foreach (string s in funtimeList)
            {
                Console.WriteLine("{0} has {1} characters in it.", s, s.Length);
            }

            // write to the console the number of vowels in each item in the funtimeList
            foreach (string s in funtimeList)
            {
                int numVowels = 0;
                foreach (char c in s)
                {
                    if ("aeiou".Contains(c.ToString()))
                        numVowels++;
                }
                Console.WriteLine("{0} contains {1} vowels.", s, numVowels);
            }
            

            while (true)
            {
                test = Console.ReadLine();
                if (!int.TryParse(test, out result))
                    Console.WriteLine("Not a valid input!");
                else
                {
                    Console.WriteLine(result);
                    break;
                }
            }

            // vowel counter by itself
            string countMyVowels = "This is a test string";
            int numberOfVowels = countMyVowels.Count(x => "aeiou".Contains(x.ToString().ToLower()));
            Console.WriteLine("{0} has {1} vowel(s) in it.", countMyVowels, numberOfVowels);

            Console.ReadKey();
        }
    }
}
