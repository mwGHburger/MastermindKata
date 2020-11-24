using System.Collections.Generic;
using Xunit;

namespace Mastermind.Tests
{
    public class EncryptedCollectionsGeneratorTests
    {
        [Fact]
        public void Generate_ShouldReturnAListWithBlackIndicatingCorrectIndex()
        {
            var validColours = TestHelper.SetupCorrectColours();
            var playerInput = new List<string>()
            {
                "Red", "Orange", "Yellow", "Orange"
            };
            var encryptedCollectionGenerator = new EncryptedCollectionsGenerator(TestHelper.SetupNumberOfWinningColours());
            var expected = new List<string>()
            {
                "Black", "White"
            };

            var actual = encryptedCollectionGenerator.Generate(playerInput, validColours);
            

            Assert.Equal(expected, actual);
        }
    }
}