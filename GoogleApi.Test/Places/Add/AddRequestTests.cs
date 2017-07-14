using System;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Add.Request;
using GoogleApi.Entities.Places.Common.Enums;
using NUnit.Framework;

namespace GoogleApi.Test.Places.Add
{
    [TestFixture]
    public class AddRequestTests : BaseTest
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new PlacesAddRequest();

            Assert.IsTrue(request.IsSsl);
            Assert.AreEqual(Language.English, request.Language);
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new PlacesAddRequest
            {
                Key = null,
                Name = "test",
                Location = new Location(0, 0),
                Types = new[] { PlaceLocationType.StreetAddress }
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.QueryStringParameters;
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsStringEmptyTest()
        {
            var request = new PlacesAddRequest
            {
                Key = string.Empty,
                Name = "test",
                Location = new Location(0, 0),
                Types = new[] { PlaceLocationType.StreetAddress }
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.QueryStringParameters;
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void GetQueryStringParametersWhenNameIsNullTest()
        {
            var request = new PlacesAddRequest
            {
                Key = this.ApiKey,
                Name = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.QueryStringParameters;
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Name must be provided");
        }

        [Test]
        public void GetQueryStringParametersWhenNameIsStringEmptyTest()
        {
            var request = new PlacesAddRequest
            {
                Key = this.ApiKey,
                Name = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.QueryStringParameters;
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Name must be provided");
        }

        [Test]
        public void GetQueryStringParametersWhenLocationIsNullTest()
        {
            var request = new PlacesAddRequest
            {
                Key = this.ApiKey,
                Name = "Home",
                Location = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.QueryStringParameters;
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Location must be provided");
        }

        [Test]
        public void GetQueryStringParametersWhenTypesIsNullTest()
        {
            var request = new PlacesAddRequest
            {
                Key = this.ApiKey,
                Name = "Home",
                Location = new Location(55.664425, 12.502264),
                Types = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.QueryStringParameters;
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Types must be provided. At least one type must be specified");
        }

        [Test]
        public void GetQueryStringParametersWhenTypesIsEmptyTest()
        {
            var request = new PlacesAddRequest
            {
                Key = this.ApiKey,
                Name = "Home",
                Location = new Location(55.664425, 12.502264),
                Types = new PlaceLocationType[0]
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.QueryStringParameters;
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Types must be provided. At least one type must be specified");
        }
    }
}