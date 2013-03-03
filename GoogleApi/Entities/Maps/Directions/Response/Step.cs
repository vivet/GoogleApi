using System;
using System.Runtime.Serialization;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Common.Enums;

namespace GoogleApi.Entities.Maps.Directions.Response
{
	/// <summary>
	/// Each element in the steps array defines a single step of the calculated directions. A step is the most atomic unit of a direction's route, containing a single step describing a specific, single instruction on the journey. E.g. "Turn left at W. 4th St." The step not only describes the instruction but also contains distance and duration information relating to how this step relates to the following step. For example, a step denoted as "Merge onto I-80 West" may contain a duration of "37 miles" and "40 minutes," indicating that the next step is 37 miles/40 minutes from this step.
	/// </summary>
	[DataContract(Name = "step")]
	public class Step
	{
		/// <summary>
		/// html_instructions contains formatted instructions for this step, presented as an HTML text string.
		/// </summary>
		[DataMember(Name = "html_instructions")]
		public string HtmlInstructions { get; set; }

		/// <summary>
		/// Contains an object holding an array of encoded points that represent an approximate (smoothed) path of the resulting directions.
		/// </summary>
		[DataMember(Name = "polyline")]
		public OverviewPolyline PolyLine { get; set; }

		/// <summary>
		/// distance contains the distance covered by this step until the next step. (See the discussion of this field in Directions Legs above.) This field may be undefined if the distance is unknown.
		/// </summary>
		[DataMember(Name = "distance")]
		public Distance Distance { get; set; }

		/// <summary>
		/// duration contains the typical time required to perform the step, until the next step (See the description in Directions Legs above.) This field may be undefined if the duration is unknown.
		/// </summary>
		[DataMember(Name = "duration")]
		public Duration Duration { get; set; }

		/// <summary>
		/// start_location contains the location of the starting point of this step, as a single set of lat and lng fields.
		/// </summary>
		[DataMember(Name = "start_location")]
		public Location StartLocation { get; set; }

		/// <summary>
		/// end_location contains the location of the starting point of this step, as a single set of lat and lng fields.
		/// </summary>
		[DataMember(Name = "end_location")]
		public Location EndLocation { get; set; }

		/// <summary>
		/// More information about the step. Only avaliable when TravelMode = Transit
		/// </summary>
		[DataMember(Name = "transit_details")]
		public TransitDetails TransitDetails { get; set; }

		/// <summary>
		/// Contains detailed directions for walking or driving steps in transit directions. Substeps are only available when TravelMode is set to Transit.
		/// </summary>
		[DataMember(Name = "sub_steps")]
		public Step SubSteps { get; set; }

		/// <summary>
		/// Gets the mode of transportation used in this step
		/// </summary>
		public TravelMode TravelMode { get; set; }

		/// <summary>
		/// Gets the mode of transportation used in this step
		/// </summary>
		[DataMember(Name = "travel_mode")]
		internal string TravelModeString
		{
			get { return TravelMode.ToString(); }
			set
			{
				TravelMode _travelMode;
				if (Enum.TryParse(value, true, out _travelMode))
				{
					TravelMode = _travelMode;
				}
			}
		}
	}
}
