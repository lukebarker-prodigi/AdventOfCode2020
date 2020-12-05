using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
    public class Passport
    {
        private const string BirthYearKey = "byr";
        private const string IssueYearKey = "iyr";
        private const string ExpirationYearKey = "eyr";
        private const string HeightKey = "hgt";
        private const string HairColourKey = "hcl";
        private const string EyeColourKey = "ecl";
        private const string PassportIdKey = "pid";
        private const string CountryIdKey = "cid";
        
        
        public Passport(string passportStr)
        {
            if (string.IsNullOrWhiteSpace(passportStr))
            {
                throw new ArgumentException("Empty passport!");
            }

            passportStr = passportStr.Replace("\r\n", " ");

            var passportParts = new Dictionary<string, string>();

            var existingfields = passportStr.Split(' ');

            foreach (var field in existingfields)
            {
                var components = field.Split(':');
                passportParts.TryAdd(components[0], components[1]);
            }

            passportParts.TryGetValue(BirthYearKey, out BirthYear);
            passportParts.TryGetValue(IssueYearKey, out IssueYear);
            passportParts.TryGetValue(ExpirationYearKey, out ExpirationYear);
            passportParts.TryGetValue(HeightKey, out Height);
            passportParts.TryGetValue(HairColourKey, out HairColour);
            passportParts.TryGetValue(EyeColourKey, out EyeColour);
            passportParts.TryGetValue(PassportIdKey, out PassportId);
            passportParts.TryGetValue(CountryIdKey, out CountryId);
        }

        public string BirthYear;

        public string IssueYear;

        public string ExpirationYear;

        public string Height;

        public string HairColour;

        public string EyeColour;

        public string PassportId;

        public string CountryId;

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(BirthYear)
                   && !string.IsNullOrWhiteSpace(IssueYear)
                   && !string.IsNullOrWhiteSpace(ExpirationYear)
                   && !string.IsNullOrWhiteSpace(Height)
                   && !string.IsNullOrWhiteSpace(HairColour)
                   && !string.IsNullOrWhiteSpace(EyeColour)
                   && !string.IsNullOrWhiteSpace(PassportId);
        }

        public bool IsValidPart2()
        {
            return BirthYearIsValid()
                   && IssueYearIsValid()
                   && ExpirationYearIsValid()
                   && HeightIsValid()
                   && HairColourIsValid()
                   && EyeColourIsValid()
                   && PassportIdIsValid();
        }

        private bool BirthYearIsValid()
        {
            var yearAsInt = Convert.ToInt32(BirthYear);
            
            return yearAsInt >= 1920 && yearAsInt <= 2002;
        }
        
        private bool IssueYearIsValid()
        {
            var yearAsInt = Convert.ToInt32(IssueYear);
            
            return yearAsInt >= 2010 && yearAsInt <= 2020;
        }
        
        private bool ExpirationYearIsValid()
        {
            var yearAsInt = Convert.ToInt32(ExpirationYear);
            
            return yearAsInt >= 2020 && yearAsInt <= 2030;
        }

        private bool HeightIsValid()
        {
            var components = Height.Split(new[] {"cm", "in"}, StringSplitOptions.None);
            if (components.Length <= 1) return false;
            var valAsNumber = Convert.ToSingle(components[0]);
            var sizeUnit = Height.Substring(Height.Length - 2);

            if (sizeUnit == "cm")
            {
                return valAsNumber >= 150 && valAsNumber <= 193;
            }
            
            if (sizeUnit == "in")
            {
                return valAsNumber >= 59 && valAsNumber <= 76;
            }

            return false;
        }

        private bool HairColourIsValid()
        {
            var regex = new Regex("^#[0-9a-fA-F]{6}$");
            if (string.IsNullOrWhiteSpace(HairColour))
            {
                return false;
            }
            var isOk = regex.IsMatch(HairColour);

            return isOk;
        }

        private bool EyeColourIsValid()
        {
            var validColours = new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            var isOk = validColours.Contains(EyeColour);

            return isOk;
        }

        private bool PassportIdIsValid()
        {
            var isOk = uint.TryParse(PassportId, out _) && PassportId.Length == 9;
            return isOk;
        }
    }
}