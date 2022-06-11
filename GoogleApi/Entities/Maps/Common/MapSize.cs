using System;

namespace GoogleApi.Entities.Maps.Common
{
	/// <summary>
	/// Map Size.
	/// </summary>
	public class MapSize
	{
		private const int MIN_WIDTH = 1;
		private const int MAX_WIDTH = 4096;
		private const int MIN_HEIGHT = 1;
		private const int MAX_HEIGHT = 4096;

        /// <summary>
        /// Width.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Height.
        /// </summary>
        public int Height { get; set; }

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="width">The width.</param>
		/// <param name="height">The height.</param>
		public MapSize(int width, int height)
		{
            if (width is < 1 or > 4096)
            {
                throw new ArgumentOutOfRangeException(nameof(width), width, $"'{nameof(width)}' must be greater than {MapSize.MIN_WIDTH} and less than {MapSize.MAX_WIDTH}.");
            }

            if (height is < 1 or > 4096)
            {
                throw new ArgumentOutOfRangeException(nameof(height), height, $"'{nameof(height)}' must be greater than {MapSize.MIN_HEIGHT} and less than {MapSize.MAX_HEIGHT}.");
            }

			this.Width = width;
			this.Height = height;
		}

        /// <summary>
        /// Returns the <see cref="Width"/> x <see cref="Height"/>. 
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return $"{this.Width}x{this.Height}";
        }
    }
}