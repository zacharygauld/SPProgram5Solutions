using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilderExample
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilderExample();
            Console.ReadKey();
        }

        static void StringBuilderExample()
        {
            StringBuilder aStringBuilder = new StringBuilder();
            aStringBuilder.AppendLine("Hello world!");
            aStringBuilder.AppendLine("My favorite color is blue.");

            Console.WriteLine(aStringBuilder.ToString());

            string myString = string.Empty;
            myString += "Hello world!";
            myString += "\n";
            myString += "My favorite color is blue.";

            Console.WriteLine(myString);
        }
    }
}
