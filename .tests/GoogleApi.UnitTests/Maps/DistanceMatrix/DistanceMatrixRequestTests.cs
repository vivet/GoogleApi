using System;
using System.Globalization;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.DistanceMatrix
{
    [TestFixture]
    public class DistanceMatrixRequestTests
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new DistanceMatrixRequest();

            Assert.IsTrue(request.IsSsl);
            Assert.AreEqual(Units.Metric, request.Units);
            Assert.AreEqual(AvoidWay.Nothing, request.Avoid);
            Assert.AreEqual(TravelMode.Driving, request.TravelMode);
            Assert.AreEqual(TransitMode.Bus | TransitMode.Train | TransitMode.Subway | TransitMode.Tram, request.TransitMode);
            Assert.AreEqual(TransitRoutingPreference.Nothing, request.TransitRoutingPreference);
            Assert.AreEqual(Language.English, request.Language);
            Assert.IsNull(request.ArrivalTime);
            Assert.IsNull(request.DepartureTime);
            Assert.IsNull(request.Region);
        }

        [Test]
        public void SetIsSslTest()
        {
            var exception = Assert.Throws<NotSupportedException>(() => new DistanceMatrixRequest
            {
                IsSsl = false
            });
            Assert.AreEqual("This operation is not supported, Request must use SSL", exception.Message);
        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new DistanceMatrixRequest
            {
                Origins = new[] { new Location("test") },
                Destinations = new[] { new Location("test") }
            };

            Assert.DoesNotThrow(() => request.GetQueryStringParameters());
        }

        [Test]
        public void GetQueryStringParametersWhenHeadingTest()
        {
            var request = new DistanceMatrixRequest
            {
                Origins = new[] { new Location(1, 2) { Heading = 90 } },
                Destinations = new[] { new Location(1, 2) { Heading = 90 } }
            };

            Assert.DoesNotThrow(() => request.GetQueryStringParameters());
        }

        [Test]
        public void GetQueryStringParametersWhenUseSideOfRoadTest()
        {
            var request = new DistanceMatrixRequest
            {
                Origins = new[] { new Location(1, 2) { UseSideOfRoad = true } },
                Destinations = new[] { new Location(1, 2) { UseSideOfRoad = true } }
            };

            Assert.DoesNotThrow(() => request.GetQueryStringParameters());
        }

        [Test]
        public void GetQueryStringParametersWhenOriginsIsNullTest()
        {
            var request = new DistanceMatrixRequest
            {
                Destinations = new[] { new Location("test") }
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Origins is required");
        }

        [Test]
        public void GetQueryStringParametersWhenOriginsIsEmptyTest()
        {
            var request = new DistanceMatrixRequest
            {
                Origins = new Location[0],
                Destinations = new[] { new Location(0, 0) }
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Origins is required");
        }

        [Test]
        public void GetQueryStringParametersWhenDestinationsIsNullTest()
        {
            var request = new DistanceMatrixRequest
            {
                Origins = new[] { new Location(0, 0) }, 
                Destinations = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Destinations is required");
        }

        [Test]
        public void GetQueryStringParametersWhenDestinationsIsEmptyTest()
        {
            var request = new DistanceMatrixRequest
            {
                Origins = new[] { new Location(0, 0) },
                Destinations = new Location[0]
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Destinations is required");
        }

        [Test]
        public void GetUriTest()
        {
            var request = new DistanceMatrixRequest
            {
                Key = "abc",
                Origins = new[] { new Location("test") },
                Destinations = new[] { new Location("test") },
                TravelMode = TravelMode.Bicycling
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/distancematrix/json?key={request.Key}&origins={Uri.EscapeDataString(string.Join("|", request.Origins))}&destinations={Uri.EscapeDataString(string.Join("|", request.Destinations))}&units={request.Units.ToString().ToLower()}&mode={request.TravelMode.ToString().ToLower()}&language={request.Language.ToCode()}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenTravelModeTransitTest()
        {
            var request = new DistanceMatrixRequest
            {
                Key = "abc",
                Origins = new[] { new Location("test") },
                Destinations = new[] { new Location("test") },
                TravelMode = TravelMode.Transit,
                TransitMode = TransitMode.Subway | TransitMode.Bus
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/distancematrix/json?key={request.Key}&origins={Uri.EscapeDataString(string.Join("|", request.Origins))}&destinations={Uri.EscapeDataString(string.Join("|", request.Destinations))}&units={request.Units.ToString().ToLower()}&mode={request.TravelMode.ToString().ToLower()}&language={request.Language.ToCode()}&transit_mode={Uri.EscapeDataString(request.TransitMode.ToEnumString('|'))}&departure_time=now", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenTravelModeTransitAndArrivalTimeTest()
        {
            var request = new DistanceMatrixRequest
            {
                Key = "abc",
                Origins = new[] { new Location("test") },
                Destinations = new[] { new Location("test") },
                TravelMode = TravelMode.Transit,
                TransitMode = TransitMode.Subway | TransitMode.Bus,
                ArrivalTime = DateTime.UtcNow
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/distancematrix/json?key={request.Key}&origins={Uri.EscapeDataString(string.Join("|", request.Origins))}&destinations={Uri.EscapeDataString(string.Join("|", request.Destinations))}&units={request.Units.ToString().ToLower()}&mode={request.TravelMode.ToString().ToLower()}&language={request.Language.ToCode()}&transit_mode={Uri.EscapeDataString(request.TransitMode.ToEnumString('|'))}&arrival_time={request.ArrivalTime.GetValueOrDefault().DateTimeToUnixTimestamp().ToString(CultureInfo.InvariantCulture)}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenTravelModeTransitAndDepartureTimeTest()
        {
            var request = new DistanceMatrixRequest
            {
                Key = "abc",
                Origins = new[] { new Location("test") },
                Destinations = new[] { new Location("test") },
                TravelMode = TravelMode.Transit,
                TransitMode = TransitMode.Subway | TransitMode.Bus,
                DepartureTime = DateTime.UtcNow
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/distancematrix/json?key={request.Key}&origins={Uri.EscapeDataString(string.Join("|", request.Origins))}&destinations={Uri.EscapeDataString(string.Join("|", request.Destinations))}&units={request.Units.ToString().ToLower()}&mode={request.TravelMode.ToString().ToLower()}&language={request.Language.ToCode()}&transit_mode={Uri.EscapeDataString(request.TransitMode.ToEnumString('|'))}&departure_time={request.DepartureTime.GetValueOrDefault().DateTimeToUnixTimestamp().ToString(CultureInfo.InvariantCulture)}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenTravelModeTransitAndDepartureTimeAndTransitRoutingPreferenceTest()
        {
            var request = new DistanceMatrixRequest
            {
                Key = "abc",
                Origins = new[] { new Location("test") },
                Destinations = new[] { new Location("test") },
                TravelMode = TravelMode.Transit,
                TransitMode = TransitMode.Subway | TransitMode.Bus,
                DepartureTime = DateTime.UtcNow,
                TransitRoutingPreference = TransitRoutingPreference.FewerTransfers
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/distancematrix/json?key={request.Key}&origins={Uri.EscapeDataString(string.Join("|", request.Origins))}&destinations={Uri.EscapeDataString(string.Join("|", request.Destinations))}&units={request.Units.ToString().ToLower()}&mode={request.TravelMode.ToString().ToLower()}&language={request.Language.ToCode()}&transit_mode={Uri.EscapeDataString(request.TransitMode.ToEnumString('|'))}&transit_routing_preference=fewer_transfers&departure_time={request.DepartureTime.GetValueOrDefault().DateTimeToUnixTimestamp().ToString(CultureInfo.InvariantCulture)}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenTravelModeDrivingTest()
        {
            var request = new DistanceMatrixRequest
            {
                Key = "abc",
                Origins = new[] { new Location("test") },
                Destinations = new[] { new Location("test") },
                TravelMode = TravelMode.Driving
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/distancematrix/json?key={request.Key}&origins={Uri.EscapeDataString(string.Join("|", request.Origins))}&destinations={Uri.EscapeDataString(string.Join("|", request.Destinations))}&units={request.Units.ToString().ToLower()}&mode={request.TravelMode.ToString().ToLower()}&language={request.Language.ToCode()}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenTravelModeDrivingAndDepartureTimeTest()
        {
            var request = new DistanceMatrixRequest
            {
                Key = "abc",
                Origins = new[] { new Location("test") },
                Destinations = new[] { new Location("test") },
                TravelMode = TravelMode.Driving, 
                DepartureTime = DateTime.UtcNow
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/distancematrix/json?key={request.Key}&origins={Uri.EscapeDataString(string.Join("|", request.Origins))}&destinations={Uri.EscapeDataString(string.Join("|", request.Destinations))}&units={request.Units.ToString().ToLower()}&mode={request.TravelMode.ToString().ToLower()}&language={request.Language.ToCode()}&departure_time={request.DepartureTime.GetValueOrDefault().DateTimeToUnixTimestamp().ToString(CultureInfo.InvariantCulture)}&traffic_model={request.TrafficModel.ToString().ToLower()}", uri.PathAndQuery);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("  ")]
        public void GetUriWhenWhenRegionIsNullEmptyOrWhiteSpace(string region)
        {
            var request = new DistanceMatrixRequest
            {
                Key = "abc",
                Region = region,
                Origins = new[] { new Location("test") },
                Destinations = new[] { new Location("test") }
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/distancematrix/json?key={request.Key}&origins={Uri.EscapeDataString(string.Join("|", request.Origins))}&destinations={Uri.EscapeDataString(string.Join("|", request.Destinations))}&units={request.Units.ToString().ToLower()}&mode={request.TravelMode.ToString().ToLower()}&language={request.Language.ToCode()}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenWhenRegionIsNotNullEmptyOrWhiteSpace()
        {
            var request = new DistanceMatrixRequest
            {
                Key = "abc",
                Region = "us",
                Origins = new[] { new Location("test") },
                Destinations = new[] { new Location("test") }
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/distancematrix/json?key={request.Key}&origins={Uri.EscapeDataString(string.Join("|", request.Origins))}&destinations={Uri.EscapeDataString(string.Join("|", request.Destinations))}&units={request.Units.ToString().ToLower()}&mode={request.TravelMode.ToString().ToLower()}&language={request.Language.ToCode()}&region=us", uri.PathAndQuery);
        }
    }
}