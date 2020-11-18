using System.Collections.Generic;

namespace Mastermind.Tests
{
    public static class TestHelper
    {
        public static List<string> SetupColours()
        {
            return new List<string>()
            {
                "Red", "Blue", "Green", "Orange", "Purple", "Yellow"
            };
        }

        public static List<string> SetupCorrectColours()
        {
            return new List<string>()
            {
                "Red", "Blue", "Green", "Yellow"
            };
        }
    }
}