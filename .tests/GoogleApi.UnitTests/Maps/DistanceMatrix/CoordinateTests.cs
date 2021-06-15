using System.Globalization;
using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.DistanceMatrix
{
    [TestFixture]
    public class CoordinateTests
    {
        [Test]
        public void ConstructorTest()
        {
            var coordinate = new Coordinate(1, 1);

            Assert.AreEqual(1, coordinate.Latitude);
            Assert.AreEqual(1, coordinate.Longitude);
            Assert.IsNull(coordinate.Heading);
            Assert.IsFalse(coordinate.UseSideOfRoad);
        }

        [Test]
        public void ToStringTest()
        {
            var coordinate = new Coordinate(1, 1);

            var toString = coordinate.ToString();
            Assert.AreEqual($"{coordinate.Latitude.ToString(CultureInfo.InvariantCulture)},{coordinate.Longitude.ToString(CultureInfo.InvariantCulture)}", toString);
        }

        [Test]
        public void ToStringWhenHeadingTest()
        {
            var coordinate = new Coordinate(1, 1)
            {
                Heading = 90
            };

            var toString = coordinate.ToString();
            Assert.AreEqual($"heading={coordinate.Heading}:{coordinate.Latitude.ToString(CultureInfo.InvariantCulture)},{coordinate.Longitude.ToString(CultureInfo.InvariantCulture)}", toString);
        }

        [Test]
        public void ToStringWhenHeadingAndSideOfRoadTest()
        {
            var coordinate = new Coordinate(1, 1)
            {
                Heading = 90,
                UseSideOfRoad = true
            };

            var toString = coordinate.ToString();
            Assert.AreEqual($"side_of_road:{coordinate.Latitude.ToString(CultureInfo.InvariantCulture)},{coordinate.Longitude.ToString(CultureInfo.InvariantCulture)}", toString);
        }

        [Test]
        public void ToStringWhenSideOfRoadTest()
        {
            var coordinate = new Coordinate(1, 1)
            {
                UseSideOfRoad = true
            };

            var toString = coordinate.ToString();
            Assert.AreEqual($"side_of_road:{coordinate.Latitude.ToString(CultureInfo.InvariantCulture)},{coordinate.Longitude.ToString(CultureInfo.InvariantCulture)}", toString);
        }
    }
}