namespace Mastermind
{
    public static class StandardMessages
    {
        public static string Welcome()
        {
            return "Welcome to Mastermind";
        }
        public static string GeneratingColours()
        {
            return "Generating new colours...";
        }

        public static string AskForInput()
        {
            return "Please provide 4, comma-separated colours: ";
        }

        public static string AnnounceWinner()
        {
            return "You win!";
        }

        public static string SizeError()
        {
            return "Error: you must pass 4 colours!";
        }

        public static string ColourNameError()
        {
            return "Error: you have given an invalid colour!";
        }

        public static string GuessCountError()
        {
            return "Error: you have had more than 60 tries!";
        }

        public static string EndOfApplication()
        {
            return "Ending Application...";
        }
    }
}