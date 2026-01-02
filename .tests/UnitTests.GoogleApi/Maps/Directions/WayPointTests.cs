using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Directions.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.GoogleApi.Maps.Directions;

[TestClass]
public class WayPointTests
{
    [TestMethod]
    public void ConstructorTest()
    {
        var wayPoint = new WayPoint(new LocationEx(new Address("address")));

        Assert.AreEqual("address", wayPoint.Location.String);
        Assert.IsFalse(wayPoint.IsVia);
    }

    [TestMethod]
    public void ConstructorWhenIsViaTest()
    {
        var wayPoint = new WayPoint(new LocationEx(new Address("address")), true);

        Assert.AreEqual("address", wayPoint.Location.String);
        Assert.IsTrue(wayPoint.IsVia);
    }

    [TestMethod]
    public void ToStringTest()
    {
        var wayPoint = new WayPoint(new LocationEx(new Address("address")));

        var toString = wayPoint.ToString();
        Assert.AreEqual(wayPoint.Location.ToString(), toString);
    }

    [TestMethod]
    public void ToStringWhenIsViaTest()
    {
        var wayPoint = new WayPoint(new LocationEx(new Address("address")), true);

        var toString = wayPoint.ToString();
        Assert.AreEqual($"via:{wayPoint.Location}", toString);
        Assert.IsTrue(wayPoint.IsVia);
    }
}