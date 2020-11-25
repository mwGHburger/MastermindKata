using System.Collections.Generic;
using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class EncryptedCollectionsGeneratorTests
    {
        [Fact]
        public void Generate_ShouldReturnAListWithBlackIndicatingCorrectIndex()
        {
            var mockListShuffler = new Mock<IListShuffler>();
            var validColours = TestHelper.SetupCorrectColours();
            var playerInput = new List<string>()
            {
                "Red", "Orange", "Yellow", "Orange"
            };
            var encryptedCollectionGenerator = new EncryptedCollectionsGenerator(mockListShuffler.Object, TestHelper.SetupNumberOfWinningColours());
            var expected = new List<string>()
            {
                "White", "Black"
            };

            mockListShuffler.Setup(x => x.Shuffle(It.IsAny<List<string>>())).Returns(new List<string>()
            {
                "White",
                "Black"
            });

            var actual = encryptedCollectionGenerator.Generate(playerInput, validColours);
            

            Assert.Equal(expected, actual);
        }
    }
}