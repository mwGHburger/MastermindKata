using System.Collections.Generic;

namespace Mastermind
{
    public interface IErrorValidator
    {
        string ErrorMessage {get;}
        void Validate(List<string> inputColours);
    }
}