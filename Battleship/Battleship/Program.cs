using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            // create validation loop for playing again and start the game
            bool validation = false;
            ConsoleKey input = ConsoleKey.Z;
            do
            {
                validation = false;
                Grid grid = new Grid();
                grid.PlayGame();
                Console.WriteLine("Would you like to play again? (Y/N)");
                while (!validation)
                {
                    input = Console.ReadKey(true).Key;
                    if (input == ConsoleKey.Y || input == ConsoleKey.N)
                        validation = true;
                }
            } while (input == ConsoleKey.Y);

            // thank the user for playing
            Console.Clear();
            Console.WriteLine("Thanks for playing! Press any key to exit . . .");
            Console.ReadKey();
        }
    }

    class Point
    {
        // enumeration
        public enum PointStatus { Empty, Ship, Hit, Miss }

        // properties
        public int X { get; set; }
        public int Y { get; set; }
        public PointStatus Status { get; set; }

        // constructor
        public Point(int x, int y, PointStatus p)
        {
            this.X = x;
            this.Y = y;
            this.Status = p;
        }
    }

    class Ship
    {
        // enumeration
        public enum ShipType { Carrier, Battleship, Cruiser, Submarine, Minesweeper }

        // properties
        public ShipType Type { get; set; }
        public List<Point> OccupiedPoints { get; set; }
        public int Length { get; set; }
        public bool HasDisplayedMessage { get; set; }
        private bool _isDestroyed;
        public bool IsDestroyed
        {
            get
            {
                // this logic will check if a ship is destroyed or not
                bool destroyed = false;
                foreach (Point point in OccupiedPoints)
                {
                    if (point.Status == Point.PointStatus.Hit)
                        destroyed = true;
                    else
                    {
                        destroyed = false;
                        break;
                    }
                }
                if (destroyed)
                {
                    if (!HasDisplayedMessage)
                    {
                        Console.WriteLine("\nYou sunk the {0}!", this.Type);
                        Console.WriteLine("Press any key to continue . . .");
                        Console.ReadKey();
                        HasDisplayedMessage = true;
                    }
                }
                return destroyed;
            }
        }

        // constructor
        public Ship(ShipType typeOfShip)
        {
            this.OccupiedPoints = new List<Point>();
            this.Type = typeOfShip;

            // length of the ship corresponds with the type of ship
            switch (this.Type)
            {
                case ShipType.Carrier:
                    this.Length = 5;
                    break;
                case ShipType.Battleship:
                    this.Length = 4;
                    break;
                case ShipType.Cruiser:
                    this.Length = 3;
                    break;
                case ShipType.Submarine:
                    this.Length = 3;
                    break;
                case ShipType.Minesweeper:
                    this.Length = 2;
                    break;
                default:
                    break;
            }

            HasDisplayedMessage = false;
        }
    }

    class Grid
    {
        // enumeration
        public enum PlaceShipDirection { Horizontal, Vertical }

        // properties
        public Point[,] Ocean { get; set; }
        public List<Ship> ListOfShips { get; set; }
        private bool _allShipsDestroyed;
        public bool AllShipsDestroyed
        {
            get
            {
                bool allDestroyed = false;
                foreach (Ship ship in ListOfShips)
                {
                    if (ship.IsDestroyed)
                        allDestroyed = true;
                    else
                    {
                        allDestroyed = false;
                        break;
                    }
                }

                return allDestroyed;  
            }
        }
        public int CombatRound { get; set; }

        // constructor
        public Grid()
        {
            // make the ocean
            this.Ocean = new Point[10, 10];

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                    this.Ocean[x, y] = new Point(x, y, Point.PointStatus.Empty);
            }

            // create ships and put them in the ship list
            this.ListOfShips = new List<Ship>();
            this.ListOfShips.Add(new Ship(Ship.ShipType.Carrier));
            this.ListOfShips.Add(new Ship(Ship.ShipType.Battleship));
            this.ListOfShips.Add(new Ship(Ship.ShipType.Cruiser));
            this.ListOfShips.Add(new Ship(Ship.ShipType.Submarine));
            this.ListOfShips.Add(new Ship(Ship.ShipType.Minesweeper));

            // randomly place the ships on the grid, making sure the ship won't go out of bounds or is on top of another ship
            Random rng = new Random();
            foreach (Ship ship in ListOfShips)
            {
                bool validPlacement = false;
                PlaceShipDirection direction = (PlaceShipDirection)rng.Next(0, 2);
                int startX = 0;
                int startY = 0;
                int xToCheck = 0;
                int yToCheck = 0;
                int check = 0;
                // checks if the ship will go out of bounds
                while (!validPlacement)
                {
                    direction = (PlaceShipDirection)rng.Next(0, 2);
                    startX = rng.Next(0, 10);
                    startY = rng.Next(0, 10);
                    xToCheck = startX;
                    yToCheck = startY;

                    switch (direction)
                    {
                        case PlaceShipDirection.Horizontal:
                            while (ship.Length > (9 - startX))
                            {
                                startX = rng.Next(0, 10);
                                xToCheck = startX;
                            }
                            break;
                        case PlaceShipDirection.Vertical:
                            while (ship.Length > (9 - startY))
                            {
                                startY = rng.Next(0, 10);
                                yToCheck = startY;
                            }
                            break;
                        default:
                            break;
                    }
                    // checks to see if there's a ship in the way
                    while (Ocean[xToCheck, yToCheck].Status == Point.PointStatus.Empty && check < ship.Length)
                    {
                        switch (direction)
                        {
                            case PlaceShipDirection.Horizontal:
                                xToCheck++;
                                check++;
                                break;
                            case PlaceShipDirection.Vertical:
                                yToCheck++;
                                check++;
                                break;
                            default:
                                break;
                        }
                    }
                    if (Ocean[xToCheck, yToCheck].Status == Point.PointStatus.Empty)
                    {
                        PlaceShip(ship, direction, startX, startY);
                        validPlacement = true;
                    }
                }
            }
        }

        /// <summary>
        /// Places the ship in the grid
        /// </summary>
        /// <param name="shipToPlace">Ship to place</param>
        /// <param name="direction">Direction to place the ship</param>
        /// <param name="startX">Starting X position of the ship</param>
        /// <param name="startY">Starting Y position of the ship</param>
        void PlaceShip(Ship shipToPlace, PlaceShipDirection direction, int startX, int startY)
        {
            for (int i = 0; i < shipToPlace.Length; i++)
            {
                this.Ocean[startX, startY].Status = Point.PointStatus.Ship;
                shipToPlace.OccupiedPoints.Add(this.Ocean[startX, startY]);

                switch (direction)
                {
                    case PlaceShipDirection.Horizontal:
                        startX++;
                        break;
                    case PlaceShipDirection.Vertical:
                        startY++;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Writes the ocean grid to the console
        /// </summary>
        void DisplayOcean()
        {
            Console.WriteLine("   0  1  2  3  4  5  6  7  8  9");
            for (int y = 0; y < 10; y++)
            {
                Console.Write("{0} ", y);
                for (int x = 0; x < 10; x++)
                {
                    switch (Ocean[x, y].Status)
                    {
                        case Point.PointStatus.Empty:
                            Console.Write("[ ]");
                            break;
                        case Point.PointStatus.Ship:
                            Console.Write("[ ]");
                            break;
                        case Point.PointStatus.Hit:
                            Console.Write("[X]");
                            break;
                        case Point.PointStatus.Miss:
                            Console.Write("[O]");
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Player's target
        /// </summary>
        /// <param name="x">Targeted X coordinate</param>
        /// <param name="y">Targeted Y coordinate</param>
        /// <returns>Returns true if the current amount of ships destroyed is more than the previous amount of ships</returns>
        bool Target(int x, int y)
        {
            int numberOfShipsDestroyed = ListOfShips.Where(z => z.IsDestroyed).Count();
            if (Ocean[x, y].Status == Point.PointStatus.Ship)
            {
                Ocean[x, y].Status = Point.PointStatus.Hit;
                Console.WriteLine("\nHIT!");
                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey();

            }
            else if (Ocean[x, y].Status == Point.PointStatus.Empty)
            {
                Ocean[x, y].Status = Point.PointStatus.Miss;
                Console.WriteLine("\nMISS!");
                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nYou've already attacked that coordinate!");
                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey();
            }

            int numberOfShipsDestroyedNow = ListOfShips.Where(z => z.IsDestroyed).Count();

            if (numberOfShipsDestroyedNow > numberOfShipsDestroyed)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Game logic
        /// </summary>
        public void PlayGame()
        {
            int x = 0;
            int y = 0;

            // loops while there are ships that still have not been sunk
            while (!AllShipsDestroyed)
            {
                bool validInput = false;
                Console.Clear();
                DisplayOcean();
                // input validation loop for X
                while (!validInput)
                {
                    Console.WriteLine("\nEnter an X coordinate: ");
                    bool xIsNumber = int.TryParse(Console.ReadLine(), out x);
                    if (!xIsNumber)
                        Console.WriteLine("Not a valid X coordinate!");
                    else if (x < 0 || x > 9)
                        Console.WriteLine("Not a valid X coordinate!");
                    else
                        validInput = true;
                }
                validInput = false;
                // input validation loop for Y
                while (!validInput)
                {
                    Console.WriteLine("\nEnter a Y coordinate: ");
                    bool yIsNumber = int.TryParse(Console.ReadLine(), out y);
                    if (!yIsNumber)
                        Console.WriteLine("Not a valid Y coordinate!");
                    else if (y < 0 || y > 9)
                        Console.WriteLine("Not a valid Y coordinate!");
                    else
                        validInput = true;
                }

                // call Target() function with the X and Y coordinates
                Target(x, y);
                // increment the combat round
                CombatRound++;
            }

            // clear the console
            Console.Clear();

            // display the ocean
            DisplayOcean();

            // tell how well the player did
            Console.WriteLine("\nYou've destroyed all the ships! It took you {0} turns.", CombatRound);
        }
    }
}
