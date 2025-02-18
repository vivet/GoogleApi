using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Interfaces;

namespace GoogleApi.Entities.Maps.Roads.SnapToRoads.Request;

/// <summary>
/// SnapToRoads request.
/// </summary>
public class SnapToRoadsRequest : BaseMapsRequest, IRequestQueryString
{
    /// <inheritdoc />
    protected internal override string BaseUrl => "roads.googleapis.com/v1/snapToRoads";

    /// <summary>
    /// path — The path to be snapped (required). The path parameter accepts a list of latitude/longitude pairs. Latitude and longitude values should be separated by commas.
    /// Coordinates should be separated by the pipe character: "|". For example: path=60.170880,24.942795|60.170879,24.942796|60.170877,24.942796.
    /// </summary>
    public virtual IEnumerable<LatLng> Path { get; set; } = new List<LatLng>();

    /// <summary>
    /// Interpolate — Whether to interpolate a path to include all points forming the full road-geometry.
    /// When true, additional interpolated points will also be returned, resulting in a path that smoothly follows the geometry of the road, even around corners and through tunnels.
    /// Interpolated paths will most likely contain more points than the original path. Defaults to false.
    /// </summary>
    public virtual bool Interpolate { get; set; }

    /// <inheritdoc />
    public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
    {
        var parameters = base.GetQueryStringParameters();

        if (this.Path == null || !this.Path.Any())
            throw new ArgumentException($"'{nameof(this.Path)}' is required");

        if (this.Path.Count() > 100)
            throw new ArgumentException($"'{nameof(this.Path)}' must contain equal or less than 100 coordinates");

        parameters.Add("path", string.Join("|", this.Path));
        parameters.Add("interpolate", this.Interpolate.ToString().ToLower());

        return parameters;
    }
}