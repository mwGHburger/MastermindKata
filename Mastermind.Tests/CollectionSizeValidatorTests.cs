using System.Collections.Generic;
using Xunit;

namespace Mastermind.Tests
{
    public class CollectionSizeValidatorTests
    {
        [Fact]
        public void IsCollectionSizeValid_ShouldReturnTrue_GivenCorrectCollectionSize()
        {
            var collection = new List<string>()
            {
                "1",
                "2",
                "3",
                "4"
            };
            var collectionSizeChecker = new CollectionSizeValidator();

            var actual = collectionSizeChecker.IsValid(collection);

            Assert.True(actual);
        }

        [Fact]
        public void IsCollectionSizeValid_ShouldReturnFalse_GivenIncorrectCollectionSize()
        {
            var collection = new List<string>()
            {
                "1",
                "2",
            };
            var collectionSizeChecker = new CollectionSizeValidator();

            var actual = collectionSizeChecker.IsValid(collection);

            Assert.False(actual);
        }
    }
}