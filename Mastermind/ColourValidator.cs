using System.Collections.Generic;

namespace Mastermind
{
    public class ColourValidator
    {
        private List<string> _colours;

        public ColourValidator(List<string> colours)
        {
            _colours = colours;
        }
        public bool AreColoursValid(List<string> collection)
        {
            foreach(string colour in collection)
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