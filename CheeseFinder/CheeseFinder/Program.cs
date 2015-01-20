using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheeseFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            CheeseFinder cheeseFinder = new CheeseFinder();
            cheeseFinder.DrawGrid();

            Console.ReadKey();
        }
    }

            public enum PointStatus { Empty, Cheese, Mouse }

    class Point
    {

        public int X { get; set; }
        public int Y { get; set; }
        public PointStatus Status { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    class CheeseFinder
    {
        public Point[,] Grid { get; set; }
        public Point Mouse { get; set; }
        public Point Cheese { get; set; }
        public int Round { get; set; }

        public CheeseFinder()
        {
            Random rng = new Random();
            this.Grid = new Point[10,10];

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                    Grid[x, y] = new Point(x, y);
            }

            this.Mouse = this.Grid[rng.Next(0, 10), rng.Next(0, 10)];

            do
            {
                this.Cheese = this.Grid[rng.Next(0, 10), rng.Next(0, 10)];
            } while (Cheese.X == Mouse.X && Cheese.Y == Mouse.Y);

            this.Mouse.Status = PointStatus.Mouse;
            this.Cheese.Status = PointStatus.Cheese;
        }

        public void DrawGrid()
        {
            Console.Clear();
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                    switch (Grid[x, y].Status)
                    {
                        case PointStatus.Empty:
                            Console.Write("[ ]");
                            break;
                        case PointStatus.Cheese:
                            Console.Write("[C]");
                            break;
                        case PointStatus.Mouse:
                            Console.Write("[M]");
                            break;
                        default:
                            break;
                    }
                Console.WriteLine();
            }
        }

        public ConsoleKey GetUserMove()
        {
            ConsoleKeyInfo input = Console.ReadKey();
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    if (ValidMove(input.Key))
                        return input.Key;
                    else
                        Console.WriteLine("Not a valid move!");
                    break;
                case ConsoleKey.DownArrow:
                    if (ValidMove(input.Key))
                        return input.Key;
                    else
                        Console.WriteLine("Not a valid move!");
                    break;
                case ConsoleKey.RightArrow:
                    if (ValidMove(input.Key))
                        return input.Key;
                    else
                        Console.WriteLine("Not a valid move!");
                    break;
                case ConsoleKey.LeftArrow:
                    if (ValidMove(input.Key))
                        return input.Key;
                    else
                        Console.WriteLine("Not a valid move!");
                    break;
                default:
                    break;
            }

            return input.Key;
        }

        public bool ValidMove(ConsoleKey input)
        {

            switch (input)
            {
                case ConsoleKey.LeftArrow:
                    if (Mouse.X == 0)
                        return false;
                    else
                        Mouse.X--;
                    break;
                case ConsoleKey.RightArrow:
                    if (Mouse.X == 9)
                        return false;
                    else
                        Mouse.X++;
                    break;
                case ConsoleKey.UpArrow:
                    if (Mouse.Y == 9)
                        return false;
                    else
                        Mouse.Y++;
                    break;
                case ConsoleKey.DownArrow:
                    if (Mouse.Y == 0)
                        return false;
                    else
                        Mouse.Y--;
                    break;
                default:
                    break;
            }

            return true;
        }

        public bool MoveMouse(ConsoleKey input)
        {

        }
    }
}
