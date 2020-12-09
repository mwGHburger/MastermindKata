using System.Collections.Generic;

namespace Mastermind
{
    public static class ApplicationProperties
    {
        public static int MaxGuesses = 60;
        public static int NumberOfWinningColours = 4;

        public static List<string> ValidColours = new List<string>()
        {
            "Red", "Blue", "Green", "Orange", "Purple", "Yellow"
        };
    }
}