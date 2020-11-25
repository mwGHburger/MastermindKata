using System;
using System.Collections.Generic;
using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class ListShufflerTests
    {
        [Fact]
        public void Shuffle_ShouldReturnListWithItsElementsShuffled()
        {
            var mockRandomiser = new Mock<IRandomiser>();
            var listShuffler = new ListShuffler(mockRandomiser.Object);
            var inputList = new List<string>()
            {
                "Black",
                "Black",
                "White",
                "White"

            };
            var expected = new List<string>()
            {
                "White",
                "Black",
                "White",
                "Black"
            };

            mockRandomiser.SetupSequence(x => x.GenerateRandomNumber(It.IsAny<Int32>()))
                .Returns(2)
                .Returns(0)
                .Returns(1)
                .Returns(0);

            var actual = listShuffler.Shuffle(inputList);

            Assert.Equal(expected, actual);
        }
    }
}