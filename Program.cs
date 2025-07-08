using System;
using System.Text;

class Program
{
    static void Main(string [] args)
    {
        string? tzId = null;
        if (args.Length > 0){
           tzId = args[0];
        }
         // ##### NOTES  ######################################################
         // Time Zone names are case-sensitive -- both types must match case in defined Identifier
        // list of IANA IDS: https://en.wikipedia.org/wiki/List_of_tz_database_time_zones
        // Get user's current TZ from Browser using JS: Intl.DateTimeFormat().resolvedOptions().timeZone
        // List of Windows TZs : https://learn.microsoft.com/en-us/windows-hardware/manufacture/desktop/default-time-zones?view=windows-11
         // Specify the time zone ID (Windows or IANA depending on platform and .NET version)
        string timeZoneId = tzId ?? "Eastern Standard Time"; // Example for Windows
        // string timeZoneId = "America/New_York"; // Example for IANA (Linux/macOS or .NET 6+)

        try
        {
            TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            DateTime utcNow = DateTime.UtcNow;
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, tz);

            Console.WriteLine($"Current time in {timeZoneId}: {localTime}");
        }
        catch (TimeZoneNotFoundException)
        {
            Console.WriteLine("Time zone ID not found.");
        }
        catch (InvalidTimeZoneException)
        {
            Console.WriteLine("Time zone data is corrupt.");
        }
    }
}
