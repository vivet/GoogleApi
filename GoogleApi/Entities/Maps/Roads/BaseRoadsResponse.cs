using System.Collections.Generic;
using GoogleApi.Entities.Maps.Roads.Common;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Maps.Roads
{
    /// <summary>
    /// Base abstract roads response.
    /// </summary>
    public abstract class BaseRoadsResponse : BaseResponse
    {
        /// <summary>
        /// An array of snapped points.
        /// </summary>
        [JsonProperty("snappedPoints")]
        public virtual IEnumerable<SnappedPoint> SnappedPoints { get; set; }

        /// <summary>
        /// A list of errors which occurred. 
        /// </summary>
        [JsonProperty("errors")]
        public virtual IEnumerable<Error> Errors { get; set; }

        /// <summary>
        /// A warning message about the result quality, typically populated if the input points were too sparse
        /// </summary>
        [JsonProperty("warningMessage")]
        public virtual string WarningMessage { get; set; }
    }
}