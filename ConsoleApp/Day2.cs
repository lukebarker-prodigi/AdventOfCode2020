using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Day2 : IDay
    {
        private List<PasswordRow> _extractedPasswords;
        
        public string[] RawInput { get; set; }
        
        public async Task Part1Async()
        {
            RawInput = await AdventOfCodeHelper.ReadInputForDayAsync(2);

            _extractedPasswords = ExtractPasswordRows(RawInput);

            var validPasswordCount = 0;

            foreach (var passwordRow in _extractedPasswords)
            {
                validPasswordCount += Convert.ToInt32(passwordRow.PasswordStringIsValid());
            }

            Console.WriteLine($"[Day 2] {validPasswordCount} valid passwords detected!");
        }

        public async Task Part2Async()
        {
            var validPasswordCount = 0;

            foreach (var passwordRow in _extractedPasswords)
            {
                validPasswordCount += Convert.ToInt32(passwordRow.PasswordStringIsValidPart2());
            }

            Console.WriteLine($"[Day 2] {validPasswordCount} valid passwords detected!");
        }
        
        static List<PasswordRow> ExtractPasswordRows(IEnumerable<string> rows)
        {
            var passwordRows = new List<PasswordRow>();
            var regex = new Regex("^([0-9]+)-([0-9]+)\\s([a-z]):\\s([a-z]+)$");
            
            var rowCount = 0;

            foreach (var row in rows)
            {
                var match = regex.Match(row);

                while (match.Success)
                {
                    passwordRows.Add(new PasswordRow()
                    {
                        MinOccurences = Convert.ToInt32(match.Groups[1].ToString()),
                        MaxOccurences = Convert.ToInt32(match.Groups[2].ToString()),
                        Character = match.Groups[3].ToString()[0],
                        PasswordString = match.Groups[4].ToString()
                    });
                    rowCount += 1;
                    Console.WriteLine($"- Row {rowCount}");
                    for (int i = 1; i <= match.Groups.Count; i++)
                    {
                        var grp = match.Groups[i];
                        Console.WriteLine("\t- Group " + i + " = '" + grp + "'");
                    }
                    match = match.NextMatch();
                }
            }

            return passwordRows;
        }
    }
}