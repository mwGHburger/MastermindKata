using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class GuessCountValidatorTests
    {
        [Fact]
        public void Validate_ShouldReturnTrue_IfCurrentCountIsLessThanMaxCount()
        {
            var mockGuessCounter = new Mock<ICounter>();
            var guessCountValidator = new GuessCountValidator(mockGuessCounter.Object, 60);

            mockGuessCounter.Setup(x => x.CurrentCount).Returns(50);

            var actual = guessCountValidator.Validate();

            Assert.True(actual);
        }

        [Fact]
        public void Validate_ShouldReturnFalse_IfCurrentCountIsLessThanMaxCount()
        {
            var mockGuessCounter = new Mock<ICounter>();
            var guessCountValidator = new GuessCountValidator(mockGuessCounter.Object, 60);

            mockGuessCounter.Setup(x => x.CurrentCount).Returns(61);

            var actual = guessCountValidator.Validate();

            Assert.False(actual);
        }
    }
}