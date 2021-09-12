using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.StaticMaps.Request.Enums
{
    /// <summary>
    /// Elements are subdivisions of a feature.
    /// A road, for example, consists of the graphical line (the geometry) on the map, and also the text denoting its name (a label).
    /// The following elements are available, but note that a specific feature may support none, some, or all, of the elements:
    /// </summary>
    public enum StyleElement
    {

        /// <summary>
        /// selects all elements of the specified feature. (default)
        /// </summary>
        [EnumMember(Value = "all")]
        All,

        /// <summary>
        /// selects all geometric elements of the specified feature.
        /// </summary>
        [EnumMember(Value = "geometry")]
        Geometry,

        /// <summary>
        /// selects only the fill of the feature's geometry.
        /// </summary>
        [EnumMember(Value = "geometry.fill")]
        Geometry_Fill,

        /// <summary>
        /// selects only the stroke of the feature's geometry.
        /// </summary>
        [EnumMember(Value = "geometry.stroke")]
        Geometry_Stroke,

        /// <summary>
        /// selects the textual labels associated with the specified feature.
        /// </summary>
        [EnumMember(Value = "labels")]
        Labels,

        /// <summary>
        /// selects only the icon displayed within the feature's label.
        /// </summary>
        [EnumMember(Value = "labels.icon")]
        Labels_Icon,

        /// <summary>
        /// selects only the text of the label.
        /// </summary>
        [EnumMember(Value = "labels.text")]
        Labels_Text,

        /// <summary>
        /// selects only the fill of the label. The fill of a label is typically rendered as a colored outline that surrounds the label text.
        /// </summary>
        [EnumMember(Value = "labels.text.fill")]
        Labels_Text_Fill,

        /// <summary>
        /// selects only the stroke of the label's text.
        /// </summary>
        [EnumMember(Value = "labels.text.stroke")]
        Labels_Text_Stroke 
    }
}