using System;
namespace NasaqData
{
    public class DailyQuote
    {
        public DateTime Date { get; }
        public decimal Close { get; }
        public ulong Volume { get; }
        public decimal Open { get; }
        public decimal High { get; }
        public decimal Low { get; }

        public DailyQuote(DateTime date,
            decimal close,
            ulong volume,
            decimal open,
            decimal high,
            decimal low)
        {
            Date = date;
            Close = close;
            Volume = volume;
            Open = open;
            High = high;
            Low = low;
        }

        public DailyQuote(string line)
        {
            string[] cells = line.Split(',');

            Date = Convert.ToDateTime(cells[0]);
            Close = Convert.ToDecimal(cells[1].Remove(0,1));
            Volume = Convert.ToUInt64(cells[2]);
            Open = Convert.ToDecimal(cells[3].Remove(0,1));
            High = Convert.ToDecimal(cells[4].Remove(0,1));
            Low = Convert.ToDecimal(cells[5].Remove(0,1));
        }

    }
}
