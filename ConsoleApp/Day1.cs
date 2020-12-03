using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Day1 : IDay
    {
        private int[] _numbers;
        private int _expectedTotal;
        
        public string[] RawInput { get; set; }
        
        public async Task Part1Async()
        {
            RawInput = await AdventOfCodeHelper.ReadInputForDayAsync(1);

            _numbers = RawInput.Select(x => Convert.ToInt32(x)).ToArray();
            // var numbers = new[] {1721, 979, 366, 299, 675, 1456};
            
            _expectedTotal = 2020;

            Console.WriteLine("[Day 1] Defined parameters:");
            Console.WriteLine(_numbers);
            Console.WriteLine($"[Day 1] expectedTotal: {_expectedTotal}");

            // Part 1
            Console.WriteLine("[Day 1] Finding pair with sum...");
            
            var pair = FindPairWithSum(_numbers, _expectedTotal);

            if (pair.HasValue)
            {
                Console.WriteLine($"[Day 1] Pair found: {pair}");
                Console.WriteLine($"[Day 1] Product: {pair.Value.first * pair.Value.second}");
            }
            else
            {
                Console.WriteLine("[Day 1] Pair not found :(");
            }
        }

        public async Task Part2Async()
        {
            // Part 2
            Console.WriteLine("[Day 1] Finding triplet with sum...");
            
            var triplet = FindTripletWithSum(_numbers, _expectedTotal);

            if (triplet.HasValue)
            {
                Console.WriteLine($"[Day 1] Triplet found: {triplet}");
                Console.WriteLine($"[Day 1] Product: {triplet.Value.first * triplet.Value.second * triplet.Value.third}");
            }
            else
            {
                Console.WriteLine("[Day 1] Triplet not found :(");
            }
        }

        private static (int first, int second)? FindPairWithSum(int[] numbers, int sum)
        {
            var compliments = new HashSet<int>();

            foreach (var number in numbers)
            {
                var currentCompliment = sum - number;
                
                if (compliments.Contains(currentCompliment))
                {
                    return (number, currentCompliment);
                }

                compliments.Add(number);
            }

            return null;
        }

        private static (int first, int second, int third)? FindTripletWithSum(int[] numbers, int sum)
        {
            var compliments = new HashSet<int>();

            foreach (var number in numbers)
            {
                var currentCompliment = sum - number;
                var numbersWithoutCurrentNumber = new List<int>(numbers);
                numbersWithoutCurrentNumber.Remove(number);
                var potentialPair = FindPairWithSum(numbersWithoutCurrentNumber.ToArray(), currentCompliment);

                if (potentialPair.HasValue)
                {
                    return (number, potentialPair.Value.first, potentialPair.Value.second);
                }

                compliments.Add(number);
            }

            return null;
        }
    }
}