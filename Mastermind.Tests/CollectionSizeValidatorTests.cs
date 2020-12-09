using System;
using System.Collections.Generic;
using Xunit;

namespace Mastermind.Tests
{
    public class CollectionSizeValidatorTests
    {
        CollectionSizeValidator collectionSizeChecker = new CollectionSizeValidator(TestHelper.SetupNumberOfWinningColours);

        [Fact]
        public void Validate_ShouldThrowArgumentException_GivenIncorrectCollectionSize()
        {
            var playerInput = new List<string>()
            {
                "1","2"
            };

            var ex = Assert.Throws<ArgumentException>(() => collectionSizeChecker.Validate(playerInput));

            Assert.Equal("Error: you must pass 4 colours!\n", ex.Message);
        }
    }
}