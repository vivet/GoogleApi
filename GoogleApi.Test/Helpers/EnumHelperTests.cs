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
            var _result = EnumHelper.ToEnumString(PlaceLocationType.POST_OFFICE);
            Assert.AreEqual("post_office", _result);
        }


        [Test]
        public void ToEnum_Success()
        {
            var _result = EnumHelper.ToEnum<PlaceLocationType>("post_office");
            Assert.AreEqual(PlaceLocationType.POST_OFFICE, _result);
        }
    }
}