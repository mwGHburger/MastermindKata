using System.Collections.Generic;

namespace Mastermind
{
    public static class ClassInstantiatorFactory
    {        
        public static MastermindApplication CreateMastermindApplication()
        {
            return new MastermindApplication(CreateUserInterface(), CreateFormatter(), CreateErrorsValidator(), CreateWinnerValidator(), CreateWinnerColoursGenerator(), CreateEncryptedCollectionsGenerator(), ApplicationStopper.Instance, GuessCounter.Instance);
        }

        private static IUserInterface CreateUserInterface()
        {
            return new CommandLine();
        }

        private static IFormatter CreateFormatter()
        {
            return new Formatter();
        }

        private static IErrorValidator CreateErrorsValidator()
        {
            return new InputErrorsValidator(CreateErrorValidators());
        }

        private static List<IErrorValidator> CreateErrorValidators()
        {
            return new List<IErrorValidator>()
            {
                new GuessCountValidator(GuessCounter.Instance, ApplicationStopper.Instance, ApplicationProperties.MaxGuesses),
                new CollectionSizeValidator(ApplicationProperties.NumberOfWinningColours),
                new ColourNameValidator(ApplicationProperties.ValidColours)
            };
        }

        private static IWinnerValidator CreateWinnerValidator()
        {
            return new WinnerValidator();
        }

        private static IWinningColoursGenerator CreateWinnerColoursGenerator()
        {
            return new WinningColoursGenerator(Randomiser.Instance, ApplicationProperties.ValidColours, ApplicationProperties.NumberOfWinningColours);
        }

        private static IHintGenerator CreateEncryptedCollectionsGenerator()
        {
            return new HintGenerator(CreateListShuffler(), ApplicationProperties.NumberOfWinningColours);
        }

        private static IListShuffler CreateListShuffler()
        {
            return new ListShuffler(Randomiser.Instance);
        }
    }
}