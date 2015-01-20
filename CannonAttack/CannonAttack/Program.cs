﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannonAttack
{
    class Program
    {
        private static readonly int MaxNumberOfShots = 50;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Cannon Attack");
            bool isStillPlaying = true;

            while (isStillPlaying)
            {
                bool isAHit = false;

                Cannon cannon = Cannon.GetInstance();
                while (!isAHit && cannon.Shots < MaxNumberOfShots)
                {
                    int angle;
                    int velocity;

                    Console.WriteLine("Target is at {0} meters", cannon.DistanceOfTarget);
                    GetInputVariable(out angle, out velocity);
                    var shot = cannon.Shoot(angle, velocity);
                    isAHit = shot.Item1;
                    Console.WriteLine(shot.Item2);
                }

                isStillPlaying = GetIsPlayingAgain();
                cannon.Reset();
            }
            Console.WriteLine("Thanks for playing Cannon Attack");
            Console.ReadKey();
        }

        private static bool GetIsPlayingAgain()
        {
            bool isPlayingAgain = false;
            bool validAnswer = false;
            while (!validAnswer)
            {
                Console.Write("Do you want to play again (y/n)?");
                string playAgain = Console.ReadLine();

                if (playAgain == "y" || playAgain == "Y")
                {
                    isPlayingAgain = true;
                    validAnswer = true;
                }

                if (playAgain == "n" || playAgain == "N")
                {
                    isPlayingAgain = false;
                    validAnswer = true;
                }
            }
            return isPlayingAgain;
        }

        private static void GetInputVariable(out int angle, out int velocity)
        {
            string angleBuffer;
            string velocityBuffer;

            Console.Write("Enter Angle(1-90):");
            angleBuffer = Console.ReadLine();
            if (!int.TryParse(angleBuffer, out angle))
            {
                Console.WriteLine("Not a number defaulting to 45");
                angle = 45;
            }

            Console.Write("Enter Velocity (meters per second):");
            velocityBuffer = Console.ReadLine();
            if (!int.TryParse(velocityBuffer, out velocity))
            {
                Console.WriteLine("Not a number defaulting to 100 meters per second");
                velocity = 100;
            }
        }
    }
}
