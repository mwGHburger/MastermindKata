using System.Collections.Generic;

namespace Mastermind
{
    public interface IWinnerValidator
    {
        bool isWinner(List<string> input, List<string> winningColours);
    }
}