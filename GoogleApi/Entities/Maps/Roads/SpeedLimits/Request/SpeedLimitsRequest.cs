using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Maps.Roads.Common.Enums;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Roads.Common;

namespace GoogleApi.Entities.Maps.Roads.SpeedLimits.Request;

/// <summary>
/// Speed limits request.
/// </summary>
public class SpeedLimitsRequest : BaseMapsRequest, IRequestQueryString
{
    /// <inheritdoc />
    protected internal override string BaseUrl => "roads.googleapis.com/v1/speedLimits";

    /// <summary>
    /// path — The path to be snapped (required or PlaceIds).
    /// The path parameter accepts a list of latitude/longitude pairs.
    /// Latitude and longitude values should be separated by commas.
    /// Coordinates should be separated by the pipe character: "|". For example: path=60.170880,24.942795|60.170879,24.942796|60.170877,24.942796.
    /// </summary>
    public virtual IEnumerable<Coordinate> Path { get; set; } = new List<Coordinate>();

    /// <summary>
    /// placeId — The place ID of the road segment.
    /// Place IDs are returned by the snapToRoads method. You can pass up to 100 placeIds with each request.
    /// </summary>
    public virtual IEnumerable<Place> Places { get; set; } = new List<Place>();

    /// <summary>
    /// units (optional) — Whether to return speed limits in kilometers or miles per hour. This can be set to either KPH or MPH. Defaults to KPH.
    /// </summary>
    public virtual Units Unit { get; set; } = Units.Kph;

    /// <inheritdoc />
    public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
    {
        var parameters = base.GetQueryStringParameters();

        if ((this.Path == null || !this.Path.Any()) && (this.Places == null || !this.Places.Any()))
            throw new ArgumentException($"'{nameof(this.Path)}' or '{nameof(this.Places)}' is required");

        if (this.Path != null && this.Path.Any())
        {
            if (this.Path.Count() > 100)
                throw new ArgumentException($"'{nameof(this.Path)}' must contain equal or less than 100 coordinates");

            parameters.Add("path", string.Join("|", this.Path));
        }
        else
        {
            if (this.Places.Count() > 100)
                throw new ArgumentException($"'{nameof(this.Places)}' must contain equal or less than 100 places");

            foreach (var place in this.Places)
            {
                parameters.Add("placeId", place.ToString());
            }
        }

        return parameters;
    }
}