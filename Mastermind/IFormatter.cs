using System.Collections.Generic;

namespace Mastermind
{
    public interface IFormatter
    {
        List<string> ConvertToList(string input);
        string ConvertToString(List<string> list);
        
    }
}