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
			InitLazyPoints(default(StreamingContext));
		}

		[OnDeserializing]
		private void InitLazyPoints(StreamingContext _contex)
		{
			_pointsLazy = new Lazy<IEnumerable<Location>>(DecodePoints);
		}

		/// <summary>
        /// Adapted from http://jeffreysambells.com/2010/05/27/decoding-polylines-from-google-maps-direction-api-with-java
        /// The algorithm explained here - https://developers.google.com/maps/documentation/utilities/polylinealgorithm
        /// </summary>
		/// <returns></returns>
		/// <exception cref="PointsDecodingException">Unexpectedly couldn't decode points</exception>
		private IEnumerable<Location> DecodePoints()
		{
			IEnumerable<Location> _points;

			try
			{
				var _poly = new List<Location>();
                var _index = 0;
				var _lat = 0;
                var _lng = 0;

                while (_index < this.EncodedPoints.Length)
				{
					int _b, _shift = 0, _result = 0;
					do
					{
                        _b = this.EncodedPoints[_index++] - 63;
						_result |= (_b & 0x1f) << _shift;
						_shift += 5;
					} while (_b >= 0x20);
                    var _dlat = ((_result & 1) != 0 ? ~(_result >> 1) : (_result >> 1));
					_lat += _dlat;

					_shift = 0;
					_result = 0;
					do
					{
                        _b = this.EncodedPoints[_index++] - 63;
						_result |= (_b & 0x1f) << _shift;
						_shift += 5;
					} while (_b >= 0x20);
					var _dlng = ((_result & 1) != 0 ? ~(_result >> 1) : (_result >> 1));
					_lng += _dlng;

					_poly.Add(new Location((int)((_lat / 1E5) * 1E6), (int)((_lng / 1E5) * 1E6)));
				}

				_points = _poly.ToArray();
			}
			catch (Exception _ex)
			{
                throw new PointsDecodingException("Couldn't decode points", this.EncodedPoints, _ex);
			}

			return _points;
		}

		/// <summary>
		/// The RAW data of points from Google
		/// </summary>
		/// <returns></returns>
        public virtual string GetRawPointsData()
		{
			return this.EncodedPoints;
		}
	}
}