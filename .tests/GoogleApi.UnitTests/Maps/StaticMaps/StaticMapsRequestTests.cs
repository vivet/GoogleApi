using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
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

            Assert.AreEqual(640, request.Size.Width);
            Assert.AreEqual(640, request.Size.Height);
            Assert.AreEqual(MapType.Roadmap, request.Type);
            Assert.AreEqual(ImageFormat.Png, request.Format);
            Assert.AreEqual(Language.English, request.Language);
        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new StaticMapsRequest
            {
                Key = "key",
                Center = new Location(new Coordinate(1, 1)),
                ZoomLevel = 1
            };

            var queryStringParameters = request.GetQueryStringParameters();
            Assert.IsNotNull(queryStringParameters);

            var key = queryStringParameters.FirstOrDefault(x => x.Key == "key");
            var keyExpected = request.Key;
            Assert.IsNotNull(key);
            Assert.AreEqual(keyExpected, key.Value);

            var size = queryStringParameters.FirstOrDefault(x => x.Key == "size");
            var sizeExpected = request.Size.ToString();
            Assert.IsNotNull(size);
            Assert.AreEqual(sizeExpected, size.Value);

            var type = queryStringParameters.FirstOrDefault(x => x.Key == "maptype");
            var typeExpected = request.Type.ToString().ToLower();
            Assert.IsNotNull(type);
            Assert.AreEqual(typeExpected, type.Value);

            var scale = queryStringParameters.FirstOrDefault(x => x.Key == "scale");
            var scaleExpected = ((int)request.Scale).ToString();
            Assert.IsNotNull(scale);
            Assert.AreEqual(scaleExpected, scale.Value);

            var format = queryStringParameters.FirstOrDefault(x => x.Key == "format");
            var formatExpected = request.Format.GetParameterName();
            Assert.IsNotNull(format);
            Assert.AreEqual(formatExpected, format.Value);

            var center = queryStringParameters.FirstOrDefault(x => x.Key == "center");
            var centerExpected = request.Center.ToString();
            Assert.IsNotNull(center);
            Assert.AreEqual(centerExpected, center.Value);

            var zoom = queryStringParameters.FirstOrDefault(x => x.Key == "zoom");
            var zoomExpected = request.ZoomLevel.ToString();
            Assert.IsNotNull(zoom);
            Assert.AreEqual(zoomExpected, zoom.Value);
        }

        [Test]
        public void GetQueryStringParametersWhenCenterIsNullTest()
        {
            var request = new StaticMapsRequest
            {
                Key = "key",
                ZoomLevel = 1
            };

            var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
            Assert.AreEqual("Center is required, unless Markers, Paths or Visibles is defined", exception.Message);
        }

        [Test]
        public void GetQueryStringParametersWhenZoomLevelIsNullTest()
        {
            var request = new StaticMapsRequest
            {
                Key = "key",
                Center = new Location(new Coordinate(1, 1))
            };

            var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
            Assert.AreEqual("ZoomLevel is required, unless Markers, Paths or Visibles is defined", exception.Message);
        }

        [Test]
        public void GetQueryStringParametersWhenRegionTest()
        {
            var request = new StaticMapsRequest
            {
                Key = "key",
                Center = new Location(new Coordinate(1, 1)),
                ZoomLevel = 1,
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
        public void GetQueryStringParametersWhenPathsTest()
        {
            var request = new StaticMapsRequest
            {
                Key = "key",
                Center = new Location(new Coordinate(1, 1)),
                ZoomLevel = 1,
                Paths = new List<MapPath> 
                {
                    new MapPath
                    {
                        Weight = 10,
                        Geodesic = false,
                        Color = "color",
                        FillColor = "fillcolor",
                        Points = new List<Location>
                        {
                            new Location(new Coordinate(1, 1)),
                            new Location(new Coordinate(2, 2))
                        }
                    }
                }
            };

            var queryStringParameters = request.GetQueryStringParameters();
            Assert.IsNotNull(queryStringParameters);

            var path = queryStringParameters.FirstOrDefault(x => x.Key == "path");
            var pathExpected = request.Paths.First().ToString();
            Assert.IsNotNull(path);
            Assert.AreEqual(pathExpected, path.Value);
        }

        [Test]
        public void GetQueryStringParametersWhenPathsMultipleTest()
        {
            var request = new StaticMapsRequest
            {
                Key = "key",
                Center = new Location(new Coordinate(1, 1)),
                ZoomLevel = 1,
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
                            new Location(new Coordinate(1, 1)),
                            new Location(new Coordinate(2, 2))
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
                            new Location(new Coordinate(3, 3)),
                            new Location(new Coordinate(4, 4))
                        }
                    }
                }
            };

            var queryStringParameters = request.GetQueryStringParameters();
            Assert.IsNotNull(queryStringParameters);

            var path1 = queryStringParameters.FirstOrDefault(x => x.Key == "path");
            var pathExpected1 = request.Paths.First().ToString();
            Assert.IsNotNull(path1);
            Assert.AreEqual(pathExpected1, path1.Value);

            var path2 = queryStringParameters.LastOrDefault(x => x.Key == "path");
            var pathExpected2 = request.Paths.Last().ToString();
            Assert.IsNotNull(path2);
            Assert.AreEqual(pathExpected2, path2.Value);
        }

        [Test]
        public void GetQueryStringParametersWhenPathsWhenPointsIsEmptyTest()
        {
            var request = new StaticMapsRequest
            {
                Key = "key",
                Center = new Location(new Coordinate(1, 1)),
                ZoomLevel = 1,
                Paths = new List<MapPath>
                {
                    new MapPath
                    {
                        Color = "color"
                    }
                }
            };

            var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
            Assert.AreEqual("Paths must contain two or more locations", exception.Message);
        }

        [Test]
        public void GetQueryStringParametersWhenStylesTest()
        {
            var request = new StaticMapsRequest
            {
                Key = "key",
                Center = new Location(new Coordinate(1, 1)),
                ZoomLevel = 1,
                Styles = new List<MapStyle>
                {
                    new MapStyle
                    {
                        Feature = StyleFeature.Administrative_Country,
                        Element = StyleElement.Geometry_Fill,
                        Style = new StyleRule
                        {
                            Hue = "hue",
                            Lightness = 10,
                            Saturation = 10,
                            Gamma = 1,
                            InvertLightness = true,
                            Visibility = StyleVisibility.Simplified,
                            Color = "color",
                            Weight = 1
                        }
                    }
                }
            };

            var queryStringParameters = request.GetQueryStringParameters();
            Assert.IsNotNull(queryStringParameters);

            var style = queryStringParameters.FirstOrDefault(x => x.Key == "style");
            var styleExpected = request.Styles.First().ToString();
            Assert.IsNotNull(style);
            Assert.AreEqual(styleExpected, style.Value);
        }

        [Test]
        public void GetQueryStringParametersWhenStylesMultipleTest()
        {
            var request = new StaticMapsRequest
            {
                Key = "key",
                Center = new Location(new Coordinate(1, 1)),
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

            var queryStringParameters = request.GetQueryStringParameters();
            Assert.IsNotNull(queryStringParameters);

            var style1 = queryStringParameters.FirstOrDefault(x => x.Key == "style");
            var styleExpected1 = request.Styles.First().ToString();
            Assert.IsNotNull(style1);
            Assert.AreEqual(styleExpected1, style1.Value);

            var style2 = queryStringParameters.LastOrDefault(x => x.Key == "style");
            var styleExpected2 = request.Styles.Last().ToString();
            Assert.IsNotNull(style2);
            Assert.AreEqual(styleExpected2, style2.Value);
        }

        [Test]
        public void GetQueryStringParametersWhenVisiblesTest()
        {
            var request = new StaticMapsRequest
            {
                Key = "key",
                Center = new Location(new Coordinate(1, 1)),
                ZoomLevel = 1,
                Visibles = new[]
                {
                    new Location(new Coordinate(1, 1)) 
                }
            };

            var queryStringParameters = request.GetQueryStringParameters();
            Assert.IsNotNull(queryStringParameters);

            var visible = queryStringParameters.FirstOrDefault(x => x.Key == "visible");
            var visibleExpected = string.Join("|", request.Visibles.Select(x => x.ToString()));
            Assert.IsNotNull(visible);
            Assert.AreEqual(visibleExpected, visible.Value);
        }

        [Test]
        public void GetQueryStringParametersWhenVisiblesMultipleTest()
        {
            var request = new StaticMapsRequest
            {
                Key = "key",
                Center = new Location(new Coordinate(1, 1)),
                ZoomLevel = 1,
                Visibles = new[]
                {
                    new Location(new Coordinate(1, 1)),
                    new Location(new Coordinate(2, 2))
                }
            };

            var queryStringParameters = request.GetQueryStringParameters();
            Assert.IsNotNull(queryStringParameters);

            var visible = queryStringParameters.FirstOrDefault(x => x.Key == "visible");
            var visibleExpected = string.Join("|", request.Visibles.Select(x => x.ToString()));
            Assert.IsNotNull(visible);
            Assert.AreEqual(visibleExpected, visible.Value);
        }

        [Test]
        public void GetQueryStringParametersWhenMarkersTest()
        {
            var request = new StaticMapsRequest
            {
                Key = "key",
                Center = new Location(new Coordinate(1, 1)),
                ZoomLevel = 1,
                Markers = new[]
                {
                    new MapMarker
                    {
                        Label = "label",
                        Size = MarkerSize.Normal,
                        Color = "color",
                        Icon = new MapMarkerIcon("url"),
                        Locations = new[]
                        {
                            new Location(new Coordinate(1, 1))
                        }
                    }
                }
            };

            var queryStringParameters = request.GetQueryStringParameters();
            Assert.IsNotNull(queryStringParameters);

            var markers = queryStringParameters.FirstOrDefault(x => x.Key == "markers");
            var markersExpected = string.Join("|", request.Markers.Select(x => x.ToString()));
            Assert.IsNotNull(markers);
            Assert.AreEqual(markersExpected, markers.Value);
        }

        [Test]
        public void GetQueryStringParametersWhenMarkersMultipleTest()
        {
            var request = new StaticMapsRequest
            {
                Key = "key",
                Center = new Location(new Coordinate(1, 1)),
                ZoomLevel = 1,
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
                            new Location(new Coordinate(1, 1))
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
                            new Location(new Coordinate(2, 2))
                        }
                    }
                }
            };

            var queryStringParameters = request.GetQueryStringParameters();
            Assert.IsNotNull(queryStringParameters);

            var markers1 = queryStringParameters.FirstOrDefault(x => x.Key == "markers");
            var markersExpected1 = request.Markers.First().ToString();
            Assert.IsNotNull(markers1);
            Assert.AreEqual(markersExpected1, markers1.Value);

            var markers2 = queryStringParameters.LastOrDefault(x => x.Key == "markers");
            var markersExpected2 = request.Markers.Last().ToString();
            Assert.IsNotNull(markers2);
            Assert.AreEqual(markersExpected2, markers2.Value);
        }

        [Test]
        public void GetQueryStringParametersWhenMarkersAndLocationsIsEmptyTest()
        {
            var request = new StaticMapsRequest
            {
                Key = "key",
                Center = new Location(new Coordinate(1, 1)),
                ZoomLevel = 1,
                Markers = new[]
                {
                    new MapMarker
                    {
                        Label = "label"
                    }
                }
            };

            var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
            Assert.AreEqual("Markers must contain at least one location", exception.Message);
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new StaticMapsRequest
            {
                Key = null
            };

            var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
            Assert.AreEqual("'Key' is required", exception.Message);
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsEmptyTest()
        {
            var request = new StaticMapsRequest
            {
                Key = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
            Assert.AreEqual("'Key' is required", exception.Message);
        }
    }
}