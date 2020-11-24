using System.Collections.Generic;
using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class FormatterTests
    {
        Formatter formatter = new Formatter();
        
        [Fact]
        public void ConvertToList_ShouldReturnListOfStrings()
        {
            var playerInput = "red, blue, Green, Yellow";
            var expected = new List<string>()
            {
                "Red", "Blue", "Green", "Yellow"
            };

            var actual = formatter.ConvertToList(playerInput);
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertToString_ShouldReturnString()
        {
            var playerInput = new List<string>()
            {
                "Black", "White"
            };
            var expected = "['Black', 'White']";

            var actual = formatter.ConvertToString(playerInput);

            Assert.Equal(expected, actual);
        }
    }
}