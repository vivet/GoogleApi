using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.StaticMaps.Request;
using GoogleApi.Entities.Maps.StaticMaps.Request.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests.Maps.StaticMaps;

[TestClass]
public class MapMarkerTests
{
    [TestMethod]
    public void ToStringTest()
    {
        var mapMarker = new MapMarker();

        var toString = mapMarker.ToString();
        Assert.IsNull(toString);
    }

    [TestMethod]
    public void ToStringWhenLocationsOnlyTest()
    {
        var mapMarker = new MapMarker
        {
            Locations =
            [
                new Location(new Coordinate(1, 1))
            ]
        };

        var toString = mapMarker.ToString();
        Assert.AreEqual($"{string.Join("|", mapMarker.Locations.Select(x => x.ToString()))}", toString);
    }

    [TestMethod]
    public void ToStringWhenLocationsMultipleTest()
    {
        var mapMarker = new MapMarker
        {
            Locations =
            [
                new Location(new Coordinate(1, 1)),
                new Location(new Coordinate(2, 2))
            ]
        };

        var toString = mapMarker.ToString();
        Assert.AreEqual($"{string.Join("|", mapMarker.Locations.Select(x => x.ToString()))}", toString);
    }

    [TestMethod]
    public void ToStringWhenLabelTest()
    {
        var mapMarker = new MapMarker
        {
            Label = "label",
            Locations =
            [
                new Location(new Coordinate(1, 1))
            ]
        };

        var toString = mapMarker.ToString();
        Assert.AreEqual($"label:{mapMarker.Label}|{string.Join("|", mapMarker.Locations.Select(x => x.ToString()))}", toString);
    }

    [TestMethod]
    public void ToStringWhenLabelAndSizeIsTinyTest()
    {
        var mapMarker = new MapMarker
        {
            Label = "label",
            Size = MarkerSize.Tiny,
            Locations =
            [
                new Location(new Coordinate(1, 1))
            ]
        };

        var toString = mapMarker.ToString();
        Assert.AreEqual($"size:{mapMarker.Size?.ToString().ToLower()}|{string.Join("|", mapMarker.Locations.Select(x => x.ToString()))}", toString);
    }

    [TestMethod]
    public void ToStringWhenLabelAndSizeIsSmallTest()
    {
        var mapMarker = new MapMarker
        {
            Label = "label",
            Size = MarkerSize.Small,
            Locations =
            [
                new Location(new Coordinate(1, 1))
            ]
        };

        var toString = mapMarker.ToString();
        Assert.AreEqual($"size:{mapMarker.Size?.ToString().ToLower()}|{string.Join("|", mapMarker.Locations.Select(x => x.ToString()))}", toString);
    }

    [TestMethod]
    public void ToStringWhenColorTest()
    {
        var mapMarker = new MapMarker
        {
            Color = "color",
            Locations =
            [
                new Location(new Coordinate(1, 1))
            ]
        };

        var toString = mapMarker.ToString();
        Assert.AreEqual($"color:{mapMarker.Color}|{string.Join("|", mapMarker.Locations.Select(x => x.ToString()))}", toString);
    }

    [TestMethod]
    public void ToStringWhenIconTest()
    {
        var mapMarker = new MapMarker
        {
            Icon = new MapMarkerIcon("url"),
            Locations =
            [
                new Location(new Coordinate(1, 1))
            ]
        };

        var toString = mapMarker.ToString();
        Assert.AreEqual($"{mapMarker.Icon}|{string.Join("|", mapMarker.Locations.Select(x => x.ToString()))}", toString);
    }

    [TestMethod]
    public void ToStringWhenAllTest()
    {
        var mapMarker = new MapMarker
        {
            Label = "label",
            Size = MarkerSize.Normal,
            Color = "color",
            Icon = new MapMarkerIcon("url"),
            Locations =
            [
                new Location(new Coordinate(1, 1))
            ]
        };

        var toString = mapMarker.ToString();
        Assert.AreEqual($"label:{mapMarker.Label}|color:{mapMarker.Color}|size:{mapMarker.Size?.ToString().ToLower()}|{mapMarker.Icon}|{string.Join("|", mapMarker.Locations.Select(x => x.ToString()))}", toString);
    }
}