using System;
using GoogleApi.Entities.Maps.Roads.NearestRoads.Request;
using GoogleApi.Entities.Maps.StaticMaps.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.StaticMaps
{
    [TestFixture]
    public class StaticMapsRequestTests : BaseTest
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new StaticMapsRequest();

            Assert.IsTrue(request.IsSsl);
        }
    }
}