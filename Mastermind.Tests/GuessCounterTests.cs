using Xunit;

namespace Mastermind.Tests
{
    public class GuessCounterTests
    {
        [Fact]
        public void IncrementGuessCounter_ShouldIncreaseTheCurrentCountPropertyBy1()
        {
            var guessCounter = new GuessCounter();
            var expected = 1;

            guessCounter.IncrementCount();

            Assert.Equal(expected, guessCounter.CurrentCount);
        }
    }
}