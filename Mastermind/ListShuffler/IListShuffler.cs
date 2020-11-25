using System.Collections.Generic;

namespace Mastermind
{
    public interface IListShuffler
    {
        List<string> Shuffle(List<string> inputList);
    }
}