using System.Collections.Generic;
using GoogleApi.Entities.Common;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Maps.Directions.Response;

/// <summary>
/// Contains the encoded and decoded data returned in the overview_polyline field.
/// </summary>
public class OverviewPolyline
{
    /// <summary>
    /// Points.
    /// The encoded string containing the raw overview polyline.
    /// </summary>
    [JsonProperty("points")]
    public virtual string Points { get; set; }

    /// <summary>
    /// Decoded PolyLine.
    /// The decocded polyline from the points.
    /// An array of Location objects representing the points in the encoded overview polyline.
    /// </summary>
    [JsonIgnore]
    public virtual IEnumerable<Coordinate> Line => GoogleFunctions.DecodePolyLine(this.Points);
}