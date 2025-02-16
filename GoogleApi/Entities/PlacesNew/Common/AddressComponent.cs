using System.Collections.Generic;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Enums;

namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// Address Component.
/// </summary>
public class AddressComponent
{
    /// <summary>
    /// The full text description or name of the address component. For example,
    /// an address component for the country Australia may have a long_name of "Australia"
    /// </summary>
    public virtual string LongText { get; set; }

    /// <summary>
    /// An abbreviated textual name for the address component, if available.
    /// For example, an address component for the country of Australia may have a short_name of "AU".
    /// </summary>
    public virtual string ShortText { get; set; }

    /// <summary>
    /// An array indicating the type(s) of the address component.
    /// </summary>
    public virtual IEnumerable<AddressComponentType> Types { get; set; }

    /// <summary>
    /// The language used to format this components, in CLDR notation.
    /// </summary>
    [JsonPropertyName("languageCode")]
    public virtual Language Language { get; set; }
}