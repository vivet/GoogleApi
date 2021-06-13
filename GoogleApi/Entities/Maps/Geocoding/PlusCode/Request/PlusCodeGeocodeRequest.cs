using System;
using System.Collections.Generic;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Extensions;

namespace GoogleApi.Entities.Maps.Geocoding.PlusCode.Request
{
    /// <summary>
    /// Plus Code Request.
    /// </summary>
    public class PlusCodeGeocodeRequest : BaseGeocodeRequest
    {
        /// <summary>
        /// Base Url.
        /// </summary>
        protected internal override string BaseUrl => "plus.codes/api";

        /// <summary>
        /// Address.
        /// The street address to geocode.
        /// Ignored if PlaceId or Location is specified.
        /// </summary>
        public virtual string Address { get; set; }

        /// <summary>
        /// Place Id.
        /// Google's unique place identifier.
        /// </summary>
        public virtual string PlaceId { get; set; }

        /// <summary>
        /// Location.
        /// Latitude / Longitude.
        /// Requires key to be specified.
        /// </summary>
        public virtual Coordinate Location { get; set; }

        /// <summary>
        /// Local Code
        /// The local code relative to the locality.
        /// Only used in conjuction with Address and Location. Ignored if geocoding using Global Code.
        /// </summary>
        public virtual string LocalCode { get; set; }

        /// <summary>
        /// Global Code.
        /// The global code for the latitude/longitude.
        /// Ignored if PlaceId, Location or address is specified.
        /// </summary>
        public virtual string GlobalCode { get; set; }

        /// <summary>
        /// Email.
        /// Provide an email address that can be used to contact you.
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// See <see cref="BaseGeocodeRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>The <see cref="IList{KeyValuePair}"/> collection.</returns>
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();

            if (this.PlaceId == null && this.Location == null && string.IsNullOrEmpty(this.Address) && string.IsNullOrEmpty(this.GlobalCode))
                throw new ArgumentException("PlaceId, Location, Address or GlobalCode is required");

            var address = !string.IsNullOrEmpty(this.PlaceId)
                ? this.PlaceId
                : this.Location != null
                    ? $"{this.LocalCode} {this.Location}".Trim()
                    : !string.IsNullOrEmpty(this.Address)
                        ? $"{this.LocalCode} {this.Address}".Trim()
                        : this.GlobalCode;

            parameters.Add("address", address);

            if (!string.IsNullOrEmpty(this.Email))
                parameters.Add("email", this.Email);

            return parameters;
        }
    }
}