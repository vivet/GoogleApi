using System;
using GoogleApi.Entities.Maps.StaticMaps.Request;
using GoogleApi.Entities.Maps.StaticMaps.Request.Enums;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.StaticMaps;

[TestFixture]
public class StyleRuleTests
{
    [Test]
    public void ToStringTest()
    {
        var styleRule = new StyleRule();

        var toString = styleRule.ToString();
        Assert.IsNull(toString);
    }

    [Test]
    public void ToStringWhenHueTest()
    {
        var styleRule = new StyleRule
        {
            Hue = "hue"
        };

        var toString = styleRule.ToString();
        Assert.AreEqual($"hue:{styleRule.Hue}", toString);
    }

    [Test]
    public void ToStringWhenLightnessTest()
    {
        var styleRule = new StyleRule
        {
            Lightness = 10
        };

        var toString = styleRule.ToString();
        Assert.AreEqual($"lightness:{styleRule.Lightness}", toString);
    }

    [Test]
    public void ToStringWhenLightnessIsSmallerTest()
    {
        var styleRule = new StyleRule
        {
            Lightness = -101
        };

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var toString = styleRule.ToString();
            Assert.IsNull(toString);
        });
        Assert.IsNotNull(exception);

#if NETCOREAPP3_1_OR_GREATER
            Assert.AreEqual($"The {nameof(styleRule.Lightness)} must be between -100 and 100. (Parameter '{nameof(styleRule.Lightness)}')\r\nActual value was {styleRule.Lightness}.", exception.Message);
#else
        Assert.AreEqual($"The {nameof(styleRule.Lightness)} must be between -100 and 100.\r\nParameter name: {nameof(styleRule.Lightness)}\r\nActual value was {styleRule.Lightness}.", exception.Message);
#endif
    }

    [Test]
    public void ToStringWhenLightnessIsHigherTest()
    {
        var styleRule = new StyleRule
        {
            Lightness = 101
        };

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var toString = styleRule.ToString();
            Assert.IsNull(toString);
        });

        Assert.IsNotNull(exception);

#if NETCOREAPP3_1_OR_GREATER
            Assert.AreEqual($"The {nameof(styleRule.Lightness)} must be between -100 and 100. (Parameter '{nameof(styleRule.Lightness)}')\r\nActual value was {styleRule.Lightness}.", exception.Message);
#else
        Assert.AreEqual($"The {nameof(styleRule.Lightness)} must be between -100 and 100.\r\nParameter name: {nameof(styleRule.Lightness)}\r\nActual value was {styleRule.Lightness}.", exception.Message);
#endif
    }

    [Test]
    public void ToStringWhenSaturationTest()
    {
        var styleRule = new StyleRule
        {
            Saturation = 10
        };

        var toString = styleRule.ToString();
        Assert.AreEqual($"saturation:{styleRule.Saturation}", toString);
    }

    [Test]
    public void ToStringWhenSaturationIsSmallerTest()
    {
        var styleRule = new StyleRule
        {
            Saturation = -101
        };

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var toString = styleRule.ToString();
            Assert.IsNull(toString);
        });

        Assert.IsNotNull(exception);

#if NETCOREAPP3_1_OR_GREATER
            Assert.AreEqual($"The {nameof(styleRule.Saturation)} must be between -100 and 100. (Parameter '{nameof(styleRule.Saturation)}')\r\nActual value was {styleRule.Saturation}.", exception.Message);
#else
        Assert.AreEqual($"The {nameof(styleRule.Saturation)} must be between -100 and 100.\r\nParameter name: {nameof(styleRule.Saturation)}\r\nActual value was {styleRule.Saturation}.", exception.Message);
#endif

    }

    [Test]
    public void ToStringWhenSaturationIsHigherTest()
    {
        var styleRule = new StyleRule
        {
            Saturation = 101
        };

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var toString = styleRule.ToString();
            Assert.IsNull(toString);
        });

        Assert.IsNotNull(exception);

#if NETCOREAPP3_1_OR_GREATER
            Assert.AreEqual($"The {nameof(styleRule.Saturation)} must be between -100 and 100. (Parameter '{nameof(styleRule.Saturation)}')\r\nActual value was {styleRule.Saturation}.", exception.Message);
#else
        Assert.AreEqual($"The {nameof(styleRule.Saturation)} must be between -100 and 100.\r\nParameter name: {nameof(styleRule.Saturation)}\r\nActual value was {styleRule.Saturation}.", exception.Message);
#endif
    }

    [Test]
    public void ToStringWhenGammaTest()
    {
        var styleRule = new StyleRule
        {
            Gamma = 1
        };

        var toString = styleRule.ToString();
        Assert.AreEqual($"gamma:{styleRule.Gamma}", toString);
    }

    [Test]
    public void ToStringWhenGammaIsSmallerTest()
    {
        var styleRule = new StyleRule
        {
            Gamma = 0
        };

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var toString = styleRule.ToString();
            Assert.IsNull(toString);
        });

        Assert.IsNotNull(exception);

#if NETCOREAPP3_1_OR_GREATER
            Assert.AreEqual($"The {nameof(styleRule.Gamma)} must be between 0.01 and 10.00. (Parameter '{nameof(styleRule.Gamma)}')\r\nActual value was {styleRule.Gamma}.", exception.Message);
#else
        Assert.AreEqual($"The {nameof(styleRule.Gamma)} must be between 0.01 and 10.00.\r\nParameter name: {nameof(styleRule.Gamma)}\r\nActual value was {styleRule.Gamma}.", exception.Message);
#endif
    }

    [Test]
    public void ToStringWhenGammaIsHigherTest()
    {
        var styleRule = new StyleRule
        {
            Gamma = 101
        };

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var toString = styleRule.ToString();
            Assert.IsNull(toString);
        });

        Assert.IsNotNull(exception);

#if NETCOREAPP3_1_OR_GREATER
            Assert.AreEqual($"The {nameof(styleRule.Gamma)} must be between 0.01 and 10.00. (Parameter '{nameof(styleRule.Gamma)}')\r\nActual value was {styleRule.Gamma}.", exception.Message);
#else
        Assert.AreEqual($"The {nameof(styleRule.Gamma)} must be between 0.01 and 10.00.\r\nParameter name: {nameof(styleRule.Gamma)}\r\nActual value was {styleRule.Gamma}.", exception.Message);
#endif
    }

    [Test]
    public void ToStringWhenInvertLightnessTest()
    {
        var styleRule = new StyleRule
        {
            InvertLightness = true
        };

        var toString = styleRule.ToString();
        Assert.AreEqual("invert_lightness:true", toString);
    }

    [Test]
    public void ToStringWhenVisibilityTest()
    {
        var styleRule = new StyleRule
        {
            Visibility = StyleVisibility.Simplified
        };

        var toString = styleRule.ToString();
        Assert.AreEqual($"visibility:{styleRule.Visibility.ToString().ToLower()}", toString);
    }

    [Test]
    public void ToStringWhenColorTest()
    {
        var styleRule = new StyleRule
        {
            Color = "color"
        };

        var toString = styleRule.ToString();
        Assert.AreEqual($"color:{styleRule.Color}", toString);
    }

    [Test]
    public void ToStringWhenWeightTest()
    {
        var styleRule = new StyleRule
        {
            Weight = 1
        };

        var toString = styleRule.ToString();
        Assert.AreEqual($"weight:{styleRule.Weight}", toString);
    }

    [Test]
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