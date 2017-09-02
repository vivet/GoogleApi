using GoogleApi.Entities.Search.Common;
using GoogleApi.Entities.Search.Common.Enums;
using NUnit.Framework;

namespace GoogleApi.Test.Search.Web.Entities
{
    [TestFixture]
    public class CountryRestrictExpressionTests : BaseTest
    {
        [Test]
        public void ToStringTest()
        {
            const string EXPECTED = "-countryIT.";

            var countryRestrictExpression = new CountryRestrictExpression
            {
                Not = true,
                Operator = Operator.And,
                Country = Country.Italy
            };

            var actual = countryRestrictExpression.ToString();

            Assert.IsNotNull(actual);
            Assert.AreEqual(EXPECTED, actual);
        }

        [Test]
        public void ToStringWhenNestedCountryRestrictTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void FromStringTest()
        {
            const string ACTUAL = "-countryIT.";
            var expected = new CountryRestrictExpression().FromString(ACTUAL);

            Assert.IsNotNull(expected);
            Assert.IsTrue(expected.Not);
            Assert.AreEqual(Country.Italy, expected.Country);
            Assert.AreEqual(Operator.And, expected.Operator);
        }

        [Test]
        public void FromStringWhenNestedCountryRestrictTest()
        {
            Assert.Inconclusive();
        }
    }
}