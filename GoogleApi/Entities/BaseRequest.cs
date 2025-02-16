using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.Common.Extensions;

namespace GoogleApi.Entities;

/// <summary>
/// Base abstract class for requests.
/// </summary>
public abstract class BaseRequest : IRequest
{
    /// <summary>
    /// Base Url (abstract).
    /// </summary>
    [JsonIgnore]
    protected internal abstract string BaseUrl { get; }

    /// <inheritdoc />
    [JsonIgnore]
    public virtual string Key { get; set; }

    /// <summary>
    /// See Client Id.
    /// </summary>
    [JsonIgnore]
    public virtual string ClientId { get; set; }

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

        if (this.ClientId == null)
        {
            return uri;
        }

        var url = $"{uri.LocalPath}{uri.Query}&client={this.ClientId}";

        var privateKey = this.Key.Replace("-", "+").Replace("_", "/");
        var privateKeyBytes = Convert.FromBase64String(privateKey);
        var pathAndQueryBytes = Encoding.ASCII.GetBytes(uri.LocalPath + uri.Query);

        var hmacsha1 = new HMACSHA1(privateKeyBytes);
        var computeHash = hmacsha1.ComputeHash(pathAndQueryBytes);
        var signature = Convert.ToBase64String(computeHash).Replace("+", "-").Replace("/", "_");

        return new Uri($"{uri.Scheme}://{uri.Host}{url}&signature={signature}");
    }

    /// <inheritdoc />
    public virtual IList<KeyValuePair<string, string>> GetQueryStringParameters()
    {
        var parameters = new List<KeyValuePair<string, string>>();

        if (this.ClientId == null)
        {
            if (!string.IsNullOrWhiteSpace(this.Key))
            {
                parameters
                    .Add("key", this.Key);
            }
        }
        else
        {
            if (string.IsNullOrWhiteSpace(this.Key))
            {
                throw new ArgumentException("Key is required");
            }

            if (!this.ClientId.StartsWith("gme-"))
            {
                throw new ArgumentException("ClientId must begin with 'gme-'");
            }
        }

        return parameters;
    }
}