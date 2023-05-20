using System.Collections.Generic;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Enums;

namespace GoogleApi.Entities.Common;

/// <summary>
/// Address Component.
/// </summary>
public class AddressComponent
{
    /// <summary>
    /// short_name is an abbreviated textual name for the address component, if available. For example, an address component for the state of Alaska may have a long_name of "Alaska" and a short_name of "AK" using the 2-letter postal abbreviation.
    /// </summary>
    [JsonPropertyName("short_name")]
    public virtual string ShortName { get; set; }

    /// <summary>
    /// long_name is the full text description or name of the address component as returned by the Geocoder.
    /// </summary>
    [JsonPropertyName("long_name")]
    public virtual string LongName { get; set; }

    /// <summary>
    /// types[] is an array indicating the type of the address component.
    /// </summary>
    public virtual IEnumerable<AddressComponentType> Types { get; set; }
}