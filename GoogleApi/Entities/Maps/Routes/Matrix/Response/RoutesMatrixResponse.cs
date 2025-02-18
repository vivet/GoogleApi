using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Routes.Matrix.Response.Converters;

namespace GoogleApi.Entities.Maps.Routes.Matrix.Response;

/// <summary>
/// Routes Matrix Response.
/// </summary>
[JsonConverter(typeof(RoutesMatrixResponseJsonConverter))]
public class RoutesMatrixResponse : BaseResponseX
{
    /// <summary>
    /// Matrix Element.
    /// </summary>
    public virtual IEnumerable<MatrixElement> Elements { get; set; } = new List<MatrixElement>();

    /// <summary>
    /// Error Message.
    /// </summary>
    [JsonIgnore]
    public override string ErrorMessage => this.Elements?.Select(x => x.Error?.Message).FirstOrDefault();

    /// <summary>
    /// Status.
    /// </summary>
    [JsonIgnore]
    public override Status Status => this.Elements?.Select(x => x.Error?.Status).FirstOrDefault() ?? base.Status;
}