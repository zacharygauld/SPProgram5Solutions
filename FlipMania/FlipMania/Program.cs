using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipMania
{
    class Program
    {
        static void Main(string[] args)
        {
            // call functions
            FlipCoins(10000);
            FlipForHeads(10000);
            // prevent console window from closing immediately
            Console.ReadKey();
        }

        static void FlipCoins (int numberOfFlips)
        {
            // declare counters for number of heads and tails
            int numberOfHeads = 0;
            int numberOfTails = 0;
            // declare new instance of the Random object
            Random rng = new Random();
            int randomNumber = 0;
            // loop that repeats as many times as indicated by numberOfFlips
            for (int i = 0; i < numberOfFlips; i++)
            {
                // flip a coin
                randomNumber = rng.Next(0,2);
                // if heads (0), increment numberOfHeads by 1; if tails (1), increment numberOfTails by 1
                if (randomNumber == 0)
                {
                    numberOfHeads++;
                }
                else
                    numberOfTails++;
            }
            // output number of times coin was flipped, number of heads, number of tails
            Console.WriteLine("We flipped a coin " + numberOfFlips + " times.");
            Console.WriteLine("Number of Heads: " + numberOfHeads);
            Console.WriteLine("Number of Tails: " + numberOfTails);
        }

        static void FlipForHeads (int numberOfHeads)
        {
            // declare counters for number of heads and total flips
            int numberOfHeadsFlipped = 0;
            int totalFlips = 0;
            // declare new instance of the Random object
            Random rng = new Random();
            int randomNumber = 0;
            // loop until numberOfHeadsFlipped equals numberOfHeads argument
            while (numberOfHeadsFlipped < numberOfHeads)
            {
                // flip a coin
                randomNumber = rng.Next(0, 2);
                // increment numberOfHeadsFlipped if the random number is 0
                if (randomNumber == 0)
                {
                    numberOfHeadsFlipped++;
                }
                // increment totalFlips every flip
                totalFlips++;
            }
            // output number of heads wanted and total flips it took to get to that amount of heads
            Console.WriteLine("\nWe are flipping a coin until we find " + numberOfHeads + " heads.");
            Console.WriteLine("It took " + totalFlips + " flips to find " + numberOfHeads + " heads.");
        }
    }
}
