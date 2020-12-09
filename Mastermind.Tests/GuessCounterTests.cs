using Xunit;

namespace Mastermind.Tests
{
    public class GuessCounterTests
    {
        [Fact]
        public void IncrementGuessCounter_ShouldIncreaseTheCurrentCountPropertyBy1()
        {
            var guessCounter = GuessCounter.Instance;
            var expected = 1;

            guessCounter.IncrementCount();

            Assert.Equal(expected, guessCounter.CurrentCount);
        }
    }
}