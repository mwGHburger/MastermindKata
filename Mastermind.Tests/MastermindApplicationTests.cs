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
            var mockErrorsValidator = new Mock<IErrorsValidator>();
            var mockWinnerValidator = new Mock<IWinnerValidator>();
            var mockColoursGenerator = new Mock<IWinningColoursGenerator>();
            var mockEncryptedCollectionsGenerator = new Mock<IEncryptedCollectionsGenerator>();
            var mockApplicationStopper = new Mock<IApplicationStopper>();
            var mastermind = new MastermindApplication(
                mockUserInterface.Object, 
                mockFormatter.Object, 
                mockErrorsValidator.Object, 
                mockWinnerValidator.Object, 
                mockColoursGenerator.Object, 
                mockEncryptedCollectionsGenerator.Object, 
                mockApplicationStopper.Object
            );

            mockApplicationStopper.Setup(x => x.StopApplication).Returns(true);

            mastermind.Run();

            mockUserInterface.Verify(x => x.Print(It.IsAny<string>()), Times.Exactly(5));
            mockUserInterface.Verify(x => x.GetInput(), Times.Exactly(1));
            mockFormatter.Verify(x => x.ConvertToList(It.IsAny<string>()), Times.Exactly(1));
            mockFormatter.Verify(x => x.ConvertToString(It.IsAny<List<string>>()), Times.Exactly(1));
            mockErrorsValidator.Verify(x => x.Check(It.IsAny<List<string>>()), Times.Exactly(1));
            mockWinnerValidator.Verify(x => x.isWinner(It.IsAny<List<string>>(), It.IsAny<List<string>>()), Times.Exactly(1));
            mockColoursGenerator.Verify(x => x.Generate(), Times.Exactly(1));
            mockEncryptedCollectionsGenerator.Verify(x => x.Generate(It.IsAny<List<string>>(), It.IsAny<List<string>>()));
        }
    }
}