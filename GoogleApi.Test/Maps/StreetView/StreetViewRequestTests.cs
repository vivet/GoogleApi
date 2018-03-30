using GoogleApi.Entities.Maps.StaticMaps.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.StreetView
{
    [TestFixture]
    public class StreetViewRequestTests : BaseTest
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new StaticMapsRequest();

            Assert.IsTrue(request.IsSsl);
        }
    }
}