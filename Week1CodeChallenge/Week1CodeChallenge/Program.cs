using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            // FIZZBUZZ
            Console.WriteLine("FIZZBUZZ!");
            Console.WriteLine("(Numbers 0 to 20)");
            // check if the numbers 0 through 20 are prime or not
            for (int i = 0; i <= 20; i++)
            {
                FizzBuzz(i);
            }
            Console.WriteLine("\n(Numbers 92 to 79)");
            // check if the numbers 92 through 79 are prime or not
            for (int i = 92; i >= 79; i -- )
            {
                FizzBuzz(i);
            }

            // YODAIZER
            Console.WriteLine("\nYODAIZER!");
            // convert the string into Yoda speak
            Yodaizer("I like code");

            // TEXTSTATS
            Console.WriteLine("\nTEXTSTATS!");
            // check statistics about a string
            TextStats("Do. Or do not. There is no try.");

            // IS THE NUMBER PRIME?
            Console.WriteLine("\nIS THE NUMBER PRIME?");
            // check every odd number from 1 to 25 to see if it's prime or not
            for (int i = 1; i <= 25; i+= 2 )
            {
                IsPrime(i);
            }

            // DASHINSERT
            Console.WriteLine("\nJENNY, DON'T CHANGE YOUR NUMBER.");
            // insert dashes in between odd numbers in the integer
            DashInsert(8675309);

            // prevent console window from closing immediately
            Console.ReadKey();
        }

        /// <summary>
        /// Output FizzBuzz if a number is divisble by 5 and 3, Buzz if a number is divisible by only 3, or Fizz if a number is divisible by only 5
        /// </summary>
        /// <param name="number">Number to input</param>
        static void FizzBuzz(int number)
        {
            // if the number is divisible by both 5 and 3, output "FizzBuzz"
            if (number % 5 == 0 && number % 3 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            // if the number is divisible only by 3, output "Buzz"
            else if (number % 3 == 0)
            {
                Console.WriteLine("Buzz");
            }
            // if the number is divisible only by 5, output "Fizz"
            else if (number % 5 == 0)
            {
                Console.WriteLine("Fizz");
            }
            // if the number isn't divisible by 5 or 3, output the number only
            else
                Console.WriteLine(number);
        }

        /// <summary>
        /// Takes a string and prints the words out in reverse order. If the string contains only 3 words, "(last word), (first word) (second word)" will be outputted instead
        /// </summary>
        /// <param name="text">String to convert to Yoda speak</param>
        static void Yodaizer(string text)
        {
            // convert string text to a textList as well as create a new list for Yoda text
            List<string> textList = text.Split().ToList();
            List<string> yodaText = new List<string>();

            // if there are three words in the string, format it to have the last word first, a comma, and the first and second words last
            if (textList.Count() == 3)
            {
                Console.WriteLine("{0}, {1} {2}", textList[2], textList[0], textList[1]);
            }
            else
            {
                // add the text to the yodaText list from last word to first
                for (int i = textList.Count() - 1; i >= 0; i--)
                {
                    yodaText.Add(textList[i]);
                }

                // convert the yodaText list to an array, join the elements together into one string, and output
                string output = string.Join(" ", yodaText.ToArray());
                Console.WriteLine(output);
            }
        }

        /// <summary>
        /// Shows various statistics about a string
        /// </summary>
        /// <param name="input">String to check</param>
        static void TextStats (string input)
        {
            // create counters to keep track the number of characters, number of words, etc.
            int numCharacters = 0;
            int numWords = 0;
            int numVowels = 0;
            int numConsonants = 0;
            int numSpecialChars = 0;
            // hold the seperate words in a list and hold the input string into all lower case in lowerString
            List<string> theWords = input.Split().ToList();
            string lowerString = input.ToLower();

            // calculate number of characters, vowels, consonants, and special characters
            for (int i = 0; i < lowerString.Count(); i++)
            {
                numCharacters++;
                if ("aeiou".Contains(lowerString[i]))
                {
                    numVowels++;
                }
                else if (!" .?!,".Contains(lowerString[i]))
                {
                    numConsonants++;
                }
                else
                {
                    numSpecialChars++;
                }
            }
            // calculate the number of words
            for (int i = 0; i < theWords.Count(); i++ )
            {
                numWords++;
            }

            // initialize variables for longest, second longest, and shortest words
            int longestWordCount = 0;
            int shortestWordCount = theWords[0].Count();
            string longestWord = "";
            string secondLongestWord = "";
            string shortestWord = theWords[0];

            // check to see what words are the longest, second longest, and shortest
            foreach (string s in theWords)
            {
                string word = s;
                int curCount = 0;
                for (int i = 0; i < word.Length; i++)
                {
                    // do not include special characters into the count
                    if (!"! .?,".Contains(word[i]))
                    {
                        curCount++;
                    }
                }
                // if the shortest word is longer than the current word
                if (shortestWordCount > curCount)
                {
                    // make the shortest word the current word
                    shortestWord = word;
                    // make the word count for the shortest word the current count
                    shortestWordCount = curCount;
                }
                // if the current word is longer than the longest word
                else if (curCount > longestWordCount)
                {
                    // make the previous longest word into the second longest word
                    secondLongestWord = longestWord;
                    // make the current word the longest word
                    longestWord = word;
                    // make the word count for the longest word the current count
                    longestWordCount = curCount;
                }
            }
            
            // output
            Console.WriteLine(input);
            Console.WriteLine("Number of characters: {0}", numCharacters);
            Console.WriteLine("Number of words: {0}", numWords);
            Console.WriteLine("Number of vowels: {0}", numVowels);
            Console.WriteLine("Number of consonants: {0}", numConsonants);
            Console.WriteLine("Number of special characters: {0}", numSpecialChars);
            // remove special characters in the output
            Console.WriteLine("Longest word: {0}", longestWord.Replace("!","").Replace(",","").Replace("?","").Replace(".",""));
            Console.WriteLine("Second longest word: {0}", secondLongestWord.Replace("!", "").Replace(",", "").Replace("?", "").Replace(".", ""));
            Console.WriteLine("Shortest word: {0}", shortestWord.Replace("!", "").Replace(",", "").Replace("?", "").Replace(".", ""));
        }

        /// <summary>
        /// Check to see if a number is prime
        /// </summary>
        /// <param name="number">Number to check if prime</param>
        static void IsPrime (int number)
        {
            // check every number from 2 to less than the number inputted
            for (int i = 2; i < number; i++)
            {
                // check if the number is not prime by seeing if it is divisible by i
                if (number % i == 0)
                {
                    // if the number isn't prime, output the number and escape the function
                    // there is no need to continue as the number has already been figured
                    // to be not prime
                    Console.WriteLine(number);
                    return;
                }
            }

            // if the number is prime, display this
            Console.WriteLine("{0} is a prime number.", number);
        }

        /// <summary>
        /// Adds dashes in between odd numbers in an integer
        /// </summary>
        /// <param name="number">Number to add dashes to</param>
        static void DashInsert (int number)
        {
            // assign variables to hold the inputted number as a string, a list to hold strings for the output,
            // a string to hold the current digit being looked at and an integer to hold the next digit after being
            // converted from a string back to an integer
            string numberString = number.ToString();
            List<string> outputList = new List<string>();
            string currentDigit = "";
            int nextDigit = 0;

            // loop through every element of numberString
            for (int i = 0; i < numberString.Length; i++)
            {
                // assign the current digit as the current element in numberString
                currentDigit = numberString[i].ToString();

                // check to see if there is another number after the current element to check
                if (i + 1 < numberString.Length)
                {
                    // assign nextDigit as the next element in numberString
                    nextDigit = int.Parse(numberString[i + 1].ToString());
                    // check to see if the current digit is odd and not a zero
                    if (int.Parse(currentDigit) % 2 != 0 && int.Parse(currentDigit) != 0)
                    {
                        // check to see if the next digit is odd and not a zero
                        if (nextDigit % 2 != 0 && nextDigit != 0)
                        {
                            // add the current digit to outputList
                            outputList.Add(currentDigit);
                            // add a dash to outputList as the next digit is odd
                            outputList.Add("-");
                        }                           
                        else
                        {
                            // the next digit isn't odd, so just add the current digit to outputList without adding a dash after
                            outputList.Add(currentDigit);
                        }                           
                    }
                    else
                    {
                        // the current digit isn't odd, so just add the current digit to the outputList
                        outputList.Add(currentDigit);
                    }
                } 
                else
                {
                    // there isn't a digit to check next, so just add the current digit to the outputList
                    outputList.Add(currentDigit);
                }
            }
            // convert the outputList to an array, join the elements together into one string, and output
            string output = string.Join("", outputList.ToArray());
            Console.WriteLine(output);
        }
    }
}
