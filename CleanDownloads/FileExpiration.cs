using Microsoft.Extensions.Configuration;
using System;

/* 12/7/2020
 * Holds logic for grabbing information
 * from the configuration file and then
 * converting the input into a relevant
 * expiration date.
 * 
 * Zach Robinson
 */

namespace CleanDownloads
{
    public class FileExpiration
    {
        readonly IConfiguration _config;

        public FileExpiration(IConfiguration config)
        {
            _config = config;
        }

        public DateTime GetExpirationDate()
        {
            var expirationSection = _config.GetSection("Expiration");
            var years = GetNegative(expirationSection.GetValue<int>("Years"));
            var months = GetNegative(expirationSection.GetValue<int>("Months"));
            var days = GetNegative(expirationSection.GetValue<int>("Days"));
            
            return DateTime.Now
                .AddYears(years)
                .AddMonths(months)
                .AddDays(days);

            // uses unary operator to invert a positive value
            static int GetNegative(int value) =>
                value > 0 ? -value : value;
        }

    }
}
