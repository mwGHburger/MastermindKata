using System.Collections.Generic;
using System.Linq;

namespace Mastermind
{
    public class WinnerValidator : IWinnerValidator
    {
        public bool isWinner(List<string> inputColours, List<string> winningColours)
        {
            return winningColours.SequenceEqual(inputColours);
        }
    }
}