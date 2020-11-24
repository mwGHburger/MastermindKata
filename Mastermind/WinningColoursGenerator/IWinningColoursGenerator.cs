using System.Collections.Generic;

namespace Mastermind
{
    public interface IWinningColoursGenerator
    {
        List<string> Generate();
    }
}