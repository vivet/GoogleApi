using System;
using System.Collections.Generic;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.Routes.Request.Enums;

namespace GoogleApi.Entities.Maps.Routes.Request;

/// <summary>
/// Routes Request.
/// </summary>
public class RoutesRequest : BaseMapsRequest, IRequestJson
{
    /// <inheritdoc />
    protected internal override string BaseUrl => "routes.googleapis.com/v2:computeRoutes";

    /// <summary>
    /// Origin waypoint (required).
    /// </summary>
    public virtual WayPoint Origin { get; set; }

    /// <summary>
    /// Destination waypoint (required).
    /// </summary>
    public virtual WayPoint Destination { get; set; }

    /// <summary>
    /// Intermediates waypoint (optional).
    /// A set of waypoints along the route (excluding terminal points), for either stopping at or passing by. Up to 25 intermediate waypoints are supported
    /// </summary>
    public virtual WayPoint Intermediates { get; set; }

    /// <summary>
    /// Specifies the mode of transportation. (optional).
    /// </summary>
    public virtual RouteTravelMode TravelMode { get; set; } = RouteTravelMode.Drive;

    /// <summary>
    /// Specifies the mode of transportation. (optional).
    /// </summary>
    public virtual RoutingPreference RoutingPreference { get; set; } = RoutingPreference.TrafficAware;

    /// <summary>
    /// Specifies the mode of transportation. (optional).
    /// </summary>
    public virtual PolylineQuality PolylineQuality { get; set; } = PolylineQuality.Overview;

    /// <summary>
    /// Specifies the mode of transportation. (optional).
    /// </summary>
    public virtual PolylineEncoding PolylineEncoding { get; set; } = PolylineEncoding.EncodedPolyline;

    /// <summary>
    /// The departure time (optional).
    /// If you don't set this value, then this value defaults to the time that you made the request.
    /// If you set this value to a time that has already occurred, then the request fails.
    /// A timestamp in RFC3339 UTC "Zulu" format, with nanosecond resolution and up to nine fractional digits.
    /// Examples: "2014-10-02T15:01:23Z" and "2014-10-02T15:01:23.045123456Z".
    /// </summary>
    public virtual DateTime? DepartureTime { get; set; }

    /// <summary>
    /// Compute Alternative Routes (optional).
    /// Specifies whether to calculate alternate routes in addition to the route.
    /// No alternative routes are returned for requests that have intermediate waypoints.
    /// </summary>
    public virtual bool ComputeAlternativeRoutes { get; set; } = false;

    /// <summary>
    /// Route Modifiers (optional).
    /// A set of conditions to satisfy that affect the way routes are calculated.
    /// </summary>
    public virtual RouteModifiers RouteModifiers { get; set; }

    /// <summary>
    /// Language Code (optional).
    /// The BCP-47 language code, such as "en-US" or "sr-Latn".
    /// For more information, see http://www.unicode.org/reports/tr35/#Unicode_locale_identifier.
    /// See Language Support for the list of supported languages.
    /// When you don't provide this value, the display language is inferred from the location of the route request.
    /// </summary>
    public virtual Language Language { get; set; } = Language.English;

    /// <summary>
    /// Region Code (optional).
    /// The region code, specified as a ccTLD ("top-level domain") two-character value.
    /// For more information see https://en.wikipedia.org/wiki/List_of_Internet_top-level_domains#Country_code_top-level_domains
    /// </summary>
    public virtual string RegionCode { get; set; }

    /// <summary>
    /// Units (optional).
    /// Specifies the units of measure for the display fields.
    /// This includes the instruction field in NavigationInstruction.
    /// The units of measure used for the route, leg, step distance, and duration are not affected by this value.
    /// If you don't provide this value, then the display units are inferred from the location of the request.
    /// </summary>
    public virtual Units Units { get; set; } = Units.Metric;

    /// <summary>
    /// Requested Reference Routes (optional).
    /// Specifies what reference routes to calculate as part of the request in addition to the default route.
    /// A reference route is a route with a different route calculation objective than the default route.
    /// For example a FUEL_EFFICIENT reference route calculation takes into account various parameters
    /// that would generate an optimal fuel efficient route.
    /// </summary>
    public virtual IEnumerable<ReferenceRoute> RequestedReferenceRoutes { get; set; } = new List<ReferenceRoute>();

    /// <summary>
    /// Extra Computations (optional).
    /// A list of extra computations which may be used to complete the request.
    /// Note: These extra computations may return extra fields on the response.
    /// These extra fields must also be specified in the field mask to be returned in the response.
    /// </summary>
    public virtual IEnumerable<ExtraComputation> ExtraComputations { get; set; } = new List<ExtraComputation>();
}