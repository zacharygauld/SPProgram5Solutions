using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Hyperspace
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey input;
            bool inputValid = false;
            // game loop
            do
            {
                inputValid = false;
                // create new Hyperspace object
                Hyperspace hyperspace = new Hyperspace();
                Console.ReadKey();
                // play the game while the player hasn't been smashed
                while (!hyperspace.Smashed)
                    hyperspace.PlayGame();
                // death message
                Console.BackgroundColor = ConsoleColor.Red;
                hyperspace.PrintAtPosition(20, 4, "YOU CRASHED AND BURNED!!!", ConsoleColor.White);
                Console.BackgroundColor = ConsoleColor.Black;
                // ask player if s/he'd like to play again?
                hyperspace.PrintAtPosition(20, 5, "Would you like to play again? (Y/N)", ConsoleColor.Green);

                // input validation
                do
                {
                    input = Console.ReadKey(true).Key;
                    if (input == ConsoleKey.Y || input == ConsoleKey.N)
                        inputValid = true;
                } while (!inputValid); 
            } while (input == ConsoleKey.Y);
        }
    }

    class Unit
    {
        // properties
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor Color { get; set; }
        public string Symbol { get; set; }
        public bool IsSpaceRift { get; set; }

        // variables
        static List<string> ObstacleList = new List<string>() { "*", "!", ".", ":", ";", ":", "'" };
        static Random rng = new Random();

        // constructors
        public Unit(int x, int y)
        {
            X = x;
            Y = y;
            Color = ConsoleColor.Cyan;
            Symbol = ObstacleList[rng.Next(0, ObstacleList.Count())];
        }

        public Unit(int x, int y, ConsoleColor color, string symbol, bool isSpaceRift)
        {
            X = x;
            Y = y;
            Color = color;
            Symbol = symbol;
            IsSpaceRift = isSpaceRift;
        }

        /// <summary>
        /// Draw the symbol
        /// </summary>
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = Color;
            Console.Write(Symbol);
        }
    }

    class Hyperspace
    {
        // properties
        public int Score { get; set; }
        public int Speed { get; set; }
        public List<Unit> ObstacleList { get; set; }
        public Unit SpaceShip { get; set; }
        public bool Smashed { get; set; }

        // variables
        private Random rng = new Random();

        // constructor
        public Hyperspace()
        {
            Score = 0;
            Speed = 0;
            ObstacleList = new List<Unit>();
            Console.SetWindowSize(60, 50);
            Console.SetBufferSize(60, 50);
            SpaceShip = new Unit((Console.WindowWidth / 2) - 1, Console.WindowHeight - 1, ConsoleColor.Red, "^", false);
        }

        /// <summary>
        /// Game logic
        /// </summary>
        public void PlayGame()
        {
            Random rng = new Random();

            // 10% chance of creating a rift
            if (rng.Next(1, 11) > 9)
                ObstacleList.Add(new Unit(rng.Next(0, (Console.WindowWidth - 1)), 5, ConsoleColor.Green, "%", true));
            else
                ObstacleList.Add(new Unit(rng.Next(0, (Console.WindowWidth - 1)), 5));

            // call MoveShip(), MoveObstacles(), and DrawGame()
            MoveShip();
            MoveObstacles();
            DrawGame();

            // increment the speed if the speed is less than 170
            if (Speed < 170)
                Speed++;

            Thread.Sleep(170 - Speed);

            // fun message
            if (Speed == 170)
                PrintAtPosition(20, 4, "LUDRICOUS SPEED!!!", ConsoleColor.White);
        }

        /// <summary>
        /// Moves the ship
        /// </summary>
        void MoveShip()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey();
                while (Console.KeyAvailable) { Console.ReadKey(true); }

                if (keyPressed.Key == ConsoleKey.LeftArrow && SpaceShip.X > 0)
                    SpaceShip.X--;

                else if (keyPressed.Key == ConsoleKey.RightArrow && SpaceShip.X < (Console.WindowWidth - 2))
                    SpaceShip.X++;
            }
        }

        /// <summary>
        /// Scrolls the obstacles down the screen
        /// </summary>
        void MoveObstacles()
        {
            List<Unit> newObstacleList = new List<Unit>();
            foreach (Unit unit in ObstacleList)
            {
                unit.Y++;
                if (unit.IsSpaceRift == true && unit.X == SpaceShip.X && unit.Y == SpaceShip.Y)
                {
                    if (Speed >= 50)
                        Speed -= 50;
                    else
                        Speed = 0;
                }


                if (unit.IsSpaceRift == false && unit.X == SpaceShip.X && unit.Y == SpaceShip.Y)
                    Smashed = true;

                if (unit.Y < Console.WindowHeight)
                    newObstacleList.Add(unit);
                else
                    Score++;

                ObstacleList = newObstacleList;
            }
        }

        /// <summary>
        /// Draws the game on the console window
        /// </summary>
        void DrawGame()
        {
            Console.Clear();
            SpaceShip.Draw();
            foreach (Unit unit in ObstacleList)
                unit.Draw();

            PrintAtPosition(20, 2, "Score: " + Score, ConsoleColor.Green);
            PrintAtPosition(20, 3, "Speed: " + Speed, ConsoleColor.Green);
        }

        /// <summary>
        /// Prints a string at a particular position
        /// </summary>
        /// <param name="x">X coordinate to print at</param>
        /// <param name="y">Y coordinate to print at</param>
        /// <param name="text">Text to print</param>
        /// <param name="color">Color to print the text</param>
        public void PrintAtPosition(int x, int y, string text, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(text);
        }
    }
}
