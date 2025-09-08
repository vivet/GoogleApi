using System;
using GoogleApi.Entities.Maps.StaticMaps.Request;
using GoogleApi.Entities.Maps.StaticMaps.Request.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests.Maps.StaticMaps;

[TestClass]
public class MapMarkerIconTests
{
    [TestMethod]
    public void ToStringTest()
    {
        var exception = Assert.ThrowsException<ArgumentNullException>(() => new MapMarkerIcon(null));

        Assert.IsNotNull(exception);
        Assert.IsTrue(exception.Message.StartsWith("Value cannot be null"));
        Assert.IsTrue(exception.Message.Contains("url"));
    }

    [TestMethod]
    public void ToStringWhenAnchorTest()
    {
        var mapMarkerIcon = new MapMarkerIcon("url")
        {
            Anchor = Anchor.Bottom
        };

        var toString = mapMarkerIcon.ToString();
        Assert.AreEqual($"icon:{mapMarkerIcon.Url}|anchor:{mapMarkerIcon.Anchor.ToString().ToLower()}", toString);
    }

    [TestMethod]
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