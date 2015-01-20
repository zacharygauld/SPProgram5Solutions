using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextStatsLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            // call TextStats() with a string
            TextStats("I'm Commander Shepard and this is my favorite store on the Citadel.");
            // prevent console window from closing immediately
            Console.ReadKey();
        }

        static void TextStats (string input)
        {
            // output the input back tot he user
            Console.WriteLine(input);
            // print out the number of characters
            Console.WriteLine("Number of characters: {0}", input.Sum(x => x.ToString().Length));
            // print out the number of words
            Console.WriteLine("Number of words: {0}", input.Split().Length);
            // print out the number of vowels
            Console.WriteLine("Number of vowels: {0}", input.Count(x => "aeiou".Contains(x.ToString().ToLower())));
            // print out the number of consonants
            Console.WriteLine("Number of consonants: {0}", input.Count(x => "bcdfghjklmnpqrstvwxyz".Contains(x.ToString().ToLower())));
            // print out the number of special characters
            Console.WriteLine("Number of special characters: {0}", input.Count(x => !"qwertyuiopasdfghjklzxcvbnm".Contains(x.ToString().ToLower())));
            // print out the longest word
            Console.WriteLine("Longest word: {0}", input.Split().OrderByDescending(x => x.Length).First());
            // print out the shortest word
            Console.WriteLine("Shortest word: {0}", input.Split().OrderBy(x => x.Length).First());
        }
    }
}
