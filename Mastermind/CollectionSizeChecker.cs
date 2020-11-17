using System.Collections.Generic;

namespace Mastermind
{
    public class CollectionSizeChecker
    {
        public bool IsCollectionSizeValid(List<string> collection)
        {
            return collection.Count.Equals(4);
        }
    }
}