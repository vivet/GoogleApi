using GoogleApi.Entities.Maps.StaticMaps.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.GoogleApi.Maps.StaticMaps;

[TestClass]
public class AnchorCoordinateTests
{
    [TestMethod]
    public void ConstructorTest()
    {
        var anchorCoordinate = new AnchorCoordinate(1, 1);

        Assert.AreEqual(1, anchorCoordinate.X);
        Assert.AreEqual(1, anchorCoordinate.Y);
    }

    [TestMethod]
    public void ToStringTest()
    {
        var anchorCoordinate = new AnchorCoordinate(1, 1);

        var toString = anchorCoordinate.ToString();
        Assert.AreEqual($"{anchorCoordinate.X},{anchorCoordinate.Y}", toString);
    }
}