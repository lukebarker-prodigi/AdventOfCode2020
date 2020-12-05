using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class PlaneSeat
    {
        private const string RowCharacterSet = "FB";
        private const string ColCharacterSet = "LR";

        public PlaneSeat(string seatStr)
        {
            var rowStr = seatStr.Substring(0, 7);
            var colStr = seatStr.Substring(7, 3);
            
            RowNumber = TryParseNumber(rowStr, RowCharacterSet);
            ColumnNumber = TryParseNumber(colStr, ColCharacterSet);
        }
        
        public int RowNumber { get; set; }
        
        public int ColumnNumber { get; set; }

        public int SeatId => (RowNumber * 8) + ColumnNumber;

        private int TryParseNumber(string input, string characterSet)
        {
            var sb = new StringBuilder();

            foreach (var character in input)
            {
                var index = characterSet.IndexOf(character);

                if (index >= 0)
                {
                    sb.Append(index);
                }
            }

            return Convert.ToInt32(sb.ToString(), 2);
        }
    }
}