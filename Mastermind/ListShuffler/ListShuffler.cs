using System.Collections.Generic;

namespace Mastermind
{
    public class ListShuffler : IListShuffler
    {
        private IRandomiser _randomiser;

        public ListShuffler(IRandomiser randomiser)
        {
            _randomiser = randomiser;
        } 
        public List<string> Shuffle(List<string> inputList)
        {
            var shuffledList = new List<string>();

            while(inputList.Count > 0)
            {
                var randomIndex = _randomiser.GenerateRandomNumber(inputList.Count);
                shuffledList.Add(inputList[randomIndex]);
                inputList.RemoveAt(randomIndex);
            }
            return shuffledList;
        }
    }
}