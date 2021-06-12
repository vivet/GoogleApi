using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Places.AutoComplete.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Places.AutoComplete
{
    [TestFixture]
    public class AutoCompleteRequstTests
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new PlacesAutoCompleteRequest();

            Assert.IsNull(request.Offset);
            Assert.IsNull(request.Radius);
            Assert.IsNull(request.Location);
            Assert.AreEqual(Language.English, request.Language);
        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = "abc",
                Input = "abc"
            };

            Assert.DoesNotThrow(() => request.GetQueryStringParameters());
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = null
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
            var request = new PlacesAutoCompleteRequest
            {
                Key = string.Empty
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
            var request = new PlacesAutoCompleteRequest
            {
                Key = "abc",
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
            var request = new PlacesAutoCompleteRequest
            {
                Key = "abc",
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
            var request = new PlacesAutoCompleteRequest
            {
                Key = "abc",
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
            var request = new PlacesAutoCompleteRequest
            {
                Key = "abc",
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
        public void GetUriTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = "abc",
                Input = "abc"
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/autocomplete/json?key={request.Key}&input={request.Input}&language={request.Language.ToCode()}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenOffsetTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = "abc",
                Input = "abc",
                Offset = "abc"
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/autocomplete/json?key={request.Key}&input={request.Input}&language={request.Language.ToCode()}&offset={request.Offset}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenSessionTokenTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = "abc",
                Input = "abc",
                SessionToken = "abc"
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/autocomplete/json?key={request.Key}&input={request.Input}&language={request.Language.ToCode()}&sessiontoken={request.SessionToken}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenLocationTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = "abc",
                Input = "abc",
                Location = new Location(1, 1)
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/autocomplete/json?key={request.Key}&input={request.Input}&language={request.Language.ToCode()}&location={Uri.EscapeDataString(request.Location.ToString())}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenRadiusTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = "abc",
                Input = "abc", 
                Radius = 50
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/autocomplete/json?key={request.Key}&input={request.Input}&language={request.Language.ToCode()}&radius={request.Radius}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenStrictboundsTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = "abc",
                Input = "abc",
                Strictbounds = true
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/autocomplete/json?key={request.Key}&input={request.Input}&language={request.Language.ToCode()}&strictbounds", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenComponentsTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = "abc",
                Input = "abc",
                Components = new[]
                {
                    new KeyValuePair<Component, string>(Component.Administrative_Area, "abc") 
                }
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/autocomplete/json?key={request.Key}&input={request.Input}&language={request.Language.ToCode()}&components={Uri.EscapeDataString(string.Join("|", request.Components.Select(x => $"{x.Key.ToString().ToLower()}:{x.Value}")))}", uri.PathAndQuery);
        }
    }
}