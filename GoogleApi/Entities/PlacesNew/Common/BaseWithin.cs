using System.Text.Json.Serialization;

namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// Base Within (abstract).
/// </summary>
[JsonDerivedType(typeof(WithinCirle))]
[JsonDerivedType(typeof(WithinRectangle))] 
public abstract class BaseWithin;