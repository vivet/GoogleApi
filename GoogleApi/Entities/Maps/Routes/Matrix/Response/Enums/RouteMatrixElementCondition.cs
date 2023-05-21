using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Routes.Matrix.Response.Enums;

/// <summary>
/// Route Matrix Element Condition.
/// </summary>
public enum RouteMatrixElementCondition
{
    /// <summary>
    /// Only used when the status of the element is not OK.
    /// </summary>
    [EnumMember(Value = "ROUTE_MATRIX_ELEMENT_CONDITION_UNSPECIFIED")]
    RouteMatrixElementConditionUnspecified,

    /// <summary>
    /// A route was found, and the corresponding information was filled out for the element.
    /// </summary>
    [EnumMember(Value = "ROUTE_EXISTS")]
    RouteExists,

    /// <summary>
    /// No route could be found. Fields containing route information, such as distanceMeters or duration, will not be filled out in the element.
    /// </summary>
    [EnumMember(Value = "ROUTE_NOT_FOUND")]
    RouteNotFound
}