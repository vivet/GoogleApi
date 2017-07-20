using System;
using GoogleApi.Entities.Maps.Geocode.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Geocode
{
    [TestFixture]
    public class GeocodingRequestTests : BaseTest
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new GeocodingRequest();

            Assert.IsTrue(request.IsSsl);
        }

        [Test]
        public void GeocodingWhenAddressAndLocationIsNullTest()
        {
            var request = new GeocodingRequest();
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.QueryStringParameters;
                Assert.IsNull(parameters);
            });

            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Location or Address is required");
        }
    }
}