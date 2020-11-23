using System.Collections.Generic;
using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class FormatterTests
    {
        [Fact]
        public void ConvertToList_ShouldReturnListOfStrings()
        {
            var formatter = new Formatter();
            var input = "red, blue, Green, Yellow";
            var expected = new List<string>()
            {
                "Red",
                "Blue",
                "Green",
                "Yellow"
            };

            var actual = formatter.ConvertToList(input);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertToString_ShouldReturnString()
        {
            var formatter = new Formatter();
            var input = new List<string>()
            {
                "Black",
                "White",
            };
            var expected = "['Black', 'White']";

            var actual = formatter.ConvertToString(input);
            Assert.Equal(expected, actual);
        }
    }
}