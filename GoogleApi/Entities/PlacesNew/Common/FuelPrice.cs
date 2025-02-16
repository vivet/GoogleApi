using System;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Converters;
using GoogleApi.Entities.PlacesNew.Common.Enums;

namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// Fuel price information for a given type.
/// </summary>
public class FuelPrice
{
    /// <summary>
    /// The type of fuel.
    /// </summary>
    public virtual FuelType Type { get; set; }

    /// <summary>
    /// The price of the fuel.
    /// </summary>
    public virtual Money Price { get; set; }

    /// <summary>
    /// The time the fuel price was last updated.
    /// A timestamp in RFC3339 UTC "Zulu" format, with nanosecond resolution and up to nine fractional digits.
    /// Examples: "2014-10-02T15:01:23Z" and "2014-10-02T15:01:23.045123456Z"
    /// </summary>
    [JsonConverter(typeof(EpochSecondsToDateTimeJsonConverter))]
    public virtual DateTime UpdateTime { get; set; }
}