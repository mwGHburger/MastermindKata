namespace Mastermind
{
    public static class StandardMessages
    {
        public static string WelcomeMessage = "Welcome to Mastermind\n";
        public static string GeneratingColoursMessage = "Generating new colours...\n";
        public static string AskForInputMessage = $"\nPlease provide {ApplicationProperties.NumberOfWinningColours}, comma-separated colours: ";
        public static string AnnounceWinner = "You win!\n";
        public static string EndOfApplication = "Ending Application...";

        // TODO: Can be Enums
        public static string CorrectIndexPosition()
        {
            return "Black";
        }

        public static string WrongIndexPosition()
        {
            return "White";
        }
    }
}