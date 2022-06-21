using System;
using System.Globalization;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.DistanceMatrix;

[TestFixture]
public class DistanceMatrixRequestTests
{
    [Test]
    public void ConstructorDefaultTest()
    {
        var request = new DistanceMatrixRequest();

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
    public void GetQueryStringParametersTest()
    {
        var request = new DistanceMatrixRequest
        {
            Key = "key",
            Origins = new[]
            {
                new LocationEx(new Address("address1")),
                new LocationEx(new Address("address2"))
            },
            Destinations = new[]
            {
                new LocationEx(new Address("address1")),
                new LocationEx(new Address("address2"))
            }
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var key = queryStringParameters.FirstOrDefault(x => x.Key == "key");
        var keyExpected = request.Key;
        Assert.IsNotNull(key);
        Assert.AreEqual(keyExpected, key.Value);

        var origin = queryStringParameters.FirstOrDefault(x => x.Key == "origins");
        var originExpected = string.Join("|", request.Origins.Select(x => x.ToString()));
        Assert.IsNotNull(origin);
        Assert.AreEqual(originExpected, origin.Value);

        var destination = queryStringParameters.FirstOrDefault(x => x.Key == "destinations");
        var destinationExpected = string.Join("|", request.Destinations.Select(x => x.ToString()));
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

    [Test]
    public void GetQueryStringParametersWhenChannelTest()
    {
        var request = new DistanceMatrixRequest
        {
            Key = "key",
            Origins = new[]
            {
                new LocationEx(new Address("address"))
            },
            Destinations = new[]
            {
                new LocationEx(new Address("address"))
            },
            Channel = "channel"
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var channel = queryStringParameters.FirstOrDefault(x => x.Key == "channel");
        var channelExpected = request.Channel;
        Assert.IsNotNull(channel);
        Assert.AreEqual(channelExpected, channel.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenLanguageTest()
    {
        var request = new DistanceMatrixRequest
        {
            Key = "key",
            Origins = new[]
            {
                new LocationEx(new Address("address"))
            },
            Destinations = new[]
            {
                new LocationEx(new Address("address"))
            },
            Language = Language.Afrikaans
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var language = queryStringParameters.FirstOrDefault(x => x.Key == "language");
        var languageExpected = request.Language.ToCode();
        Assert.IsNotNull(language);
        Assert.AreEqual(languageExpected, language.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenUnitsTest()
    {
        var request = new DistanceMatrixRequest
        {
            Key = "key",
            Origins = new[]
            {
                new LocationEx(new Address("address"))
            },
            Destinations = new[]
            {
                new LocationEx(new Address("address"))
            },
            Units = Units.Imperial
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var units = queryStringParameters.FirstOrDefault(x => x.Key == "units");
        var unitsExpected = request.Units.ToString().ToLower();
        Assert.IsNotNull(units);
        Assert.AreEqual(unitsExpected, units.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenRegionTest()
    {
        var request = new DistanceMatrixRequest
        {
            Key = "key",
            Origins = new[]
            {
                new LocationEx(new Address("address"))
            },
            Destinations = new[]
            {
                new LocationEx(new Address("address"))
            },
            Region = "region"
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var region = queryStringParameters.FirstOrDefault(x => x.Key == "region");
        var regionExpected = request.Region;
        Assert.IsNotNull(region);
        Assert.AreEqual(regionExpected, region.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenAvoidTest()
    {
        var request = new DistanceMatrixRequest
        {
            Key = "key",
            Origins = new[]
            {
                new LocationEx(new Address("address"))
            },
            Destinations = new[]
            {
                new LocationEx(new Address("address"))
            },
            Avoid = AvoidWay.Highways | AvoidWay.Ferries
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var avoid = queryStringParameters.FirstOrDefault(x => x.Key == "avoid");
        var avoidExpected = request.Avoid.ToEnumString('|');
        Assert.IsNotNull(avoid);
        Assert.AreEqual(avoidExpected, avoid.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenTravelModeTest()
    {
        var request = new DistanceMatrixRequest
        {
            Key = "key",
            Origins = new[]
            {
                new LocationEx(new Address("address"))
            },
            Destinations = new[]
            {
                new LocationEx(new Address("address"))
            },
            TravelMode = TravelMode.Bicycling
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var mode = queryStringParameters.FirstOrDefault(x => x.Key == "mode");
        var modeExpected = request.TravelMode.ToString().ToLower();
        Assert.IsNotNull(mode);
        Assert.AreEqual(modeExpected, mode.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenTravelModeDrivingAndDepartureTimeTest()
    {
        var request = new DistanceMatrixRequest
        {
            Key = "key",
            Origins = new[]
            {
                new LocationEx(new Address("address"))
            },
            Destinations = new[]
            {
                new LocationEx(new Address("address"))
            },
            TravelMode = TravelMode.Driving,
            DepartureTime = DateTime.UtcNow.AddHours(1)
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var departureTime = queryStringParameters.FirstOrDefault(x => x.Key == "departure_time");
        var departureTimeExpected = request.DepartureTime.GetValueOrDefault().DateTimeToUnixTimestamp().ToString(CultureInfo.InvariantCulture);
        Assert.IsNotNull(departureTime);
        Assert.AreEqual(departureTimeExpected, departureTime.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenTravelModeDrivingAndDepartureTimeAndTrafficModelTest()
    {
        var request = new DistanceMatrixRequest
        {
            Key = "key",
            Origins = new[]
            {
                new LocationEx(new Address("address"))
            },
            Destinations = new[]
            {
                new LocationEx(new Address("address"))
            },
            TravelMode = TravelMode.Driving,
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

    [Test]
    public void GetQueryStringParametersWhenTravelModeTransitTest()
    {
        var request = new DistanceMatrixRequest
        {
            Key = "key",
            Origins = new[]
            {
                new LocationEx(new Address("address"))
            },
            Destinations = new[]
            {
                new LocationEx(new Address("address"))
            },
            TravelMode = TravelMode.Transit
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

    [Test]
    public void GetQueryStringParametersWhenTravelModeTransitAndDepartureTimeTest()
    {
        var request = new DistanceMatrixRequest
        {
            Key = "key",
            Origins = new[]
            {
                new LocationEx(new Address("address"))
            },
            Destinations = new[]
            {
                new LocationEx(new Address("address"))
            },
            TravelMode = TravelMode.Transit,
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

    [Test]
    public void GetQueryStringParametersWhenTravelModeTransitAndArrivalTimeTest()
    {
        var request = new DistanceMatrixRequest
        {
            Key = "key",
            Origins = new[]
            {
                new LocationEx(new Address("address"))
            },
            Destinations = new[]
            {
                new LocationEx(new Address("address"))
            },
            TravelMode = TravelMode.Transit,
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

    [Test]
    public void GetQueryStringParametersWhenTravelModeTransitAndTransitModeTest()
    {
        var request = new DistanceMatrixRequest
        {
            Key = "key",
            Origins = new[]
            {
                new LocationEx(new Address("address"))
            },
            Destinations = new[]
            {
                new LocationEx(new Address("address"))
            },
            TravelMode = TravelMode.Transit,
            TransitMode = TransitMode.Subway | TransitMode.Rail
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var transitMode = queryStringParameters.FirstOrDefault(x => x.Key == "transit_mode");
        var transitModeExpected = request.TransitMode.ToEnumString('|');
        Assert.IsNotNull(transitMode);
        Assert.AreEqual(transitModeExpected, transitMode.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenTravelModeTransitAndTransitRoutingPreferenceTest()
    {
        var request = new DistanceMatrixRequest
        {
            Key = "key",
            Origins = new[]
            {
                new LocationEx(new Address("address"))
            },
            Destinations = new[]
            {
                new LocationEx(new Address("address"))
            },
            TravelMode = TravelMode.Transit,
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

    [Test]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new DistanceMatrixRequest
        {
            Key = null
        };

        var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
        Assert.IsNotNull(exception);
        Assert.AreEqual("'Key' is required", exception.Message);
    }

    [Test]
    public void GetQueryStringParametersWhenKeyIsEmptyTest()
    {
        var request = new DistanceMatrixRequest
        {
            Key = string.Empty
        };

        var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
        Assert.IsNotNull(exception);
        Assert.AreEqual("'Key' is required", exception.Message);
    }

    [Test]
    public void GetQueryStringParametersWhenOriginIsNullTest()
    {
        var request = new DistanceMatrixRequest
        {
            Key = "key",
            Destinations = new []
            {
                new LocationEx(new Address("address"))
            }
        };

        var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
        Assert.IsNotNull(exception);
        Assert.AreEqual("'Origins' is required", exception.Message);
    }

    [Test]
    public void GetQueryStringParametersWhenDestinationIsNullTest()
    {
        var request = new DistanceMatrixRequest
        {
            Key = "key",
            Origins = new []
            {
                new LocationEx(new Address("address"))
            }
        };

        var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
        Assert.IsNotNull(exception);
        Assert.AreEqual("'Destinations' is required", exception.Message);
    }
}