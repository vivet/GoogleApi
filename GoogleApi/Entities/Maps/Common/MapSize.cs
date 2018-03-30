using System;

namespace GoogleApi.Entities.Maps.Common
{
	/// <summary>
	/// Map Size.
	/// </summary>
	public class MapSize
	{
		private const int MIN_WITDTH = 1;
		private const int MAX_WITDTH = 4096;
		private const int MIN_HEIGHT = 1;
		private const int MAX_HEIGHT = 4096;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="width">The width.</param>
		/// <param name="height">The height.</param>
		public MapSize(int width, int height)
		{
			if (width < 1 || width > 4096)
				throw new ArgumentOutOfRangeException($"Width must be greater than {MapSize.MIN_WITDTH} and less than {MapSize.MAX_WITDTH}.");

			if (height < 1 || height > 4096)
				throw new ArgumentOutOfRangeException($"Width must be greater than {MapSize.MIN_HEIGHT} and less than {MapSize.MAX_HEIGHT}.");

			this.Width = width;
			this.Height = height;
		}

		/// <summary>
		/// Width.
		/// </summary>
		public int Width { get; set; }

		/// <summary>
		/// Height.
		/// </summary>
		public int Height { get; set; }
	}
}