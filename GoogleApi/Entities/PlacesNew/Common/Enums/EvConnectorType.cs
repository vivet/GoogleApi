namespace GoogleApi.Entities.PlacesNew.Search.Text.Request.Enums;

/// <summary>
/// See http://ieeexplore.ieee.org/stamp/stamp.jsp?arnumber=6872107 for additional information/context on EV charging connector types.
/// </summary>
public enum EvConnectorType
{
    /// <summary>
    /// Unspecified connector.
    /// </summary>
    EV_CONNECTOR_TYPE_UNSPECIFIED,
    
    /// <summary>
    /// Other connector types.
    /// </summary>
    EV_CONNECTOR_TYPE_OTHER,
    
    /// <summary>
    /// J1772 type 1 connector.
    /// </summary>
    EV_CONNECTOR_TYPE_J1772,
    
    /// <summary>
    /// IEC 62196 type 2 connector. Often referred to as MENNEKES.
    /// </summary>
    EV_CONNECTOR_TYPE_TYPE_2,
    
    /// <summary>
    /// CHAdeMO type connector.
    /// </summary>
    EV_CONNECTOR_TYPE_CHADEMO,

    /// <summary>
    /// Combined Charging System (AC and DC). Based on SAE. Type-1 J-1772 connector
    /// </summary>
    EV_CONNECTOR_TYPE_CCS_COMBO_1,
    
    /// <summary>
    /// Combined Charging System (AC and DC). Based on Type-2 Mennekes connector
    /// </summary>
    EV_CONNECTOR_TYPE_CCS_COMBO_2,

    /// <summary>
    /// The generic TESLA connector.
    /// This is NACS in the North America but can be non-NACS in other parts of the world (e.g. CCS Combo 2 (CCS2) or GB/T).
    /// This value is less representative of an actual connector type, and more represents the ability to charge a Tesla brand vehicle at a Tesla owned charging station.
    /// </summary>
    EV_CONNECTOR_TYPE_TESLA,
    
    /// <summary>
    /// GB/T type corresponds to the GB/T standard in China. This type covers all GB_T types.
    /// </summary>
    EV_CONNECTOR_TYPE_UNSPECIFIED_GB_T,

    /// <summary>
    /// Unspecified wall outlet.
    /// </summary>
    EV_CONNECTOR_TYPE_UNSPECIFIED_WALL_OUTLET
}