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
            var mockApplicationStopper = new Mock<IApplicationStopper>();
            var guessCountValidator = new GuessCountValidator(mockGuessCounter.Object,mockApplicationStopper.Object , 60);

            mockGuessCounter.Setup(x => x.CurrentCount).Returns(50);

            var actual = guessCountValidator.isValid();

            Assert.True(actual);
        }

        [Fact]
        public void Validate_ShouldReturnFalse_IfCurrentCountIsLessThanMaxCount()
        {
            var mockGuessCounter = new Mock<ICounter>();
            var mockApplicationStopper = new Mock<IApplicationStopper>();
            var guessCountValidator = new GuessCountValidator(mockGuessCounter.Object, mockApplicationStopper.Object, 60);

            mockGuessCounter.Setup(x => x.CurrentCount).Returns(61);

            var actual = guessCountValidator.isValid();

            Assert.False(actual);
            mockApplicationStopper.VerifySet(x => x.StopApplication = true);
        }
    }
}