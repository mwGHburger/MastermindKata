using System.Collections.Generic;
using System.Linq;

namespace Mastermind
{
    public class WinnerValidator
    {
        public bool isWinner(List<string> inputColours, List<string> winningColours)
        {
            return winningColours.SequenceEqual(inputColours);
        }
    }
}