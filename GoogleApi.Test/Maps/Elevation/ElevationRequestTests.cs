using System;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Elevation.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Elevation
{
    [TestFixture]
    public class ElevationRequestTests : BaseTest
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new ElevationRequest();

            Assert.IsTrue(request.IsSsl);
        }

        [Test]
        public void GetQueryStringParametersWhenPathAndSamplesIsNullTest()
        {
            var request = new ElevationRequest
            {
                Path = new[] { new Location(40.7141289, -73.9614074) },
                Samples = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Samples is required, when using Path");
        }

        [Test]
        public void GetQueryStringParametersWhenPathAndLocationTest()
        {
            var request = new ElevationRequest
            {
                Path = new[] { new Location(40.7141289, -73.9614074) },
                Locations = new[] { new Location(40.7141289, -73.9614074) }
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Path and Locations cannot both be specified");
        }

        [Test]
        public void GetQueryStringParametersWhenPathAndLocationIsNullTest()
        {
            var request = new ElevationRequest();

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Locations or Path is required");
        }

        [Test]
        public void SetIsSslTest()
        {
            var exception = Assert.Throws<NotSupportedException>(() => new ElevationRequest
            {
                IsSsl = false
            });
            Assert.AreEqual("This operation is not supported, Request must use SSL", exception.Message);
        }
    }
}