using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Helpers;
using NUnit.Framework;

namespace GoogleApi.Test.Helpers
{
    [TestFixture]
    public class EnumHelperTests
    {

        [Test]
        public void ToEnumString_Success()
        {
            var _result = EnumHelper.ToEnumString(PlaceType.POST_OFFICE);
            Assert.AreEqual("post_office", _result);
        }


        [Test]
        public void ToEnum_Success()
        {
            var _result = EnumHelper.ToEnum<PlaceType>("post_office");
            Assert.AreEqual(PlaceType.POST_OFFICE, _result);
        }
    }
}