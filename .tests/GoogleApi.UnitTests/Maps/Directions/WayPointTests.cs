using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Directions.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.Directions;

[TestFixture]
public class WayPointTests
{
    [Test]
    public void ConstructorTest()
    {
        var wayPoint = new WayPoint(new LocationEx(new Address("address")));

        Assert.AreEqual("address", wayPoint.Location.String);
        Assert.IsFalse(wayPoint.IsVia);
    }

    [Test]
    public void ConstructorWhenIsViaTest()
    {
        var wayPoint = new WayPoint(new LocationEx(new Address("address")), true);

        Assert.AreEqual("address", wayPoint.Location.String);
        Assert.IsTrue(wayPoint.IsVia);
    }

    [Test]
    public void ToStringTest()
    {
        var wayPoint = new WayPoint(new LocationEx(new Address("address")));

        var toString = wayPoint.ToString();
        Assert.AreEqual(wayPoint.Location.ToString(), toString);
    }

    [Test]
    public void ToStringWhenIsViaTest()
    {
        var wayPoint = new WayPoint(new LocationEx(new Address("address")), true);

        var toString = wayPoint.ToString();
        Assert.AreEqual($"via:{wayPoint.Location}", toString);
        Assert.IsTrue(wayPoint.IsVia);
    }
}