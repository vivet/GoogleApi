using System;
using System.Collections.Generic;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.DistanceMatrix.Request.Enums;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Maps.DistanceMatrix.Request
{
    public class DistanceMatrixRequest : SignableRequest
	{
        private AvoidWay _avoid = AvoidWay.Nothing;
        private Units _units = Units.Metric;

        protected internal override string BaseUrl
		{
			get
			{
                return base.BaseUrl + "distancematrix/";
			}
		}

		/// <summary>
        /// One or more addresses and/or textual latitude/longitude values, separated with the pipe (|) character, from which to calculate distance and time. If you pass an address as a string, the service will geocode the string and convert it to a latitude/longitude coordinate to calculate directions. If you pass coordinates, ensure that no space exists between the latitude and longitude values.
		/// </summary>
        public virtual IEnumerable<Location> Origins { get; set; }

		/// <summary>
        /// One or more addresses and/or textual latitude/longitude values, separated with the pipe (|) character, to which to calculate distance and time. If you pass an address as a string, the service will geocode the string and convert it to a latitude/longitude coordinate to calculate directions. If you pass coordinates, ensure that no space exists between the latitude and longitude values
		/// </summary>
        public virtual IEnumerable<Location> Destinations { get; set; }

        /// <summary>
        /// (optional, defaults to driving) — specifies what mode of transport to use when calculating directions. Valid values are specified in Travel Modes.
        /// </summary>
        public virtual TravelMode TravelMode { get; set; }

        /// <summary>
        /// language (optional) — The language in which to return results. See the supported list of domain languages. 
        /// Note that we often update supported languages so this list may not be exhaustive. 
        /// If language is not supplied, the Directions service will attempt to use the native language of the browser wherever possible. 
        /// You may also explicitly bias the results by using localized domains of http://map.google.com. 
        /// See Region Biasing for more information.
        /// </summary>
        public virtual string Language { get; set; }

        /// <summary>
        /// avoid (optional) indicates that the calculated route(s) should avoid the indicated features. Currently, this parameter supports the following two arguments:
        /// tolls indicates that the calculated route should avoid toll roads/bridges.
        /// highways indicates that the calculated route should avoid highways.
        /// (For more information see Route Restrictions below.)
        /// </summary>
        public virtual AvoidWay Avoid
        {
            get { return _avoid; }
            set { _avoid = value; }
        }

        /// <summary>
        /// Distance Matrix results contain text within distance fields to indicate the distance of the calculated route. The unit system to use can be specified:
        /// Units=metric (default) returns distances in kilometers and meters.
        /// Units=imperial returns distances in miles and feet.
        /// * Note: this unit system setting only affects the text displayed within distance fields. The distance fields also contain values which are always expressed in meters
        /// </summary>
        public virtual Units Units
        {
            get { return _units; }
            set { _units = value; }
        }

        protected override QueryStringParametersList GetQueryStringParameters()
		{
			if (Origins == null)
				throw new ArgumentException("Must specify an Origins");

            if (Destinations == null)
				throw new ArgumentException("Must specify a Destinations");
            
            if (!Enum.IsDefined(typeof(AvoidWay), Avoid))
				throw new ArgumentException("Invalid enumeration value for 'Avoid'");

            if (!Enum.IsDefined(typeof(TravelMode), TravelMode))
				throw new ArgumentException("Invalid enumeration value for 'TravelMode'");

			var parameters = base.GetQueryStringParameters();

            parameters.Add("origins", string.Join("|", Origins));
            parameters.Add("destinations", string.Join("|", Destinations));
            parameters.Add("mode", TravelMode.ToString().ToLower());
            parameters.Add("units", Units.ToString().ToLower());

            if (!string.IsNullOrWhiteSpace(Language))
                parameters.Add("language", Language);

            if (Avoid != AvoidWay.Nothing)
				parameters.Add("avoid", Avoid.ToString().ToLower());

			return parameters;
		}
	}
}