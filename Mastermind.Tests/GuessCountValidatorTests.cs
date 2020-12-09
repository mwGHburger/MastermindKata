using System;
using System.Collections.Generic;
using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class GuessCountValidatorTests
    {
        List<string> mockList = new List<string>();
        Mock<ICounter> mockGuessCounter = new Mock<ICounter>();
        Mock<IApplicationStopper> mockApplicationStopper = new Mock<IApplicationStopper>();

        [Fact]
        public void Validate_ShouldThrowArgumentException_IfCurrentCountIsMoreThanMaxCount()
        {
            var guessCountValidator = new GuessCountValidator(mockGuessCounter.Object, mockApplicationStopper.Object, 60);

            mockGuessCounter.Setup(x => x.CurrentCount).Returns(61);

            var ex = Assert.Throws<ArgumentException>(() => guessCountValidator.Validate(mockList));

            Assert.Equal("Error: you have had more than 60 tries!\n", ex.Message);

            mockApplicationStopper.VerifySet(x => x.StopApplication = true);
        }
    }
}