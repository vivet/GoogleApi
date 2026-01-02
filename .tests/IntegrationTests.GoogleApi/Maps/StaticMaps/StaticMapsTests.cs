using System.Collections.Generic;
using System.Threading.Tasks;
using GoogleApi;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.StaticMaps.Request;
using GoogleApi.Entities.Maps.StaticMaps.Request.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests.GoogleApi.Maps.StaticMaps;

[TestClass]
public class StaticMapsTests : BaseTest
{
    [TestMethod]
    public async Task StaticMapsTest()
    {
        var request = new StaticMapsRequest
        {
            Key = this.Settings.ApiKey,
            Center = new Location(new Coordinate(60.170877, 24.942796)),
            ZoomLevel = 1
        };

        var result = await GoogleMaps.StaticMaps.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [TestMethod]
    public async Task StaticMapsWhenRegionTest()
    {
        var request = new StaticMapsRequest
        {
            Key = this.Settings.ApiKey,
            Center = new Location(new Coordinate(60.170877, 24.942796)),
            ZoomLevel = 1,
            Region = "us"
        };

        var result = await GoogleMaps.StaticMaps.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [TestMethod]
    public async Task StaticMapsWhenPathsTest()
    {
        var request = new StaticMapsRequest
        {
            Key = this.Settings.ApiKey,
            Paths = new List<MapPath>
            {
                new()
                {
                    Weight = 10,
                    Geodesic = false,
                    Color = "color1",
                    FillColor = "fillcolor1",
                    Points = new List<Location>
                    {
                        new(new Coordinate(60.170877, 24.942796)),
                        new(new Coordinate(60.180877, 24.952796))
                    }
                },
                new()
                {
                    Weight = 11,
                    Geodesic = true,
                    Color = "color1",
                    FillColor = "fillcolor2",
                    Points = new List<Location>
                    {
                        new(new Coordinate(60.170877, 24.942796)),
                        new(new Coordinate(60.180877, 24.952796))
                    }
                }
            }
        };

        var result = await GoogleMaps.StaticMaps.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [TestMethod]
    public async Task StaticMapsWhenPathsAsEncodedPolylineTest()
    {
        var request = new StaticMapsRequest
        {
            Key = this.Settings.ApiKey,
            Paths = new List<MapPath>
            {
                new()
                {
                    Weight = 10,
                    Geodesic = false,
                    Color = "color1",
                    FillColor = "fillcolor1",
                    EncodedPoints = GoogleFunctions.EncodePolyLine(new List<Coordinate>
                    {
                        new(60.170877, 24.942796),
                        new(60.180877, 24.952796)
                    })
                },
                new()
                {
                    Weight = 11,
                    Geodesic = true,
                    Color = "color1",
                    FillColor = "fillcolor2",
                    Points = new List<Location>
                    {
                        new(new Coordinate(60.170877, 24.942796)),
                        new(new Coordinate(60.180877, 24.952796))
                    }
                }
            }
        };

        var result = await GoogleMaps.StaticMaps.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [TestMethod]
    public async Task StaticMapsWhenStylesTest()
    {
        var request = new StaticMapsRequest
        {
            Key = this.Settings.ApiKey,
            Center = new Location(new Coordinate(60.170877, 24.942796)),
            ZoomLevel = 1,
            Styles = new List<MapStyle>
            {
                new()
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
                new()
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

        var result = await GoogleMaps.StaticMaps.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [TestMethod]
    public async Task StaticMapsWhenVisiblesTest()
    {
        var request = new StaticMapsRequest
        {
            Key = this.Settings.ApiKey,
            Visibles =
            [
                new Location(new Coordinate(60.170877, 24.942796)),
                new Location(new Coordinate(60.180877, 24.952796))
            ]
        };

        var result = await GoogleMaps.StaticMaps.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [TestMethod]
    public async Task StaticMapsWhenMarkersTest()
    {
        var request = new StaticMapsRequest
        {
            Key = this.Settings.ApiKey,
            Markers =
            [
                new MapMarker
                {
                    Label = "label1",
                    Size = MarkerSize.Normal,
                    Color = "color2",
                    Icon = new MapMarkerIcon("url1"),
                    Locations =
                    [
                        new Location(new Coordinate(60.170877, 24.942796))
                    ]
                },
                new MapMarker
                {
                    Label = "label2",
                    Size = MarkerSize.Mid,
                    Color = "color2",
                    Icon = new MapMarkerIcon("url2"),
                    Locations =
                    [
                        new Location(new Coordinate(60.180877, 24.952796))
                    ]
                }
            ]
        };

        var result = await GoogleMaps.StaticMaps.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }
}