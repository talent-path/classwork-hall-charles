using System;

namespace DateTimeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a date (yyyy-MM-dd):");
            string userInput = Console.ReadLine();

            DateTime userDate = DateTime.ParseExact(userInput, "yyyy-MM-dd", null);

            int daysTilFriday = System.DayOfWeek.Friday - userDate.DayOfWeek;

            DateTime dateOfFriday = userDate.AddDays(daysTilFriday);

            Console.WriteLine("User Date: " + userDate);
            Console.WriteLine("Date of next Friday: " + dateOfFriday);
            Console.WriteLine("Days until next Friday: " + daysTilFriday);

        }
    }
}
