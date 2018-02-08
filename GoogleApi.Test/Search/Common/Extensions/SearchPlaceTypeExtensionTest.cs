using GoogleApi.Entities.Places.Search.Common.Enums;
using GoogleApi.Entities.Search.Common.Enums.Extensions;
using NUnit.Framework;

namespace GoogleApi.Test.Search.Common.Extensions
{
    [TestFixture]
    public class SearchPlaceTypeExtensionTest
    {
        [Test]
        public void ToUnderscoreString()
        {
            const SearchPlaceType ENUM = SearchPlaceType.HomeGoodsStore;

            var result = ENUM.ToUnderscoreString();
            Assert.AreEqual("home_goods_store", result);
        }
    }
}