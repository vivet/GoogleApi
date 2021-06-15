using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Common;
using NUnit.Framework;
using Coordinate = GoogleApi.Entities.Maps.DistanceMatrix.Request.Coordinate;
using Location = GoogleApi.Entities.Maps.DistanceMatrix.Request.Location;

namespace GoogleApi.UnitTests.Maps.DistanceMatrix
{
    [TestFixture]
    public class LocationTests
    {
        [Test]
        public void ConstructorWhenPlaceTest()
        {
            var place = new Place("id");
            var location = new Location(place);

            Assert.AreEqual(place.ToString(), location.String);
        }

        [Test]
        public void ConstructorWhenAddressTest()
        {
            var address = new Address("address");
            var location = new Location(address);

            Assert.AreEqual(address.ToString(), location.String);
        }

        [Test]
        public void ConstructorWhenPlusCodeTest()
        {
            var plusCode = new PlusCode("global", "local");
            var location = new Location(plusCode);

            Assert.AreEqual(plusCode.ToString(), location.String);
        }

        [Test]
        public void ConstructorWhenCoordinateTest()
        {
            var coordinate = new Coordinate(1, 1);
            var location = new Location(coordinate);

            Assert.AreEqual(coordinate.ToString(), location.String);
        }

        [Test]
        public void ToStringTest()
        {
            var coordinate = new Coordinate(1, 1);
            var location = new Location(coordinate);

            var toString = location.ToString();

            Assert.AreEqual(location.String, toString);
        }
    }
}