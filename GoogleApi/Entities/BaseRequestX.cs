using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Interfaces;

namespace GoogleApi.Entities;

/// <summary>
/// Base abstract class for requests.
/// </summary>
public abstract class BaseRequestX : IRequestX
{
    /// <summary>
    /// Base Url (abstract).
    /// </summary>
    [JsonIgnore]
    protected internal abstract string BaseUrl { get; }

    /// <inheritdoc />
    [JsonIgnore]
    public virtual string Key { get; set; }

    /// <inheritdoc />
    [JsonIgnore]
    public virtual string FieldMask { get; set; } = "*";

    /// <inheritdoc />
    public virtual Uri GetUri()
    {
        const string SCHEME = "https://";

        var queryStringParameters = this.GetQueryStringParameters()
            .Select(x =>
                x.Value == null
                    ? Uri.EscapeDataString(x.Key)
                    : Uri.EscapeDataString(x.Key) + "=" + Uri.EscapeDataString(x.Value));
        var queryString = string.Join("&", queryStringParameters);

        if (!string.IsNullOrEmpty(queryString))
        {
            queryString = $"?{queryString}";
        }

        var uri = new Uri($"{SCHEME}{this.BaseUrl}{queryString}");

        return uri;
    }

    /// <inheritdoc />
    public virtual IList<KeyValuePair<string, string>> GetQueryStringParameters()
    {
        var parameters = new List<KeyValuePair<string, string>>();

        if (string.IsNullOrEmpty(this.Key))
        {
            throw new ArgumentException($"'{nameof(this.Key)}' is required");
        }
        
        return parameters;
    }
}