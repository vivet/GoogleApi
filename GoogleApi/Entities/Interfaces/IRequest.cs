using System;
using System.Collections.Generic;

namespace GoogleApi.Entities.Interfaces;

/// <summary>
/// Base interface for requests.
/// </summary>
public interface IRequest
{
    /// <summary>
    /// Your application's API key (required).
    /// This key identifies your application for purposes of quota management and so that Places added from your application are made immediately available to your app.
    /// Visit the APIs Console to create an API Project and obtain your key.
    /// https://developers.google.com/maps/api-key-best-practices
    /// </summary>
    string Key { get; set; }

    /// <summary>
    /// The client ID provided to you by Google Enterprise Support, or null to disable URL signing.
    /// All client IDs begin with a "gme-" prefix.
    /// </summary>
    string ClientId { get; set; }

    /// <summary>
    /// Returns the Uri for the request.
    /// </summary>
    /// <returns>The <see cref="Uri"/>.</returns>
    Uri GetUri();

    /// <summary>
    /// Get the query string collection of aggregated from all parameters added to the request.
    /// </summary>
    /// <returns>The <see cref="IList{KeyValuePair}"/> collection.</returns>
    IList<KeyValuePair<string, string>> GetQueryStringParameters();
}