using System.Collections.Generic;

namespace Mastermind
{
    public interface IErrorsValidator
    {
        void Check(List<string> inputColours);
    }
}