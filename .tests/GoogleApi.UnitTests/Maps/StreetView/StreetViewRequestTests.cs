using System;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.StreetView.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.StreetView
{
    [TestFixture]
    public class StreetViewRequestTests
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new StreetViewRequest();

            Assert.IsTrue(request.IsSsl);
        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new StreetViewRequest
            {
                Key = "abc",
                Location = new Location(1, 1),
                Size = new MapSize(100, 100),
                Pitch = 20,
                Heading = 3,
                FieldOfView = 2
            };

            var parameters = request.GetQueryStringParameters();

            Assert.IsNotNull(parameters);
            Assert.IsTrue(parameters.Any(x => x.Key == "location" && x.Value == "1,1"));
            Assert.IsTrue(parameters.Any(x => x.Key == "size" && x.Value == "100x100"));
            Assert.IsTrue(parameters.Any(x => x.Key == "pitch" && x.Value == "20"));
            Assert.IsTrue(parameters.Any(x => x.Key == "heading" && x.Value == "3"));
            Assert.IsTrue(parameters.Any(x => x.Key == "fov" && x.Value == "2"));
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new StreetViewRequest
            {
                Key = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsStringEmptyTest()
        {
            var request = new StreetViewRequest
            {
                Key = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void GetQueryStringParametersWhenPitchIsOutOfRangeLowerTest()
        {
            var request = new StreetViewRequest
            {
                Key = "abc",
                Location = new Location(0, 0),
                Pitch = -100
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Pitch must be greater than -90 and less than 90");
        }

        [Test]
        public void GetQueryStringParametersWhenPitchIsOutOfRangeHigherTest()
        {
            var request = new StreetViewRequest
            {
                Key = "abc",
                Location = new Location(0, 0),
                Pitch = 100
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Pitch must be greater than -90 and less than 90");
        }

        [Test]
        public void GetQueryStringParametersWhenHeadingIsOutOfRangeLowerTest()
        {
            var request = new StreetViewRequest
            {
                Key = "abc",
                Location = new Location(0, 0),
                Heading = -1
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Heading must be greater than 0 and less than 360");
        }

        [Test]
        public void GetQueryStringParametersWhenHeadingIsOutOfRangeHigherTest()
        {
            var request = new StreetViewRequest
            {
                Key = "abc",
                Location = new Location(0, 0),
                Heading = 361
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Heading must be greater than 0 and less than 360");
        }

        [Test]
        public void GetQueryStringParametersWhenFieldOfViewIsOutOfRangeLowerTest()
        {
            var request = new StreetViewRequest
            {
                Key = "abc",
                Location = new Location(0, 0),
                FieldOfView = -1
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Field of view must be greater than 0 and less than 120");
        }

        [Test]
        public void GetQueryStringParametersWhenFieldOfViewIsOutOfRangeHigherTest()
        {
            var request = new StreetViewRequest
            {
                Key = "abc",
                Location = new Location(0, 0),
                FieldOfView = 121
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Field of view must be greater than 0 and less than 120");
        }
    }
}