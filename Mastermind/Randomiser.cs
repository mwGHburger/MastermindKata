using System;

namespace Mastermind
{
    public class Randomiser
    {
        public int GenerateRandomNumber(int maxValue)
        {
            var rand = new Random();
            return rand.Next(maxValue);
        }
    }
}