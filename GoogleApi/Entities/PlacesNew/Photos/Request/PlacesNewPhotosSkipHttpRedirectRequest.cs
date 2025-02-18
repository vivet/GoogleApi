using System.Collections.Generic;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Interfaces;

namespace GoogleApi.Entities.PlacesNew.Photos.Request;

/// <inheritdoc />
public class PlacesNewPhotosSkipHttpRedirectRequest : PlacesNewPhotosRequest
{
    /// <inheritdoc />
    public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
    {
        var parameters = base.GetQueryStringParameters();

        parameters
            .Add("skipHttpRedirect", "true");

        return parameters;
    }
}