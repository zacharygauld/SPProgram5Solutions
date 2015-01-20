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
            // create a new list of strings called products
            List<string> products = new List<string>() {"Basketball", "Baseball", "Tennis Raquet", "Running Shoes", "Wrestling Shoes", 
                "Soccer Ball", "Football", "Shoulder Pads", 
                "Trail Running Shoes", "Cycling Shoes", "Kayak", "Kayak Paddles"};


            //declare a variable kayakProducts and set it equal to all products that contain the word "Kayak"
            List<string> kayakProducts = products.Where(x => x.Contains("Kayak")).ToList();

            //print the kayakProducts to the console using a foreach loop.
            Console.WriteLine("kayakProducts");
            foreach (string product in kayakProducts)
                Console.WriteLine(product);

            Console.WriteLine();

            //declare a variable shoeProducts and set it equal to all products that contain the word "Shoes"
            List<string> shoeProducts = products.Where(x => x.Contains("Shoes")).ToList();

            //print the shoeProducts to the console using a foreach loop or string.Join().
            Console.WriteLine("shoeProducts");
            foreach (string product in shoeProducts)
                Console.WriteLine(product);

            Console.WriteLine();

            //declare a variable ballProducts and set it equal to all the products that have ball in the name.
            List<string> ballProducts = products.Where(x => x.Contains("ball")).ToList();

            //print the ballProducts to the console using a foreach loop or string.Join().
            Console.WriteLine("ballProducts");
            foreach (string product in ballProducts)
                Console.WriteLine(product);

            Console.WriteLine();

            //sort ballProducts alphabetically and print them to the console.
            Console.WriteLine("Products in ballProducts listed alphabetically: {0}", string.Join(", ", ballProducts.OrderBy(x => x)));

            //add six more items to the products list using .add().
            products.Add("Tennis Ball");
            products.Add("Golf Ball");
            products.Add("Sneakers");
            products.Add("Bike");
            products.Add("Helmet");
            products.Add("Gloves");

            //print the product with the longest name to the console using the .First() extension.
            Console.WriteLine("\nLongest product name: {0}", products.OrderByDescending(x => x.Length).First());

            //print the product with the shortest name to the console using OrderBy() and the .First() extension.
            Console.WriteLine("\nShortest product name: {0}",products.OrderBy(x => x.Length).First());

            //print the product with the 4th shortest name to the console using an index or Skip/Take (you must convert the results to a list using .ToList()).
            Console.WriteLine("\nProduct with 4th shortest name: {0}", products.OrderBy(x => x.Length).ToList()[3]);

            //print the ballProduct with the 2nd longest name to the console using an index or Skip/Take (you must convert the results to a list using .ToList()).
            Console.WriteLine("\nProduct with 2nd longest name: {0}", products.OrderBy(x => x.Length).ToList()[1]);

            //declare a variable reversedProducts and set it equal to all products ordered by the longest word first. (use the OrderByDescending() extension).
            List<string> reversedProducts = products.OrderByDescending(x => x.Length).ToList();

            //print out the reversedProducts to the console using a foreach loop.
            Console.WriteLine("\nreversedProducts");
            foreach (string product in reversedProducts)
                Console.WriteLine(product);

            //print out all the products ordered by the longest word first using the OrderByDecending() extension and a foreach loop.  
            //Note: you will not use a variable to store your list
            Console.WriteLine("\nproducts from longest to shortest");
            foreach (string product in products.OrderByDescending(x => x.Length).ToList())
                Console.WriteLine(product);

            Console.ReadKey();
        }
    }
}