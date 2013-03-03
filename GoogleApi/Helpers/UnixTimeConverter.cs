using System;

namespace GoogleApi.Helpers
{
	public static class UnixTimeConverter
	{
		private static DateTime _epoch = new DateTime(1970, 1, 1);

		/// <summary>
		/// Converts a DateTime to a Unix timestamp
		/// </summary>
		public static int DateTimeToUnixTimestamp(DateTime _dateTime)
		{
			return (int)(_dateTime - _epoch.ToLocalTime()).TotalSeconds;
		}
	}
}