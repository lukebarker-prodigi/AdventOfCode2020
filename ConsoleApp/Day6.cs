using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Day6 : IDay
    {
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        private const int AlphabetLength = 26;

        public string[] RawInput { get; set; }
        public async Task Part1Async()
        {
            ReadBatchData();

            var totalAnswers = 0;

            for (int i = 0; i < RawInput.Length; i++)
            {
                if (RawInput[i].Contains("\r\n"))
                {
                    RawInput[i] = RawInput[i].Replace("\r\n", " ");
                }

                var uniqueAnswers = RawInput[i].Intersect(Alphabet);
                totalAnswers += uniqueAnswers.Count();
            }

            Console.WriteLine($"[Day 6] Total Answers in part 1: {totalAnswers}");
        }

        public async Task Part2Async()
        {
            var totalAnswers = 0;

            foreach (var group in RawInput)
            {
                var answersDict = new Dictionary<char, int>();
                var answers = group.Split(' ');

                foreach (var answer in answers)
                {
                    foreach (var c in answer)
                    {
                        if (!answersDict.ContainsKey(c))
                        {
                            answersDict[c] = 0;
                        }

                        answersDict[c]++;
                    }
                }
                
                // answers.Length represents the number of people in each group!
                var lettersWhereAllAnsweredYes = answersDict.Count(kvp => kvp.Value == answers.Length);
                totalAnswers += lettersWhereAllAnsweredYes;
            }
            
            Console.WriteLine($"[Day 6] Total Answers in part 2: {totalAnswers}");
        }
        
        private void ReadBatchData()
        {
            RawInput = File.ReadAllText("Inputs/Day6.txt").Split(
                new[] { "\r\n\r\n" },
                StringSplitOptions.None
            );
        }
    }
}