using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.StaticMaps.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.StaticMaps
{
    [TestFixture]
    public class MapPathTests
    {
        [Test]
        public void ToStringTest()
        {
            var mapPath = new MapPath
            {
                Weight = 10,
                Geodesic = true,
                Points = new List<Location>
                {
                    new Location(new Coordinate(1, 1)),
                    new Location(new Coordinate(2, 2))
                }
            };

            var toString = mapPath.ToString();

            Assert.AreEqual($"weight:{mapPath.Weight}|geodesic:{mapPath.Geodesic.ToString().ToLower()}|{mapPath.Points.First()}|{mapPath.Points.Last()}", toString);
        }

        [Test]
        public void ToStringWhenColorTest()
        {
            var mapPath = new MapPath
            {
                Weight = 10,
                Geodesic = true,
                Color = "red",
                Points = new List<Location>
                {
                    new Location(new Coordinate(1, 1)),
                    new Location(new Coordinate(2, 2))
                }
            };

            var toString = mapPath.ToString();

            Assert.AreEqual($"weight:{mapPath.Weight}|geodesic:{mapPath.Geodesic.ToString().ToLower()}|color:{mapPath.Color}|{mapPath.Points.First()}|{mapPath.Points.Last()}", toString);
        }

        [Test]
        public void ToStringWhenFillColorTest()
        {
            var mapPath = new MapPath
            {
                Weight = 10,
                Geodesic = true,
                FillColor = "blue",
                Points = new List<Location>
                {
                    new Location(new Coordinate(1, 1)),
                    new Location(new Coordinate(2, 2))
                }
            };

            var toString = mapPath.ToString();

            Assert.AreEqual($"weight:{mapPath.Weight}|geodesic:{mapPath.Geodesic.ToString().ToLower()}|fillcolor:{mapPath.FillColor}|{mapPath.Points.First()}|{mapPath.Points.Last()}", toString);
        }
    }
}