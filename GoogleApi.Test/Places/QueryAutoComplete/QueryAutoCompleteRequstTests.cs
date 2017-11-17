using System;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.QueryAutoComplete.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Places.QueryAutoComplete
{
    [TestFixture]
    public class QueryAutoCompleteRequstTests : BaseTest
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new PlacesQueryAutoCompleteRequest();

            Assert.IsTrue(request.IsSsl);
            Assert.IsNull(request.Offset);
            Assert.IsNull(request.Radius);
            Assert.IsNull(request.Location);
            Assert.AreEqual(Language.English, request.Language);
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = null,
                Input = "test"
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsStringEmptyTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = string.Empty,
                Input = "test"
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void GetQueryStringParametersWhenInputIsNullTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Input is required");
        }

        [Test]
        public void GetQueryStringParametersWhenInputIsStringEmptyTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Input is required");
        }

        [Test]
        public void GetQueryStringParametersWhenRadiusIsLessThanOneTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "abc",
                Radius = 0
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Radius must be greater than or equal to 1 and less than or equal to 50.000");
        }

        [Test]
        public void GetQueryStringParametersWhenRadiusIsGereaterThanFiftyThousandTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "abc",
                Radius = 50001
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Radius must be greater than or equal to 1 and less than or equal to 50.000");
        }

        [Test]
        public void SetIsSslTest()
        {
            var exception = Assert.Throws<NotSupportedException>(() => new PlacesQueryAutoCompleteRequest
            {
                IsSsl = false
            });
            Assert.AreEqual("This operation is not supported, Request must use SSL", exception.Message);
        }
    }
}