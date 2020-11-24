using System.Reflection.Emit;
using System.Collections.Generic;

namespace Mastermind
{
    public class WinningColoursGenerator : IWinningColoursGenerator
    {
        private IRandomiser _randomiser;
        private List<string> _validColours;
        private int _numberOfWinningColours;

        public WinningColoursGenerator(IRandomiser randomiser, List<string> validColours, int numberOfWinningColours)
        {
            _randomiser = randomiser;
            _validColours = validColours;
            _numberOfWinningColours = numberOfWinningColours;
        }
        public List<string> Generate()
        {
            var winningColours = new List<string>();
            for(int i = 0;i < _numberOfWinningColours; i++)
            {
                var randomPosition = _randomiser.GenerateRandomNumber(_validColours.Count);
                winningColours.Add(_validColours[randomPosition]);
            }
            return winningColours;
        }
    }
}