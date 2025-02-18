using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Interfaces;

namespace GoogleApi.Entities.Maps.Roads.NearestRoads.Request;

/// <summary>
/// NearestRoads request.
/// </summary>
public class NearestRoadsRequest : BaseMapsRequest, IRequestQueryString
{
    /// <inheritdoc />
    protected internal override string BaseUrl => "roads.googleapis.com/v1/nearestRoads";

    /// <summary>
    /// points — A list of latitude/longitude pairs. Latitude and longitude values should be separated by commas.
    /// Coordinates should be separated by the pipe character: "|".
    /// For example: points=60.170880,24.942795|60.170879,24.942796|60.170877,24.942796.
    /// </summary>
    public virtual IEnumerable<LatLng> Points { get; set; } = new List<LatLng>();

    /// <inheritdoc />
    public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
    {
        var parameters = base.GetQueryStringParameters();

        if (this.Points == null || !this.Points.Any())
            throw new ArgumentException($"'{nameof(this.Points)}' is required");

        if (this.Points.Count() > 100)
            throw new ArgumentException($"'{nameof(this.Points)}' must contain equal or less than 100 coordinates");

        parameters.Add("points", string.Join("|", this.Points));

        return parameters;
    }
}