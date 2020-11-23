using System.Collections.Generic;

namespace Mastermind
{
    public static class ClassInstantiatorFactory
    {
        private static int _maxGuesses = 60;
        private static ICounter _guessCounter = CreateGuessCounter();
        private static IApplicationStopper _applicationStopper = CreateApplicationStopper();
        public static MastermindApplication CreateMastermindApplication()
        {
            return new MastermindApplication(CreateUserInterface(), CreateFormatter(), CreateErrorsValidator(), CreateWinnerValidator(), CreateWinnerColoursGenerator(), CreateEncryptedCollectionsGenerator(), _applicationStopper, _guessCounter);
        }

        private static IUserInterface CreateUserInterface()
        {
            return new CommandLine();
        }

        private static IFormatter CreateFormatter()
        {
            return new Formatter();
        }

        private static IErrorsValidator CreateErrorsValidator()
        {
            return new InputErrorsValidator(CreateErrorValidators());
        }

        private static List<IErrorValidator> CreateErrorValidators()
        {
            return new List<IErrorValidator>()
            {
                new GuessCountValidator(_guessCounter, _applicationStopper, _maxGuesses),
                new CollectionSizeValidator(),
                new ColourNameValidator(CreateValidColours())
            };
        }

        private static List<string> CreateValidColours()
        {
            return new List<string>()
            {
                "Red", "Blue", "Green", "Orange", "Purple", "Yellow"
            };
        }

        private static ICounter CreateGuessCounter()
        {
            return new GuessCounter();
        }

        private static IApplicationStopper CreateApplicationStopper()
        {
            return new ApplicationStopper();
        }

        private static IWinnerValidator CreateWinnerValidator()
        {
            return new WinnerValidator();
        }

        private static IWinningColoursGenerator CreateWinnerColoursGenerator()
        {
            return new WinningColoursGenerator(CreateRandomiser(), CreateValidColours());
        }

        private static IRandomiser CreateRandomiser()
        {
            return new Randomiser();
        }

        private static IEncryptedCollectionsGenerator CreateEncryptedCollectionsGenerator()
        {
            return new EncryptedCollectionsGenerator();
        }
    }
}