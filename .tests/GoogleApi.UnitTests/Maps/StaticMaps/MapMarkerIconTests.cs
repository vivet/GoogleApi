using System;
using GoogleApi.Entities.Maps.StaticMaps.Request;
using GoogleApi.Entities.Maps.StaticMaps.Request.Enums;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.StaticMaps;

[TestFixture]
public class MapMarkerIconTests
{
    [Test]
    public void ToStringTest()
    {
        var exception = Assert.Throws<ArgumentNullException>(() =>
        {
            var markerIcon = new MapMarkerIcon(null);
            Assert.IsNull(markerIcon);
        });

        Assert.IsNotNull(exception);
        Assert.IsTrue(exception.Message.StartsWith("Value cannot be null"));
        Assert.IsTrue(exception.Message.Contains("url"));
    }

    [Test]
    public void ToStringWhenAnchorTest()
    {
        var mapMarkerIcon = new MapMarkerIcon("url")
        {
            Anchor = Anchor.Bottom
        };

        var toString = mapMarkerIcon.ToString();
        Assert.AreEqual($"icon:{mapMarkerIcon.Url}|anchor:{mapMarkerIcon.Anchor.ToString().ToLower()}", toString);
    }

    [Test]
    public void ToStringWhenAnchorCoordinateTest()
    {
        var mapMarkerIcon = new MapMarkerIcon("url")
        {
            AnchorCoordinate = new AnchorCoordinate(1, 1)
        };

        var toString = mapMarkerIcon.ToString();
        Assert.AreEqual($"icon:{mapMarkerIcon.Url}|anchor:{mapMarkerIcon.AnchorCoordinate}", toString);
    }
}