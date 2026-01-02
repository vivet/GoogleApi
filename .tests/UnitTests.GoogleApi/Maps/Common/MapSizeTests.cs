using System;
using GoogleApi.Entities.Maps.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.GoogleApi.Maps.Common;

[TestClass]
public class MapSizeTests
{
    [TestMethod]
    public void ConstructorTest()
    {
        var mapSize = new MapSize(1, 1);

        Assert.AreEqual(1, mapSize.Width);
        Assert.AreEqual(1, mapSize.Height);
    }

    [TestMethod]
    public void ConstructorWhenWidthIsLowerTest()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new MapSize(0, 1));

        Assert.IsNotNull(exception);
        Assert.IsTrue(exception.Message.Contains("'width' must be greater than 1 and less than 4096."));
    }

    [TestMethod]
    public void ConstructorWhenWidthIsHigherTest()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new MapSize(4097, 1));

        Assert.IsNotNull(exception);
        Assert.IsTrue(exception.Message.Contains("'width' must be greater than 1 and less than 4096."));
    }

    [TestMethod]
    public void ConstructorWhenHeightIsLowerTest()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new MapSize(1, 0));
        
        Assert.IsNotNull(exception);
        Assert.IsTrue(exception.Message.Contains("'height' must be greater than 1 and less than 4096."));
    }

    [TestMethod]
    public void ConstructorWhenHeightIsHigherTest()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new MapSize(1, 4097));

        Assert.IsNotNull(exception);
        Assert.IsTrue(exception.Message.Contains("'height' must be greater than 1 and less than 4096."));
    }

    [TestMethod]
    public void ToStringTest()
    {
        var mapSize = new MapSize(1, 1);

        var toString = mapSize.ToString();
        Assert.AreEqual($"{mapSize.Width}x{mapSize.Height}", toString);
    }
}