using System.Text.Json.Serialization;
using GoogleApi.Entities.Interfaces;

namespace GoogleApi.Entities.Maps;

/// <summary>
/// Base Maps X Request.
/// </summary>
public abstract class BaseMapsXRequest : BaseMapsRequest, IRequestJsonX
{
    /// <inheritdoc />
    [JsonIgnore]
    public virtual string FieldMask { get; set; } = "*";
}