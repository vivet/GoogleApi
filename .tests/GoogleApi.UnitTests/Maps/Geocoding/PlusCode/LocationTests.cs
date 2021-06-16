using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Geocoding.PlusCode.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.Geocoding.PlusCode
{
    [TestFixture]
    public class LocationTests
    {
        [Test]
        public void ConstructorWhenCoordinateTest()
        {
            var coordinate = new Coordinate(1, 1);
            var location = new Entities.Maps.Geocoding.PlusCode.Request.Location(coordinate);
            Assert.AreEqual(coordinate.ToString(), location.String);
        }

        [Test]
        public void ConstructorWhenAddressTest()
        {
            var address = new Entities.Common.Address("address");
            var location = new Entities.Maps.Geocoding.PlusCode.Request.Location(address);
            Assert.AreEqual(address.ToString(), location.String);
        }

        [Test]
        public void ConstructorWhenGlobalCodeTest()
        {
            var globalCode = new GlobalCode("code");
            var location = new Entities.Maps.Geocoding.PlusCode.Request.Location(globalCode);
            Assert.AreEqual(globalCode.ToString(), location.String);
        }

        [Test]
        public void ConstructorWhenLocalCodeAndLocalityTest()
        {
            var localCodeAndLocality = new LocalCodeAndLocality("code", "locality");
            var location = new Entities.Maps.Geocoding.PlusCode.Request.Location(localCodeAndLocality);
            Assert.AreEqual(localCodeAndLocality.ToString(), location.String);
        }
    }
}