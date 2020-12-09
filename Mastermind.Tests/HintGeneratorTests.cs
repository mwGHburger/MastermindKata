using System.Collections.Generic;
using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class EncryptedCollectionsGeneratorTests
    {
        [Fact]
        public void Generate_ShouldReturn_AShuffledHintList_ForCorrectColours_InTheWrongPosition()
        {
            var mockListShuffler = new Mock<IListShuffler>();
            var validColours = TestHelper.SetupWinningColours();
            var playerInput = new List<string>()
            {
                "Green", "Green", "Purple", "Purple"
            };
            var hintGenerator = new HintGenerator(mockListShuffler.Object, TestHelper.SetupNumberOfWinningColours);
            var expected = new List<string>()
            {
                "White",
            };

            mockListShuffler.Setup(x => x.Shuffle(It.Is<List<string>>(x => x.FindAll(i => i.Equals("White")).Count.Equals(1)))).Returns(new List<string>()
            {
                "White",
            });

            var actual = hintGenerator.Generate(playerInput, validColours);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Generate_ShouldReturn_AShuffledHintList_ForCorrectColours_InTheCorrectPosition()
        {
            var mockListShuffler = new Mock<IListShuffler>();
            var validColours = new List<string>()
            {
                "Red",
                "Green",
                "Blue",
                "Green"
            };
            var playerInput = new List<string>()
            {
                "Green", "Green", "Green", "Green"
            };
            var hintGenerator = new HintGenerator(mockListShuffler.Object, TestHelper.SetupNumberOfWinningColours);
            var expected = new List<string>()
            {
                "Black",
                "Black",
            };

            mockListShuffler.Setup(x => x.Shuffle(It.Is<List<string>>(x => x.FindAll(i => i.Equals("Black")).Count.Equals(2)))).Returns(new List<string>()
            {
                "Black",
                "Black",
            });

            var actual = hintGenerator.Generate(playerInput, validColours);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Generate_ShouldReturn_AShuffledHintList()
        {
            var mockListShuffler = new Mock<IListShuffler>();
            var validColours = TestHelper.SetupWinningColours();
            var playerInput = new List<string>()
            {
                "Red", "Orange", "Yellow", "Orange"
            };
            var hintGenerator = new HintGenerator(mockListShuffler.Object, TestHelper.SetupNumberOfWinningColours);
            var expected = new List<string>()
            {
                "White", "Black"
            };

            mockListShuffler.Setup(x => x.Shuffle(
                It.Is<List<string>>(
                    x => x.FindAll(
                        i => i.Equals("Black") || i.Equals("White")
                    ).Count.Equals(2)
                )
                ))
            .Returns(new List<string>()
            {
                "White",
                "Black"
            });

            var actual = hintGenerator.Generate(playerInput, validColours);
            

            Assert.Equal(expected, actual);
        }
    }
}