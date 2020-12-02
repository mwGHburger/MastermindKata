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
        private IHintGenerator _hintGenerator;
        private IApplicationStopper _applicationStopper;
        private ICounter _guessCounter;

        public MastermindApplication(IUserInterface userInterface, IFormatter formatter, IErrorsValidator errorsValidator, IWinnerValidator winnerValidator, IWinningColoursGenerator winningColoursGenerator, IHintGenerator hintGenerator, IApplicationStopper applicationStopper, ICounter guessCounter)
        {
            _userInterface = userInterface;
            _formatter = formatter;
            _errorsValidator = errorsValidator;
            _winnerValidator = winnerValidator;
            _winningColoursGenerator = winningColoursGenerator;
            _hintGenerator = hintGenerator;
            _applicationStopper = applicationStopper;
            _guessCounter = guessCounter;
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
                _guessCounter.IncrementCount();
                var coloursList = _formatter.ConvertToList(inputColours);
                try
                {
                    _errorsValidator.Check(coloursList);
                    if(_winnerValidator.isWinner(coloursList, winningColours))
                    {
                        _userInterface.Print(StandardMessages.AnnounceWinner());
                        _applicationStopper.StopApplication = true;
                    }
                    var hint = _hintGenerator.Generate(coloursList,winningColours);
                    var hintString = _formatter.ConvertToString(hint);
                    _userInterface.Print(hintString);
                }
                catch(Exception exception)
                {
                    _userInterface.Print(exception.Message);
                }
            }
            while(!_applicationStopper.StopApplication);
            _userInterface.Print(StandardMessages.EndOfApplication());
        }
    }
}