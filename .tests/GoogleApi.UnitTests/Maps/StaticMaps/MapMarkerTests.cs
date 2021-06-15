using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.StaticMaps.Request;
using GoogleApi.Entities.Maps.StaticMaps.Request.Enums;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.StaticMaps
{
    [TestFixture]
    public class MapMarkerTests
    {
        [Test]
        public void ToStringTest()
        {
            var mapMarker = new MapMarker();

            var toString = mapMarker.ToString();
            Assert.IsNull(toString);
        }

        [Test]
        public void ToStringWhenLocationsOnlyTest()
        {
            var mapMarker = new MapMarker
            {
                Locations = new[]
                {
                    new Location(new Coordinate(1, 1))
                }
            };

            var toString = mapMarker.ToString();
            Assert.AreEqual($"{string.Join("|", mapMarker.Locations.Select(x => x.ToString()))}", toString);
        }

        [Test]
        public void ToStringWhenLocationsMultipleTest()
        {
            var mapMarker = new MapMarker
            {
                Locations = new[]
                {
                    new Location(new Coordinate(1, 1)),
                    new Location(new Coordinate(2, 2))
                }
            };

            var toString = mapMarker.ToString();
            Assert.AreEqual($"{string.Join("|", mapMarker.Locations.Select(x => x.ToString()))}", toString);
        }

        [Test]
        public void ToStringWhenLabelTest()
        {
            var mapMarker = new MapMarker
            {
                Label = "label",
                Locations = new[]
                {
                    new Location(new Coordinate(1, 1))
                }
            };

            var toString = mapMarker.ToString();
            Assert.AreEqual($"label:{mapMarker.Label}|{string.Join("|", mapMarker.Locations.Select(x => x.ToString()))}", toString);
        }

        [Test]
        public void ToStringWhenLabelAndSizeIsTinyTest()
        {
            var mapMarker = new MapMarker
            {
                Label = "label",
                Size = MarkerSize.Tiny,
                Locations = new[]
                {
                    new Location(new Coordinate(1, 1))
                }
            };

            var toString = mapMarker.ToString();
            Assert.AreEqual($"size:{mapMarker.Size?.ToString().ToLower()}|{string.Join("|", mapMarker.Locations.Select(x => x.ToString()))}", toString);
        }

        [Test]
        public void ToStringWhenLabelAndSizeIsSmallTest()
        {
            var mapMarker = new MapMarker
            {
                Label = "label",
                Size = MarkerSize.Small,
                Locations = new[]
                {
                    new Location(new Coordinate(1, 1))
                }
            };

            var toString = mapMarker.ToString();
            Assert.AreEqual($"size:{mapMarker.Size?.ToString().ToLower()}|{string.Join("|", mapMarker.Locations.Select(x => x.ToString()))}", toString);
        }

        [Test]
        public void ToStringWhenColorTest()
        {
            var mapMarker = new MapMarker
            {
                Color = "color",
                Locations = new[]
                {
                    new Location(new Coordinate(1, 1))
                }
            };

            var toString = mapMarker.ToString();
            Assert.AreEqual($"color:{mapMarker.Color}|{string.Join("|", mapMarker.Locations.Select(x => x.ToString()))}", toString);
        }

        [Test]
        public void ToStringWhenIconTest()
        {
            var mapMarker = new MapMarker
            {
                Icon = new MapMarkerIcon("url"),
                Locations = new[]
                {
                    new Location(new Coordinate(1, 1))
                }
            };

            var toString = mapMarker.ToString();
            Assert.AreEqual($"{mapMarker.Icon}|{string.Join("|", mapMarker.Locations.Select(x => x.ToString()))}", toString);
        }

        [Test]
        public void ToStringWhenAllTest()
        {
            var mapMarker = new MapMarker
            {
                Label = "label",
                Size = MarkerSize.Normal, 
                Color = "color",
                Icon = new MapMarkerIcon("url"),
                Locations = new[]
                {
                    new Location(new Coordinate(1, 1))
                }
            };

            var toString = mapMarker.ToString();
            Assert.AreEqual($"label:{mapMarker.Label}|color:{mapMarker.Color}|size:{mapMarker.Size?.ToString().ToLower()}|{mapMarker.Icon}|{string.Join("|", mapMarker.Locations.Select(x => x.ToString()))}", toString);
        }
    }
}