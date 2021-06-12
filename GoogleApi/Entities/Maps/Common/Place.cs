namespace GoogleApi.Entities.Maps.Directions.Request
{
    /// <summary>
    /// Place.
    /// </summary>
    public class Place
    {
        /// <summary>
        /// The place Id.
        /// </summary>
        public virtual string Id { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"place_id:{this.Id}";
        }
    }
}