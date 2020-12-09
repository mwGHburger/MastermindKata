using System;
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
        public void Validate(List<string> inputColours)
        {
            if(!inputColours.Count.Equals(_numberOfWinningColours))
            {
                throw new ArgumentException(ErrorMessage);
            };
        }
    }
}