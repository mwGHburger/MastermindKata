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
        List<string> mockInput = new List<string>();

        [Fact]
        public void Check_ShouldReturnFalse_And_PrintErrorToConsoleForInvalidTries()
        {
            var errorValidators = TestHelper.SetupValidators(mockGuessCounterValidator.Object, mockCollectionSizeValidator.Object, mockColourNameValidator.Object);
            var game = new InputErrorsValidator(errorValidators);
            var errorMessage = "Error: you have had more than 60 tries!";

            mockGuessCounterValidator.Setup(x => x.IsValid(mockInput)).Returns(false);
            mockGuessCounterValidator.Setup(x => x.ErrorMessage).Returns(errorMessage);
            
            var exception = Assert.Throws<Exception>(() => game.Check(mockInput));
            Assert.Equal(errorMessage, exception.Message);

            mockGuessCounterValidator.Verify(x => x.IsValid(mockInput), Times.Exactly(1));
            mockCollectionSizeValidator.Verify(x => x.IsValid(mockInput), Times.Exactly(0));
            mockColourNameValidator.Verify(x => x.IsValid(mockInput), Times.Exactly(0));
            
        }

        [Fact]
        public void Check_ShouldReturnFalse_And_PrintErrorToConsoleForInvalidCollectionSize()
        {
            var errorValidators = TestHelper.SetupValidators(mockGuessCounterValidator.Object, mockCollectionSizeValidator.Object, mockColourNameValidator.Object);
            var game = new InputErrorsValidator(errorValidators);
            var errorMessage = "Error: you must pass 4 colours!";

            mockGuessCounterValidator.Setup(x => x.IsValid(mockInput)).Returns(true);
            mockCollectionSizeValidator.Setup(x => x.IsValid(mockInput)).Returns(false);
            mockCollectionSizeValidator.Setup(x => x.ErrorMessage).Returns(errorMessage);

            var exception = Assert.Throws<Exception>(() => game.Check(mockInput));
            Assert.Equal(errorMessage, exception.Message);

            mockGuessCounterValidator.Verify(x => x.IsValid(mockInput), Times.Exactly(1));
            mockCollectionSizeValidator.Verify(x => x.IsValid(mockInput), Times.Exactly(1));
            mockColourNameValidator.Verify(x => x.IsValid(mockInput), Times.Exactly(0));
        }

        [Fact]
        public void Check_ShouldReturnFalse_And_PrintErrorToConsoleForInvalidColourNames()
        {
            var errorValidators = TestHelper.SetupValidators(mockGuessCounterValidator.Object, mockCollectionSizeValidator.Object, mockColourNameValidator.Object);
            var game = new InputErrorsValidator(errorValidators);
            var errorMessage = "Error: you have given an invalid colour!";

            mockGuessCounterValidator.Setup(x => x.IsValid(mockInput)).Returns(true);
            mockCollectionSizeValidator.Setup(x => x.IsValid(mockInput)).Returns(true);
            mockColourNameValidator.Setup(x => x.IsValid(mockInput)).Returns(false);
            mockColourNameValidator.Setup(x => x.ErrorMessage).Returns(errorMessage);

            var exception = Assert.Throws<Exception>(() => game.Check(mockInput));
            Assert.Equal(errorMessage, exception.Message);

            mockGuessCounterValidator.Verify(x => x.IsValid(mockInput), Times.Exactly(1));
            mockCollectionSizeValidator.Verify(x => x.IsValid(mockInput), Times.Exactly(1));
            mockColourNameValidator.Verify(x => x.IsValid(mockInput), Times.Exactly(1));
        }
    }
}