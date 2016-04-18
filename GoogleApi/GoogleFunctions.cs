using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoogleApi.Entities.Common;

namespace GoogleApi
{
    /// <summary>
    /// Polyline encoding is a lossy compression algorithm that allows you to store a series of coordinates as a single string. Point coordinates are encoded using signed values. If you only have a few static points, you may also wish to use the interactive polyline encoding utility.
    /// The encoding process converts a binary value into a series of character codes for ASCII characters using the familiar base64 encoding scheme: to ensure proper display of these characters, encoded values are summed with 63 (the ASCII character '?') before converting them into ASCII. The algorithm also checks for additional character codes for a given point by checking the least significant bit of each byte group; if this bit is set to 1, the point is not yet fully formed and additional data must follow.
    /// Additionally, to conserve space, points only include the offset from the previous point (except of course for the first point). All points are encoded in Base64 as signed integers, as latitudes and longitudes are signed values. The encoding format within a polyline needs to represent two coordinates representing latitude and longitude to a reasonable precision. Given a maximum longitude of +/- 180 degrees to a precision of 5 decimal places (180.00000 to -180.00000), this results in the need for a 32 bit signed binary integer value.
    /// Note that the backslash is interpreted as an escape character within string literals. Any output of this utility should convert backslash characters to double-backslashes within string literals.
    /// See https://developers.google.com/maps/documentation/utilities/polylinealgorithm
    /// </summary>
    public static class GoogleFunctions
    {
        /// <summary>
        /// Encode a list of locations into a polyline string. 
        /// </summary>
        /// <param name="_locations"></param>
        /// <returns></returns>
        public static string EncodePolyLine(IEnumerable<Location> _locations)
        {
            var _encodedString = new StringBuilder();

            var _encodeDiff = (Action<int>)(_diff =>
            {
                var _shifted = _diff << 1;
                if (_diff < 0)
                    _shifted = ~_shifted;

                var _rem = _shifted;

                while (_rem >= 0x20)
                {
                    _encodedString.Append((char)((0x20 | (_rem & 0x1f)) + 63));
                    _rem >>= 5;
                }

                _encodedString.Append((char)(_rem + 63));
            });

            var _lastLat = 0;
            var _lastLng = 0;

            foreach (var _location in _locations)
            {
                var _lat = (int)Math.Round(_location.Latitude * 1E5);
                var _lng = (int)Math.Round(_location.Longitude * 1E5);

                _encodeDiff(_lat - _lastLat);
                _encodeDiff(_lng - _lastLng);

                _lastLat = _lat;
                _lastLng = _lng;
            }

            return _encodedString.ToString();
        }
        /// <summary>
        /// Merge polylines into one encoded polyline string.
        /// </summary>
        /// <param name="_encdodedLocations"></param>
        /// <returns></returns>
        public static string MergePolyLine(params string[] _encdodedLocations)
        {
            if (_encdodedLocations == null)
                throw new ArgumentNullException("_encdodedLocations");

            IList<Location> _locations = new List<Location>();
            _locations = _encdodedLocations.Where(_x => !string.IsNullOrEmpty(_x)).Aggregate(_locations, (_current, _encdodedLocation) => _current.Concat(GoogleApi.GoogleFunctions.DecodePolyLine(_encdodedLocation)).ToList());

            return GoogleApi.GoogleFunctions.EncodePolyLine(_locations);
        }
        /// <summary>
        /// Decode a polyline string into locations.
        /// </summary>
        /// <param name="_encdodedLocations"></param>
        /// <returns></returns>
        public static IEnumerable<Location> DecodePolyLine(string _encdodedLocations)
        {
            if (string.IsNullOrEmpty(_encdodedLocations))
                throw new ArgumentNullException("_encdodedLocations");

            var _polylineChars = _encdodedLocations.ToCharArray();
            var _index = 0;

            var _currentLat = 0;
            var _currentLng = 0;

            while (_index < _polylineChars.Length)
            {
                // Calculate next latitude
                var _sum = 0;
                var _shifter = 0;
                int _next5Bits;
                do
                {
                    _next5Bits = _polylineChars[_index++] - 63;
                    _sum |= (_next5Bits & 31) << _shifter;
                    _shifter += 5;
                } while (_next5Bits >= 32 && _index < _polylineChars.Length);

                if (_index >= _polylineChars.Length)
                    break;

                _currentLat += (_sum & 1) == 1 ? ~(_sum >> 1) : _sum >> 1;

                // Calculate next longitude
                _sum = 0;
                _shifter = 0;
                do
                {
                    _next5Bits = _polylineChars[_index++] - 63;
                    _sum |= (_next5Bits & 31) << _shifter;
                    _shifter += 5;
                } while (_next5Bits >= 32 && _index < _polylineChars.Length);

                if (_index >= _polylineChars.Length && _next5Bits >= 32)
                    break;

                _currentLng += (_sum & 1) == 1 ? ~(_sum >> 1) : _sum >> 1;
                yield return new Location(Convert.ToDouble(_currentLat) / 1E5, Convert.ToDouble(_currentLng) / 1E5);
            }
        }
    }
}