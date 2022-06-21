using System;

namespace GoogleApi.Entities.Common.Extensions;

/// <summary>
/// DateTime extensions.
/// </summary>
public static class DateTimeExtension
{
    /// <summary>
    /// Unix Epoch value.
    /// </summary>
    public static readonly DateTime epoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    /// <summary>
    /// Converts a DateTime to a Unix timestamp.
    /// </summary>
    public static int DateTimeToUnixTimestamp(this DateTime dateTime)
    {
        return (int)(dateTime - epoch).TotalSeconds;
    }
}