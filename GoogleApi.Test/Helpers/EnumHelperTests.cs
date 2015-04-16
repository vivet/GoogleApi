using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Helpers;
using NUnit.Framework;

namespace GoogleApi.Test.Helpers
{
    [TestFixture]
    public class EnumHelperTests
    {

        [Test]
        public void ToEnumString_Member_Success()
        {
            var result = EnumHelper.ToEnumString(PlaceType.PostOffice);
            Assert.AreEqual("post_office", result);
        }

        [Test]
        public void ToEnumString_Normal_Success()
        {
            var result = EnumHelper.ToEnumString(PriceLevel.Moderate);
            Assert.AreEqual("2", result);
        }


        [Test]
        public void ToEnum_Member_Success()
        {
            var result = EnumHelper.ToEnum<PlaceType>("post_office");
            Assert.AreEqual(PlaceType.PostOffice, result);
        }

        [Test]
        public void ToEnum_Normal_Success()
        {
            var result = EnumHelper.ToEnum<PriceLevel>("3");
            Assert.AreEqual(PriceLevel.Expensive, result);
        }
    }
}
