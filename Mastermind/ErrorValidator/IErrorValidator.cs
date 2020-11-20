using System.Collections.Generic;

namespace Mastermind
{
    public interface IErrorValidator
    {
        string ErrorMessage {get;}
        bool IsValid(List<string> collection);
    }
}