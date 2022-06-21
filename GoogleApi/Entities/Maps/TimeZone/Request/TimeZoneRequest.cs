using System;
using System.Collections.Generic;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Interfaces;

namespace GoogleApi.Entities.Maps.TimeZone.Request;

/// <summary>
/// TimeZone request.
/// </summary>
public class TimeZoneRequest : BaseMapsChannelRequest, IRequestQueryString
{
    /// <inheritdoc />
    protected internal override string BaseUrl => "maps.googleapis.com/maps/api/timezone/json";

    /// <summary>
    /// A comma-separated lat,lng tuple (eg. location=-33.86,151.20), representing the location to look up
    /// </summary>
    public virtual Coordinate Location { get; set; }

    /// <summary>
    /// Timestamp specifies the desired time as seconds since midnight, January 1, 1970 UTC.
    /// The Time Zone API uses the timestamp to determine whether or not Daylight Savings should be applied.
    /// Times before 1970 can be expressed as negative values.
    /// </summary>
    public virtual DateTime TimeStamp { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// The language in which to return results. See the list of supported domain languages.
    /// Note that we often update supported languages so this list may not be exhaustive. Defaults to en.
    /// </summary>
    public virtual Language Language { get; set; } = Language.English;

    /// <inheritdoc />
    public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
    {
        var parameters = base.GetQueryStringParameters();

        if (this.Location == null)
            throw new ArgumentException($"'{nameof(this.Location)}' is required");

        parameters.Add("language", this.Language.ToCode());
        parameters.Add("location", this.Location.ToString());
        parameters.Add("timestamp", this.TimeStamp.DateTimeToUnixTimestamp().ToString());

        return parameters;
    }
}