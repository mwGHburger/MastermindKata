using System.Collections.Generic;

namespace Mastermind
{
    public static class ClassInstantiatorFactory
    {
        private static int _maxGuesses = 60;
        public static MastermindApplication CreateMastermindApplication()
        {
            return new MastermindApplication(CreateUserInterface(), CreateFormatter(), CreateErrorsValidator(), CreateWinnerValidator(), CreateWinnerColoursGenerator(), CreateEncryptedCollectionsGenerator(), CreateApplicationStopper());
        }

        public static IUserInterface CreateUserInterface()
        {
            return new CommandLine();
        }

        public static IFormatter CreateFormatter()
        {
            return new Formatter();
        }

        public static IErrorsValidator CreateErrorsValidator()
        {
            return new InputErrorsValidator(CreateErrorValidators());
        }

        public static List<IErrorValidator> CreateErrorValidators()
        {
            return new List<IErrorValidator>()
            {
                new CollectionSizeValidator(),
                new ColourNameValidator(CreateValidColours()),
                new GuessCountValidator(CreateGuessCounter(), CreateApplicationStopper(), _maxGuesses)
            };
        }

        public static List<string> CreateValidColours()
        {
            return new List<string>()
            {
                "Red", "Blue", "Green", "Orange", "Purple", "Yellow"
            };
        }

        public static ICounter CreateGuessCounter()
        {
            return new GuessCounter();
        }

        public static IApplicationStopper CreateApplicationStopper()
        {
            return new ApplicationStopper();
        }

        public static IWinnerValidator CreateWinnerValidator()
        {
            return new WinnerValidator();
        }

        public static IWinningColoursGenerator CreateWinnerColoursGenerator()
        {
            return new WinningColoursGenerator(CreateRandomiser(), CreateValidColours());
        }

        public static IRandomiser CreateRandomiser()
        {
            return new Randomiser();
        }

        public static IEncryptedCollectionsGenerator CreateEncryptedCollectionsGenerator()
        {
            return new EncryptedCollectionsGenerator();
        }
    }
}