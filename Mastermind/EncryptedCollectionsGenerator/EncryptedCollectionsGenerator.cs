using System.Collections.Generic;

namespace Mastermind
{
    public class EncryptedCollectionsGenerator : IEncryptedCollectionsGenerator
    {
        private int _numberOfWinningColours;

        public EncryptedCollectionsGenerator(int numberOfWinningColours)
        {
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
            return encryptedColours;
        }
    }
}