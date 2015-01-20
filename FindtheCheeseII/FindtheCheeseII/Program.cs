using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindtheCheeseII
{
    class Program
    {
        static void Main(string[] args)
        {
            // declare variables
            bool playing = true;
            bool validChoice = false;
            string input = string.Empty;
            // loop while playing is true
            while (playing)
            {
                CheeseFinder cheeseFinder = new CheeseFinder();
                cheeseFinder.PlayGame();

                // check to see if the user enters a valid choice
                while (!validChoice)
                {
                    Console.WriteLine("Would you like to play again? (Y/N)");
                    input = Console.ReadLine();
                    if (input == "N" || input == "n")
                    {
                        playing = false;
                        validChoice = true;
                    }
                    else if (!(input == "Y" || input == "y"))
                        Console.WriteLine("Not a valid input!");
                    else
                        validChoice = true;
                }

                validChoice = false;
            }

            // thank the user for playing
            Console.WriteLine("Thank you for playing! Press any key to exit . . .");
            Console.ReadKey();
        }
    }

    class Point
    {
        // enumerations
        public enum PointStatus { Empty, Cheese, Mouse, Cat, CatAndCheese }

        // properties
        public int X { get; set; }
        public int Y { get; set; }
        public PointStatus Status { get; set; }

        // constructor
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    class Mouse
    {
        // properties
        public Point Position { get; set; }
        public int Energy { get; set; }
        public bool HasBeenPouncedOn { get; set; }

        // constructor
        public Mouse()
        {
            this.Energy = 50;
        }
    }

    class Cat
    {
        // properties
        public Point Position { get; set; }

        // constructor
        public Cat()
        {

        }
    }

    class CheeseFinder
    {
        // properties
        public Point[,] Grid { get; set; }
        public Mouse Mouse { get; set; }
        public Point Cheese { get; set; }
        public int CheeseCount { get; set; }
        public List<Cat> Cats { get; set; }
        public int CatIndex { get; set; }

        // constructor
        public CheeseFinder()
        {
            this.Mouse = new Mouse();
            this.Cats = new List<Cat>();
            Random rng = new Random();
            this.Grid = new Point[10, 10];
            this.CatIndex = 0;

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                    Grid[x, y] = new Point(x, y);
            }

            this.Mouse.Position = this.Grid[rng.Next(0, 10), rng.Next(0, 10)];
            this.Mouse.Position.Status = Point.PointStatus.Mouse;
        }

        // methods
        /// <summary>
        /// Draw the grid
        /// </summary>
        public void DrawGrid()
        {
            // clear the console
            Console.Clear();
            // draw the grid
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                    switch (Grid[x, y].Status)
                    {
                        case Point.PointStatus.Empty:
                            Console.Write("[ ]");
                            break;
                        case Point.PointStatus.Cheese:
                            Console.Write("[C]");
                            break;
                        case Point.PointStatus.Mouse:
                            Console.Write("[M]");
                            break;
                        case Point.PointStatus.Cat:
                            Console.Write("[X]");
                            break;
                        case Point.PointStatus.CatAndCheese:
                            Console.Write("[X]");
                            break;
                        default:
                            break;
                    }
                // make a new line for the next line of the grid
                Console.WriteLine();
            }

            // write player stats
            Console.WriteLine("Cheese count: {0}", CheeseCount);
            Console.WriteLine("Mouse energy: {0}", Mouse.Energy);
        }
        /// <summary>
        /// Check to see if the user's move is valid
        /// </summary>
        /// <returns>Returns the key if it's valid</returns>
        public ConsoleKey GetUserMove()
        {
            while (true)
            {
                ConsoleKeyInfo input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (ValidMove(input.Key))
                            return input.Key;
                        else
                            Console.WriteLine("Move is invalid!");
                        break;
                    case ConsoleKey.RightArrow:
                        if (ValidMove(input.Key))
                            return input.Key;
                        else
                            Console.WriteLine("Move is invalid!");
                        break;
                    case ConsoleKey.UpArrow:
                        if (ValidMove(input.Key))
                            return input.Key;
                        else
                            Console.WriteLine("Move is invalid!");
                        break;
                    case ConsoleKey.DownArrow:
                        if (ValidMove(input.Key))
                            return input.Key;
                        else
                            Console.WriteLine("Move is invalid!");
                        break;
                    default:
                        Console.WriteLine("Key is invalid!");
                        break;
                }
            }
        }

        /// <summary>
        /// Checks to see if the user pressed a valid key
        /// </summary>
        /// <param name="input">Input to check</param>
        /// <returns>True if the move is valid, false if not</returns>
        public bool ValidMove(ConsoleKey input)
        {
            switch (input)
            {
                case ConsoleKey.LeftArrow:
                    if (this.Mouse.Position.X == 0)
                        return false;
                    else
                    {
                        MoveMouse(input);
                        return true;
                    }

                case ConsoleKey.RightArrow:
                    if (this.Mouse.Position.X == 9)
                        return false;
                    else
                    {
                        MoveMouse(input);
                        return true;
                    }

                case ConsoleKey.UpArrow:
                    if (this.Mouse.Position.Y == 0)
                        return false;
                    else
                    {
                        MoveMouse(input);
                        return true;
                    }
 
                case ConsoleKey.DownArrow:
                    if (this.Mouse.Position.Y == 9)
                        return false;
                    else
                    {
                        MoveMouse(input);
                        return true;
                    }

                default:
                    return false;

            }
        }

        /// <summary>
        /// Moves the mouse
        /// </summary>
        /// <param name="input">User's input key</param>
        public void MoveMouse(ConsoleKey input)
        {
            int previousX = Mouse.Position.X;
            int previousY = Mouse.Position.Y;

            Grid[previousX, previousY].Status = Point.PointStatus.Empty;
            switch (input)
            {
                case ConsoleKey.LeftArrow:
                    this.Mouse.Position.X--;
                    break;
                case ConsoleKey.RightArrow:
                    this.Mouse.Position.X++;
                    break;
                case ConsoleKey.UpArrow:
                    this.Mouse.Position.Y--;
                    break;
                case ConsoleKey.DownArrow:
                    this.Mouse.Position.Y++;
                    break;
                default:
                    break;
            }
            this.Grid[Mouse.Position.X, Mouse.Position.Y].Status = Point.PointStatus.Mouse;

            // if the mouse moves on the cheese
            if (this.Grid[Mouse.Position.X, Mouse.Position.Y] == this.Grid[Cheese.X, Cheese.Y])
            {
                CheeseCount++;
                Mouse.Energy += 10;
                PlaceCheese();
                if (CheeseCount % 2 == 0)
                    AddCat();
            }
            else
                Mouse.Energy--;
        }

        /// <summary>
        /// Places the cheese
        /// </summary>
        public void PlaceCheese()
        {
            Random rng = new Random();
            int x = 0;
            int y = 0;

            // places the cheese into a random spot
            do
            {
                x = rng.Next(0, 10);
                y = rng.Next(0, 10);
                this.Cheese = this.Grid[x, y];
            } while (Grid[x, y].Status != Point.PointStatus.Empty);

            Grid[x, y].Status = Point.PointStatus.Cheese;
        }

        /// <summary>
        /// Add the cat
        /// </summary>
        public void AddCat()
        {
            // add a new cat
            Cats.Add(new Cat());
            // calls the PlaceCat() function with a cat at the current CatIndex
            PlaceCat(Cats[this.CatIndex]);
            this.CatIndex++;
        }

        /// <summary>
        /// Place a cat in a random area of the grid
        /// </summary>
        /// <param name="cat">Cat to place</param>
        public void PlaceCat(Cat cat)
        {
            Random rng = new Random();
            int x = 0;
            int y = 0;

            do
            {
                x = rng.Next(0, 10);
                y = rng.Next(0, 10);
                cat.Position = this.Grid[x, y];
            } while (Grid[x, y].Status != Point.PointStatus.Empty);

            cat.Position.Status = Point.PointStatus.Cat;
        }

        /// <summary>
        /// Moves the cat
        /// </summary>
        /// <param name="cat">Cat to move</param>
        public void MoveCat(Cat cat)
        {
            int relativeX = Mouse.Position.X - cat.Position.X;
            int relativeY = Mouse.Position.Y - cat.Position.Y;

            // checks directions the cat can go
            bool tryLeft = relativeX < 0;
            bool tryRight = relativeX > 0;
            bool tryUp = relativeY < 0;
            bool tryDown = relativeY > 0;
            bool validMove = false;

            int startingX = cat.Position.X;
            int startingY = cat.Position.Y;

            // make a new RNG
            // 80% chance to move
            Random rng = new Random();
            if (rng.Next(1, 6) < 4)
            {
                while (!validMove && (tryLeft || tryRight || tryUp || tryDown))
                {
                    if (tryLeft)
                    {
                        cat.Position.X--;
                        tryLeft = false;
                    }
                    if (tryRight)
                    {
                        cat.Position.X++;
                        tryRight = false;
                    }
                    if (tryUp)
                    {
                        cat.Position.Y--;
                        tryUp = false;
                    }
                    if (tryDown)
                    {
                        cat.Position.Y++;
                        tryDown = false;
                    }
                }

                cat.Position.Status = Grid[cat.Position.X, cat.Position.Y].Status;
                Point targetPosition = cat.Position;

                // if the cat makes a valid move
                if (IsValidCatMove(targetPosition))
                {
                    if (Grid[startingX, startingY].Status == Point.PointStatus.CatAndCheese)
                        Grid[startingX, startingY].Status = Point.PointStatus.Cheese;
                    else
                        Grid[startingX, startingY].Status = Point.PointStatus.Empty;

                    if (Grid[cat.Position.X, cat.Position.Y] == Grid[Mouse.Position.X, Mouse.Position.Y])
                    {
                        Mouse.HasBeenPouncedOn = true;
                        Grid[cat.Position.X, cat.Position.Y].Status = Point.PointStatus.Cat;
                    }
                    else if (Grid[cat.Position.X, cat.Position.Y] == Grid[Cheese.X, Cheese.Y])
                        Grid[cat.Position.X, cat.Position.Y].Status = Point.PointStatus.CatAndCheese;
                    else
                        Grid[cat.Position.X, cat.Position.Y].Status = Point.PointStatus.Cat;
                }
            }
        }

        /// <summary>
        /// Checks if the cat is making a valid move
        /// </summary>
        /// <param name="targetPosition">The position to check</param>
        /// <returns>True if the move is valid, false if it is invalid</returns>
        public bool IsValidCatMove(Point targetPosition)
        {
            if (targetPosition.Status == Point.PointStatus.Empty || targetPosition.Status == Point.PointStatus.Mouse)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Main game loop
        /// </summary>
        public void PlayGame()
        {
            // place the cheese
            PlaceCheese();
            
            // loop while the mouse is still alive and hasn't been pounced on
            while (Mouse.Energy > 0 && Mouse.HasBeenPouncedOn == false)
            {
                // draw the grid
                DrawGrid();
                // get the user move
                GetUserMove();

                // move each cat in the Cat list
                foreach (Cat cat in Cats)
                    MoveCat(cat);
            }
            // removes mouse point for debugging purposes
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (Grid[x, y].Status == Point.PointStatus.Mouse)
                        Grid[x, y].Status = Point.PointStatus.Empty;
                }
            }
            // draw the grid
            DrawGrid();

            // output a message depending on the circumstance
            if (Mouse.Energy == 0 && Mouse.HasBeenPouncedOn == false)
            {
                Console.WriteLine("You've lost all of your energy!");
                Console.WriteLine("You have consumed {0} cheese(s).", CheeseCount);
            }
            else
            {
                Console.WriteLine("You've been pounced on by a cat!");
                Console.WriteLine("You have consumed {0} cheese(s).", CheeseCount);
            }
        }
    }
}
