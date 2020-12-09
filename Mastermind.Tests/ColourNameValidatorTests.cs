using System;
using System.Collections.Generic;
using Xunit;

namespace Mastermind.Tests
{
    public class ColourValidatorTests
    {
        ColourNameValidator colourChecker = new ColourNameValidator(TestHelper.SetupColours());
        [Fact]
        public void Validate_ShouldThrowArgumentException_WhenAllColoursAreInvalid()
        {
            var playerInput = new List<string>()
            {
                "Red", "Blue", "Green", "NotColour"
            };

            var ex = Assert.Throws<ArgumentException>(() => colourChecker.Validate(playerInput));
            Assert.Equal("Error: you have given an invalid colour!\n", ex.Message);
        }

    }
}