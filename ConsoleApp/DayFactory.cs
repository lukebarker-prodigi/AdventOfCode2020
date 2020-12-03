using System;

namespace ConsoleApp
{
    public class DayFactory
    {
        public static IDay CreateDay(int dayNumber)
        {
            AdventOfCodeHelper.ValidateDayNumber(dayNumber);

            var type = Type.GetType($"ConsoleApp.Day{dayNumber}") ??
                       throw new ArgumentException("Day not available yet!", nameof(dayNumber));

            dynamic instance = Activator.CreateInstance(type) as IDay;

            return instance;
        }

        public static IDay CreateCurrentDay()
        {
            return CreateDay(DateTime.UtcNow.Day);
        }
    }
}