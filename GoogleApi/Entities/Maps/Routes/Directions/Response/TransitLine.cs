using System.Collections.Generic;

namespace GoogleApi.Entities.Maps.Routes.Directions.Response;

/// <summary>
/// Contains information about the transit line used in this step.
/// </summary>
public class TransitLine
{
    /// <summary>
    /// The transit agency (or agencies) that operates this transit line.
    /// </summary>
    public virtual IEnumerable<TransitAgency> Agencies { get; set; }

    /// <summary>
    /// The full name of this transit line,
    /// For example, "8 Avenue Local".
    /// </summary>
    public virtual string Name { get; set; }

    /// <summary>
    /// The URI for this transit line as provided by the transit agency.
    /// </summary>
    public virtual string Uri { get; set; }

    /// <summary>
    /// The color commonly used in signage for this line. Represented in hexadecimal.
    /// </summary>
    public virtual string Color { get; set; }

    /// <summary>
    /// The URI for the icon associated with this line.
    /// </summary>
    public virtual string IconUri { get; set; }

    /// <summary>
    /// The short name of this transit line. This name will normally be a line number, such as "M7" or "355".
    /// </summary>
    public virtual string NameShort { get; set; }

    /// <summary>
    /// The color commonly used in text on signage for this line. Represented in hexadecimal.
    /// </summary>
    public virtual string TextColor { get; set; }

    /// <summary>
    /// The type of vehicle that operates on this transit line.
    /// </summary>
    public virtual TransitVehicle Vehicle { get; set; }
}