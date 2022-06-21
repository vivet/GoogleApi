using System;
using System.Collections.Generic;
using GoogleApi.Entities.Common.Extensions;

namespace GoogleApi.Entities.Maps.Geocoding.Place.Request;

/// <summary>
/// Place Geocoding Request.
/// </summary>
public class PlaceGeocodeRequest : BaseGeocodeRequest
{
    /// <summary>
    /// PlaceId (required).
    /// The place ID of the place for which you wish to obtain the human-readable address.
    /// The place ID is a unique identifier that can be used with other Google APIs. For example, you can use the placeID returned by the Google Maps Roads API
    /// to get the address for a snapped point. For more information about place IDs, see the place ID overview.
    /// The place ID may only be specified if the request includes an API key or a Google Maps APIs Premium Plan client ID.
    /// </summary>
    public virtual string PlaceId { get; set; }

    /// <inheritdoc />
    public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
    {
        var parameters = base.GetQueryStringParameters();

        if (string.IsNullOrWhiteSpace(this.PlaceId))
            throw new ArgumentException($"'{nameof(this.PlaceId)}' is required");

        parameters.Add("place_id", this.PlaceId);

        return parameters;
    }
}