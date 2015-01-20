using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            // call CombatSimulator()
            CombatSimulator();
        }

        /// <summary>
        /// The Combat Simulator
        /// </summary>
        static void CombatSimulator()
        {
            // initialize variables to keep track of input, choice validation, stats, etc.
            string input = string.Empty;
            bool validChoice = false;
            bool playing = true;
            bool gameOn = true;
            int playerHP = 100;
            int enemyHP = 200;
            int points = 0;

            // resize and change colors for the console window
            Console.SetWindowSize(125, 50);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            // outer game loop
            while (playing)
            {
                // inner game loop
                while (gameOn)
                {
                    // output the title
                    Console.Clear();
                    Console.WriteLine("\n\n -MMMMMMMN-       `hMMMMMMM+       `sMMMMMN/        `+ydmNNMMMMMMMMMMMMM/  :shmNNNNNMMNNNNMMMNh`");
                    Console.WriteLine(" -MMMMMMMMN:     .dMMMMMMMM+      -dMMMMMMMMy`     -NMMMMMmddddddddddddd:`sMMMMMNmddddddddddddy`");
                    Console.WriteLine(" -NNNNNNNNNm:   .dNNNNNNNNN/     /mNNmd+yyyys+`    :ooooo/-----------``  `++++++/::::::::--.``");
                    Console.WriteLine(" -mmmmmsdmmmd: -dmmmmommmdh:   `+sssso-..oddddd+`  `sdmmmmmmmmmmmmddmmdy:`:ydddddddddddddddmdho`");
                    Console.WriteLine(" .ddddd+-ydddh+hhyyy/-ysyyh/  -hdddddddddddddddds.   `-:/+++++++++ohhhhhh-  .://+++++++++shhhhho`");
                    Console.WriteLine(" .hhhhh+`.osssssyhh/`:hhhhh:`/hhhhyoooooooooyyyyys-`:+++++++++++++oyyyyyy.`++++++++++++++syyyyy+`");
                    Console.WriteLine(" .sssss+` .oyyyyys:  :yyyyy:syyyys:         .osssss/+ssssssssssssssssso+. `yssssssssssssssssso:`");
                    Console.WriteLine(" `------`  `-----.   .-----------.           `-----------------......`    `----.....-----...``");
                    Console.WriteLine(" `/yhdhhhhh.       -shdhhhhh+`      -shdhhhhh+`     .oydhhhhhs`      -shdhhhhh/     /hhhdmdhhho");
                    Console.WriteLine(" oNNdoooooo`      `mNmoooooo:      `mmmoooooo:     `hmmyooooo/`     -mmh.              `hmd`");
                    Console.WriteLine(" :yhs+/////`      `dho-......      `hho-......     `oyyo/////:`     .sys:-----.        `shy`");
                    Console.WriteLine("  `-::////:`      `//-`            `/:-`             `-::::::-`      `.-::::::-        `:::`");
                    Console.WriteLine("\n\n88888 8              .d88b.                8  dP                               888b.       8          8 8 w             ");
                    Console.WriteLine("  8   8d8b. .d88b    8P  Y8 8d8b. .d88b    8wdP  8d8b .d8b. .d88 .d88 8d8b.    8  .8 .d88b 88b. .d88b 8 8 w .d8b. 8d8b. ");
                    Console.WriteLine("  8   8P Y8 8.dP'    8b  d8 8P Y8 8.dP'    88Yb  8P   8' .8 8  8 8  8 8P Y8    8wwK' 8.dP' 8  8 8.dP' 8 8 8 8' .8 8P Y8 ");
                    Console.WriteLine("  8   8   8 `Y88P    `Y88P' 8   8 `Y88P    8  Yb 8    `Y8P' `Y88 `Y88 8   8    8  Yb `Y88P 88P' `Y88P 8 8 8 `Y8P' 8   8 ");
                    Console.WriteLine("                                                            wwdP                                                        ");

                    // output the dialogue
                    Console.WriteLine("\n\n\n\nYou don't like how things are being run in your clan. Facing the clan leader with your complaints, he bashes his head\nagainst yours."
                        + " \"Face me, then,\" the clan leader growls. \"You're going to have to kill me if you want change.\" With no other\noptions, you prepare for battle.");
                    
                    // if player's HP is more than 20, have it show normally
                    if (playerHP > 20)
                        Console.WriteLine("\nYour HP (max 100): {0}", playerHP);
                        // if player's HP is 20 or less, change color of HP text to red
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nYOUR HP IS LOW (max 100): {0}", playerHP);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    // output enemy's stats and battle choices
                    Console.WriteLine("Clan Leader's HP: {0}", enemyHP);
                    Console.WriteLine("\nPick 1 to fire your Claymore shotgun, 2 to headbutt, or 3 to regenerate HP, and press enter.");
                    Console.WriteLine("1. Claymore, 2. Headbutt, 3. Regenerate");

                    // player and enemy die together! Break out of inner game loop
                    if (playerHP == 0 && enemyHP == 0)
                    {
                        Console.WriteLine("\nBoth you and the clan leader die from the wounds sustained in battle. Who will lead the clan now?! You've failed!");
                        gameOn = false;
                        break;
                    }
                    // player wins! Break out of inner game loop
                    else if (enemyHP == 0)
                    {
                        Console.WriteLine("\nWith the krogan clan leader killed, you've gained the respect of the other clan members. Congratulations! You are now the\nnew clan leader!");
                        gameOn = false;
                        break;
                    }
                        // player loses! Break out of inner game loop
                    else if (playerHP == 0)
                    {
                        Console.WriteLine("\nThe krogan clan leader stomps on your corpse and chuckles darkly. \"Anyone else wanna try a revolution?!\" he snarls. You've\nfailed!");
                        gameOn = false;
                        break;
                    }

                    // validate player's choice
                    while (!validChoice)
                    {
                        input = Console.ReadLine();
                        validChoice = ChoiceValidation(input);
                    }
                    // invalidate choice so the validation loop will run again the next inner game loop go-around
                    validChoice = false;

                    // make points equal to the return of Points()
                    points = Points(input);

                    // output correct information based on the input
                    switch (input)
                    {
                        case "1":
                            // because choice 1 has a 7 in 10 chance of hitting the enemy, pass input to RandomChance(). If true is returned, the player hits
                            if (RandomChance(input) == true)
                            {
                                // output and decrement enemy's HP
                                Console.WriteLine("\nYou hit the clan leader with your Claymore for {0} damage!", points);
                                enemyHP -= points;
                            }
                            else
                                // the player misses if a false is returned from RandomChance()
                                Console.WriteLine("\nYour Claymore missed!");
                            break;

                        case "2":
                            // choice 2 never misses. Output and decrement enemy's HP
                            Console.WriteLine("\nYou hit the clan leader with a headbutt for {0} damage!", points);
                            enemyHP -= points;
                            break;

                        case "3":
                            // player HP cap set to 100. Player loses a turn if s/he tries to heal while at 100 HP
                            if (playerHP == 100)
                                Console.WriteLine("\nYou are at max HP and cannot regenerate anymore. You lose a turn!");
                            else if (playerHP + points > 100)
                            {
                                // because the HP cap is 100, make points 100 - playerHP, output and increment playerHP
                                points = 100 - playerHP;
                                Console.WriteLine("\nYou regenerated slightly to heal {0} HP!", points);
                                playerHP += points;
                            }
                            else
                            {
                                // output and increment playerHP
                                Console.WriteLine("\nYou regenerated slightly to heal {0} HP!", points);
                                playerHP += points;
                            }
                            break;
                    }

                    // make points equal the return of Points()
                    points = Points("enemy");
                    // because enemy has a 4 in 5 chance of hitting the player, pass input to RandomChance(). If true is returned, the enemy hits
                    if (RandomChance("enemy") == true)
                    {
                        // output and decrement playerHP
                        Console.WriteLine("The clan leader headbutts you for {0} damage!", points);
                        playerHP -= points;
                    }
                    else
                        // if RandomChance () returns false, enemy misses
                        Console.WriteLine("You dodged the clan leader's headbutt!");

                    // tell player to press any key to continue
                    Console.WriteLine("\nPress any key to continue ...");

                    // make player's HP 0 if it's below 0
                    if (playerHP < 0)
                        playerHP = 0;
                    // make enemy's HP 0 if it's below 0
                    if (enemyHP < 0)
                        enemyHP = 0;
                    
                    // player presses any key to continue
                    Console.ReadKey();
                }
                // make valid false to allow the play again validation loop to execute
                bool valid = false;

                while (!valid)
                {
                    // ask if the player wants to play again
                    Console.WriteLine("\nWould you like to play again? (Y/N)");
                    input = Console.ReadLine();
                    // if player wants to play again, set play and enemy HP to 100 and 200, respectively, set gameOn back to true so the inner game loop can execute and valid to true
                    // so the validation loop ends
                    if (input == "Y" || input == "y")
                    {
                        gameOn = true;
                        valid = true;
                        playerHP = 100;
                        enemyHP = 200;
                    }
                        // set playing to false so the outer game loop will not run again and set valid to true so the validation loop ends
                    else if (input == "N" || input == "n")
                    {
                        playing = false;
                        valid = true;
                    }
                        // choice is not valid. Loop around to ask player if they'd like to play again
                    else
                    {
                        Console.WriteLine("That's not a valid input!");
                    }
                }
            }
            // thank the player for playing and tell them to press any key to exit
            Console.WriteLine("\nThanks for playing! Come and play again soon!");
            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }

        /// <summary>
        /// Checks to see if the input is valid
        /// </summary>
        /// <param name="input">Input to check</param>
        /// <returns>Returns true of choice is valid, false if invalid</returns>
        static bool ChoiceValidation (string input)
        {
            int choice = 0;
            // checks to see if input can be parsed as an integer
            if (int.TryParse(input, out choice))
            {
                // if choice is less than zero or more than three, alert that the choice is invalid and return false
                if (choice < 1 || choice > 3)
                {
                    Console.WriteLine("Not a valid choice! Try again.");
                    return false;
                }
                    // choice is valid, so return true
                else
                    return true;
            }
                // input cannot be parsed. Alert the input is invalid and return false
            else
            {
                Console.WriteLine("Not a valid choice! Try again.");
                return false;
            }
        }

        /// <summary>
        /// Randomly generates the amount of points an attack will deal / how much HP will be regained when healing
        /// </summary>
        /// <param name="input">Input to check</param>
        /// <returns>Returns the amount of points the RNG determines</returns>
        static int Points (string input)
        {
            // create RNG to generate point amount
            Random rng = new Random();
            int points = 0;

            switch (input)
            {
                    // attack 1 can deal 20 to 35 points of damage
                case "1":
                    points = rng.Next(20, 36);
                    break;
                    // attack 2 can deal 10 to 15 points of damage
                case "2":
                    points = rng.Next(10, 16);
                    break;
                    // healing can generate 10 to 20 points of HP
                case "3":
                    points = rng.Next(10, 21);
                    break;
                    // enemy can deal 5 to 15 points of damage
                case "enemy":
                    points = rng.Next(5, 16);
                    break;
            }
            // return the amount of points
            return points;
        }

        /// <summary>
        /// Decides if an attack will hit or not
        /// </summary>
        /// <param name="input">Input to check</param>
        /// <returns>Returns true if attack hits and false if attack misses</returns>
        static bool RandomChance (string input)
        {
            // create RNG to determine the chance of hitting
            Random rng = new Random();

            // attack 1 has a 70% chance of hitting
            if (input != "enemy")
            {
                // if the RNG generates a number that is more than 7, attack will miss!
                if (rng.Next(1, 11) > 7)
                    return false;
                else
                    return true;
            }
                // enemy has an 80% chance of hitting
            else
            {
                // if the RNG generates a number that is more than 4, attack will miss!
                if (rng.Next(1, 6) > 4)
                    return false;
                else
                    return true;
            }
        }
    }
}