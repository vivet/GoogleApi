using System;

namespace GoogleApi.Entities.Maps.Geocoding.PlusCode.Request
{
    /// <summary>
    /// Local Code And Locality.
    /// The local code part of a plus code, and a locality.
    /// </summary>
    public class LocalCodeAndLocality
    {
        /// <summary>
        /// Code.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Locality.
        /// </summary>
        public string Locality { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="localCode">The local code.</param>
        /// <param name="locality">The locality.</param>
        public LocalCodeAndLocality(string localCode, string locality)
        {
            this.Code = localCode ?? throw new ArgumentNullException(nameof(localCode));
            this.Locality = locality ?? throw new ArgumentNullException(nameof(locality));
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{this.Code} {this.Locality}";
        }
    }
}