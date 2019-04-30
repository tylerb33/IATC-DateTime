using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //DATE PROMPT AND PROCESSING
            DateTime userDateFormatted;

            string userDate = GetDateFromUser();
            string userDateFormat = GetDateFormatFromUser();

            switch (userDateFormat)
            {
                case "MM/DD":
                    userDateFormatted = DateTime.ParseExact(userDate, "M/d/yyyy", null);
                    break;

                case "DD/MM":
                    userDateFormatted = DateTime.ParseExact(userDate, "d/M/yyyy", null);
                    break;
                default:
                    userDateFormatted = DateTime.ParseExact(userDate, "M/d/yyyy", null);
                    break;
            }

            TimeSpan previousDate = DateTime.Now.Subtract(userDateFormatted);

            if (previousDate.Ticks < 0)
            {
                ConsoleOutput($"{ userDate } is { Math.Round(-previousDate.TotalDays, 0 , MidpointRounding.AwayFromZero) } days in the future.", "Cyan");
            }
            else
            {
                ConsoleOutput($"It has been {Math.Round(previousDate.TotalDays, 0, MidpointRounding.AwayFromZero) } days since { userDate }", "Cyan");
            }



            //TIME PROMPT AND PROCESSING
            Console.WriteLine("Enter a time:");
            string userTime = Console.ReadLine();

            DateTime userTimeFormatted;
            Console.WriteLine("Have you entered in 12-hour or 24-hour format?");
            Console.WriteLine("Enter either '12' or '24'");
            string userTimeFormat = Console.ReadLine();

            switch (userTimeFormat)
            {
                case "12":
                    userTimeFormatted = DateTime.ParseExact(userTime, "h:mm tt", null);
                    break;
                case "24":
                    userTimeFormatted = DateTime.ParseExact(userTime, "H:mm", null);
                    break;
                default: userTimeFormatted = DateTime.ParseExact(userTime, "h:mm tt", null);
                    break;
            }


            TimeSpan previousTime = DateTime.Now.Subtract(userTimeFormatted);

            if (previousTime.Ticks < 0)
            {
                previousTime = previousTime.Add(TimeSpan.FromHours(24));
            }

            Console.WriteLine($"It has been {previousTime.Hours} hours and {previousTime.Minutes} minutes since {userTime}.");





            Console.ReadLine();
        }

        private static void ConsoleOutput(string text, string foreground = "White")
        {
            switch (foreground)
            {
                case "White":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case "Green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case "Cyan":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;

                case "Yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case "Red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

            }

            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static string GetDateFromUser()
        {
            ConsoleOutput("Enter a date:", "Green");
            string userDate = Console.ReadLine();
            return userDate;
        }

        private static string GetDateFormatFromUser()
        {
            ConsoleOutput("Have you entered in MM/DD/YYY or DD/MM/YYYY format?", "Green");
            ConsoleOutput("Enter either 'MM/DD' or 'DD/MM'", "Yellow");
            string userDateFormat = Console.ReadLine();
            return userDateFormat;
        }
    }
}
