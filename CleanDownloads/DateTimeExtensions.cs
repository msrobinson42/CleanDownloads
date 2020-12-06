using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDownloads
{
    static class DateTimeExtensions
    {
        public static bool IsEarlierThan(this DateTime @this, DateTime date)
        {
            return @this < date;
        }

        public static bool IsLaterThan(this DateTime @this, DateTime date)
        {
            return @this > date;
        }
    }

    static class DateTimeOffsetExtensions
    {
        public static bool IsEarlierThan(this DateTimeOffset @this, DateTimeOffset date)
        {
            return @this < date;
        }

        public static bool IsLaterThan(this DateTimeOffset @this, DateTimeOffset date)
        {
            return @this > date;
        }
    }
}
