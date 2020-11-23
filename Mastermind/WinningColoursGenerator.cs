using System.Reflection.Emit;
using System.Collections.Generic;

namespace Mastermind
{
    public class WinningColoursGenerator : IWinningColoursGenerator
    {
        private IRandomiser _randomiser;
        private List<string> _validColours;

        public WinningColoursGenerator(IRandomiser randomiser, List<string> validColours)
        {
            _randomiser = randomiser;
            _validColours = validColours;
        }
        public List<string> Generate()
        {
            var winningColours = new List<string>();
            for(int i = 0;i < 4;i++)
            {
                var randomPosition = _randomiser.GenerateRandomNumber(_validColours.Count);
                winningColours.Add(_validColours[randomPosition]);
            }
            return winningColours;
        }
    }
}