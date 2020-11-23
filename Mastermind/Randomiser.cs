using System;

namespace Mastermind
{
    public class Randomiser : IRandomiser
    {
        public int GenerateRandomNumber(int maxValue)
        {
            var rand = new Random();
            return rand.Next(maxValue);
        }
    }
}