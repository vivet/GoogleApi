using System;
using System.Globalization;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Places.Common;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Places.QueryAutoComplete.Request
{
	/// <summary>
    /// Places QueryAutoComplete Request.
	/// </summary>
	public class PlacesQueryAutoCompleteRequest : BasePlacesRequest
	{
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

        /// <summary>
        /// Always true. Setter is not supported.
        /// </summary>
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

        protected internal override string BaseUrl
        {
            get
            {
                return base.BaseUrl + "queryautocomplete/";
            }
        }
        
        protected override QueryStringParametersList GetQueryStringParameters()
		{
            var _parameters = base.GetQueryStringParameters();

            if (string.IsNullOrEmpty(this.Input))
                throw new ArgumentException("_input must not null or empty"); 
            
            if (this.Radius.HasValue && (this.Radius > 50000 || this.Radius < 1))
				throw new ArgumentException("Radius must be greater than or equal to 1 and less than or equal to 50000.");

            _parameters.Add("input", this.Input);

            if (!string.IsNullOrEmpty(this.Offset))
                _parameters.Add("offset", this.Offset);

            if (this.Location != null)
                _parameters.Add("location", this.Location.ToString());
	
            if (this.Radius.HasValue)
				_parameters.Add("radius", this.Radius.Value.ToString(CultureInfo.InvariantCulture));

            if (string.IsNullOrEmpty(this.Language))
                _parameters.Add("language", this.Language);

            return _parameters;
		}
	}
}
