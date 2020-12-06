using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var years = -1 * expirationSection.GetValue<int>("Years");
            var months = -1 * expirationSection.GetValue<int>("Months");
            var days = -1 * expirationSection.GetValue<int>("Days");
            
            return DateTime.Now
                .AddYears(years)
                .AddMonths(months)
                .AddDays(days);
        }
    }
}
