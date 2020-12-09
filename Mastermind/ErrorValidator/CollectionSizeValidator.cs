using System.Collections.Generic;

namespace Mastermind
{
    public class CollectionSizeValidator : IErrorValidator
    {
        private int _numberOfWinningColours;

        public CollectionSizeValidator(int numberOfWinningColours)
        {
            _numberOfWinningColours = numberOfWinningColours;
        }
        public string ErrorMessage {get;} = ErrorMessages.SizeError;
        public bool IsValid(List<string> inputColours)
        {
            return inputColours.Count.Equals(_numberOfWinningColours);
        }
    }
}