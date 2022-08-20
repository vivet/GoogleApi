using System;
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
    /// Constructor.
    /// </summary>
    /// <param name="address">The address string.</param>
    public Location(Address address)
    {
        if (address == null) 
            throw new ArgumentNullException(nameof(address));

        this.String = address.ToString();
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="coordinate"></param>
    public Location(Coordinate coordinate)
    {
        if (coordinate == null) 
            throw new ArgumentNullException(nameof(coordinate));

        this.String = coordinate.ToString();
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return this.String;
    }
}