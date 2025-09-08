using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.StaticMaps.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests.Maps.StaticMaps;

[TestClass]
public class MapPathTests
{
    [TestMethod]
    public void ToStringTest()
    {
        var mapPath = new MapPath
        {
            Weight = 10,
            Geodesic = true,
            Points = new List<Location>
            {
                new(new Coordinate(1, 1)),
                new(new Coordinate(2, 2))
            }
        };

        var toString = mapPath.ToString();

        Assert.AreEqual($"weight:{mapPath.Weight}|geodesic:{mapPath.Geodesic.ToString().ToLower()}|{mapPath.Points.First()}|{mapPath.Points.Last()}", toString);
    }

    [TestMethod]
    public void ToStringWhenColorTest()
    {
        var mapPath = new MapPath
        {
            Weight = 10,
            Geodesic = true,
            Color = "red",
            Points = new List<Location>
            {
                new(new Coordinate(1, 1)),
                new(new Coordinate(2, 2))
            }
        };

        var toString = mapPath.ToString();

        Assert.AreEqual($"weight:{mapPath.Weight}|geodesic:{mapPath.Geodesic.ToString().ToLower()}|color:{mapPath.Color}|{mapPath.Points.First()}|{mapPath.Points.Last()}", toString);
    }

    [TestMethod]
    public void ToStringWhenFillColorTest()
    {
        var mapPath = new MapPath
        {
            Weight = 10,
            Geodesic = true,
            FillColor = "blue",
            Points = new List<Location>
            {
                new(new Coordinate(1, 1)),
                new(new Coordinate(2, 2))
            }
        };

        var toString = mapPath.ToString();

        Assert.AreEqual($"weight:{mapPath.Weight}|geodesic:{mapPath.Geodesic.ToString().ToLower()}|fillcolor:{mapPath.FillColor}|{mapPath.Points.First()}|{mapPath.Points.Last()}", toString);
    }
}