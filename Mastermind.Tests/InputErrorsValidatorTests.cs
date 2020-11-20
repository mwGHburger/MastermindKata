using System;
using System.Collections.Generic;
using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class InputErrorsValidatorTests
    {
        Mock<IErrorValidator> mockGuessCounterValidator = new Mock<IErrorValidator>();
        Mock<IErrorValidator> mockCollectionSizeValidator = new Mock<IErrorValidator>();
        Mock<IErrorValidator> mockColourNameValidator = new Mock<IErrorValidator>();   

        [Fact]
        public void Check_ShouldReturnFalse_And_PrintErrorToConsoleForInvalidTries()
        {
            var errorValidators = TestHelper.SetupValidators(mockGuessCounterValidator.Object, mockCollectionSizeValidator.Object, mockColourNameValidator.Object);
            var input = new List<string>();
            var game = new InputErrorsValidator(errorValidators);
            var errorMessage = "Error: you have had more than 60 tries!";

            mockGuessCounterValidator.Setup(x => x.IsValid(input)).Returns(false);
            mockGuessCounterValidator.Setup(x => x.ErrorMessage).Returns(errorMessage);

            
            var exception = Assert.Throws<ArgumentException>(() => game.Check(input));
            Assert.Equal(errorMessage, exception.Message);

            mockGuessCounterValidator.Verify(x => x.IsValid(input), Times.Exactly(1));
            mockCollectionSizeValidator.Verify(x => x.IsValid(input), Times.Exactly(0));
            mockColourNameValidator.Verify(x => x.IsValid(input), Times.Exactly(0));
            
        }

        [Fact]
        public void Check_ShouldReturnFalse_And_PrintErrorToConsoleForInvalidCollectionSize()
        {
            var errorValidators = TestHelper.SetupValidators(mockGuessCounterValidator.Object, mockCollectionSizeValidator.Object, mockColourNameValidator.Object);
            var input = new List<string>();
            var game = new InputErrorsValidator(errorValidators);
            var errorMessage = "Error: you must pass 4 colours!";

            mockGuessCounterValidator.Setup(x => x.IsValid(input)).Returns(true);
            mockCollectionSizeValidator.Setup(x => x.IsValid(input)).Returns(false);
            mockCollectionSizeValidator.Setup(x => x.ErrorMessage).Returns(errorMessage);

            var exception = Assert.Throws<ArgumentException>(() => game.Check(input));
            Assert.Equal(errorMessage, exception.Message);

            mockGuessCounterValidator.Verify(x => x.IsValid(input), Times.Exactly(1));
            mockCollectionSizeValidator.Verify(x => x.IsValid(input), Times.Exactly(1));
            mockColourNameValidator.Verify(x => x.IsValid(input), Times.Exactly(0));
        }

        [Fact]
        public void Check_ShouldReturnFalse_And_PrintErrorToConsoleForInvalidColourNames()
        {
            var errorValidators = TestHelper.SetupValidators(mockGuessCounterValidator.Object, mockCollectionSizeValidator.Object, mockColourNameValidator.Object);
            var input = new List<string>();
            var game = new InputErrorsValidator(errorValidators);
            var errorMessage = "Error: you have given an invalid colour!";

            mockGuessCounterValidator.Setup(x => x.IsValid(input)).Returns(true);
            mockCollectionSizeValidator.Setup(x => x.IsValid(input)).Returns(true);
            mockColourNameValidator.Setup(x => x.IsValid(input)).Returns(false);
            mockColourNameValidator.Setup(x => x.ErrorMessage).Returns(errorMessage);

            var exception = Assert.Throws<ArgumentException>(() => game.Check(input));
            Assert.Equal(errorMessage, exception.Message);

            mockGuessCounterValidator.Verify(x => x.IsValid(input), Times.Exactly(1));
            mockCollectionSizeValidator.Verify(x => x.IsValid(input), Times.Exactly(1));
            mockColourNameValidator.Verify(x => x.IsValid(input), Times.Exactly(1));
        }

        // [Fact]
        // public void Check_ShouldReturnTrue_And_PrintToConsoleForCorrectColours()
        // {
        //     var errorValidators = TestHelper.SetupValidators(mockGuessCounterValidator.Object, mockCollectionSizeValidator.Object, mockColourNameValidator.Object);

        //     var input = new List<string>();
        //     var correctColours = new List<string>();
        //     var game = new Game(mockCommandLine.Object, mockWinnerValidator.Object, errorValidators);
        //     var winningMessage = "WON!";

        //     mockGuessCounterValidator.Setup(x => x.IsValid(input)).Returns(true);
        //     mockCollectionSizeValidator.Setup(x => x.IsValid(input)).Returns(true);
        //     mockColourNameValidator.Setup(x => x.IsValid(input)).Returns(true);
        //     mockWinnerValidator.Setup(x => x.isWinner(input, correctColours)).Returns(true);

        //     game.Check(input, correctColours);

        //     mockGuessCounterValidator.Verify(x => x.IsValid(input), Times.Exactly(1));
        //     mockCollectionSizeValidator.Verify(x => x.IsValid(input), Times.Exactly(1));
        //     mockColourNameValidator.Verify(x => x.IsValid(input), Times.Exactly(1));
        //     mockCommandLine.Verify(x => x.Print(winningMessage), Times.Exactly(1));

        // }
    }
}