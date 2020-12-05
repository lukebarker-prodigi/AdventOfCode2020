using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Day5 : IDay
    {
        private List<PlaneSeat> _planeSeats;
        
        public string[] RawInput { get; set; }

        public async Task Part1Async()
        {
            RawInput = await AdventOfCodeHelper.ReadInputForDayAsync(5);
            
            _planeSeats = new List<PlaneSeat>();

            foreach (var seatStr in RawInput)
            {
                _planeSeats.Add(new PlaneSeat(seatStr));
            }

            Console.WriteLine(_planeSeats.Max(ps => ps.SeatId));
        }

        public async Task Part2Async()
        {
            var seatsInList = _planeSeats.Select(x => x.SeatId).OrderBy(x => x).ToArray();

            var (i, j) = (0, 2);
            
            while (i < seatsInList.Length - 2 && j < seatsInList.Length)
            {
                var seat1 = seatsInList[i];
                var seat2 = seatsInList[j];

                // this is our seat!
                if (seat2 - seat1 != 2)
                {
                    Console.WriteLine(seat1 + 1);
                }

                i++; j++;
            }
        }
    }
}