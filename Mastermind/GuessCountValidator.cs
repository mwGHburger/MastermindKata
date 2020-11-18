namespace Mastermind
{
    public class GuessCountValidator
    {
        private ICounter _guessCounter;
        private int _maxGuesses;

        public GuessCountValidator(ICounter guessCounter, int maxGuesses)
        {
            _guessCounter = guessCounter;
            _maxGuesses = maxGuesses;
        }

        public bool Validate()
        {
            return _guessCounter.CurrentCount <= _maxGuesses;
        }
    }
}