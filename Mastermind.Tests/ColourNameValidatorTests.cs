using System.Collections.Generic;
using Xunit;

namespace Mastermind.Tests
{
    public class ColourValidatorTests
    {
        [Fact]
        public void AreColoursValid_ShouldReturnTrue_WhenAllColoursAreValid()
        {
            var colours = TestHelper.SetupColours();
            var collection = new List<string>()
            {
                "Red",
                "Blue",
                "Green",
                "Orange"
            };
            var colourChecker = new ColourValidator(colours);

            var actual = colourChecker.AreColoursValid(collection);

            Assert.True(actual);
        }

        [Fact]
        public void AreColoursValid_ShouldReturnFalse_ForAnyInvalidColours()
        {
            var colours = TestHelper.SetupColours();
            var collection = new List<string>()
            {
                "Red",
                "Blue",
                "Grey",
                "Orange"
            };
            var colourChecker = new ColourValidator(colours);

            var actual = colourChecker.AreColoursValid(collection);

            Assert.False(actual);
        }

    }
}