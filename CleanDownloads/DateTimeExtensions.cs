using System;

/* 12/7/2020
 * Extension methods to wrap the
 * functionality of the relational
 * comparison of the DateTime class
 * to make it more readable.
 * 
 * Zach Robinson
 */

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
