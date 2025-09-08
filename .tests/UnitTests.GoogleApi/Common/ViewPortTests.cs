using GoogleApi.Entities.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests.Common;

[TestClass]
public class ViewPortTests
{
    [TestMethod]
    public void ConstructorTest()
    {
        var southWest = new Coordinate(1, 1);
        var northEast = new Coordinate(2, 2);
        var viewPort = new ViewPort(southWest, northEast);

        Assert.AreEqual(northEast, viewPort.NorthEast);
        Assert.AreEqual(southWest, viewPort.SouthWest);
    }

    [TestMethod]
    public void ToStringTest()
    {
        var southWest = new Coordinate(1, 1);
        var northEast = new Coordinate(2, 2);
        var viewPort = new ViewPort(southWest, northEast);

        var toString = viewPort.ToString();
        Assert.AreEqual($"{southWest}|{northEast}", toString);
    }
}