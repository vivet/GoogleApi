using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Extensions;
using NUnit.Framework;

namespace GoogleApi.Test.Common.Extensions
{
    [TestFixture]
    public class EnumExtensionTest
    {
        [Test]
        public void ToEnumStringTest()
        {
            var result = LocationType.PostalCode.ToEnumString();
            Assert.AreEqual("postal_code", result);
        }

        [Test]
        public void ToEnumStringWhenDelimieterTest()
        {
            var result = LocationType.PostalCode.ToEnumString(',');
            Assert.AreEqual("postalcode", result);
        }
    }
}