using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            // call the ChangeMaker function with different parameters
            ChangeMaker(3.18);
            ChangeMaker(0.99);
            ChangeMaker(12.93);
            // extra credit amount!
            ChangeMaker(724.89);
            // prevent the console from closing immediately
            Console.ReadKey();
        }

        /// <summary>
        /// Input an amount to break down into change
        /// </summary>
        /// <param name="amount">Amount to break down into change</param>
        static void ChangeMaker (double amount)
        {
            // create newAmount variable so the original amount won't be modified as the code runs
            // create variables to hold the counters for the different denominations
            double newAmount = amount;
            int hundreds = 0;
            int fifties = 0;
            int twenties = 0;
            int tens = 0;
            int fives = 0;
            int ones = 0;
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;
            int pennies = 0;
            
            // loop while there is still money left
            while (newAmount > 0)
            {
                // check to see if the current amount is more than or equal to 100; if so, remove 100 from the amount
                // and add one to the hundreds counter
                while (newAmount >= 100)
                {
                    newAmount -= 100;
                    hundreds++;
                }
                // check to see if the current amount is more than or equal to 50; if so, remove 50 from the amount
                // and add one to the fifties counter
                while (newAmount >= 50)
                {
                    newAmount -= 50;
                    fifties++;
                }
                // check to see if the current amount is more than or equal to 20; if so, remove 20 from the amount
                // and add one to the twenties counter
                while (newAmount >= 20)
                {
                    newAmount -= 20;
                    twenties++;
                }
                // check to see if the current amount is more than or equal to 10; if so, remove 10 from the amount
                // and add one to the tens counter
                while (newAmount >= 10)
                {
                    newAmount -= 10;
                    tens++;
                }
                // check to see if the current amount is more than or equal to 5; if so, remove 5 from the amount
                // and add one to the fives counter
                while (newAmount >= 5)
                {
                    newAmount -= 5;
                    fives++;
                }
                // check to see if the current amount is more than or equal to 1; if so, remove 1 from the amount
                // and add one to the ones counter
                while (newAmount >= 1)
                {
                    newAmount -= 1;
                    ones++;
                }
                // check to see if the current amount is more than or equal to .25; if so, remove .25 from the amount
                // and add one to the quarters counter
                while (newAmount >= .25)
                {
                    newAmount -= .25;
                    quarters++;
                }
                // check to see if the current amount is more than or equal to .10; if so, remove .10 from the amount
                // and add one to the dimes counter
                while (newAmount >= .10)
                {
                    newAmount -= .10;
                    dimes++;
                }
                // check to see if the current amount is more than or equal to .05; if so, remove .05 from the amount
                // and add one to the nickels counter
                while (newAmount >= .05)
                {
                    newAmount -= .05;
                    nickels++;
                }
                // check to see if the current amount is more than or equal to .01; if so, remove .01 from the amount
                // and add one to the pennies counter
                while (newAmount >= .01)
                {
                    newAmount -= .01;
                    pennies++;
                }
                // round the amount to the nearest penny to eliminate problems with amounts less than .01
                newAmount = Math.Round(newAmount, 2);
            }

            // output the amount and how it's broken down through the various denominations
            Console.WriteLine("Amount: ${0}", amount);
            Console.WriteLine("Hundreds: {0}", hundreds);
            Console.WriteLine("Fifties: {0}", fifties);
            Console.WriteLine("Twenties: {0}", twenties);
            Console.WriteLine("Tens: {0}", tens);
            Console.WriteLine("Fives: {0}", fives);
            Console.WriteLine("Ones: {0}", ones);
            Console.WriteLine("Quarters: {0}", quarters);
            Console.WriteLine("Dimes: {0}", dimes);
            Console.WriteLine("Nickels: {0}", nickels);
            Console.WriteLine("Pennies: {0}\n", pennies);
        }
    }
}
