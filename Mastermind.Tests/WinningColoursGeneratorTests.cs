using System.Collections.Generic;
using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class WinningColoursGeneratorTests
    {
        [Theory]
        [InlineData("Green","Blue","Purple","Yellow",2,1,4,5)]
        [InlineData("Red","Blue","Green","Orange",0,1,2,3)]
        public void Generate_ShouldReturnCollectionWith4ValidColours(string expectedColour1, string expectedColour2, string expectedColour3, string expectedColour4, int position1, int position2, int position3, int position4)
        {
            var validColours = TestHelper.SetupColours();
            var mockRandomiser = new Mock<IRandomiser>();
            var winningColoursGenerator = new WinningColoursGenerator(mockRandomiser.Object);
            var expected = new List<string>()
            {
                expectedColour1,
                expectedColour2,
                expectedColour3,
                expectedColour4
            };

            mockRandomiser.SetupSequence(x => x.GenerateRandomNumber(It.IsAny<int>()))
                .Returns(position1)
                .Returns(position2)
                .Returns(position3)
                .Returns(position4);

            var actual = winningColoursGenerator.GenerateColours(validColours);

            Assert.Equal(expected, actual);
        }
    }
}