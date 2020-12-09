// TODO: Delete this interface
using System.Collections.Generic;

namespace Mastermind
{
    public interface IErrorsValidator
    {
        void Validate(List<string> inputColours);
    }
}