using System;
using System.Collections.Generic;

namespace Mastermind
{
    public class InputErrorsValidator : IErrorsValidator
    {
        private List<IErrorValidator> _errorValidators;

        public InputErrorsValidator(List<IErrorValidator> errorValidators)
        {
            _errorValidators = errorValidators;
        }

        public void Check(List<string> inputColours)
        {
            foreach(IErrorValidator errorValidator in _errorValidators)
            {
                if(!errorValidator.IsValid(inputColours))
                {
                    throw new ArgumentException(errorValidator.ErrorMessage);
                }
            }
        }
    }
}