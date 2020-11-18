using System.Collections.Generic;

namespace Mastermind
{
    public class CollectionSizeValidator
    {
        private int _maxCollectionSize = 4;
        public bool IsCollectionSizeValid(List<string> collection)
        {
            return collection.Count.Equals(_maxCollectionSize);
        }
    }
}