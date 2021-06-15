using System;
using System.Threading;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using NUnit.Framework;
using Location = GoogleApi.Entities.Maps.DistanceMatrix.Request.Location;
using Coordinate = GoogleApi.Entities.Maps.DistanceMatrix.Request.Coordinate;

namespace GoogleApi.Test.Maps.DistanceMatrix
{
    [TestFixture]
    public class DistanceMatrixTests : BaseTest
    {
        [Test]
        public void DistanceMatrixTest()
        {
            var origin1 = new Address("285 Bedford Ave, Brooklyn, NY, USA");
            var origin2 = new Address("1 Broadway Ave, Manhattan, NY, USA");
            var destination1 = new Address("185 Broadway Ave, Manhattan, NY, USA");
            var destination2 = new Address("200 Bedford Ave, Brooklyn, NY, USA");

            var request = new DistanceMatrixRequest
            {
                Key = this.ApiKey,
                Origins = new[]
                {
                    new Location(origin1),
                    new Location(origin2)
                },
                Destinations = new[]
                {
                    new Location(destination1),
                    new Location(destination2)
                }
            };

            var result = GoogleMaps.DistanceMatrix.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void DistanceMatrixWhenAddressTest()
        {
            var origin = new Address("285 Bedford Ave, Brooklyn, NY, USA");
            var destination = new Address("185 Broadway Ave, Manhattan, NY, USA");

            var request = new DistanceMatrixRequest
            {
                Key = this.ApiKey,
                Origins = new[]
                {
                    new Location(origin)
                },
                Destinations = new[]
                {
                    new Location(destination)
                }
            };

            var result = GoogleMaps.DistanceMatrix.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void DistanceMatrixWhenCoordinateTest()
        {
            var origin = new Coordinate(55.7237480, 12.4208282);
            var destination = new Coordinate(55.72672682, 12.407996582);
            var request = new DistanceMatrixRequest
            {
                Key = this.ApiKey,
                Origins = new[]
                {
                    new Location(origin)
                },
                Destinations = new[]
                {
                    new Location(destination)
                }
            };

            var result = GoogleMaps.DistanceMatrix.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void DistanceMatrixWhenCoordinateAndHeadingTest()
        {
            var origin = new Coordinate(55.7237480, 12.4208282)
            {
                Heading = 90
            };
            var destination = new Coordinate(55.72672682, 12.407996582)
            {
                Heading = 90
            };
            var request = new DistanceMatrixRequest
            {
                Key = this.ApiKey,
                Origins = new[]
                {
                    new Location(origin)
                },
                Destinations = new[]
                {
                    new Location(destination)
                }
            };

            var result = GoogleMaps.DistanceMatrix.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void DistanceMatrixWhenCoordinateAndUseSideOfRoadTest()
        {
            var origin = new Coordinate(55.7237480, 12.4208282)
            {
                UseSideOfRoad = true
            };
            var destination = new Coordinate(55.72672682, 12.407996582)
            {
                UseSideOfRoad = true
            };
            var request = new DistanceMatrixRequest
            {
                Key = this.ApiKey,
                Origins = new[]
                {
                    new Location(origin)
                },
                Destinations = new[]
                {
                    new Location(destination)
                }
            };

            var result = GoogleMaps.DistanceMatrix.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void DistanceMatrixWhenPlaceIdTest()
        {
            var origin = new Place("ChIJaSLMpEVQUkYRL4xNOWBfwhQ");
            var destination = new Place("ChIJuc03_GlQUkYRlLku0KsLdJw");
            var request = new DistanceMatrixRequest
            {
                Key = this.ApiKey,
                Origins = new[]
                {
                    new Location(origin)
                },
                Destinations = new[]
                {
                    new Location(destination)
                }
            };

            var result = GoogleMaps.DistanceMatrix.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void DistanceMatrixWhenAvoidWayTest()
        {
            var origin = new Address("285 Bedford Ave, Brooklyn, NY, USA");
            var destination = new Address("185 Broadway Ave, Manhattan, NY, USA");
            var request = new DistanceMatrixRequest
            {
                Key = this.ApiKey,
                Origins = new[]
                {
                    new Location(origin)
                },
                Destinations = new[]
                {
                    new Location(destination)
                },
                Avoid = AvoidWay.Highways
            };

            var result = GoogleMaps.DistanceMatrix.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void DistanceMatrixWhenTravelModeDrivingAndDepartureTimeTest()
        {
            var origin = new Address("285 Bedford Ave, Brooklyn, NY, USA");
            var destination = new Address("185 Broadway Ave, Manhattan, NY, USA");
            var request = new DistanceMatrixRequest
            {
                Key = this.ApiKey,
                Origins = new[]
                {
                    new Location(origin)
                },
                Destinations = new[]
                {
                    new Location(destination)
                },
                TravelMode = TravelMode.Driving,
                DepartureTime = DateTime.UtcNow.AddHours(1)
            };

            var result = GoogleMaps.DistanceMatrix.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void DistanceMatrixWhenTravelModeTransitAndArrivalTimeTest()
        {
            var origin = new Address("285 Bedford Ave, Brooklyn, NY, USA");
            var destination = new Address("185 Broadway Ave, Manhattan, NY, USA");
            var request = new DistanceMatrixRequest
            {
                Key = this.ApiKey,
                Origins = new[]
                {
                    new Location(origin)
                },
                Destinations = new[]
                {
                    new Location(destination)
                },
                TravelMode = TravelMode.Driving,
                ArrivalTime = DateTime.UtcNow.AddHours(1),
                TransitRoutingPreference = TransitRoutingPreference.Fewer_Transfers
            };

            var result = GoogleMaps.DistanceMatrix.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void DistanceMatrixWhenAsyncTest()
        {
            var origin = new Address("285 Bedford Ave, Brooklyn, NY, USA");
            var destination = new Address("185 Broadway Ave, Manhattan, NY, USA");
            var request = new DistanceMatrixRequest
            {
                Key = this.ApiKey,
                Origins = new[]
                {
                    new Location(origin)
                },
                Destinations = new[]
                {
                    new Location(destination)
                }
            };

            var result = GoogleMaps.DistanceMatrix.QueryAsync(request).Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void DistanceMatrixWhenAsyncAndCancelledTest()
        {
            var origin = new Address("285 Bedford Ave, Brooklyn, NY, USA");
            var destination = new Address("185 Broadway Ave, Manhattan, NY, USA");
            var request = new DistanceMatrixRequest
            {
                Key = this.ApiKey,
                Origins = new[]
                {
                    new Location(origin)
                },
                Destinations = new[]
                {
                    new Location(destination)
                }
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.DistanceMatrix.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }
    }
}