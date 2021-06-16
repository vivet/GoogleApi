using System;

namespace GoogleApi.Entities.Maps.Common
{
    /// <summary>
    /// Place.
    /// </summary>
    public class Place
    {
        /// <summary>
        /// The place Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="placeId">The place id.</param>
        public Place(string placeId)
        {
            this.Id = placeId ?? throw new ArgumentNullException(nameof(placeId));
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.Id;
        }

        /// <summary>
        /// Tostring with added prefix.
        /// "{prefix}:{placeid}"
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        /// <returns>The prefixed placeid.</returns>
        public virtual string ToString(string prefix)
        {
            return $"{prefix}:{this}";
        }
    }
}