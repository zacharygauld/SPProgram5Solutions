using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatSimulatorV2
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a new Game() object
            Game game = new Game();
            // run the game
            game.PlayGame();
        }
    }

    // enumeration for the various types of attack
    public enum AttackTypes
    {
        Claymore, Headbutt, Regenerate, Medigel
    }

    // holds information for the enemy
    class Enemy
    {
        // properties
        public string Name { get; set; }
        public int HP { get; set; }
        public bool IsAlive { get { return this.HP > 0; } }
        public AttackTypes attack { get; set; }

        // constructor
        public Enemy(string name, int hp)
        {
            this.Name = name;
            this.HP = hp;
        }

        /// <summary>
        /// Attack a specific Player() object
        /// </summary>
        /// <param name="player">The Player() object to attack</param>
        public void DoAttack(Player player)
        {
            // create RNG to determine random attack choice, damage, and chance of hitting
            Random rng = new Random();
            int choice = 0;
            int damage = 0;
            int hitChance = 0;

            // if enemy's HP is 200, prevent the RNG from selecting 2, else allow 2 to be selected
            if (this.HP == 200)
                choice = rng.Next(0, 2);
            else
                choice = rng.Next(0, 3);

            // attack logic
            switch (choice)
            {
                case 0:
                    damage = rng.Next(20, 36);
                    hitChance = rng.Next(1, 11);
                    if (hitChance <= 3)
                        Console.WriteLine("{0}'s Claymore missed!", this.Name);
                    else
                    {
                        Console.WriteLine("{0}'s Claymore hits for {1} damage!", this.Name, damage);
                        player.HP -= damage;
                    }
                    break;
                case 1:
                    damage = rng.Next(10, 16);
                    Console.WriteLine("{0}'s headbutt hits for {1} damage!", this.Name, damage);
                    player.HP -= damage;
                    break;
                case 2:
                    damage = rng.Next(10, 21);
                    if (this.HP + damage > 200)
                    {
                        damage = 200 - this.HP;
                        Console.WriteLine("{0} regenerated {1} health!", this.Name, damage);
                        this.HP += damage;
                    }
                    else
                    {
                        Console.WriteLine("{0} regenerated {1} health!", this.Name, damage);
                        this.HP += damage;
                    }
                    break;
                default:
                    break;
            }

            // old attack logic (for an easier experience!)
            //if (hitChance <= 2)
            //    Console.WriteLine("You dodged {0}'s headbutt!", this.Name);
            //else
            //{
            //    Console.WriteLine("You were hit by {0}'s headbutt for {1} damage!", this.Name, damage);
            //    player.HP -= damage;
            //}

        }
    }

    // holds information for the player
    class Player
    {
        // properties
        public int HP { get; set; }
        public bool IsAlive { get { return this.HP > 0; } }
        public AttackTypes attack { get; set; }
        public int Medigel { get; set; }
        
        // constructor
        public Player(int hp)
        {
            this.HP = hp;
            this.Medigel = 2;
        }

        /// <summary>
        /// Attack an Enemy() object
        /// </summary>
        /// <param name="enemy">Enemy() object to attack</param>
        public void DoAttack(Enemy enemy)
        {
            // create RNG to determine random attack choice, damage, and chance of hitting
            Random rng = new Random();
            int damage = 0;
            int hitChance = 0;

            // call ChooseAttack()
            ChooseAttack();

            // attack logic
            switch (attack)
            {
                case AttackTypes.Claymore:
                    damage = rng.Next(20, 36);
                    hitChance = rng.Next(1, 11);
                    if (hitChance <= 3)
                        Console.WriteLine("\nYour Claymore missed!");
                    else
                    {
                        Console.WriteLine("\nYour Claymore hit {0} for {1} damage!", enemy.Name, damage);
                        enemy.HP -= damage;
                    }
                    break;
                case AttackTypes.Headbutt:
                    damage = rng.Next(10, 16);
                    Console.WriteLine("\nYour headbutt hit {0} for {1} damage!", enemy.Name, damage);
                    enemy.HP -= damage;
                    break;
                case AttackTypes.Regenerate:
                    damage = rng.Next(10, 21);
                    if (this.HP == 100)
                        Console.WriteLine("\nYou are at max HP and cannot regenerate anymore. You lose a turn!");
                    else if (this.HP + damage > 100)
                    {
                        damage = 100 - this.HP;
                        Console.WriteLine("\nYou regenerated {0} health!", damage);
                        this.HP += damage;
                    }
                    else
                    {
                        Console.WriteLine("\nYou regenerated {0} health!", damage);
                        this.HP += damage;
                    }
                    break;
                case AttackTypes.Medigel:
                    if (Medigel > 0)
                    {
                        Console.WriteLine("\nYou used medi-gel to fully restore your health!");
                        this.Medigel -= 1;
                        this.HP = 100;
                    }
                    else
                        Console.WriteLine("\nYou don't have anymore medi-gel! You lose a turn!");
                    break;
                default:
                    break;
            }


        }

        /// <summary>
        /// Asks the player to choose an attack
        /// </summary>
        private void ChooseAttack()
        {
            bool validChoice = false;

            Console.WriteLine("Pick 1 to fire your Claymore shotgun, 2 to headbutt, 3 to regenerate HP, or 4 to use medi-gel, and press enter.");

            // while a valid choice hasn't been inputted
            while (!validChoice)
            {
                string choice = Console.ReadLine();
                // set attack to an enum and set validChoice to true if the player's choice is a valid input
                // an invalid choice will not change validChoice to true
                switch (choice)
                {
                    case "1":
                        attack = AttackTypes.Claymore;
                        validChoice = true;
                        break;
                    case "2":
                        attack = AttackTypes.Headbutt;
                        validChoice = true;
                        break;
                    case "3":
                        attack = AttackTypes.Regenerate;
                        validChoice = true;
                        break;
                    case "4":
                        attack = AttackTypes.Medigel;
                        validChoice = true;
                        break;
                    default:
                        Console.WriteLine("Not a valid input! Try again.");
                        break;
                }
            }
        }
    }

    // game logic is in this class
    class Game
    {
        // properties
        public Player Player { get; set; }
        public Enemy Enemy { get; set; }

        // constructor
        // creates a new Player() and Enemy() object
        public Game()
        {
            this.Player = new Player(100);
            this.Enemy = new Enemy("Clan Leader", 200);
        }

        /// <summary>
        /// Displays combat info
        /// </summary>
        public void DisplayCombatInfo()
        {
            // changes HP text to red if HP is low
            if (this.Player.HP < 20)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("YOUR HP IS LOW! REGENERATE OR USE MEDI-GEL NOW! (max 100): {0}", this.Player.HP);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
                Console.WriteLine("Player's HP (max 100): {0}", this.Player.HP);

            Console.WriteLine("Medi-gel left: {0}", this.Player.Medigel);
            Console.WriteLine("{0}'s HP: {1}", this.Enemy.Name, this.Enemy.HP);
        }

        /// <summary>
        /// Displays the title of the game
        /// </summary>
        private void DisplayTitle()
        {
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
        }

        /// <summary>
        /// Game logic
        /// </summary>
        public void PlayGame()
        {
            // sets the window size and changes the colors in the console
            Console.SetWindowSize(125, 50);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            // loops while both the player and enemy are alive
            while (this.Player.IsAlive && this.Enemy.IsAlive)
            {
                // clears the console
                Console.Clear();
                // displays the title by calling DisplayTitle()
                DisplayTitle();
                // output dialogue
                Console.WriteLine("\n\n\n\nYou don't like how things are being run in your clan. Facing the clan leader with your complaints, he bashes his head\nagainst yours."
                        + " \"Face me, then,\" the clan leader growls. \"You're going to have to kill me if you want change.\" With no other\noptions, you prepare for battle.\n\n");
                // display combat info
                DisplayCombatInfo();
                Console.WriteLine("\n");
                // player attacks enemy
                this.Player.DoAttack(this.Enemy);
                // enemy attacks player
                this.Enemy.DoAttack(this.Player);
                
                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey();
            }
            // clear the console
            Console.Clear();
            // display the title
            DisplayTitle();

            // sets player or enemy HP to zero if it goes into the negatives
            if (this.Player.HP < 0)
                this.Player.HP = 0;

            if (this.Enemy.HP < 0)
                this.Enemy.HP = 0;
            
            // output this if both enemy and player are dead
            if (!this.Player.IsAlive && !this.Enemy.IsAlive)
                Console.WriteLine("\n\n\n\nBoth you and the clan leader die from the wounds sustained in battle. Who will lead the clan now?! You've failed!\n\n\n\n");
            // ouput this if the player is alive and the enemy is dead
            else if (this.Player.IsAlive)
                Console.WriteLine("\n\n\n\nWith the krogan clan leader killed, you've gained the respect of the other clan members. Congratulations! You are now the\nnew clan leader!\n\n\n");
            // output this if the player is dead and the enemy is alive
            else
                Console.WriteLine("\n\n\n\nThe krogan clan leader stomps on your corpse and chuckles darkly. \"Anyone else wanna try a revolution?!\" he snarls. You've\nfailed!\n\n\n");
            // display the combat info
            DisplayCombatInfo();
            // ask user if s/he wants to play again
            Console.WriteLine("\n\nPlay again (Y/N)?");
            bool validChoice = false;

            // loop while validChoice is false
            // verifies the input from the user
            while (!validChoice)
            {
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "Y":
                        this.Player.HP = 100;
                        this.Enemy.HP = 200;
                        validChoice = true;
                        this.PlayGame();
                        break;
                    case "y":
                        this.Player.HP = 100;
                        this.Enemy.HP = 200;
                        validChoice = true;
                        this.PlayGame();
                        break;
                    case "N":
                        validChoice = true;
                        break;
                    case "n":
                        validChoice = true;
                        break;
                    default:
                        Console.WriteLine("Not a valid input! Try again.");
                        break;
                }
            }

            // thank the player for playing and tell him/her to press any key to exit
            Console.WriteLine("\nThank you for playing!");
            Console.WriteLine("Press any key to close the window . . .");
            Console.ReadKey();
        }
    }
}
