namespace Mastermind
{
    public static class StandardMessages
    {
        // TODO: Change method names, make them variables
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

        // TODO: Break this down into another static class, make a messages folder 
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
            // TODO: Change 60 to variable
            return "Error: you have had more than 60 tries!\n";
        }

        public static string EndOfApplication()
        {
            return "Ending Application...";
        }

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