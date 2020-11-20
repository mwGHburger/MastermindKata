using System.Reflection.Emit;
using System.Collections.Generic;

namespace Mastermind
{
    public class WinningColoursGenerator
    {
        private IRandomiser _randomiser;

        public WinningColoursGenerator(IRandomiser randomiser)
        {
            _randomiser = randomiser;
        }
        public List<string> GenerateColours(List<string> validColours)
        {
            var winningColours = new List<string>();
            for(int i = 0;i < 4;i++)
            {
                var randomPosition = _randomiser.GenerateRandomNumber(validColours.Count);
                winningColours.Add(validColours[randomPosition]);
            }
            return winningColours;
        }
    }
}