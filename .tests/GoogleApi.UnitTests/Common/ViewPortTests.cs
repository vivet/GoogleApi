using GoogleApi.Entities.Common;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Common
{
    [TestFixture]
    public class ViewPortTests
    {
        [Test]
        public void ConstructorTest()
        {
            var southWest = new Coordinate(1, 1);
            var northEast = new Coordinate(2, 2);
            var viewPort = new ViewPort(southWest, northEast);

            Assert.AreEqual(northEast, viewPort.NorthEast);
            Assert.AreEqual(southWest, viewPort.SouthWest);
        }

        [Test]
        public void ToStringTest()
        {
            var southWest = new Coordinate(1, 1);
            var northEast = new Coordinate(2, 2);
            var viewPort = new ViewPort(southWest, northEast);

            var toString = viewPort.ToString();
            Assert.AreEqual($"{southWest}|{northEast}", toString);
        }
    }
}