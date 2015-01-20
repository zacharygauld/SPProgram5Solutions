using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterFinderandWordFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            LetterFinder("Happy", "p");

            Console.ReadKey();

        }

        static void LetterFinder (string word, string letter)
        {
            int counter = 0;
            string theWord = word.ToLower();
            string theLetter = letter.ToLower();
            for(int i = 0; i < theWord.Length; i++)
            {
                if (theWord[i].ToString() == theLetter)
                {
                    counter++;
                }
            }
            Console.WriteLine("There is/are " + counter + " " + letter.ToUpper() + "(s) in " + word);
        }

        /*static void WordFinder (string sentence, string wordToFind)
        {
            int counter = 0;
            string newWordToFind = wordToFind.ToLower();
            for(int i = 0; i < newWordToFind.Length; i++)
            {

            }


        }*/
    }
}
