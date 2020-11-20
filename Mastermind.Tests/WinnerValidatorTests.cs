using System.Collections.Generic;
using Xunit;

namespace Mastermind.Tests
{
    public class WinnerValidatorTests
    {
        [Fact]
        public void Validate_ShouldReturnTrue_ForCorrectInput()
        {
            var correctColours = TestHelper.SetupCorrectColours();
            var input = new List<string>()
            {
                "Red", "Blue", "Green", "Yellow"
            };
            var winnerValidator = new WinnerValidator();

            var actual = winnerValidator.isWinner(input, correctColours);

            Assert.True(actual);
        }

        [Theory]
        [InlineData("Red", "Orange", "Yellow", "Orange")]
        [InlineData("Blue", "Red", "Green", "Yellow")]
        public void Validate_ShouldReturnFalse_ForIncorrectInput(string colour1, string colour2, string colour3, string colour4)
        {
            var correctColours = TestHelper.SetupCorrectColours();
            var input = new List<string>()
            {
                colour1, colour2, colour3, colour4
            };
            var winnerValidator = new WinnerValidator();

            var actual = winnerValidator.isWinner(input, correctColours);

            Assert.False(actual);
        }
    }
}