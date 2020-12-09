using System;
using System.Collections.Generic;

namespace Mastermind
{
    public class ColourNameValidator : IErrorValidator
    {
        private List<string> _colours;
        public string ErrorMessage {get;} = ErrorMessages.ColourNameError;

        public ColourNameValidator(List<string> colours)
        {
            _colours = colours;
        }
        public void Validate(List<string> inputColours)
        {
            foreach(string colour in inputColours)
            {
                var doesColourExist = _colours.Exists(x => x.Equals(colour));
                if(!doesColourExist)
                {
                    throw new ArgumentException(ErrorMessage);
                }
            }
        }
    }
}