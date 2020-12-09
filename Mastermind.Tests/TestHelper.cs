using System.Collections.Generic;

namespace Mastermind.Tests
{
    public static class TestHelper
    {
        public static int SetupNumberOfWinningColours = 4;
        public static List<string> SetupColours()
        {
            return new List<string>()
            {
                "Red", "Blue", "Green", "Orange", "Purple", "Yellow"
            };
        }

        public static List<string> SetupWinningColours()
        {
            return new List<string>()
            {
                "Red", "Blue", "Green", "Yellow"
            };
        }

        public static List<IErrorValidator> SetupValidators(IErrorValidator validator1, IErrorValidator validator2, IErrorValidator validator3)
        {
            return new List<IErrorValidator>()
            {
                validator1,
                validator2,
                validator3
            };
        }
        
    }
    
}