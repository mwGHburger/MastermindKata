using System.Collections.Generic;

namespace Mastermind
{
    public class ColourNameValidator
    {
        private List<string> _colours;

        public ColourNameValidator(List<string> colours)
        {
            _colours = colours;
        }
        public bool IsValid(List<string> inputColours)
        {
            foreach(string colour in inputColours)
            {
                var doesColourExist = _colours.Exists(x => x.Equals(colour));
                if(!doesColourExist)
                {
                    return false;
                }
            }
            return true;
        }
    }
}