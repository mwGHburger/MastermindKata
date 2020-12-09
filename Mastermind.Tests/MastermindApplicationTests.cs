using System.Collections.Generic;
using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class MastermindApplicationTests
    {
        [Fact]
        public void Run_ShouldStartTheApplication_WhenWinnerExists()
        {
            var mockUserInterface = new Mock<IUserInterface>();
            var mockFormatter = new Mock<IFormatter>();
            var mockErrorsValidator = new Mock<IErrorValidator>();
            var mockWinnerValidator = new Mock<IWinnerValidator>();
            var mockColoursGenerator = new Mock<IWinningColoursGenerator>();
            var mockHintGenerator = new Mock<IHintGenerator>();
            var mockApplicationStopper = new Mock<IApplicationStopper>();
            var mockGuessCounter = new Mock<ICounter>();
            var mastermind = new MastermindApplication(
                mockUserInterface.Object, 
                mockFormatter.Object, 
                mockErrorsValidator.Object, 
                mockWinnerValidator.Object, 
                mockColoursGenerator.Object, 
                mockHintGenerator.Object, 
                mockApplicationStopper.Object,
                mockGuessCounter.Object
            );

            mockApplicationStopper.Setup(x => x.StopApplication).Returns(true);
            mockWinnerValidator.Setup(x => x.isWinner(It.IsAny<List<string>>(), It.IsAny<List<string>>())).Returns(true);

            mastermind.Run();

            mockUserInterface.Verify(x => x.Print(It.IsAny<string>()), Times.Exactly(6));
            mockUserInterface.Verify(x => x.GetInput(), Times.Exactly(1));
            mockFormatter.Verify(x => x.ConvertToList(It.IsAny<string>()), Times.Exactly(1));
            mockFormatter.Verify(x => x.ConvertToString(It.IsAny<List<string>>()), Times.Exactly(1));
            mockErrorsValidator.Verify(x => x.Validate(It.IsAny<List<string>>()), Times.Exactly(1));
            mockWinnerValidator.Verify(x => x.isWinner(It.IsAny<List<string>>(), It.IsAny<List<string>>()), Times.Exactly(1));
            mockColoursGenerator.Verify(x => x.Generate(), Times.Exactly(1));
            mockHintGenerator.Verify(x => x.Generate(It.IsAny<List<string>>(), It.IsAny<List<string>>()));
            mockGuessCounter.Verify(x => x.IncrementCount(), Times.Exactly(1));
        }
    }
}