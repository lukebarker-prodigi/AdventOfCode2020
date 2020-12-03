using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        /**
         * 
         * N.B.
         *
         * I am solving these puzzles on the assumption that the inputs are already stored in memory for us.
         * Therefore, the time taken to load from the input files to memory as arrays can be dis-regarded.
         *
         * See AdventOfCodeHelper.ReadInputForDayAsync()
         * 
         */
        
        static async Task Main(string[] args)
        {
            // await ExecuteDay(1);
            // await ExecuteDay(2);
            await ExecuteDay(3); 
        }

        static async Task ExecuteDay(int dayNumber)
        {
            Console.WriteLine($"[Day {dayNumber}] start");

            var day = DayFactory.CreateDay(dayNumber);

            Console.WriteLine($"[Day {dayNumber}] Calling part 1...");
            await day.Part1Async();
            
            Console.WriteLine($"[Day {dayNumber}] Calling part 2...");
            await day.Part2Async();
            
            Console.WriteLine($"[Day {dayNumber}] finish");
        }
    }
}