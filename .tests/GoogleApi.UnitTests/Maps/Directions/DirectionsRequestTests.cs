using System;
using System.Globalization;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.Directions.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests.Maps.Directions;

[TestClass]
public class DirectionsRequestTests
{
    [TestMethod]
    public void ConstructorDefaultsTest()
    {
        var request = new DirectionsRequest();

        Assert.AreEqual(Units.Metric, request.Units);
        Assert.AreEqual(AvoidWay.Nothing, request.Avoid);
        Assert.AreEqual(TravelMode.DRIVING, request.TravelMode);
        Assert.AreEqual(TransitMode.Bus | TransitMode.Train | TransitMode.Subway | TransitMode.Tram, request.TransitMode);
        Assert.AreEqual(TransitRoutingPreference.Nothing, request.TransitRoutingPreference);
        Assert.AreEqual(Language.English, request.Language);
        Assert.IsNull(request.ArrivalTime);
        Assert.IsNull(request.DepartureTime);
        Assert.IsFalse(request.Alternatives);
        Assert.IsFalse(request.OptimizeWaypoints);
    }

    [TestMethod]
    public void GetQueryStringParametersTest()
    {
        var request = new DirectionsRequest
        {
            Key = "key",
            Origin = new LocationEx(new Address("address")),
            Destination = new LocationEx(new Address("address"))
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var key = queryStringParameters.FirstOrDefault(x => x.Key == "key");
        var keyExpected = request.Key;
        Assert.IsNotNull(key);
        Assert.AreEqual(keyExpected, key.Value);

        var origin = queryStringParameters.FirstOrDefault(x => x.Key == "origin");
        var originExpected = request.Origin.ToString();
        Assert.IsNotNull(origin);
        Assert.AreEqual(originExpected, origin.Value);

        var destination = queryStringParameters.FirstOrDefault(x => x.Key == "destination");
        var destinationExpected = request.Destination.ToString();
        Assert.IsNotNull(origin);
        Assert.AreEqual(destinationExpected, destination.Value);

        var units = queryStringParameters.FirstOrDefault(x => x.Key == "units");
        var unitsExpected = request.Units.ToString().ToLower();
        Assert.IsNotNull(units);
        Assert.AreEqual(unitsExpected, units.Value);

        var language = queryStringParameters.FirstOrDefault(x => x.Key == "language");
        var languageExpected = request.Language.ToCode();
        Assert.IsNotNull(language);
        Assert.AreEqual(languageExpected, language.Value);

        var mode = queryStringParameters.FirstOrDefault(x => x.Key == "mode");
        var modeExpected = request.TravelMode.ToString().ToLower();
        Assert.IsNotNull(mode);
        Assert.AreEqual(modeExpected, mode.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenChannelTest()
    {
        var request = new DirectionsRequest
        {
            Key = "key",
            Origin = new LocationEx(new Address("address")),
            Destination = new LocationEx(new Address("address")),
            Channel = "channel"
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var channel = queryStringParameters.FirstOrDefault(x => x.Key == "channel");
        var channelExpected = request.Channel;
        Assert.IsNotNull(channel);
        Assert.AreEqual(channelExpected, channel.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenLanguageTest()
    {
        var request = new DirectionsRequest
        {
            Key = "key",
            Origin = new LocationEx(new Address("address")),
            Destination = new LocationEx(new Address("address")),
            Language = Language.Afrikaans
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var language = queryStringParameters.FirstOrDefault(x => x.Key == "language");
        var languageExpected = request.Language.ToCode();
        Assert.IsNotNull(language);
        Assert.AreEqual(languageExpected, language.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenUnitsTest()
    {
        var request = new DirectionsRequest
        {
            Key = "key",
            Origin = new LocationEx(new Address("address")),
            Destination = new LocationEx(new Address("address")),
            Units = Units.Imperial
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var units = queryStringParameters.FirstOrDefault(x => x.Key == "units");
        var unitsExpected = request.Units.ToString().ToLower();
        Assert.IsNotNull(units);
        Assert.AreEqual(unitsExpected, units.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenRegionTest()
    {
        var request = new DirectionsRequest
        {
            Key = "key",
            Origin = new LocationEx(new Address("address")),
            Destination = new LocationEx(new Address("address")),
            Region = "region"
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var region = queryStringParameters.FirstOrDefault(x => x.Key == "region");
        var regionExpected = request.Region;
        Assert.IsNotNull(region);
        Assert.AreEqual(regionExpected, region.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenAlternativesTest()
    {
        var request = new DirectionsRequest
        {
            Key = "key",
            Origin = new LocationEx(new Address("address")),
            Destination = new LocationEx(new Address("address")),
            Alternatives = true
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var alternatives = queryStringParameters.FirstOrDefault(x => x.Key == "alternatives");
        var alternativesExpected = request.Alternatives.ToString().ToLower();
        Assert.IsNotNull(alternatives);
        Assert.AreEqual(alternativesExpected, alternatives.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenAvoidTest()
    {
        var request = new DirectionsRequest
        {
            Key = "key",
            Origin = new LocationEx(new Address("address")),
            Destination = new LocationEx(new Address("address")),
            Avoid = AvoidWay.Highways | AvoidWay.Ferries
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var avoid = queryStringParameters.FirstOrDefault(x => x.Key == "avoid");
        var avoidExpected = request.Avoid.ToEnumString('|');
        Assert.IsNotNull(avoid);
        Assert.AreEqual(avoidExpected, avoid.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenTravelModeTest()
    {
        var request = new DirectionsRequest
        {
            Key = "key",
            Origin = new LocationEx(new Address("address")),
            Destination = new LocationEx(new Address("address")),
            TravelMode = TravelMode.BICYCLING
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var mode = queryStringParameters.FirstOrDefault(x => x.Key == "mode");
        var modeExpected = request.TravelMode.ToString().ToLower();
        Assert.IsNotNull(mode);
        Assert.AreEqual(modeExpected, mode.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenTravelModeDrivingAndDepartureTimeTest()
    {
        var request = new DirectionsRequest
        {
            Key = "key",
            Origin = new LocationEx(new Address("address")),
            Destination = new LocationEx(new Address("address")),
            TravelMode = TravelMode.DRIVING,
            DepartureTime = DateTime.UtcNow.AddHours(1)
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var departureTime = queryStringParameters.FirstOrDefault(x => x.Key == "departure_time");
        var departureTimeExpected = request.DepartureTime.GetValueOrDefault().DateTimeToUnixTimestamp().ToString(CultureInfo.InvariantCulture);
        Assert.IsNotNull(departureTime);
        Assert.AreEqual(departureTimeExpected, departureTime.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenTravelModeDrivingAndDepartureTimeAndTrafficModelTest()
    {
        var request = new DirectionsRequest
        {
            Key = "key",
            Origin = new LocationEx(new Address("address")),
            Destination = new LocationEx(new Address("address")),
            TravelMode = TravelMode.DRIVING,
            DepartureTime = DateTime.UtcNow.AddHours(1),
            TrafficModel = TrafficModel.Best_Guess
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var departureTime = queryStringParameters.FirstOrDefault(x => x.Key == "departure_time");
        var departureTimeExpected = request.DepartureTime.GetValueOrDefault().DateTimeToUnixTimestamp().ToString(CultureInfo.InvariantCulture);
        Assert.IsNotNull(departureTime);
        Assert.AreEqual(departureTimeExpected, departureTime.Value);

        var trafficModel = queryStringParameters.FirstOrDefault(x => x.Key == "traffic_model");
        var trafficModelExpected = request.TrafficModel.ToString().ToLower();
        Assert.IsNotNull(trafficModel);
        Assert.AreEqual(trafficModelExpected, trafficModel.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenTravelModeDrivingAndDepartureTimeAndTrafficModelAndWayPointsTest()
    {
        var request = new DirectionsRequest
        {
            Key = "key",
            Origin = new LocationEx(new Address("address")),
            Destination = new LocationEx(new Address("address")),
            TravelMode = TravelMode.DRIVING,
            DepartureTime = DateTime.UtcNow.AddHours(1),
            TrafficModel = TrafficModel.Best_Guess,
            WayPoints = new[]
            {
                new WayPoint(new LocationEx(new Address("waypoint_address")))
            }
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var departureTime = queryStringParameters.FirstOrDefault(x => x.Key == "departure_time");
        var departureTimeExpected = request.DepartureTime.GetValueOrDefault().DateTimeToUnixTimestamp().ToString(CultureInfo.InvariantCulture);
        Assert.IsNotNull(departureTime);
        Assert.AreEqual(departureTimeExpected, departureTime.Value);

        var trafficModel = queryStringParameters.FirstOrDefault(x => x.Key == "traffic_model");
        Assert.IsNotNull(trafficModel);
        Assert.IsNull(trafficModel.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenTravelModeDrivingAndDepartureTimeAndTrafficModelAndWayPointsViaTest()
    {
        var request = new DirectionsRequest
        {
            Key = "key",
            Origin = new LocationEx(new Address("address")),
            Destination = new LocationEx(new Address("address")),
            TravelMode = TravelMode.DRIVING,
            DepartureTime = DateTime.UtcNow.AddHours(1),
            TrafficModel = TrafficModel.Best_Guess,
            WayPoints = new[]
            {
                new WayPoint(new LocationEx(new Address("waypoint_address")), true)
            }
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var departureTime = queryStringParameters.FirstOrDefault(x => x.Key == "departure_time");
        var departureTimeExpected = request.DepartureTime.GetValueOrDefault().DateTimeToUnixTimestamp().ToString(CultureInfo.InvariantCulture);
        Assert.IsNotNull(departureTime);
        Assert.AreEqual(departureTimeExpected, departureTime.Value);

        var trafficModel = queryStringParameters.FirstOrDefault(x => x.Key == "traffic_model");
        var trafficModelExpected = request.TrafficModel.ToString().ToLower();
        Assert.IsNotNull(trafficModel);
        Assert.AreEqual(trafficModelExpected, trafficModel.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenTravelModeTransitTest()
    {
        var request = new DirectionsRequest
        {
            Key = "key",
            Origin = new LocationEx(new Address("address")),
            Destination = new LocationEx(new Address("address")),
            TravelMode = TravelMode.TRANSIT
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var mode = queryStringParameters.FirstOrDefault(x => x.Key == "mode");
        var modeExpected = request.TravelMode.ToString().ToLower();
        Assert.IsNotNull(mode);
        Assert.AreEqual(modeExpected, mode.Value);

        var transitMode = queryStringParameters.FirstOrDefault(x => x.Key == "transit_mode");
        var transitModeExpected = request.TransitMode.ToEnumString('|');
        Assert.IsNotNull(transitMode);
        Assert.AreEqual(transitModeExpected, transitMode.Value);

        var departureTime = queryStringParameters.FirstOrDefault(x => x.Key == "departure_time");
        const string DEPARTURE_TIME_EXPECTED = "now";
        Assert.IsNotNull(departureTime);
        Assert.AreEqual(DEPARTURE_TIME_EXPECTED, departureTime.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenTravelModeTransitAndDepartureTimeTest()
    {
        var request = new DirectionsRequest
        {
            Key = "key",
            Origin = new LocationEx(new Address("address")),
            Destination = new LocationEx(new Address("address")),
            TravelMode = TravelMode.TRANSIT,
            DepartureTime = DateTime.UtcNow.AddHours(1)
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var mode = queryStringParameters.FirstOrDefault(x => x.Key == "mode");
        var modeExpected = request.TravelMode.ToString().ToLower();
        Assert.IsNotNull(mode);
        Assert.AreEqual(modeExpected, mode.Value);

        var transitMode = queryStringParameters.FirstOrDefault(x => x.Key == "transit_mode");
        var transitModeExpected = request.TransitMode.ToEnumString('|');
        Assert.IsNotNull(transitMode);
        Assert.AreEqual(transitModeExpected, transitMode.Value);

        var departureTime = queryStringParameters.FirstOrDefault(x => x.Key == "departure_time");
        var departureTimeExpected = request.DepartureTime.GetValueOrDefault().DateTimeToUnixTimestamp().ToString(CultureInfo.InvariantCulture);
        Assert.IsNotNull(departureTime);
        Assert.AreEqual(departureTimeExpected, departureTime.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenTravelModeTransitAndArrivalTimeTest()
    {
        var request = new DirectionsRequest
        {
            Key = "key",
            Origin = new LocationEx(new Address("address")),
            Destination = new LocationEx(new Address("address")),
            TravelMode = TravelMode.TRANSIT,
            ArrivalTime = DateTime.UtcNow.AddHours(1)
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var mode = queryStringParameters.FirstOrDefault(x => x.Key == "mode");
        var modeExpected = request.TravelMode.ToString().ToLower();
        Assert.IsNotNull(mode);
        Assert.AreEqual(modeExpected, mode.Value);

        var transitMode = queryStringParameters.FirstOrDefault(x => x.Key == "transit_mode");
        var transitModeExpected = request.TransitMode.ToEnumString('|');
        Assert.IsNotNull(transitMode);
        Assert.AreEqual(transitModeExpected, transitMode.Value);

        var departureTime = queryStringParameters.FirstOrDefault(x => x.Key == "departure_time");
        Assert.IsNotNull(departureTime);
        Assert.IsNull(departureTime.Value);

        var arrivalTime = queryStringParameters.FirstOrDefault(x => x.Key == "arrival_time");
        var arrivalTimeExpected = request.ArrivalTime.GetValueOrDefault().DateTimeToUnixTimestamp().ToString(CultureInfo.InvariantCulture);
        Assert.IsNotNull(arrivalTime);
        Assert.AreEqual(arrivalTimeExpected, arrivalTime.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenTravelModeTransitAndTransitModeTest()
    {
        var request = new DirectionsRequest
        {
            Key = "key",
            Origin = new LocationEx(new Address("address")),
            Destination = new LocationEx(new Address("address")),
            TravelMode = TravelMode.TRANSIT,
            TransitMode = TransitMode.Subway | TransitMode.Rail
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var transitMode = queryStringParameters.FirstOrDefault(x => x.Key == "transit_mode");
        var transitModeExpected = request.TransitMode.ToEnumString('|');
        Assert.IsNotNull(transitMode);
        Assert.AreEqual(transitModeExpected, transitMode.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenTravelModeTransitAndTransitRoutingPreferenceTest()
    {
        var request = new DirectionsRequest
        {
            Key = "key",
            Origin = new LocationEx(new Address("address")),
            Destination = new LocationEx(new Address("address")),
            TravelMode = TravelMode.TRANSIT,
            TransitMode = TransitMode.Subway | TransitMode.Rail,
            TransitRoutingPreference = TransitRoutingPreference.Fewer_Transfers
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var transitRoutingPreference = queryStringParameters.FirstOrDefault(x => x.Key == "transit_routing_preference");
        var transitRoutingPreferenceExpected = request.TransitRoutingPreference.ToString().ToLower();
        Assert.IsNotNull(transitRoutingPreference);
        Assert.AreEqual(transitRoutingPreferenceExpected, transitRoutingPreference.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenWayPointsTest()
    {
        var request = new DirectionsRequest
        {
            Key = "key",
            Origin = new LocationEx(new Address("address")),
            Destination = new LocationEx(new Address("address")),
            WayPoints = new[]
            {
                new WayPoint(new LocationEx(new Address("waypoint_address")))
            }
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var wayPoints = queryStringParameters.FirstOrDefault(x => x.Key == "waypoints");
        var wayPointsExpected = string.Join("|", request.WayPoints.Select(x => x.ToString()));
        Assert.IsNotNull(wayPoints);
        Assert.AreEqual(wayPointsExpected, wayPoints.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenWayPointsAndOptimizedTest()
    {
        var request = new DirectionsRequest
        {
            Key = "key",
            Origin = new LocationEx(new Address("address")),
            Destination = new LocationEx(new Address("address")),
            WayPoints = new[]
            {
                new WayPoint(new LocationEx(new Address("waypoint_address")))
            },
            OptimizeWaypoints = true
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var wayPoints = queryStringParameters.FirstOrDefault(x => x.Key == "waypoints");
        var wayPointsExpected = string.Join("|", new[] { "optimize:true" }.Concat(request.WayPoints.Select(x => x.ToString())));
        Assert.IsNotNull(wayPoints);
        Assert.AreEqual(wayPointsExpected, wayPoints.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new DirectionsRequest
        {
            Key = null
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual("'Key' is required", exception.Message);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsEmptyTest()
    {
        var request = new DirectionsRequest
        {
            Key = string.Empty
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual("'Key' is required", exception.Message);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenOriginIsNullTest()
    {
        var request = new DirectionsRequest
        {
            Key = "key",
            Destination = new LocationEx(new Address("address"))
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual("'Origin' is required", exception.Message);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenDestinationIsNullTest()
    {
        var request = new DirectionsRequest
        {
            Key = "key",
            Origin = new LocationEx(new Address("address"))
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual("'Destination' is required", exception.Message);
    }
}