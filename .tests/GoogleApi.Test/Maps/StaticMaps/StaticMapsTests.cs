using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.StaticMaps.Request;
using GoogleApi.Entities.Maps.StaticMaps.Request.Enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using Coordinate = GoogleApi.Entities.Common.Coordinate;

namespace GoogleApi.Test.Maps.StaticMaps
{
    [TestFixture]
    public class StaticMapsTests : BaseTest<GoogleMaps.StaticMapsApi>
    {
        protected override GoogleMaps.StaticMapsApi GetClient() => new(_httpClient);
        protected override GoogleMaps.StaticMapsApi GetClientStatic() => GoogleMaps.StaticMaps;

        [Test]
        public void StaticMapsTest()
        {
            var request = new StaticMapsRequest
            {
                Key = this.ApiKey,
                Center = new Location(new Coordinate(60.170877, 24.942796)),
                ZoomLevel = 1
            };

            var result = Sut.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void StaticMapsWhenRegionTest()
        {
            var request = new StaticMapsRequest
            {
                Key = this.ApiKey,
                Center = new Location(new Coordinate(60.170877, 24.942796)),
                ZoomLevel = 1,
                Region = "us"
            };

            var result = Sut.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void StaticMapsWhenPathsTest()
        {
            var request = new StaticMapsRequest
            {
                Key = this.ApiKey,
                Paths = new List<MapPath>
                {
                    new MapPath
                    {
                        Weight = 10,
                        Geodesic = false,
                        Color = "color1",
                        FillColor = "fillcolor1",
                        Points = new List<Location>
                        {
                            new Location(new Coordinate(60.170877, 24.942796)),
                            new Location(new Coordinate(60.180877, 24.952796))
                        }
                    },
                    new MapPath
                    {
                        Weight = 11,
                        Geodesic = true,
                        Color = "color1",
                        FillColor = "fillcolor2",
                        Points = new List<Location>
                        {
                            new Location(new Coordinate(60.170877, 24.942796)),
                            new Location(new Coordinate(60.180877, 24.952796))
                        }
                    }
                }
            };

            var result = Sut.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void StaticMapsWhenStylesTest()
        {
            var request = new StaticMapsRequest
            {
                Key = this.ApiKey,
                Center = new Location(new Coordinate(60.170877, 24.942796)),
                ZoomLevel = 1,
                Styles = new List<MapStyle>
                {
                    new MapStyle
                    {
                        Feature = StyleFeature.Administrative_Country,
                        Element = StyleElement.Geometry_Fill,
                        Style = new StyleRule
                        {
                            Hue = "hue1",
                            Lightness = 10,
                            Saturation = 10,
                            Gamma = 1,
                            InvertLightness = true,
                            Visibility = StyleVisibility.Simplified,
                            Color = "color1",
                            Weight = 1
                        }
                    },
                    new MapStyle
                    {
                        Feature = StyleFeature.Administrative_Country,
                        Element = StyleElement.Geometry_Fill,
                        Style = new StyleRule
                        {
                            Hue = "hue2",
                            Lightness = 11,
                            Saturation = 11,
                            Gamma = 2,
                            InvertLightness = false,
                            Visibility = StyleVisibility.On,
                            Color = "color2",
                            Weight = 2
                        }
                    }
                }
            };

            var result = Sut.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void StaticMapsWhenVisiblesTest()
        {
            var request = new StaticMapsRequest
            {
                Key = this.ApiKey,
                Visibles = new[]
                {
                    new Location(new Coordinate(60.170877, 24.942796)),
                    new Location(new Coordinate(60.180877, 24.952796))
                }
            };

            var result = Sut.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void StaticMapsWhenMarkersTest()
        {
            var request = new StaticMapsRequest
            {
                Key = this.ApiKey,
                Markers = new[]
                {
                    new MapMarker
                    {
                        Label = "label1",
                        Size = MarkerSize.Normal,
                        Color = "color2",
                        Icon = new MapMarkerIcon("url1"),
                        Locations = new[]
                        {
                            new Location(new Coordinate(60.170877, 24.942796))
                        }
                    },
                    new MapMarker
                    {
                        Label = "label2",
                        Size = MarkerSize.Mid,
                        Color = "color2",
                        Icon = new MapMarkerIcon("url2"),
                        Locations = new[]
                        {
                            new Location(new Coordinate(60.180877, 24.952796))
                        }
                    }
                }
            };

            var result = Sut.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void StaticMapsWhenAsyncTest()
        {
            var request = new StaticMapsRequest
            {
                Key = this.ApiKey,
                Center = new Location(new Coordinate(60.170877, 24.942796)),
                ZoomLevel = 1
            };
            var result = Sut.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void StaticMapsWhenAsyncAndCancelledTest()
        {
            var request = new StaticMapsRequest
            {
                Key = this.ApiKey,
                Center = new Location(new Coordinate(60.170877, 24.942796)),
                ZoomLevel = 1
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = Sut.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual("The operation was canceled.", exception.Message);
        }
    }
}