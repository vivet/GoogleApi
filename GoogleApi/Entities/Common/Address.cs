using System;

namespace GoogleApi.Entities.Common;

/// <summary>
/// Address.
/// </summary>
public class Address
{
    /// <summary>
    /// Address.
    /// </summary>
    public virtual string String { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="address">The address.</param>
    public Address(string address)
    {
        this.String = address ?? throw new ArgumentNullException(nameof(address));
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return this.String;
    }
}