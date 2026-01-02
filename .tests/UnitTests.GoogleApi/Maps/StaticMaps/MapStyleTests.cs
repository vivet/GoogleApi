using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Maps.StaticMaps.Request;
using GoogleApi.Entities.Maps.StaticMaps.Request.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.GoogleApi.Maps.StaticMaps;

[TestClass]
public class MapStyleTests
{
    [TestMethod]
    public void ToStringTest()
    {
        var mapStyle = new MapStyle();

        var toString = mapStyle.ToString();
        Assert.IsNull(toString);
    }

    [TestMethod]
    public void ToStringWhenStyleIsNotNullTest()
    {
        var mapStyle = new MapStyle
        {
            Feature = StyleFeature.Administrative,
            Element = StyleElement.Geometry,
            Style = new StyleRule
            {
                Color = "color"
            }
        };

        var toString = mapStyle.ToString();
        Assert.AreEqual($"feature:{mapStyle.Feature.ToEnumMemberString()}|element:{mapStyle.Element.ToEnumMemberString()}|{mapStyle.Style}", toString);
    }

    [TestMethod]
    public void ToStringWhenStyleIsNotNullAndComplexTest()
    {
        var mapStyle = new MapStyle
        {
            Feature = StyleFeature.Administrative_Land_Parcel,
            Element = StyleElement.Labels_Text_Stroke,
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
        };

        var toString = mapStyle.ToString();
        Assert.AreEqual($"feature:{mapStyle.Feature.ToEnumMemberString()}|element:{mapStyle.Element.ToEnumMemberString()}|{mapStyle.Style}", toString);
    }
}