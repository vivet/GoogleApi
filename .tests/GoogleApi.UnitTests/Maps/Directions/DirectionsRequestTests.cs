using System;
using System.Globalization;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.Directions.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.Directions
{
    [TestFixture]
    public class DirectionsRequestTests
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new DirectionsRequest();

            Assert.IsTrue(request.IsSsl);
            Assert.AreEqual(Units.Metric, request.Units);
            Assert.AreEqual(AvoidWay.Nothing, request.Avoid);
            Assert.AreEqual(TravelMode.Driving, request.TravelMode);
            Assert.AreEqual(TransitMode.Bus | TransitMode.Train | TransitMode.Subway | TransitMode.Tram, request.TransitMode);
            Assert.AreEqual(TransitRoutingPreference.Nothing, request.TransitRoutingPreference);
            Assert.AreEqual(Language.English, request.Language);
            Assert.IsNull(request.ArrivalTime);
            Assert.IsNull(request.DepartureTime);
            Assert.IsFalse(request.Alternatives);
            Assert.IsFalse(request.OptimizeWaypoints);
        }

        [Test]
        public void SetIsSslTest()
        {
            var exception = Assert.Throws<NotSupportedException>(() => new DirectionsRequest
            {
                IsSsl = false
            });
            Assert.AreEqual("This operation is not supported, Request must use SSL", exception.Message);
        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new DirectionsRequest
            {
                Origin = new Location("test"),
                Destination = new Location("test")
            };

            Assert.DoesNotThrow(() => request.GetQueryStringParameters());
        }

        [Test]
        public void GetQueryStringParametersWhenOriginIsNullTest()
        {
            var request = new DirectionsRequest
            {
                Destination = new Location("test")
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Origin is required");
        }
    
        [Test]
        public void GetQueryStringParametersWhenDestinationsIsNullTest()
        {
            var request = new DirectionsRequest
            {
                Origin = new Location(0, 0)
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Destination is required");
        }

        [Test]
        public void GetUriTest()
        {
            var request = new DirectionsRequest
            {
                Key = "abc",
                Origin = new Location("285 Bedford Ave, Brooklyn, NY, USA"),
                Destination = new Location("185 Broadway Ave, Manhattan, NY, USA")
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/directions/json?key={request.Key}&origin={Uri.EscapeDataString(request.Origin.ToString())}&destination={Uri.EscapeDataString(request.Destination.ToString())}&units={request.Units.ToString().ToLower()}&mode={request.TravelMode.ToString().ToLower()}&language={request.Language.ToCode()}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenRegionTest()
        {
            var request = new DirectionsRequest
            {
                Key = "abc",
                Origin = new Location("285 Bedford Ave, Brooklyn, NY, USA"),
                Destination = new Location("185 Broadway Ave, Manhattan, NY, USA"),
                Region = "test"
                
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/directions/json?key={request.Key}&origin={Uri.EscapeDataString(request.Origin.ToString())}&destination={Uri.EscapeDataString(request.Destination.ToString())}&units={request.Units.ToString().ToLower()}&mode={request.TravelMode.ToString().ToLower()}&language={request.Language.ToCode()}&region={request.Region}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenAlternativesTrueTest()
        {
            var request = new DirectionsRequest
            {
                Key = "abc",
                Origin = new Location("285 Bedford Ave, Brooklyn, NY, USA"),
                Destination = new Location("185 Broadway Ave, Manhattan, NY, USA"),
                Alternatives = true
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/directions/json?key={request.Key}&origin={Uri.EscapeDataString(request.Origin.ToString())}&destination={Uri.EscapeDataString(request.Destination.ToString())}&units={request.Units.ToString().ToLower()}&mode={request.TravelMode.ToString().ToLower()}&language={request.Language.ToCode()}&alternatives={request.Alternatives.ToString().ToLower()}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenAvoidTest()
        {
            var request = new DirectionsRequest
            {
                Key = "abc",
                Origin = new Location("285 Bedford Ave, Brooklyn, NY, USA"),
                Destination = new Location("185 Broadway Ave, Manhattan, NY, USA"),
                Avoid = AvoidWay.Highways | AvoidWay.Indoor | AvoidWay.Ferries
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/directions/json?key={request.Key}&origin={Uri.EscapeDataString(request.Origin.ToString())}&destination={Uri.EscapeDataString(request.Destination.ToString())}&units={request.Units.ToString().ToLower()}&mode={request.TravelMode.ToString().ToLower()}&language={request.Language.ToCode()}&avoid={Uri.EscapeDataString(request.Avoid.ToEnumString('|'))}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenWayPointsTest()
        {
            var request = new DirectionsRequest
            {
                Key = "abc",
                Origin = new Location("285 Bedford Ave, Brooklyn, NY, USA"),
                Destination = new Location("185 Broadway Ave, Manhattan, NY, USA"),
                Waypoints = new [] { new Location(1, 1) }
            };

            var uri = request.GetUri();
            var waypoints = request.Waypoints.Select(x => x.ToString());

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/directions/json?key={request.Key}&origin={Uri.EscapeDataString(request.Origin.ToString())}&destination={Uri.EscapeDataString(request.Destination.ToString())}&units={request.Units.ToString().ToLower()}&mode={request.TravelMode.ToString().ToLower()}&language={request.Language.ToCode()}&waypoints={Uri.EscapeDataString(string.Join("|", waypoints))}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenWayPointsAndOptimizeTest()
        {
            var request = new DirectionsRequest
            {
                Key = "abc",
                Origin = new Location("285 Bedford Ave, Brooklyn, NY, USA"),
                Destination = new Location("185 Broadway Ave, Manhattan, NY, USA"),
                Waypoints = new[] { new Location(1, 1) },
                OptimizeWaypoints = true
            };

            var uri = request.GetUri();
            var waypoints = request.Waypoints.Select(x => x.ToString());

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/directions/json?key={request.Key}&origin={Uri.EscapeDataString(request.Origin.ToString())}&destination={Uri.EscapeDataString(request.Destination.ToString())}&units={request.Units.ToString().ToLower()}&mode={request.TravelMode.ToString().ToLower()}&language={request.Language.ToCode()}&waypoints={Uri.EscapeDataString("optimize:true|")}{Uri.EscapeDataString(string.Join("|", waypoints))}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenTravelModeTransitTest()
        {
            var request = new DirectionsRequest
            {
                Key = "abc",
                Origin = new Location("285 Bedford Ave, Brooklyn, NY, USA"),
                Destination = new Location("185 Broadway Ave, Manhattan, NY, USA"),
                TravelMode = TravelMode.Transit,
                TransitMode = TransitMode.Subway | TransitMode.Bus
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/directions/json?key={request.Key}&origin={Uri.EscapeDataString(request.Origin.ToString())}&destination={Uri.EscapeDataString(request.Destination.ToString())}&units={request.Units.ToString().ToLower()}&mode={request.TravelMode.ToString().ToLower()}&language={request.Language.ToCode()}&transit_mode={Uri.EscapeDataString(request.TransitMode.ToEnumString('|'))}&departure_time=now", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenTravelModeTransitAndArrivalTimeTest()
        {
            var request = new DirectionsRequest
            {
                Key = "abc",
                Origin = new Location("285 Bedford Ave, Brooklyn, NY, USA"),
                Destination = new Location("185 Broadway Ave, Manhattan, NY, USA"),
                TravelMode = TravelMode.Transit,
                TransitMode = TransitMode.Subway | TransitMode.Bus,
                ArrivalTime = DateTime.UtcNow
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/directions/json?key={request.Key}&origin={Uri.EscapeDataString(request.Origin.ToString())}&destination={Uri.EscapeDataString(request.Destination.ToString())}&units={request.Units.ToString().ToLower()}&mode={request.TravelMode.ToString().ToLower()}&language={request.Language.ToCode()}&transit_mode={Uri.EscapeDataString(request.TransitMode.ToEnumString('|'))}&arrival_time={request.ArrivalTime.GetValueOrDefault().DateTimeToUnixTimestamp().ToString(CultureInfo.InvariantCulture)}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenTravelModeTransitAndDepatureTtimeTest()
        {
            var request = new DirectionsRequest
            {
                Key = "abc",
                Origin = new Location("285 Bedford Ave, Brooklyn, NY, USA"),
                Destination = new Location("185 Broadway Ave, Manhattan, NY, USA"),
                TravelMode = TravelMode.Transit,
                TransitMode = TransitMode.Subway | TransitMode.Bus,
                DepartureTime = DateTime.UtcNow
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/directions/json?key={request.Key}&origin={Uri.EscapeDataString(request.Origin.ToString())}&destination={Uri.EscapeDataString(request.Destination.ToString())}&units={request.Units.ToString().ToLower()}&mode={request.TravelMode.ToString().ToLower()}&language={request.Language.ToCode()}&transit_mode={Uri.EscapeDataString(request.TransitMode.ToEnumString('|'))}&departure_time={request.DepartureTime.GetValueOrDefault().DateTimeToUnixTimestamp().ToString(CultureInfo.InvariantCulture)}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenTravelModeTransitAndTransitRoutingPreferenceTest()
        {
            var request = new DirectionsRequest
            {
                Key = "abc",
                Origin = new Location("285 Bedford Ave, Brooklyn, NY, USA"),
                Destination = new Location("185 Broadway Ave, Manhattan, NY, USA"),
                TravelMode = TravelMode.Transit,
                TransitMode = TransitMode.Subway | TransitMode.Bus,
                TransitRoutingPreference = TransitRoutingPreference.FewerTransfers | TransitRoutingPreference.LessWalking
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/directions/json?key={request.Key}&origin={Uri.EscapeDataString(request.Origin.ToString())}&destination={Uri.EscapeDataString(request.Destination.ToString())}&units={request.Units.ToString().ToLower()}&mode={request.TravelMode.ToString().ToLower()}&language={request.Language.ToCode()}&transit_mode={Uri.EscapeDataString(request.TransitMode.ToEnumString('|'))}&transit_routing_preference={Uri.EscapeDataString(request.TransitRoutingPreference.ToEnumString('|'))}&departure_time=now", uri.PathAndQuery);
        }
    }
}