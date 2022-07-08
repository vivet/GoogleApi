using System;
using GoogleApi.Entities.Maps.Common;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.Common;

[TestFixture]
public class MapSizeTests
{
    [Test]
    public void ConstructorTest()
    {
        var mapSize = new MapSize(1, 1);

        Assert.AreEqual(1, mapSize.Width);
        Assert.AreEqual(1, mapSize.Height);
    }

    [Test]
    public void ConstructorWhenWidthIsLowerTest()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var size = new MapSize(0, 1);
            Assert.IsNotNull(size);
        });

        Assert.IsNotNull(exception);
        Assert.True(exception.Message.Contains("'width' must be greater than 1 and less than 4096."));
    }

    [Test]
    public void ConstructorWhenWidthIsHigherTest()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var size = new MapSize(4097, 1);
            Assert.IsNotNull(size);
        });

        Assert.IsNotNull(exception);
        Assert.True(exception.Message.Contains("'width' must be greater than 1 and less than 4096."));
    }

    [Test]
    public void ConstructorWhenHeightIsLowerTest()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var size = new MapSize(1, 0);
            Assert.IsNotNull(size);
        });

        Assert.IsNotNull(exception);
        Assert.True(exception.Message.Contains("'height' must be greater than 1 and less than 4096."));
    }

    [Test]
    public void ConstructorWhenHeightIsHigherTest()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var size = new MapSize(1, 4097);
            Assert.IsNotNull(size);
        });

        Assert.IsNotNull(exception);
        Assert.True(exception.Message.Contains("'height' must be greater than 1 and less than 4096."));
    }

    [Test]
    public void ToStringTest()
    {
        var mapSize = new MapSize(1, 1);

        var toString = mapSize.ToString();
        Assert.AreEqual($"{mapSize.Width}x{mapSize.Height}", toString);
    }
}