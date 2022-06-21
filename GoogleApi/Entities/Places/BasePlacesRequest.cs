using System;
using System.Collections.Generic;
using GoogleApi.Entities.Interfaces;

namespace GoogleApi.Entities.Places;

/// <summary>
/// Base abstract class for Places requests.
/// </summary>
public abstract class BasePlacesRequest : BaseRequest, IRequestQueryString
{
    /// <summary>
    /// Base Url.
    /// </summary>
    protected internal override string BaseUrl => "maps.googleapis.com/maps/api/place/";

    /// <summary>
    /// See <see cref="BaseRequest.GetQueryStringParameters()"/>.
    /// </summary>
    /// <returns>The <see cref="IList{KeyValuePair}"/> collection.</returns>
    public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
    {
        var parameters = base.GetQueryStringParameters();

        if (string.IsNullOrWhiteSpace(this.Key))
            throw new ArgumentException($"'{nameof(this.Key)}' is required");

        return parameters;
    }
}