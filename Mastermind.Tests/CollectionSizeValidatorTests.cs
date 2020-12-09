using System.Collections.Generic;
using Xunit;

namespace Mastermind.Tests
{
    public class CollectionSizeValidatorTests
    {
        CollectionSizeValidator collectionSizeChecker = new CollectionSizeValidator(TestHelper.SetupNumberOfWinningColours);

        [Fact]
        public void IsCollectionSizeValid_ShouldReturnTrue_GivenCorrectCollectionSize()
        {
            var playerInput = new List<string>()
            {
                "1","2","3","4"
            };

            var actual = collectionSizeChecker.IsValid(playerInput);

            Assert.True(actual);
        }

        [Fact]
        public void IsCollectionSizeValid_ShouldReturnFalse_GivenIncorrectCollectionSize()
        {
            var playerInput = new List<string>()
            {
                "1","2"
            };

            var actual = collectionSizeChecker.IsValid(playerInput);

            Assert.False(actual);
        }
    }
}