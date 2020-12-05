using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Day4 : IDay
    {
        private List<Passport> _passports;
        
        public string[] RawInput { get; set; }

        public async Task Part1Async()
        {
            Console.WriteLine("[Day 4] Reading batch data...");
            ReadPassportBatchData();

            Console.WriteLine("[Day 4] Converting to passports...");
            ConvertToPassports();

            Console.WriteLine("[Day 4] Counting valid passports...");
            var validPassportCount = _passports.Count(p => p.IsValid());

            Console.WriteLine($"[Day 4] Counted {validPassportCount} valid passports!");
        }

        public async Task Part2Async()
        {
            Console.WriteLine("[Day 4] Counting valid passports for part 2...");
            var validPassportCount = _passports.Count(p => p.IsValidPart2());

            Console.WriteLine($"[Day 4] Counted {validPassportCount} valid passports for part 2!");
        }

        private void ReadPassportBatchData()
        {
            RawInput = File.ReadAllText("Inputs/Day4.txt").Split(
                new[] { "\r\n\r\n" },
                StringSplitOptions.None
            );
        }

        private void ConvertToPassports()
        {
            _passports = new List<Passport>();
            
            foreach (var passport in RawInput)
            {
                _passports.Add(new Passport(passport));
            }
        }
    }
}