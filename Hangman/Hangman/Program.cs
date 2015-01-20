using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Hangman();
        }

        /// <summary>
        /// Play Hangman
        /// </summary>
        static void Hangman()
        {
            // initializing variables
            List<string> wordList = new List<string>();
            wordList = ("apple blackbird pear computer driver library water backpack antidisestablishmentarianism shadow orchard shipment gymnastic atomic rear overt alienate feeling light" + 
                "tactical spider normal amateur cloud ranch shocking enormous arrival crawling angry largest felony faction broken dilemma shocking factual missing " +
                "adjustable effective consultant position crunch eternity compact bean zombie hood").ToUpper().Split().ToList();
            // when playing is set to false, the function will end
            bool playing = true;
            Random rng = new Random();
            // this is the user's reply to the playAgain prompt
            char playAgain = ' ';

            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();

            while (playing)
            {
                // these variables are reset upon a new game
                string randomWord = string.Empty;
                int guess = 6;
                string guessed = string.Empty;
                string input = string.Empty;
                string message = "Welcome, " + name + "!";
                randomWord = wordList[rng.Next(0, wordList.Count())];

                // loop while there are guesses left and the word hasn't been guessed
                while ((guess > 0) && !WordGuess(randomWord, guessed))
                {
                    // clears console window every loop
                    Console.Clear();
                    Console.WriteLine("\n\n\n" + MaskedWord(randomWord, guessed));
                    
                    Console.Write("\n\nGuessed so far: ");
                    // places a space between each character that is guessed
                    foreach (char i in guessed)
                        Console.Write("{0} ", i);

                    Console.WriteLine("\n\nGuesses left: {0}", guess);

                    Console.Write("\n{0}\nGuess a word or a letter: ", message);

                    // makes the input upper case
                    input = Console.ReadLine().ToUpper();

                    if (isValid(input))
                    {
                        // Single letter entered
                        if (input.Length == 1)
                        {
                            // Check to see if they have already guessed input
                            if (guessed.Contains(input))
                                message = "You have already guessed \"" + input + "\"!";
                            else
                            {
                                // checks if the letter inputted is in the word
                                if (randomWord.Contains(input))
                                {
                                    guessed += input;
                                    message = "Correct! " + input + " is in the word!";
                                }
                                    // the letter is NOT in the word
                                else
                                {
                                    guessed += input;
                                    guess--;
                                    message = "Oh no! " + input + " is not in the word!";
                                }
                            }
                        }
                        else // User entered more than one character (Word guess)
                        {
                            if (input.ToUpper() == randomWord)
                            {
                                // guessed cannot have duplicate characters
                                foreach (char i in input)
                                    if (!guessed.Contains(i))
                                    {
                                        guessed += i;
                                    }
                            }
                                // input is NOT the word and decrement guess counter
                            else
                            {
                                if (input == "")
                                {
                                    message = "You're stupid. You need to actually put something in! You lose a guess a\npunishment!";
                                }
                                else
                                    message = "Nope! " + input + " is not the word!";
                                guess--;
                            }
                        }

                    }
                        // tells the user the input is not valid
                    else
                        message = input + " is not a valid input. Try again.";

                    // lose condition
                    if (guess == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("You lose!");
                        Console.WriteLine("That word was: {0}", randomWord);
                    }
                        // win condition
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You win!");
                        Console.WriteLine("That word was: {0}", randomWord);
                    }
                }// end of game loop

                // ask if user wants to play again
                Console.WriteLine("Do you want to play again? (Y/any key to exit): ");
                // playAgain will contain their next keystroke
                playAgain = Console.ReadKey().KeyChar;
                if (!(playAgain == 'Y' || playAgain == 'y'))
                    playing = false;

            }// end of playing loop
        }

        /// <summary>
        /// Checks to see if user guessed the word yet
        /// </summary>
        /// <param name="targetWord">Word to guess</param>
        /// <param name="guessedSoFar">The string that contains the characters already guessed. Do not have repeated characters in the string.</param>
        /// <returns>True if word has been guessed</returns>
        static bool WordGuess(string targetWord, string guessedSoFar)
        {
            int counter = 0;
            string correctLetters = string.Empty;

            for (int i = 0; i < targetWord.Length; i++)
            {
                // forms a new string that is targetWord without repeating letters
                if (!correctLetters.Contains(targetWord[i]))
                    correctLetters += targetWord[i];
            }

            for (int i = 0; i < guessedSoFar.Length; i++)
            {
                // counts up once per non-repeating letter
                if (correctLetters.Contains(guessedSoFar[i]))
                    counter++;
            }

            // if our counter is equal to the length of our processed string
            if (counter == correctLetters.Length)
                // user guessed all correct letters
                return true;
            else
                // user hasn't guessed all correct letters
                return false;
        }

        /// <summary>
        /// Masks the letters that are not guessed already in the word
        /// </summary>
        /// <param name="targetWord">The word to guess</param>
        /// <param name="guessedSoFar">The chars that have been guessed</param>
        /// <returns>Masked word</returns>
        static string MaskedWord(string targetWord, string guessedSoFar)
        {
            string builtString = "";

            for (int i = 0; i < targetWord.Length; i++)
            {
                if (guessedSoFar.Contains(targetWord[i]))
                    builtString += targetWord[i] + " ";
                else
                    builtString += "_ ";
            }

                return builtString;
        }

        /// <summary>
        /// Checks if input is only letters
        /// </summary>
        /// <param name="input">User input</param>
        /// <returns>Valid if it's valid</returns>
        static bool isValid(string input)
        {
            bool valid = true;

            foreach(char i in input)
            {
                // if a non-letter is found, valid is false
                if(!char.IsLetter(i))
                    valid = false;
            }
            return valid;
        }
    }
}
