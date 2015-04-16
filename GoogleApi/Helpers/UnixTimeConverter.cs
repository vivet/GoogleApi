using System;

namespace GoogleApi.Helpers
{
	public static class UnixTimeConverter
	{
		private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		/// <summary>
		/// Converts a DateTime to a Unix timestamp
		/// </summary>
		public static int DateTimeToUnixTimestamp(DateTime dateTime)
		{
			return (int)(dateTime - Epoch).TotalSeconds;
		}
	}
}