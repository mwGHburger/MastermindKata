using System;
namespace Mastermind
{
    public class MastermindApplication
    {
        private IUserInterface _userInterface;
        private IFormatter _formatter;
        private IErrorsValidator _errorsValidator;
        private IWinnerValidator _winnerValidator;
        private IWinningColoursGenerator _winningColoursGenerator;
        private IEncryptedCollectionsGenerator _encryptedCollectionsGenerator;
        private IApplicationStopper _applicationStopper;

        public MastermindApplication(IUserInterface userInterface, IFormatter formatter, IErrorsValidator errorsValidator, IWinnerValidator winnerValidator, IWinningColoursGenerator winningColoursGenerator, IEncryptedCollectionsGenerator encryptedCollectionsGenerator, IApplicationStopper applicationStopper)
        {
            _userInterface = userInterface;
            _formatter = formatter;
            _errorsValidator = errorsValidator;
            _winnerValidator = winnerValidator;
            _winningColoursGenerator = winningColoursGenerator;
            _encryptedCollectionsGenerator = encryptedCollectionsGenerator;
            _applicationStopper = applicationStopper;
        }

        public void Run()
        {
            _userInterface.Print(StandardMessages.Welcome());
            _userInterface.Print(StandardMessages.GeneratingColours());
            var winningColours = _winningColoursGenerator.Generate();
            do
            {
                _userInterface.Print(StandardMessages.AskForInput());
                var inputColours = _userInterface.GetInput();
                var coloursList = _formatter.ConvertToList(inputColours);
                _errorsValidator.Check(coloursList);
                if(_winnerValidator.isWinner(coloursList, winningColours))
                {
                    _applicationStopper.StopApplication = true;
                }
                var encryptedClues = _encryptedCollectionsGenerator.Generate(coloursList,winningColours);
                var encryptedCluesString = _formatter.ConvertToString(encryptedClues);
                _userInterface.Print(encryptedCluesString);
            }
            while(!_applicationStopper.StopApplication);
            _userInterface.Print(StandardMessages.EndOfApplication());
        }
    }
}