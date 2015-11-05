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
        /// Encode it
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
        /// Decode google style polyline coordinates.
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

                _currentLat += (_sum & 1) == 1 ? ~(_sum >> 1) : (_sum >> 1);

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

                _currentLng += (_sum & 1) == 1 ? ~(_sum >> 1) : (_sum >> 1);
                yield return new Location(Convert.ToDouble(_currentLat) / 1E5, Convert.ToDouble(_currentLng) / 1E5);
            }
        }
    }
}