using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Maps.Common;

/// <summary>
/// Location.
/// </summary>
public class Location
{
    /// <summary>
    /// Location String.
    /// </summary>
    public string String { get; }

    /// <summary>
    ///
    /// </summary>
    /// <param name="address"></param>
    public Location(Address address)
    {
        this.String = address.ToString();
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="coordinate"></param>
    public Location(Coordinate coordinate)
    {
        this.String = coordinate.ToString();
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return this.String;
    }
}