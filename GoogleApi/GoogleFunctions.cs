using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoogleApi.Entities.Common;

namespace GoogleApi;

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
    /// <param name="locations"></param>
    /// <returns></returns>
    public static string EncodePolyLine(IEnumerable<Coordinate> locations)
    {
        if (locations == null)
            throw new ArgumentNullException(nameof(locations));

        var encodedString = new StringBuilder();

        var encodeDiff = (Action<int>) (diff =>
        {
            var shifted = diff << 1;
            if (diff < 0)
                shifted = ~shifted;

            var rem = shifted;

            while (rem >= 0x20)
            {
                encodedString.Append((char) ((0x20 | (rem & 0x1f)) + 63));
                rem >>= 5;
            }

            encodedString.Append((char) (rem + 63));
        });

        var lastLat = 0;
        var lastLng = 0;

        foreach (var location in locations)
        {
            if (location == null)
                continue;

            var lat = (int) Math.Round(location.Latitude * 1E5);
            var lng = (int) Math.Round(location.Longitude * 1E5);

            encodeDiff(lat - lastLat);
            encodeDiff(lng - lastLng);

            lastLat = lat;
            lastLng = lng;
        }

        return encodedString.ToString();
    }

    /// <summary>
    /// Merge polylines into one encoded polyline string.
    /// </summary>
    /// <param name="encodedLocations"></param>
    /// <returns></returns>
    public static string MergePolyLine(params string[] encodedLocations)
    {
        if (encodedLocations == null)
            throw new ArgumentNullException(nameof(encodedLocations));

        var length = encodedLocations.Length;
        var locations = new Coordinate[length];

        locations = encodedLocations.Where(x => !string.IsNullOrEmpty(x))
            .Aggregate(locations,
                (current, encdodedLocation) =>
                    current.Concat(GoogleFunctions.DecodePolyLine(encdodedLocation)).ToArray());

        return GoogleFunctions.EncodePolyLine(locations);
    }

    /// <summary>
    /// Decode a polyline string into locations.
    /// </summary>
    /// <param name="encodedLocations"></param>
    /// <returns></returns>
    public static IEnumerable<Coordinate> DecodePolyLine(string encodedLocations)
    {
        if (string.IsNullOrEmpty(encodedLocations))
            throw new ArgumentNullException(nameof(encodedLocations));

        var polylineChars = encodedLocations.ToCharArray();
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

            currentLat += (sum & 1) == 1 ? ~(sum >> 1) : sum >> 1;

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

            currentLng += (sum & 1) == 1 ? ~(sum >> 1) : sum >> 1;
            yield return new Coordinate(Convert.ToDouble(currentLat) / 1E5, Convert.ToDouble(currentLng) / 1E5);
        }
    }
}