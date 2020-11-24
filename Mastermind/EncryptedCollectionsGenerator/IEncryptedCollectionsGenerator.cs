using System.Collections.Generic;

namespace Mastermind
{
    public interface IEncryptedCollectionsGenerator
    {
        List<string> Generate(List<string> inputColours, List<string> winningColours);
    }
}