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
            var input = new List<string>()
            {
                "Red", "Orange", "Yellow", "Orange"
            };
            var encryptedCollectionGenerator = new EncryptedCollectionsGenerator();
            var actual = encryptedCollectionGenerator.Generate(input, validColours);
            var expected = new List<string>()
            {
                "Black",
                "White"
            };

            Assert.Equal(expected, actual);
        }
    }
}