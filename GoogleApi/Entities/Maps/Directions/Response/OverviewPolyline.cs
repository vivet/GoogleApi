using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Maps.Directions.Response
{
	/// <summary>
	/// Contains the encoded and decoded data returned in the overview_polyline field.
	/// </summary>
	[DataContract]
	public class OverviewPolyline
	{
        private Lazy<IEnumerable<Location>> _pointsLazy;

        /// <summary>
        /// An array of Location objects representing the points in the overview path, decoded from the string contained in the EncodedPoints property.
        /// </summary>
        public IEnumerable<Location> Points { get { return this._pointsLazy.Value; } }

        /// <summary>
		/// The encoded string containing the overview path points as they were received.
		/// </summary>
		[DataMember(Name = "points")]
        protected virtual string EncodedPoints { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
		public OverviewPolyline()
		{
			this.InitLazyPoints(default(StreamingContext));
		}

		/// <summary>
		/// The RAW data of points from Google
		/// </summary>
		/// <returns></returns>
        public virtual string GetRawPointsData()
		{
			return this.EncodedPoints;
		}

        [OnDeserializing]
        private void InitLazyPoints(StreamingContext _contex)
        {
            this._pointsLazy = new Lazy<IEnumerable<Location>>(DecodePoints);
        }
 
        private IEnumerable<Location> DecodePoints()
        {
            return GoogleFunctions.DecodePolyLine(this.EncodedPoints);
        }
    }
}