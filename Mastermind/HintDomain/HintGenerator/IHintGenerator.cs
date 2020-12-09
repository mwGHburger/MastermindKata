using System.Collections.Generic;

namespace Mastermind
{
    public interface IHintGenerator
    {
        List<string> Generate(List<string> inputColours, List<string> winningColours);
    }
}