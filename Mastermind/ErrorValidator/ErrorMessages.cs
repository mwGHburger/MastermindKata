namespace Mastermind
{
    public static class ErrorMessages
    {
        public static string SizeError = $"Error: you must pass {ApplicationProperties.NumberOfWinningColours} colours!\n";
        public static string ColourNameError = "Error: you have given an invalid colour!\n";
        public static string GuessCountError = $"Error: you have had more than {ApplicationProperties.MaxGuesses} tries!\n";
        
    }
}