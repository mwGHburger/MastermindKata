using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Mastermind
{
    public class Formatter : IFormatter
    {

        public List<string> ConvertToList(string input)
        {
            var inputColours = new List<string>();
            var coloursArray = input.Split(',');
            foreach(string colour in coloursArray)
            {
                if(String.IsNullOrEmpty(colour))
                {
                    break;
                }
                var lowerCaseColour = colour.ToLower();
                var trimmedColour = lowerCaseColour.Trim();
                string formattedColour;
                formattedColour = char.ToUpper(trimmedColour[0]) + trimmedColour.Substring(1);
                inputColours.Add(formattedColour);
            }

            return inputColours;
        }

        public string ConvertToString(List<string> encryptedList)
        {
            char[] charsToTrim = {',', ' '};
            var delimiter = ",";
            var body = "";
            foreach(string colour in encryptedList)
            {
                body += $"'{colour}'{delimiter} ";
            }
            body = body.TrimEnd(charsToTrim);
            return "[" + body + "]";
        }
    }
}