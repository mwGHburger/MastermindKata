using System.Collections.Generic;

namespace Mastermind
{
    public class CollectionSizeValidator
    {
        private int _maxCollectionSize = 4;
        public bool IsValid(List<string> inputColours)
        {
            return inputColours.Count.Equals(_maxCollectionSize);
        }
    }
}