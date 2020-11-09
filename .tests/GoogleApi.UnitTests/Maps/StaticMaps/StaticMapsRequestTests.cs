using System;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.StaticMaps.Request;
using GoogleApi.Entities.Maps.StaticMaps.Request.Enums;
using GoogleApi.Entities.Maps.StaticMaps.Request.Enums.Extensions;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.StaticMaps
{
    [TestFixture]
    public class StaticMapsRequestTests
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new StaticMapsRequest();

            Assert.IsTrue(request.IsSsl);
        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new StaticMapsRequest
            {
                Key = "abc",
                Center = new Location(1, 1),
                ZoomLevel = 2,
                Size = new MapSize(100, 100),
                Type = MapType.Hybrid,
                Scale = MapScale.Large,
                Format = ImageFormat.Png32,
                Language = Language.Arabic,
                Region = "abc"
            };

            var parameters = request.GetQueryStringParameters();

            Assert.IsNotNull(parameters);
            Assert.IsTrue(parameters.Any(x => x.Key == "center" && x.Value == "1,1"));
            Assert.IsTrue(parameters.Any(x => x.Key == "zoom" && x.Value == "2"));
            Assert.IsTrue(parameters.Any(x => x.Key == "size" && x.Value == "100x100"));
            Assert.IsTrue(parameters.Any(x => x.Key == "maptype" && x.Value == "hybrid"));
            Assert.IsTrue(parameters.Any(x => x.Key == "scale" && x.Value == "2"));
            Assert.IsTrue(parameters.Any(x => x.Key == "format" && x.Value == "png32"));
            Assert.IsTrue(parameters.Any(x => x.Key == "language" && x.Value == "ar"));
            Assert.IsTrue(parameters.Any(x => x.Key == "region" && x.Value == "abc"));
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new StaticMapsRequest
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
            var request = new StaticMapsRequest
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
        public void GetQueryStringParametersWhenLocationOrPanoramaIdIsNullTest()
        {
            var request = new StaticMapsRequest
            {
                Key = "abc"
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Center is required, unless Markers, Path or Visibles is defined");
        }

        [Test]
        public void GetQueryStringParametersWhenPathTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void GetQueryStringParametersWhenPathAndPointsIsEmptyTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void GetQueryStringParametersWhenStylesTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void GetQueryStringParametersWhenVisiblesTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void GetQueryStringParametersWhenMarkersTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void GetQueryStringParametersWhenMarkersAndLocationsIsEmptyTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void GetUriTest()
        {
            var request = new StaticMapsRequest
            {
                Key = "abc",
                Center = new Location(1, 1), 
                ZoomLevel = 1
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/staticmap?key={request.Key}&language={request.Language.ToCode()}&center={Uri.EscapeDataString(request.Center.ToString())}&zoom={request.ZoomLevel.ToString()}&size={request.Size.Width}x{request.Size.Height}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenMapTypeTest()
        {
            var request = new StaticMapsRequest
            {
                Key = "abc",
                Center = new Location(1, 1),
                ZoomLevel = 1, 
                Type = MapType.Hybrid
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/staticmap?key={request.Key}&language={request.Language.ToCode()}&center={Uri.EscapeDataString(request.Center.ToString())}&zoom={request.ZoomLevel.ToString()}&size={request.Size.Width}x{request.Size.Height}&maptype={request.Type.ToString().ToLower()}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenScaleTest()
        {
            var request = new StaticMapsRequest
            {
                Key = "abc",
                Center = new Location(1, 1),
                ZoomLevel = 1,
                Scale = MapScale.Huge
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/staticmap?key={request.Key}&language={request.Language.ToCode()}&center={Uri.EscapeDataString(request.Center.ToString())}&zoom={request.ZoomLevel.ToString()}&size={request.Size.Width}x{request.Size.Height}&scale={((int)request.Scale.GetValueOrDefault()).ToString()}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriFormatTest()
        {
            var request = new StaticMapsRequest
            {
                Key = "abc",
                Center = new Location(1, 1),
                ZoomLevel = 1,
                Format = ImageFormat.Gif
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/staticmap?key={request.Key}&language={request.Language.ToCode()}&center={Uri.EscapeDataString(request.Center.ToString())}&zoom={request.ZoomLevel.ToString()}&size={request.Size.Width}x{request.Size.Height}&format={request.Format.GetValueOrDefault().GetParameterName()}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenRegionTest()
        {
            var request = new StaticMapsRequest
            {
                Key = "abc",
                Center = new Location(1, 1),
                ZoomLevel = 1,
                Region = "abc"
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/staticmap?key={request.Key}&language={request.Language.ToCode()}&center={Uri.EscapeDataString(request.Center.ToString())}&zoom={request.ZoomLevel.ToString()}&size={request.Size.Width}x{request.Size.Height}&region={request.Region}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenPathTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void GetUriWhenStylesTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void GetUriWhenVisiblesTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void GetUriWhenMarkersTest()
        {
            Assert.Inconclusive();
        }
    }
}