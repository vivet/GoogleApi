using System;
using System.Collections.Generic;
using System.Text;
using GoogleApi.Entities.Maps.Common;

namespace GoogleApi
{
    /// <summary>
    /// See https://developers.google.com/maps/documentation/utilities/polylinealgorithm
    /// </summary>
    public static class GoogleFunctions
    {
        /// <summary>
        /// Decode google style polyline coordinates.
        /// </summary>
        /// <param name="encdodedLocations"></param>
        /// <returns></returns>
        public static IEnumerable<Location> DecodePolyLine(string encdodedLocations)
        {
            if (string.IsNullOrEmpty(encdodedLocations))
                throw new ArgumentNullException("encdodedLocations");

            var polylineChars = encdodedLocations.ToCharArray();
            var index = 0;

            var currentLat = 0;
            var currentLng = 0;

            while (index < polylineChars.Length)
            {
                // Calculate next latitude
                var sum = 0;
                var shifter = 0;
                int next5Bits;
                do
                {
                    next5Bits = polylineChars[index++] - 63;
                    sum |= (next5Bits & 31) << shifter;
                    shifter += 5;
                } while (next5Bits >= 32 && index < polylineChars.Length);

                if (index >= polylineChars.Length)
                    break;

                currentLat += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

                // Calculate next longitude
                sum = 0;
                shifter = 0;
                do
                {
                    next5Bits = polylineChars[index++] - 63;
                    sum |= (next5Bits & 31) << shifter;
                    shifter += 5;
                } while (next5Bits >= 32 && index < polylineChars.Length);

                if (index >= polylineChars.Length && next5Bits >= 32)
                    break;

                currentLng += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);
                yield return new Location(Convert.ToDouble(currentLat) / 1E5, Convert.ToDouble(currentLng) / 1E5);
            }
        }
        /// <summary>
        /// Encode it
        /// </summary>
        /// <param name="locations"></param>
        /// <returns></returns>
        public static string EncodePolyLine(IEnumerable<Location> locations)
        {
            var encodedString = new StringBuilder();

            var encodeDiff = (Action<int>)(diff =>
            {
                var shifted = diff << 1;
                if (diff < 0)
                    shifted = ~shifted;

                var rem = shifted;

                while (rem >= 0x20)
                {
                    encodedString.Append((char)((0x20 | (rem & 0x1f)) + 63));
                    rem >>= 5;
                }

                encodedString.Append((char)(rem + 63));
            });

            var lastLat = 0;
            var lastLng = 0;

            foreach (var location in locations)
            {
                var lat = (int)Math.Round(location.Latitude * 1E5);
                var lng = (int)Math.Round(location.Longitude * 1E5);

                encodeDiff(lat - lastLat);
                encodeDiff(lng - lastLng);

                lastLat = lat;
                lastLng = lng;
            }

            return encodedString.ToString();
        }
    }
}