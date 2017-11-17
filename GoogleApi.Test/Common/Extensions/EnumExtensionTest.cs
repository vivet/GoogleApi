using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Maps.Common.Enums;
using NUnit.Framework;

namespace GoogleApi.Test.Common.Extensions
{
    [TestFixture]
    public class EnumExtensionTest
    {
        [Test]
        public void ToEnumStringTest()
        {
            const AddressComponentType ENUM = AddressComponentType.Postal_Code;

            var result = ENUM.ToEnumString('|');
            Assert.AreEqual("postal_code", result);
        }

        [Test]
        public void ToEnumStringWhenFlagsTest()
        {
            const AvoidWay ENUM = AvoidWay.Highways | AvoidWay.Tolls;

            var result = ENUM.ToEnumString('|');
            Assert.AreEqual("tolls|highways", result);
        }
    }
}