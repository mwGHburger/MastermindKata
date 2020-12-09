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
            List<string> winningColoursCopy = new List<string>(winningColours);
            var encryptedColours = new List<string>();
            for(int i = 0; i < _numberOfWinningColours; i++)
            {
                if(inputColours[i].Equals(winningColoursCopy[i]))
                {
                    HandleCorrectPosition(encryptedColours, winningColoursCopy, i);
                }
                else if(winningColoursCopy.Contains(inputColours[i]))
                {
                    var correctColour = inputColours[i];
                    var correctIndex = winningColoursCopy.FindIndex(x => x.Equals(correctColour));
                    if(inputColours[correctIndex].Equals(winningColoursCopy[correctIndex]))
                    {
                        HandleCorrectPosition(encryptedColours, winningColoursCopy, correctIndex);
                    }
                    else
                    {
                        HandleIncorrectPosition(encryptedColours, winningColoursCopy, correctColour);
                    }
                }
            }
            return _listShuffler.Shuffle(encryptedColours);
        }

        private void HandleCorrectPosition(List<string> encryptedColours, List<string> winningColoursCopy, int index)
        {
            encryptedColours.Add(StandardMessages.CorrectIndexPosition());
            winningColoursCopy[index] = "null";
        }

        private void HandleIncorrectPosition(List<string> encryptedColours, List<string> winningColoursCopy, string correctColour)
        {
            encryptedColours.Add(StandardMessages.WrongIndexPosition());
            var index = winningColoursCopy.FindIndex(x => x.Equals(correctColour));
            winningColoursCopy[index] = "null";
        }
    }
}