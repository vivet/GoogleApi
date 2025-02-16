namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// Information about parking options for the place.
/// A parking lot could support more than one option at the same time.
/// </summary>
public class ParkingOptions
{
    /// <summary>
    /// Place offers free parking lots.
    /// </summary>
    public virtual bool FreeParkingLot { get; set; }

    /// <summary>
    /// Place offers paid parking lots.
    /// </summary>
    public virtual bool PaidParkingLot { get; set; }

    /// <summary>
    /// Place offers free street parking.
    /// </summary>
    public virtual bool FreeParfreeStreetParkingkingLot { get; set; }

    /// <summary>
    /// Place offers paid street parking.
    /// </summary>
    public virtual bool PaidStreetParking { get; set; }

    /// <summary>
    /// Place offers valet parking.
    /// </summary>
    public virtual bool ValetParking { get; set; }

    /// <summary>
    /// Place offers free garage parking.
    /// </summary>
    public virtual bool FreeGarageParking { get; set; }

    /// <summary>
    /// Place offers paid garage parking.
    /// </summary>
    public virtual bool PaidGarageParking { get; set; }
}