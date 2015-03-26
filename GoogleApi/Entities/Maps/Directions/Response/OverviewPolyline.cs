using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApi.Entities.Maps.Common;

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
		/// The encoded string containing the overview path points as they were received.
		/// </summary>
		[DataMember(Name = "points")]
        internal virtual string EncodedPoints { get; set; }

		/// <summary>
		/// An array of Location objects representing the points in the overview path, decoded from the string contained in the EncodedPoints property.
		/// </summary>
		/// <exception cref="PointsDecodingException">Unexpectedly couldn't decode points</exception>
		public IEnumerable<Location> Points { get { return _pointsLazy.Value; } }

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
            _pointsLazy = new Lazy<IEnumerable<Location>>(DecodePoints);
        }
        private IEnumerable<Location> DecodePoints()
        {
            try
            {
                return GoogleFunctions.DecodePolyLine(this.EncodedPoints);
            }
            catch (Exception _ex)
            {
                throw new PointsDecodingException("Couldn't decode points", this.EncodedPoints, _ex);
            }
        }
    }
}