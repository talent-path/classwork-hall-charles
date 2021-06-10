using System;

namespace Problem19
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstSundays = 0;

            for(DateTime startDate = new DateTime(1901, 1, 1); startDate <= new DateTime(2000, 12, 1); startDate = startDate.AddMonths(1))
            {
                if(startDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    firstSundays += 1;
                }
            }
            Console.WriteLine(firstSundays);
        }
    }
}
