
using System;

namespace GameAppLayered.Model
{
    internal class Game
    {
        public int NumberToGuess { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }

        public Game(int minRange, int maxRange)
        {
            MinRange = minRange;
            MaxRange = maxRange;
            Random random = new Random();
            NumberToGuess = random.Next(minRange, maxRange + 1);
        }
    }
}