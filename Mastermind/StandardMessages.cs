namespace Mastermind
{
    public static class StandardMessages
    {
        public static string Welcome()
        {
            return "Welcome to Mastermind\n";
        }
        public static string GeneratingColours()
        {
            return "Generating new colours...\n";
        }

        public static string AskForInput()
        {
            return $"\nPlease provide {ClassInstantiatorFactory.NumberOfWinningColours}, comma-separated colours: ";
        }

        public static string AnnounceWinner()
        {
            return "You win!\n";
        }

        public static string SizeError()
        {
            return "Error: you must pass 4 colours!\n";
        }

        public static string ColourNameError()
        {
            return "Error: you have given an invalid colour!\n";
        }

        public static string GuessCountError()
        {
            return "Error: you have had more than 60 tries!\n";
        }

        public static string EndOfApplication()
        {
            return "Ending Application...";
        }

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