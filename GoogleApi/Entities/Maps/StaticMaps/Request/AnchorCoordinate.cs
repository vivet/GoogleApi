namespace GoogleApi.Entities.Maps.StaticMaps.Request
{
    /// <summary>
    /// Anchor Coordinate.
    /// </summary>
    public class AnchorCoordinate
    {
        /// <summary>
        /// X.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public AnchorCoordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Returns a string representation of a <see cref="AnchorCoordinate"/>.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return $"{this.X},{this.Y}";
        }
    }
}