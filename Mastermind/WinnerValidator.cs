using System.Collections.Generic;
using System.Linq;

namespace Mastermind
{
    public class WinnerValidator
    {
        private List<string> _correctColours;

        public WinnerValidator(List<string> correctColours)
        {
            _correctColours = correctColours;
        }
        public bool Validate(List<string> input)
        {
            return _correctColours.SequenceEqual(input);
        }
    }
}