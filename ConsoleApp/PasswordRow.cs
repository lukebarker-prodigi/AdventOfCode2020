using System;
using System.Linq;

namespace ConsoleApp
{
    public class PasswordRow
    {
        public char Character { get; set; }
        public string PasswordString { get; set; }
        public int MinOccurences { get; set; }
        public int MaxOccurences { get; set; }

        public bool PasswordStringIsValid()
        {
            var charCount = PasswordString.Count(x => x == Character);

            return charCount >= MinOccurences && charCount <= MaxOccurences;
        }

        public bool PasswordStringIsValidPart2()
        {
            // min occurences is now
            var passwordStringLength = PasswordString.Length;
            return PasswordString[MinOccurences - 1] == Character ^ PasswordString[MaxOccurences - 1] == Character;
        }
    }
}