using System.Collections.Generic;

namespace Mastermind
{
    public class GuessCountValidator : IErrorValidator
    {
        private ICounter _guessCounter;
        private IApplicationStopper _applicationStopper;
        private int _maxGuesses;
        public string ErrorMessage {get;} = "Too many guesses";

        public GuessCountValidator(ICounter guessCounter, IApplicationStopper applicationStopper, int maxGuesses)
        {
            _guessCounter = guessCounter;
            _applicationStopper = applicationStopper;
            _maxGuesses = maxGuesses;
        }

        public bool IsValid(List<string> collection)
        {
            _applicationStopper.StopApplication = true;
            return _guessCounter.CurrentCount <= _maxGuesses;
        }
    }
}