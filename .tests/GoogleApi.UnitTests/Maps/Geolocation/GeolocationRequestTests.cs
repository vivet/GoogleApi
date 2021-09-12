using System;
using GoogleApi.Entities.Maps.Geolocation.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.Geolocation
{
    [TestFixture]
    public class GeolocationRequestTests
    {
        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new GeolocationRequest
            {
                Key = null
            };

            var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
            Assert.AreEqual("'Key' is required", exception.Message);
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsEmptyTest()
        {
            var request = new GeolocationRequest
            {
                Key = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
            Assert.AreEqual("'Key' is required", exception.Message);
        }
    }
}