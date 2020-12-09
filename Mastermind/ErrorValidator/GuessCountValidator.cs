using System.Collections.Generic;

namespace Mastermind
{
    public class GuessCountValidator : IErrorValidator
    {
        private ICounter _guessCounter;
        private IApplicationStopper _applicationStopper;
        private int _maxGuesses;
        public string ErrorMessage {get;} = ErrorMessages.GuessCountError;

        public GuessCountValidator(ICounter guessCounter, IApplicationStopper applicationStopper, int maxGuesses)
        {
            _guessCounter = guessCounter;
            _applicationStopper = applicationStopper;
            _maxGuesses = maxGuesses;
        }

        public bool IsValid(List<string> inputColours)
        {
            if (_guessCounter.CurrentCount < _maxGuesses)
            {
                return true;
            }
            _applicationStopper.StopApplication = true;
            return false;
        }
    }
}