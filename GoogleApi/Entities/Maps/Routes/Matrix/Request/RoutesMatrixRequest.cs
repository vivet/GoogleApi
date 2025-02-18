using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.Routes.Common.Converters;
using GoogleApi.Entities.Maps.Routes.Common.Enums;
using GoogleApi.Entities.Maps.Routes.Matrix.Request.Enums;

namespace GoogleApi.Entities.Maps.Routes.Matrix.Request;

/// <summary>
/// Routes Matrix Request.
/// </summary>
public class RoutesMatrixRequest : BaseRequestX, IRequestJsonX
{
    /// <inheritdoc />
    protected internal override string BaseUrl => "routes.googleapis.com/distanceMatrix/v2:computeRouteMatrix";

    /// <summary>
    /// Specifies the mode of transportation. (optional).
    /// </summary>
    public virtual RouteTravelMode TravelMode { get; set; } = RouteTravelMode.Drive;

    /// <summary>
    /// Specifies the mode of transportation. (optional).
    /// </summary>
    public virtual RoutingPreference? RoutingPreference { get; set; }

    /// <summary>
    /// The departure time (optional).
    /// If you don't set this value, then this value defaults to the time that you made the request.
    /// If you set this value to a time that has already occurred, then the request fails.
    /// A timestamp in RFC3339 UTC "Zulu" format, with nanosecond resolution and up to nine fractional digits.
    /// Examples: "2014-10-02T15:01:23Z" and "2014-10-02T15:01:23.045123456Z".
    /// </summary>
    [JsonConverter(typeof(DateTimeRfc3339JsonConverter))]
    public virtual DateTime? DepartureTime { get; set; }

    /// <summary>
    /// Optional. The arrival time.
    /// Be aware Can only be set when RouteTravelMode is set to TRANSIT.
    /// You can specify either departureTime or arrivalTime, but not both.
    /// A timestamp in RFC3339 UTC "Zulu" format, with nanosecond resolution and up to nine fractional digits.
    /// Examples: "2014-10-02T15:01:23Z" and "2014-10-02T15:01:23.045123456Z".
    /// </summary>
    [JsonConverter(typeof(DateTimeRfc3339JsonConverter))]
    public virtual DateTime? ArrivalTime { get; set; }

    /// <summary>
    /// Language Code (optional).
    /// The BCP-47 language code, such as "en-US" or "sr-Latn".
    /// For more information, see http://www.unicode.org/reports/tr35/#Unicode_locale_identifier.
    /// See Language Support for the list of supported languages.
    /// When you don't provide this value, the display language is inferred from the location of the route request.
    /// </summary>
    [JsonPropertyName("languageCode")]
    public virtual Language Language { get; set; } = Language.English;

    /// <summary>
    /// Optional. Specifies the assumptions to use when calculating time in traffic.
    /// This setting affects the value returned in the duration field in the Route and RouteLeg which contains the predicted time in traffic based on historical averages.
    /// TrafficModel is only available for requests that have set RoutingPreference to TRAFFIC_AWARE_OPTIMAL and RouteTravelMode to DRIVE.
    /// Defaults to BEST_GUESS if traffic is requested and TrafficModel is not specified.
    /// </summary>
    public virtual TrafficModel? TrafficModel { get; set; }

    /// <summary>
    /// Region Code (optional).
    /// The region code, specified as a ccTLD ("top-level domain") two-character value.
    /// For more information see https://en.wikipedia.org/wiki/List_of_Internet_top-level_domains#Country_code_top-level_domains
    /// </summary>
    public virtual string RegionCode { get; set; }

    /// <summary>
    /// Extra Computations (optional).
    /// A list of extra computations which may be used to complete the request.
    /// Note: These extra computations may return extra fields on the response.
    /// These extra fields must also be specified in the field mask to be returned in the response.
    /// </summary>
    public virtual IEnumerable<ExtraComputation> ExtraComputations { get; set; } = new List<ExtraComputation>();

    /// <summary>
    /// Origins (Required).
    /// Array of origins, which determines the rows of the response matrix.
    /// Several size restrictions apply to the cardinality of origins and destinations:
    /// - The number of elements(origins × destinations) must be no greater than 625 in any case.
    /// - The number of elements(origins × destinations) must be no greater than 100 if routingPreference is set to TRAFFIC_AWARE_OPTIMAL.
    /// - The number of waypoints(origins + destinations) specified as placeId must be no greater than 50.
    /// </summary>
    public virtual IEnumerable<RouteMatrixOrigin> Origins { get; set; } = new List<RouteMatrixOrigin>();

    /// <summary>
    /// Destinations (Required).
    /// Array of destinations, which determines the columns of the response matrix.
    /// </summary>
    public virtual IEnumerable<RouteMatrixDestination> Destinations { get; set; } = new List<RouteMatrixDestination>();
}