using GoogleApi.Entities.Maps.StaticMaps.Request;
using GoogleApi.Entities.Maps.StaticMaps.Request.Enums;
using NUnit.Framework;
using System;

namespace GoogleApi.UnitTests.Maps.StaticMaps
{
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

#if NETCOREAPP3_1_OR_GREATER
            Assert.AreEqual("Value cannot be null. (Parameter 'url')", exception.Message);
#else
            Assert.AreEqual("Value cannot be null.\r\nParameter name: url", exception.Message);
#endif
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
}