using System;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.DistanceMatrix
{
    [TestFixture]
    public class DistanceMatrixRequestTests : BaseTest
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
                var parameters = request.QueryStringParameters;
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
                var parameters = request.QueryStringParameters;
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
                var parameters = request.QueryStringParameters;
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
                var parameters = request.QueryStringParameters;
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Destinations is required");
        }

        [Test]
        public void GetQueryStringParametersWhenWhenTravelModeIsTransitAndDepartureTimeIsNullAndArrivalTimeIsNullTest()
        {
            var request = new DistanceMatrixRequest
            {
                Origins = new[] { new Location(1, 1) },
                Destinations = new[] { new Location("test") },
                TravelMode = TravelMode.Transit,
                DepartureTime = null,
                ArrivalTime = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.QueryStringParameters;
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "DepatureTime or ArrivalTime is required, when TravelMode is Transit");
        }
    }
}