using GoogleApi.Entities.Common.Enums;
using GoogleApi.Extensions;
using NUnit.Framework;

namespace GoogleApi.Test.Extensions
{
    [TestFixture]
    public class EnumExtensionTest
    {
        [Test]
        public void ToEnumStringTest()
        {
            var _result = LocationType.POSTAL_CODE.ToEnumString();
            Assert.AreEqual("postal_code", _result);
        }
    }
}