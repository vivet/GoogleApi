using GoogleApi.Entities.Maps.StaticMaps.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.StaticMaps
{
    [TestFixture]
    public class AnchorCoordinateTests
    {
        [Test]
        public void ConstructorTest()
        {
            var anchorCoordinate = new AnchorCoordinate(1, 1);

            Assert.AreEqual(1, anchorCoordinate.X);
            Assert.AreEqual(1, anchorCoordinate.Y);
        }

        [Test]
        public void ToStringTest()
        {
            var anchorCoordinate = new AnchorCoordinate(1, 1);

            var toString = anchorCoordinate.ToString();
            Assert.AreEqual($"{anchorCoordinate.X},{anchorCoordinate.Y}", toString);
        }
    }
}