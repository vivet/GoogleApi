using System;

namespace GoogleApi.Extensions
{
    public static class DateTimeExtensions
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Converts a DateTime to a Unix timestamp
        /// </summary>
        public static int ToUnixTimestamp(this DateTime dateTime)
        {
            return (int)(dateTime - Epoch).TotalSeconds;
        }
    }
}