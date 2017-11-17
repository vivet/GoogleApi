using System;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.Directions.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Directions
{
    [TestFixture]
    public class DirectionsRequestTests : BaseTest
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
        public void GetQueryStringParametersWhenWhenTravelModeIsTransitAndDepartureTimeIsNullAndArrivalTimeIsNullTest()
        {
            var request = new DirectionsRequest
            {
                Origin = new Location(0, 0),
                Destination = new Location("test"),
                TravelMode = TravelMode.Transit,
                DepartureTime = null,
                ArrivalTime = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "DepatureTime or ArrivalTime is required, when TravelMode is Transit");
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
    }
}