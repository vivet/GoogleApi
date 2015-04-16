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
            var result = EnumHelper.ToEnumString(PlaceType.PostOffice);
            Assert.AreEqual("post_office", result);
        }


        [Test]
        public void ToEnum_Success()
        {
            var result = EnumHelper.ToEnum<PlaceType>("post_office");
            Assert.AreEqual(PlaceType.PostOffice, result);
        }
    }
}
