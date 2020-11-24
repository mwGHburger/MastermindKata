using System.Collections.Generic;
using Xunit;

namespace Mastermind.Tests
{
    public class ColourValidatorTests
    {
        ColourNameValidator colourChecker = new ColourNameValidator(TestHelper.SetupColours());
        [Fact]
        public void AreColoursValid_ShouldReturnTrue_WhenAllColoursAreValid()
        {
            var playerInput = new List<string>()
            {
                "Red", "Blue", "Green", "Orange"
            };

            var actual = colourChecker.IsValid(playerInput);

            Assert.True(actual);
        }

        [Fact]
        public void AreColoursValid_ShouldReturnFalse_ForAnyInvalidColours()
        {
            var playerInput = new List<string>()
            {
                "Red", "Blue", "Grey", "Orange"
            };

            var actual = colourChecker.IsValid(playerInput);

            Assert.False(actual);
        }

    }
}