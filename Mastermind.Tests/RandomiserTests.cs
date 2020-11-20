using Xunit;

namespace Mastermind.Tests
{
    public class RandomiserTests
    {
        [Fact]
        public void GenerateRandomNumber_ShouldReturnIntegerBetween0AndMaximumSpecificValue()
        {
            var randomiser = new Randomiser();
            var maxValue = 7;

            var actual = randomiser.GenerateRandomNumber(maxValue);

            Assert.InRange(actual, 0, maxValue);
        }
    }
}