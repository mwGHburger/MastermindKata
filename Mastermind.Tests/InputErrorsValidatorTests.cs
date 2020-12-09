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

            mockGuessCounterValidator.Setup(x => x.ErrorMessage).Returns(errorMessage);
            mockGuessCounterValidator.Setup(x => x.Validate(mockInput)).Throws(new ArgumentException(errorMessage));
            
            var exception = Assert.Throws<ArgumentException>(() => game.Validate(mockInput));
            Assert.Equal(errorMessage, exception.Message);

            mockGuessCounterValidator.Verify(x => x.Validate(mockInput), Times.Exactly(1));
            mockCollectionSizeValidator.Verify(x => x.Validate(mockInput), Times.Exactly(0));
            mockColourNameValidator.Verify(x => x.Validate(mockInput), Times.Exactly(0));
            
        }

        [Fact]
        public void Check_ShouldReturnFalse_And_PrintErrorToConsoleForInvalidCollectionSize()
        {
            var errorValidators = TestHelper.SetupValidators(mockGuessCounterValidator.Object, mockCollectionSizeValidator.Object, mockColourNameValidator.Object);
            var game = new InputErrorsValidator(errorValidators);
            var errorMessage = "Error: you must pass 4 colours!";

            mockCollectionSizeValidator.Setup(x => x.Validate(mockInput)).Throws(new ArgumentException(errorMessage));
            mockCollectionSizeValidator.Setup(x => x.ErrorMessage).Returns(errorMessage);

            var exception = Assert.Throws<ArgumentException>(() => game.Validate(mockInput));
            Assert.Equal(errorMessage, exception.Message);

            mockGuessCounterValidator.Verify(x => x.Validate(mockInput), Times.Exactly(1));
            mockCollectionSizeValidator.Verify(x => x.Validate(mockInput), Times.Exactly(1));
            mockColourNameValidator.Verify(x => x.Validate(mockInput), Times.Exactly(0));
        }

        [Fact]
        public void Check_ShouldReturnFalse_And_PrintErrorToConsoleForInvalidColourNames()
        {
            var errorValidators = TestHelper.SetupValidators(mockGuessCounterValidator.Object, mockCollectionSizeValidator.Object, mockColourNameValidator.Object);
            var game = new InputErrorsValidator(errorValidators);
            var errorMessage = "Error: you have given an invalid colour!";

            mockColourNameValidator.Setup(x => x.Validate(mockInput)).Throws(new ArgumentException(errorMessage));
            mockColourNameValidator.Setup(x => x.ErrorMessage).Returns(errorMessage);

            var exception = Assert.Throws<ArgumentException>(() => game.Validate(mockInput));
            Assert.Equal(errorMessage, exception.Message);

            mockGuessCounterValidator.Verify(x => x.Validate(mockInput), Times.Exactly(1));
            mockCollectionSizeValidator.Verify(x => x.Validate(mockInput), Times.Exactly(1));
            mockColourNameValidator.Verify(x => x.Validate(mockInput), Times.Exactly(1));
        }
    }
}