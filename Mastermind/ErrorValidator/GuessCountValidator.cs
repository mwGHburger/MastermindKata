namespace Mastermind
{
    public class GuessCountValidator
    {
        private ICounter _guessCounter;
        private IApplicationStopper _applicationStopper;
        private int _maxGuesses;

        public GuessCountValidator(ICounter guessCounter, IApplicationStopper applicationStopper, int maxGuesses)
        {
            _guessCounter = guessCounter;
            _applicationStopper = applicationStopper;
            _maxGuesses = maxGuesses;
        }

        public bool isValid()
        {
            _applicationStopper.StopApplication = true;
            return _guessCounter.CurrentCount <= _maxGuesses;
        }
    }
}