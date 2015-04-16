using System;
using System.Collections.Generic;
using System.Globalization;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Places.Common;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Places.PlacesQueryAutoComplete.Request
{
	/// <summary>
	/// The Query Autocomplete service allows you to add on-the-fly geographic query predictions to your application. Instead of searching for a 
	/// specific location, a user can type in a categorical search, such as "pizza near New York" and the service responds with a list of suggested 
	/// queries matching the string. As the Query Autocomplete service can match on both full words as well as substrings, applications can send 
	/// queries as the user types to provide on-the-fly predictions.
	/// </summary>
	public class PlacesQueryAutoCompleteRequest : PlacesBaseRequest
	{
		protected internal override string BaseUrl
		{
			get
			{
                return base.BaseUrl + "queryautocomplete/";
			}
		}

		/// <summary>
		/// Your application's API key. This key identifies your application for purposes of quota management and so that Places 
		/// added from your application are made immediately available to your app. Visit the APIs Console to create an API Project and obtain your key.
		/// </summary>
        public virtual string ApiKey { get; set; } 

        /// <summary>
        /// The text string on which to search. The Place service will return candidate matches based on this string and order results based on their perceived relevance.
        /// </summary>
        public virtual string Input { get; set; } 

        /// <summary>
        /// The character position in the input term at which the service uses text for predictions. For example, if the input is 'Googl' and the completion point is 3, the service will match on 'Goo'. The offset should generally be set to the position of the text caret. If no offset is supplied, the service will use the entire term.        
        /// </summary>
        public virtual string Offset { get; set; }

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

		public override bool IsSsl
		{
			get
			{
				return true;
			}
			set
			{
				throw new NotSupportedException("This operation is not supported, PlacesRequest must use SSL");
			}
		}

        protected override IDictionary<string, string> GetQueryStringParameters()
		{
            if (string.IsNullOrEmpty(ApiKey))
                throw new ArgumentException("ApiKey must not null or empty");

            if (string.IsNullOrEmpty(Input))
                throw new ArgumentException("_input must not null or empty"); 
            
            if (Radius.HasValue && (Radius > 50000 || Radius < 1))
				throw new ArgumentException("Radius must be greater than or equal to 1 and less than or equal to 50000.");

			var parameters = base.GetQueryStringParameters();

            parameters.Add("key", ApiKey);
            parameters.Add("input", Input);

            if (!string.IsNullOrEmpty(Offset))
                parameters.Add("offset", Offset);

            if (Location != null)
                parameters.Add("location", Location.ToString());
	
            if (Radius.HasValue)
				parameters.Add("radius", Radius.Value.ToString(CultureInfo.InvariantCulture));

            if (string.IsNullOrEmpty(Language))
                parameters.Add("language", Language);

            return parameters;
		}
	}
}
