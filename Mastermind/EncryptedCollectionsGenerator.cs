using System.Collections.Generic;

namespace Mastermind
{
    public class EncryptedCollectionsGenerator
    {
        public List<string> Generate(List<string> inputColours, List<string> winningColours)
        {
            var encryptedColours = new List<string>();
            for(int i = 0; i < 4; i++)
            {
                if(inputColours[i].Equals(winningColours[i]))
                {
                    encryptedColours.Add("Black");
                }
                else if(winningColours.Contains(inputColours[i]))
                {
                    encryptedColours.Add("White");
                }
            }
            return encryptedColours;
        }
    }
}