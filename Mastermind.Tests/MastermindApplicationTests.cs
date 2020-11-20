using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class MastermindApplicationTests
    {
        [Fact]
        public void Run_ShouldStartTheApplication()
        {
            var mockCommandLine = new Mock<IUserInterface>();
            var mockErrorsValidator = new Mock<IErrorsValidator>();
            var mockWinnerValidator = new Mock<IWinnerValidator>();
            var mockEncryptedCollectionsGenerator = new Mock<IEncryptedCollectionsGenerator>();
            var mastermind = new MastermindApplication(mockCommandLine.Object, mockErrorsValidator.Object, mockWinnerValidator.Object, mockEncryptedCollectionsGenerator.Object);

        }
    }
}