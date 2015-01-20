using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            // call functions
            Console.WriteLine("What is the 10,001st prime number?");
            FindNPrimes(10001);
            Console.WriteLine("\nEven Fibonacci Sequencer with a max value of 1,000,000:");
            EvenFibonacciSequencer(1000000);
            Console.WriteLine("\nLongest Collatz sequence under 1,000,000:");
            LongestCollatzSequence();

            // prevent console window from closing immediately
            Console.ReadKey();
        }

        /// <summary>
        /// Finds the nth prime number
        /// </summary>
        /// <param name="maxPrime">The prime number you want to find</param>
        static void FindNPrimes(int maxPrime)
        {
            // if maxPrime is 1, output 2 as 2 is the first prime number
            if (maxPrime == 1)
            {
                Console.WriteLine("2");
                // exit the function
                return;
            }

            // set currentPrimeNumber to 2 and number to 4
            // currentPrimeNumber holds the number of prime numbers found and number holds the number being tested
            int currentPrimeNumber = 2;
            int number = 4;

            // loop while currentPrimeNumber doesn't equal maxPrime
            while (currentPrimeNumber != maxPrime)
            {
                // loop while i is less than or equal to number
                for (int i = 2; i <= number; i++)
                {
                    // if number is divisible by i and the number isn't i, the number isn't a prime number
                    // increment number by 1 and break out of the for loop to text the next number
                    if (number % i == 0 && number != i)
                    {
                        number++;
                        break;
                    }

                    // if i equals the number, then the number is prime
                    // increment currentPrimeNumber by 1 as a prime number has been found and increment number to test the next number
                    // break out of the for loop as the number has been determined to be prime
                    if (i == number)
                    {
                        number++;
                        currentPrimeNumber++;
                        break;
                    }
                }
            }

            // output number decremented by 1 as the loop increments the number by 1 before breaking out
            // the number before it's incremented by 1 is the prime number
            Console.WriteLine(number -= 1);
        }

        /// <summary>
        /// Adds all even numbers up to the maxValue
        /// </summary>
        /// <param name="maxValue">Number you want to stop at</param>
        static void EvenFibonacciSequencer(int maxValue)
        {
            // create variables to keep track of data
            int firstNumber = 1;
            int secondNumber = 2;
            int firstEvenNumber = 0;
            int secondEvenNumber = 0;
            int total = 0;
            int evenTotal = 0;

            // loop while evenTotal is less than maxValue
            while (evenTotal < maxValue)
            {
                // if the secondNumber is divisble by 2
                if (secondNumber % 2 == 0)
                {
                    // make firstEvenNumber the secondNumber
                    firstEvenNumber = secondNumber;
                    // add firstEvenNumber and secondEvenNumber to figure out the total for evenTotal
                    evenTotal = firstEvenNumber + secondEvenNumber;
                    // make firstEvenNumber the secondEvenNumber
                    firstEvenNumber = secondEvenNumber;
                    // make secondEvenNumber the evenTotal
                    secondEvenNumber = evenTotal;
                }

                // add the firstNumber and secondNumber together to figure out the total
                total = firstNumber + secondNumber;
                // make firstNumber the secondNumber
                firstNumber = secondNumber;
                // make secondNumber the total
                secondNumber = total;
            }

            // output evenTotal
            Console.WriteLine(evenTotal);
        }

        /// <summary>
        /// Outputs the longest Collatz Sequence under 1,000,000
        /// </summary>
        static void LongestCollatzSequence()
        {
            // create variables to keep track of data
            long number = 0;
            long longestNumber = 0;
            int longestChain = 0;
            int currentChain = 0;

            // loop while i is less than or equal to 1,000,000
            for (int i = 1; i <= 1000000; i++)
            {
                // reset currentChain to 0
                currentChain = 0;
                // make number equal to i
                number = i;
                // while number isn't 1
                while (number != 1)
                {
                    // if the number is even, divide the number by 2 and increment currentChain
                    if (number % 2 == 0)
                    {
                        number = number / 2;
                        currentChain++;
                    }
                        // if the number is odd, times it by 3 and add 1 and increment currentChain
                    else
                    {
                        number = (3 * number) + 1;
                        currentChain++;
                    }
                }

                // check to see if currentChain is greater than longestChain
                if (currentChain > longestChain)
                {
                    // since currentChain is longer than longestChain, make the longestChain the currentChain
                    longestChain = currentChain;
                    // also make the longestNumber equal to i
                    longestNumber = i;
                }
            }

            // output the number that produces the longest chain
            Console.WriteLine(longestNumber);
        }
    }
}
