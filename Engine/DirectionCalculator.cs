using System;

namespace Engine
{
    public class DirectionCalculator
    {
        public const int North = 0;
        public const int East = 1;
        public const int South = 2;
        public const int West = 3;

        public static int RandomDirection()
        {
            return new Random().Next(4);
        }
        public static int Reverse(int i)
        {
            return (i + 2) % 4;
        }

        public static int TurnLeft(int i)
        {
            return (i - 1 + 4) % 4;
        }

        public static int TurnRight(int i)
        {
            return (i + 1) % 4;
        }
    }
}