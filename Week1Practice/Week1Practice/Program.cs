using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            // DECLARING VARIABLES
            string myName = "Zachary";
            int myAge = 25;
            bool myBool = true;
            List<string> productsList = new List<string>() { "basketball", "baseball glove", "tennis shoes", "hockey puck" };

            // PRINTING VARIABLES TO THE CONSOLE USING CONSOLE.WRITELINE()
            Console.WriteLine("PRINTING VARIABLES TO THE CONSOLE USING CONSOLE.WRITELINE()\n");
            Console.WriteLine("My name is " + myName + " and I'm a beast of a programmer");
            Console.WriteLine("I am " + myAge + " years awesome.");
            Console.WriteLine("I set my boolean value equal to " + myBool);            
            // Print out each value in productsList
            for (int i = 0; i < productsList.Count(); i++)
            {
                Console.WriteLine(productsList[i]);
            }

            // FOR LOOP PRACTICE
            Console.WriteLine("\nFOR LOOP PRACTICE\n");
            // Prints out numbers 1 to 10
            Console.WriteLine("Prints out 1 to 10");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }
            // Prints out numbers 10 to 1
            Console.WriteLine("\nPrints out 10 to 1");
            for (int i = 10; i >= 1; i--)
            {
                Console.WriteLine(i);
            }
            // Prints out even numbers 10 to 30
            Console.WriteLine("\nPrints out even numbers 10 to 30");
            for (int i = 10; i <= 30; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
            // Prints out every 5th number 100 to 75
            Console.WriteLine("\nPrints out every 5th number 100 to 75");
            for (int i = 100; i >= 75; i -= 5)
            {
                Console.WriteLine(i);
            }

            // WHILE LOOP PRACTICE
            Console.WriteLine("\nWHILE LOOP PRACTICE\n");
            // Prints out 1 to 10
            Console.WriteLine("Prints out 1 to 10");
            int x = 1;
            while (x <= 10)
            {
                Console.WriteLine(x);
                x++;
            }
            // Prints out 10 to 1
            Console.WriteLine("\nPrints out 10 to 1");
            x = 10;
            while (x >= 1)
            {
                Console.WriteLine(x);
                x--;
            }
            // Prints out even numbers 15 to 30
            Console.WriteLine("\nPrints out even numbers 15 to 30");
            x = 15;
            while (x <= 30)
            {
                if (x % 2 == 0)
                {
                    Console.WriteLine(x);
                }
                x++;
            }
            // Prints out every 5th number 100 to 75
            Console.WriteLine("\nPrints out every 5th number 100 to 75");
            x = 100;
            while (x >= 75)
            {
                Console.WriteLine(x);
                x -= 5;
            }
            // Prints out 1 to 10 until the loop reaches a number divisible by 4 and set myBool to false
            Console.WriteLine("\nPrints out 1 to 10 until loop reaches # divisible by 4; set myBool to false");
            x = 1;
            while (myBool)
            {
                if (x % 4 == 0)
                {
                    myBool = false;
                }
                Console.WriteLine(x);
                x++;
            }

            // PUTTING IT TOGETHER
            Console.WriteLine("\nPUTTING IT TOGETHER\n");
            // Print out number of letters in myName
            Console.WriteLine("My name, " + myName + ", has " + myName.Count() + " letters in it.");
            // Print out the number of items in productsList
            Console.WriteLine("My product list has " + productsList.Count() + " items in it.");
            // Print out number of letters in each item in productsList
            for (int i = 0; i < productsList.Count(); i++)
            {
                Console.WriteLine(productsList[i] + " has " + productsList[i].Replace(" ", "").Length + " letters in it.");
            }
            Console.WriteLine(productsList[1]);
            // CALLING FUNCTIONS
            Console.WriteLine("\nDECLARING AND CALLING FUNCTIONS\n");
            Greeting("Beef Hardchest");
            Greeting(myName);
            DoubleIt(1337);
            DoubleIt(myAge);
            Multiply(2, 8);
            Multiply(3, myAge);
            LoopThis(20, 30);
            LoopThis(0, myAge);
            SuperLoop(0, 100, 15);
            SuperLoop(0, 200, myAge);

            // CALLING RETURN FUNCTIONS
            Console.WriteLine("\nDECLARING AND CALLING RETURN FUNCTIONS\n");
            Console.WriteLine(NewGreeting("Neil deGrasse-Tyson"));
            Console.WriteLine(NewGreeting(myName));
            Console.WriteLine("10 tripled is " + TripleIt(10));
            Console.WriteLine(myAge + " tripled is " + TripleIt(myAge));
            Console.WriteLine("\nRealMultiply(5, 10)");
            Console.WriteLine(RealMultiply(5, 10));
            Console.WriteLine("\nRealMultiply(2, myAge)");
            Console.WriteLine(RealMultiply(2, myAge));

            // FUNCTION CALL MADNESS!
            Console.WriteLine("\nFUNCTION CALL MADNESS!");
            SuperLoop(RealMultiply(1, 5), TripleIt(myAge), TripleIt(myAge - 10));
            SuperLoop(RealMultiply(1, TripleIt(3)), TripleIt(RealMultiply(myAge, 7)), TripleIt(myAge - RealMultiply(2, 4)));

            Console.ReadKey();        
        }

        // DECLARING FUNCTIONS
        /// <summary>
        /// Writes out a greeting
        /// </summary>
        /// <param name="name">String to display in greeting</param>
        static void Greeting (string name)
        {
            Console.WriteLine("Hello " + name);
        }
        /// <summary>
        /// Doubles a number
        /// </summary>
        /// <param name="x">Number to double</param>
        static void DoubleIt (int number)
        {
            Console.WriteLine(number + " doubled is " + (number * 2));
        }
        /// <summary>
        /// Multiplies two numbers
        /// </summary>
        /// <param name="num1">First number to multiply</param>
        /// <param name="num2">Second number to multiply</param>
        static void Multiply (int num1, int num2)
        {
            Console.WriteLine(num1 + " times " + num2 + " is " + (num1 * num2));
        }
        /// <summary>
        /// Displays "I'm looping from [startNum] to [endNum]" and outputs [starNum] to [endNum]
        /// </summary>
        /// <param name="startNum">Number to start at</param>
        /// <param name="endNum">Number to end at</param>
        static void LoopThis (int startNum, int endNum)
        {
            Console.WriteLine("\nI'm looping from " + startNum + " to " + endNum);
            int x = startNum;
            while (x <= endNum)
            {
                Console.WriteLine(x);
                x++;
            }
        }
        /// <summary>
        /// Creates a for loop, allowing the user to specify a starting number, an ending number, and the increment
        /// </summary>
        /// <param name="startNum">Number to start at</param>
        /// <param name="endNum">Number to end at</param>
        /// <param name="increment">How much to increment</param>
        static void SuperLoop (int startNum, int endNum, int increment)
        {
            Console.WriteLine("\nI'm looping from " + startNum + " to " + endNum + ", incrementing " + increment + " each time");
            int loopCount = 0;
            for(int i = startNum; i <= endNum; i+=increment)
            {
                Console.WriteLine(i);
                loopCount++;
            }
            Console.WriteLine("That loop was craaaaaazy, we looped " + loopCount + " times");
        }

        // DECLARING RETURN FUNCTIONS
        /// <summary>
        /// Returns a string of "Hello, [string]"
        /// </summary>
        /// <param name="name">String to input</param>
        /// <returns>Returns "Hello, [string]"</returns>
        static string NewGreeting(string name)
        {
            return "Hello, " + name;
        }
        /// <summary>
        /// Multiplies a number by 3
        /// </summary>
        /// <param name="number">The number you want to multiply by 3</param>
        /// <returns>Returns your number multiplied by 3</returns>
        static int TripleIt(int number)
        {
            return number * 3;
        }
        /// <summary>
        /// Multiplies two numbers with each other
        /// </summary>
        /// <param name="num1">First number to multiply</param>
        /// <param name="num2">Second number to multiply</param>
        /// <returns>The product of both numbers multiplied by each other</returns>
        static int RealMultiply(int num1, int num2)
        {
            return num1 * num2;
        }
    }
}
