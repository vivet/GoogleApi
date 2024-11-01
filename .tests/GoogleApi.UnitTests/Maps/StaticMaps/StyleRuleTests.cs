using System;
using GoogleApi.Entities.Maps.StaticMaps.Request;
using GoogleApi.Entities.Maps.StaticMaps.Request.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests.Maps.StaticMaps;

[TestClass]
public class StyleRuleTests
{
    [TestMethod]
    public void ToStringTest()
    {
        var styleRule = new StyleRule();

        var toString = styleRule.ToString();
        Assert.IsNull(toString);
    }

    [TestMethod]
    public void ToStringWhenHueTest()
    {
        var styleRule = new StyleRule
        {
            Hue = "hue"
        };

        var toString = styleRule.ToString();
        Assert.AreEqual($"hue:{styleRule.Hue}", toString);
    }

    [TestMethod]
    public void ToStringWhenLightnessTest()
    {
        var styleRule = new StyleRule
        {
            Lightness = 10
        };

        var toString = styleRule.ToString();
        Assert.AreEqual($"lightness:{styleRule.Lightness}", toString);
    }

    [TestMethod]
    public void ToStringWhenLightnessIsSmallerTest()
    {
        var styleRule = new StyleRule
        {
            Lightness = -101
        };

        var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(styleRule.ToString);

        Assert.IsNotNull(exception);
        Assert.IsTrue(exception.Message.Contains($"The {nameof(styleRule.Lightness)} must be between -100 and 100."));
    }

    [TestMethod]
    public void ToStringWhenLightnessIsHigherTest()
    {
        var styleRule = new StyleRule
        {
            Lightness = 101
        };

        var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(styleRule.ToString);

        Assert.IsNotNull(exception);
        Assert.IsTrue(exception.Message.Contains($"The {nameof(styleRule.Lightness)} must be between -100 and 100."));
    }

    [TestMethod]
    public void ToStringWhenSaturationTest()
    {
        var styleRule = new StyleRule
        {
            Saturation = 10
        };

        var toString = styleRule.ToString();
        Assert.AreEqual($"saturation:{styleRule.Saturation}", toString);
    }

    [TestMethod]
    public void ToStringWhenSaturationIsSmallerTest()
    {
        var styleRule = new StyleRule
        {
            Saturation = -101
        };

        var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(styleRule.ToString);

        Assert.IsNotNull(exception);
        Assert.IsTrue(exception.Message.Contains($"The {nameof(styleRule.Saturation)} must be between -100 and 100."));
    }

    [TestMethod]
    public void ToStringWhenSaturationIsHigherTest()
    {
        var styleRule = new StyleRule
        {
            Saturation = 101
        };

        var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(styleRule.ToString);

        Assert.IsNotNull(exception);
        Assert.IsTrue(exception.Message.Contains($"The {nameof(styleRule.Saturation)} must be between -100 and 100."));
    }

    [TestMethod]
    public void ToStringWhenGammaTest()
    {
        var styleRule = new StyleRule
        {
            Gamma = 1
        };

        var toString = styleRule.ToString();
        Assert.AreEqual($"gamma:{styleRule.Gamma}", toString);
    }

    [TestMethod]
    public void ToStringWhenGammaIsSmallerTest()
    {
        var styleRule = new StyleRule
        {
            Gamma = 0
        };

        var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(styleRule.ToString);

        Assert.IsNotNull(exception);
        Assert.IsTrue(exception.Message.Contains($"The {nameof(styleRule.Gamma)} must be between 0.01 and 10.00"));
    }

    [TestMethod]
    public void ToStringWhenGammaIsHigherTest()
    {
        var styleRule = new StyleRule
        {
            Gamma = 101
        };

        var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(styleRule.ToString);

        Assert.IsNotNull(exception);
        Assert.IsTrue(exception.Message.Contains($"The {nameof(styleRule.Gamma)} must be between 0.01 and 10.00"));
    }

    [TestMethod]
    public void ToStringWhenInvertLightnessTest()
    {
        var styleRule = new StyleRule
        {
            InvertLightness = true
        };

        var toString = styleRule.ToString();
        Assert.AreEqual("invert_lightness:true", toString);
    }

    [TestMethod]
    public void ToStringWhenVisibilityTest()
    {
        var styleRule = new StyleRule
        {
            Visibility = StyleVisibility.Simplified
        };

        var toString = styleRule.ToString();
        Assert.AreEqual($"visibility:{styleRule.Visibility.ToString().ToLower()}", toString);
    }

    [TestMethod]
    public void ToStringWhenColorTest()
    {
        var styleRule = new StyleRule
        {
            Color = "color"
        };

        var toString = styleRule.ToString();
        Assert.AreEqual($"color:{styleRule.Color}", toString);
    }

    [TestMethod]
    public void ToStringWhenWeightTest()
    {
        var styleRule = new StyleRule
        {
            Weight = 1
        };

        var toString = styleRule.ToString();
        Assert.AreEqual($"weight:{styleRule.Weight}", toString);
    }

    [TestMethod]
    public void ToStringWhenAllStylesTest()
    {
        var styleRule = new StyleRule
        {
            Hue = "hue",
            Lightness = 10,
            Saturation = 10,
            Gamma = 1,
            InvertLightness = true,
            Visibility = StyleVisibility.Simplified,
            Color = "color",
            Weight = 1
        };

        var toString = styleRule.ToString();
        Assert.AreEqual($"hue:{styleRule.Hue}|lightness:{styleRule.Lightness}|saturation:{styleRule.Saturation}|gamma:{styleRule.Gamma}|invert_lightness:true|visibility:{styleRule.Visibility.ToString().ToLower()}|color:{styleRule.Color}|weight:{styleRule.Weight}", toString);
    }
}