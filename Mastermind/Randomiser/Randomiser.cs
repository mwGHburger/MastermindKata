using System;

namespace Mastermind
{
    public sealed class Randomiser : IRandomiser
    {
        private static readonly Randomiser instance = new Randomiser();
        public int GenerateRandomNumber(int maxValue)
        {
            var rand = new Random();
            return rand.Next(maxValue);
        }
        public static Randomiser Instance  
        {  
            get  
            {  
                return instance;  
            }  
        } 
    }
}