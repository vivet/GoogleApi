using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.PlacesNew.Common;

namespace GoogleApi.Entities.PlacesNew.Details.Response;

/// <summary>
/// Places New Details Response.
/// </summary>
public class PlacesNewDetailsResponse : Place, IResponse
{
    /// <inheritdoc />
    public virtual string RawJson { get; set; }

    /// <inheritdoc />
    public virtual string RawQueryString { get; set; }

    /// <inheritdoc />
    public virtual Status Status { get; set; }

    /// <inheritdoc />
    [JsonIgnore]
    public virtual string ErrorMessage { get; set; }
}