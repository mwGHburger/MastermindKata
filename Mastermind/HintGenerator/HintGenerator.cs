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
                    HandleCorrectPosition(encryptedColours, winningColours, i);
                }
                else if(winningColours.Contains(inputColours[i]))
                {
                    var correctColour = inputColours[i];
                    var correctIndex = winningColours.FindIndex(x => x.Equals(correctColour));
                    if(inputColours[correctIndex].Equals(winningColours[correctIndex]))
                    {
                        HandleCorrectPosition(encryptedColours, winningColours, correctIndex);
                    }
                    else
                    {
                        HandleIncorrectPosition(encryptedColours, winningColours, correctColour);
                    }
                }
            }
            return _listShuffler.Shuffle(encryptedColours);
        }

        private void HandleCorrectPosition(List<string> encryptedColours, List<string> winningColours, int index)
        {
            encryptedColours.Add(StandardMessages.CorrectIndexPosition());
            winningColours[index] = "null";
        }

        private void HandleIncorrectPosition(List<string> encryptedColours, List<string> winningColours, string correctColour)
        {
            encryptedColours.Add(StandardMessages.WrongIndexPosition());
            var index = winningColours.FindIndex(x => x.Equals(correctColour));
            winningColours[index] = "null";
        }
    }
}