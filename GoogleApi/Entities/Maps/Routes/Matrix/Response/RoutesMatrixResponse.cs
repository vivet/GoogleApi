using System.Collections.Generic;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Maps.Routes.Matrix.Response.Converters;

namespace GoogleApi.Entities.Maps.Routes.Matrix.Response;

/// <summary>
/// Routes Matrix Response.
/// </summary>
[JsonConverter(typeof(RoutesMatrixResponseConverter))]
public class RoutesMatrixResponse : BaseRouteResponse
{
    /// <summary>
    /// Matrix Element.
    /// </summary>
    public virtual IEnumerable<MatrixElement> Elements { get; set; }
}