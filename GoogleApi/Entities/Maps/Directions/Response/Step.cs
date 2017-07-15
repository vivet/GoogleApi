using System.Collections.Generic;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Common;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Maps.Directions.Response
{
    /// <summary>
    /// Each element in the steps array defines a single step of the calculated directions. A step is the most atomic unit of a direction's route, containing a single step describing a specific, single instruction on the journey. E.g. "Turn left at W. 4th St." The step not only describes the instruction but also contains distance and duration information relating to how this step relates to the following step. For example, a step denoted as "Merge onto I-80 West" may contain a duration of "37 miles" and "40 minutes," indicating that the next step is 37 miles/40 minutes from this step.
    /// </summary>
    public class Step
    {
        /// <summary>
        /// html_instructions contains formatted instructions for this step, presented as an HTML text string.
        /// </summary>
        [JsonProperty("html_instructions")]
        public virtual string HtmlInstructions { get; set; }

        /// <summary>
        /// distance contains the distance covered by this step until the next step. (See the discussion of this field in Directions Legs above.) This field may be undefined if the distance is unknown.
        /// </summary>
        [JsonProperty("distance")]
        public virtual Distance Distance { get; set; }

        /// <summary>
        /// duration contains the typical time required to perform the step, until the next step (See the description in Directions Legs above.) This field may be undefined if the duration is unknown.
        /// </summary>
        [JsonProperty("duration")]
        public virtual Duration Duration { get; set; }

        /// <summary>
        /// start_location contains the location of the starting point of this step, as a single set of lat and lng fields.
        /// </summary>
        [JsonProperty("start_location")]
        public virtual Location StartLocation { get; set; }

        /// <summary>
        /// end_location contains the location of the starting point of this step, as a single set of lat and lng fields.
        /// </summary>
        [JsonProperty("end_location")]
        public virtual Location EndLocation { get; set; }

        /// <summary>
        /// Contains an object holding an array of encoded points that represent an approximate (smoothed) path of the resulting directions.
        /// </summary>
        [JsonProperty("polyline")]
        public virtual OverviewPolyline PolyLine { get; set; }

        /// <summary>
        /// More information about the step. Only avaliable when TravelMode = Transit
        /// </summary>
        [JsonProperty("transit_details")]
        public virtual TransitDetails TransitDetails { get; set; }

        /// <summary>
        /// steps contains detailed directions for walking or driving steps in transit directions. Substeps are only available when travel_mode is set to "transit". 
        /// The inner steps array is of the same type as steps.
        /// </summary>
        [JsonProperty("steps")]
        public virtual IEnumerable<Step> Steps { get; set; }
    }
}