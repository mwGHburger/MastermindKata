using System.Collections.Generic;

namespace Mastermind
{
    public class HintGenerator : IHintGenerator
    {
        private IListShuffler _listShuffler;
        private int _numberOfWinningColours;

        public HintGenerator(IListShuffler listShuffler, int numberOfWinningColours)
        {
            _listShuffler = listShuffler;
            _numberOfWinningColours = numberOfWinningColours;
        }
        public List<string> Generate(List<string> inputColours, List<string> winningColours)
        {
            var encryptedColours = new List<string>();
            for(int i = 0; i < _numberOfWinningColours; i++)
            {
                if(inputColours[i].Equals(winningColours[i]))
                {
                    encryptedColours.Add(StandardMessages.CorrectIndexPosition());
                }
                else if(winningColours.Contains(inputColours[i]))
                {
                    encryptedColours.Add(StandardMessages.WrongIndexPosition());
                }
            }

            return _listShuffler.Shuffle(encryptedColours);
        }
    }
}