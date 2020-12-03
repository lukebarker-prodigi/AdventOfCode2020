﻿using System;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class AdventOfCodeHelper
    {
        private const string InputsFolder = "Inputs";

        public static async Task<string[]> ReadInputForDayAsync(int dayNumber)
        {
            ValidateDayNumber(dayNumber);

            return await File.ReadAllLinesAsync(Path.Combine(InputsFolder, $"Day{dayNumber}.txt"));
        }

        public static void ValidateDayNumber(int dayNumber)
        {
            if (dayNumber < 1 || dayNumber > 31)
            {
                throw new ArgumentException($"Day number {dayNumber} is invalid for December!", nameof(dayNumber));
            }
        }
    }
}