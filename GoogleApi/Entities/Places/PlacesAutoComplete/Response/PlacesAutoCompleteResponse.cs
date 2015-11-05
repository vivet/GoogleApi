using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Places.Common;

namespace GoogleApi.Entities.Places.PlacesAutoComplete.Response
{
    /// <summary>
    /// When the Places service returns JSON results from a search, it places them within a predictions array.
    /// </summary>
    [DataContract]
    public class PlacesAutoCompleteResponse : MapsBaseResponse, IResponseFor
	{
		/// <summary>
        /// Contains an array of predictions, with information about the prediction.
		/// </summary>
		[DataMember(Name = "predictions")]
        public virtual IEnumerable<Prediction> Predictions { get; set; }
	}
}
