using System.Collections.Generic;

namespace Mastermind
{
    public class CollectionSizeValidator : IErrorValidator
    {
        private int _maxCollectionSize = 4;
        public string ErrorMessage {get;} = StandardMessages.SizeError();
        public bool IsValid(List<string> inputColours)
        {
            return inputColours.Count.Equals(_maxCollectionSize);
        }
    }
}