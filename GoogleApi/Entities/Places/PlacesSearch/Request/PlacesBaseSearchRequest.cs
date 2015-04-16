using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Places.Common;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Places.PlacesSearch.Request
{
    public abstract class PlacesBaseSearchRequest : PlacesBaseRequest
    {
        /// <summary>
        /// Your application's API key. This key identifies your application for purposes of quota management and so that Places 
        /// added from your application are made immediately available to your app. Visit the APIs Console to create an API Project and obtain your key.
        /// </summary>
        public virtual string ApiKey { get; set; }

        /// <summary>
        /// The point around which you wish to retrieve Place information. Must be specified as latitude,longitude.
        /// </summary>
        public virtual Location Location { get; set; }

        /// <summary>
        /// The distance (in meters) within which to return Place results. Note that setting a radius biases results to the indicated area, but may not fully restrict results to the specified area. See Location Biasing below.
        /// </summary>
        public virtual double? Radius { get; set; }

        /// <summary>
        /// The language in which to return results. See the supported list of domain languages. Note that we often update supported languages so this list may not be exhaustive. If language is not supplied, the Place service will attempt to use the native language of the domain from which the request is sent.
        /// </summary>
        public virtual string Language { get; set; }

        public virtual IEnumerable<PlaceType> Types { get; set; }



        protected override QueryStringParametersList GetQueryStringParameters()
        {
            if (string.IsNullOrEmpty(ApiKey))
                throw new ArgumentException("ApiKey must not null or empty", "ApiKey");

            if (Location == null)
                throw new ArgumentException("Location must not be null", "Location");

            if (!Radius.HasValue)
                throw new ArgumentException("Radius must not be null", "Radius");

            if (Radius.HasValue && (Radius > 50000 || Radius < 1))
                throw new ArgumentOutOfRangeException("Radius", "Radius must be greater than or equal to 1 and less than or equal to 50000.");

            var parameters = base.GetQueryStringParameters();

            parameters.Add("key", ApiKey);

            if (Location != null)
                parameters.Add("location", Location.ToString());

            if (Radius.HasValue)
                parameters.Add("radius", Radius.Value.ToString(CultureInfo.InvariantCulture));

            if (!string.IsNullOrEmpty(Language))
                parameters.Add("language", Language);

            if (Types != null && Types.Any())
                parameters.Add("types", string.Join("|", Types.Select(EnumHelper.ToEnumString)));


            return parameters;
        }

    }
}
