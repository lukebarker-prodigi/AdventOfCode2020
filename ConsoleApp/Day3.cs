using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Day3 : IDay
    {
        private const char Tree = '#';
        private const char OpenSpace = '.';
        private const int SpacesToTheRightFromPart1 = 3;

        private ulong _treeCountPart1;

        public string[] RawInput { get; set; }

        public async Task Part1Async()
        {
            RawInput = await AdventOfCodeHelper.ReadInputForDayAsync(3);

            _treeCountPart1 = CountTrees(SpacesToTheRightFromPart1, 1);
            
            Console.WriteLine($"[Day 3] Tree count for part 1 is: {_treeCountPart1}!");
        }

        public async Task Part2Async()
        {
            // can just copy from part 1
            var right3Down1 = _treeCountPart1;

            var right1Down1 = CountTrees(1, 1);
            var right5Down1 = CountTrees(5, 1);
            var right7Down1 = CountTrees(7, 1);
            var right1Down2 = CountTrees(1, 2);

            // The multiplied entries were creating a negative number, caused by an overflow error
            // Converting to unsigned 64-bit resolved the issue.
            var grandTotal = right3Down1 * right1Down1 * right5Down1 * right7Down1 * right1Down2;
            Console.WriteLine($"[Day 3] Grand total: {grandTotal}!");
        }
        
        private ulong CountTrees(int spacesRight, int spacesDown)
        {
            ulong treeCount = 0;
            var width = RawInput[0].Length;
            var height = RawInput.Length;

            var (i, j) = (0, 0);

            while (j < height)
            {
                i = (i + spacesRight) % width;
                j += spacesDown;

                if (j >= height)
                {
                    break;
                }
                
                var currentChar = RawInput[j][i];

                var isATree = currentChar == Tree;
                treeCount += Convert.ToUInt64(isATree);

                var logName = isATree ? nameof(Tree) : nameof(OpenSpace);
                Console.WriteLine($"[Day 3] Position {(j, i)} is a: {logName}");
            }

            return treeCount;
        }
    }
}