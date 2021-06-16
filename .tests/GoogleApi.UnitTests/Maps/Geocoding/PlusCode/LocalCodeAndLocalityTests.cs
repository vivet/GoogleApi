using GoogleApi.Entities.Maps.Geocoding.PlusCode.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.Geocoding.PlusCode
{
    [TestFixture]
    public class LocalCodeAndLocalityTests
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var localCodeAndLocality = new LocalCodeAndLocality("code", "locality");
            Assert.AreEqual("code", localCodeAndLocality.Code);
            Assert.AreEqual("locality", localCodeAndLocality.Locality);
        }

        [Test]
        public void ToStringTest()
        {
            var localCodeAndLocality = new LocalCodeAndLocality("code", "locality");

            var toString = localCodeAndLocality.ToString();
            Assert.AreEqual($"{localCodeAndLocality.Code} {localCodeAndLocality.Locality}", toString);
        }
    }
}