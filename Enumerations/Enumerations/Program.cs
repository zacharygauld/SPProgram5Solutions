using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumerations
{
    public enum Colors
    {
        Red, Green, Blue, Orange
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();
            myCar.Color = Colors.Red;
            myCar.SayColor();

            Console.ReadKey();
        }
    }

    public class Car
    {
        public Colors Color { get; set; }

        public void SayColor()
        {
            Console.WriteLine("{0}: {1}", (int)this.Color, this.Color);
        }

        public void EnumsWorkGreatWithSwitches()
        {
            switch (this.Color)
            {
                case Colors.Red:
                    break;
                case Colors.Green:
                    break;
                case Colors.Blue:
                    break;
                case Colors.Orange:
                    break;
                default:
                    break;
            }
        }
    }
}
