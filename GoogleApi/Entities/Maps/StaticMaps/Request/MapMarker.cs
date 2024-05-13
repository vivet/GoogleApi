using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.StaticMaps.Request.Enums;

namespace GoogleApi.Entities.Maps.StaticMaps.Request;

/// <summary>
/// Represents a set of location markers to be drawn on a map with certain style properties.
/// </summary>
public class MapMarker
{
    /// <summary>
    /// Label (optional) specifies a single uppercase alphanumeric character from the set {A-Z, 0-9}.
    /// The requirement for uppercase characters is new to this version of the API.
    /// Note that default and mid sized markers are the only markers capable of displaying an alphanumeric-character parameter.
    /// Tiny and small markers are not capable of displaying an alphanumeric-character.
    /// </summary>
    public virtual string Label { get; set; }

    /// <summary>
    /// Color (optional).
    /// Specifies a color either as a 24-bit (example: color=0xFFFFCC) or 32-bit hexadecimal value (example: color=0xFFFFCCFF),
    /// or from the set {black, brown, green, purple, yellow, blue, gray, orange, red, white}.
    /// When a 32-bit hex value is specified, the last two characters specify the 8-bit alpha transparency value.
    /// This value varies between 00 (completely transparent) and FF (completely opaque).
    /// Note that transparencies are supported in paths, though they are not supported for markers.
    /// </summary>
    public virtual string Color { get; set; }

    /// <summary>
    /// Size: (optional) specifies the size of marker from the set {tiny, mid, small}.
    /// If no size parameter is set, the marker will appear in its default (normal) size.
    /// </summary>
    public virtual MarkerSize? Size { get; set; }

    /// <summary>
    /// Rather than use Google's marker icons, you are free to use your own custom icons instead.
    /// You can use up to five unique custom icons per request. This limitation does not mean that you are limited to only 5 marked locations on your map.
    /// Each unique icon may be used with more than one markers location on your map.
    /// </summary>
    public virtual MapMarkerIcon Icon { get; set; }

    /// <summary>
    /// Each marker descriptor must contain a set of one or more locations defining where to place the marker on the map.
    /// These locations may be either specified as latitude/longitude values or as addresses.
    /// These locations are separated using the pipe character (|).
    /// The location parameters define the marker's location on the map. If the location is off the map, that marker will not appear in the constructed image provided
    /// that center and zoom parameters are supplied. However, if these parameters are not supplied, the Google Static Maps API server will automatically
    /// construct an image which contains the supplied markers.
    /// </summary>
    public virtual IEnumerable<Location> Locations { get; set; } = new List<Location>();

    /// <summary>
    /// Returns a string representation of a <see cref="MapMarker"/>.
    /// </summary>
    /// <returns>The string representation.</returns>
    public override string ToString()
    {
        var builder = new StringBuilder();

        if (!this.Locations.Any())
        {
            return null;
        }

        var hasLabel = !string.IsNullOrEmpty(this.Label) && this.Size is not (MarkerSize.Tiny or MarkerSize.Small);
        if (hasLabel)
        {
            builder
                .Append($"label:{this.Label}|");
        }

        if (this.Color != null)
        {
            builder
                .Append($"color:{this.Color}|");
        }

        if (this.Size.HasValue)
        {
            builder
                .Append($"size:{this.Size?.ToString().ToLower()}|");
        }

        if (this.Icon != null)
        {
            builder
                .Append($"{this.Icon}|");
        }

        builder
            .Append(string.Join("|", this.Locations.Select(x => x.ToString())));

        if (builder.Length == 0)
        {
            return null;
        }

        return builder
            .ToString();
    }
}