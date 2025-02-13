// https://learn.microsoft.com/en-us/dotnet/api/system.datetime?view=net-9.0
using System;
using System.Globalization;

namespace DotNetAPI;

public class DateTimeApp
{
  public static void Main(string[] args)
  {
    // Current date and time
    DateTime now = DateTime.Now;
    Console.WriteLine("Current Date and Time: " + now);

    // Specific date and time
    DateTime specificDate = new DateTime(2025, 5, 15, 14, 30, 0);
    Console.WriteLine("Specific Date: " + specificDate);

    // Formatting date: 
    // https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tostring?view=net-9.0#system-datetime-tostring
    Console.WriteLine("Formatted Date: " + now.ToString("yyyy/MM/dd HH:mm:ss"));

    CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("pt-BR");
    Console.WriteLine("Brazil format: " + now.ToString());
    CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
    Console.WriteLine("US format: " + now.ToString());

    Console.WriteLine("Universal Time: " + now.ToUniversalTime());
    Console.WriteLine(now.DayOfWeek);
    Console.WriteLine(now.DayOfYear);
    Console.WriteLine(now.Year);
    Console.WriteLine(now.Month);
    Console.WriteLine(now.Day);
    Console.WriteLine(now.Minute);
    Console.WriteLine(now.Second);
    Console.WriteLine(now.Millisecond);

    // Date Arithmetic
    DateTime futureDate = now.AddDays(10);
    Console.WriteLine("Ten days in the future: " + futureDate);

    DateTime pastDate = now.AddMonths(-2);
    Console.WriteLine("Two months ago: " + pastDate);

    DateTime twoHoursAgo = now.AddHours(-2);
    Console.WriteLine("Two hours ago: " + twoHoursAgo);

    // Difference between dates
    TimeSpan difference = futureDate - now;
    Console.WriteLine("Days between now and future date: " + difference.Days);

    // Parsing a date string
    Console.Write("Type a date using the format YYYY-MM-DD[ hh:mm:ss] = ");
    string dateString = Console.ReadLine();
    DateTime parsedDate;
    if (DateTime.TryParse(dateString, out parsedDate))
    {
      Console.WriteLine("Parsed Date: " + parsedDate);
    }
    else
    {
      Console.WriteLine("Invalid Date Format");
    }

    /*
     * UTC (Coordinated Universal Time) is the primary time standard used worldwide to regulate clocks and time. 
     * It is the same everywhere on Earth and does not change with the seasons
     * (i.e., no Daylight Saving Time adjustments)
     */
    DateTime utcNow = DateTime.UtcNow;
    Console.WriteLine("Current UTC Time: " + utcNow);

    // Converting to different time zones
    TimeZoneInfo pstZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
    DateTime pstTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, pstZone);
    Console.WriteLine("PST Time: " + pstTime);

    Console.WriteLine("All timezones");
    Console.WriteLine("".PadLeft(80, '='));
    var timeZones = TimeZoneInfo.GetSystemTimeZones();
    foreach (TimeZoneInfo timeZone in timeZones)
    {
      Console.WriteLine($"{timeZone.Id}: {timeZone.DisplayName}");
    }
  }
}