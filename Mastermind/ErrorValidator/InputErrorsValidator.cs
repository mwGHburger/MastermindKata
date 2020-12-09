using System;
using System.Collections.Generic;

namespace Mastermind
{
    public class InputErrorsValidator : IErrorValidator
    {
        private List<IErrorValidator> _errorValidators;
        public string ErrorMessage {get;}

        public InputErrorsValidator(List<IErrorValidator> errorValidators)
        {
            _errorValidators = errorValidators;
        }

        public void Validate(List<string> inputColours)
        {
            foreach(IErrorValidator errorValidator in _errorValidators)
            {
                errorValidator.Validate(inputColours);
            }
        }
    }
}