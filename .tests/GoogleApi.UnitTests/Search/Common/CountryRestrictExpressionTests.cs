using GoogleApi.Entities.Search.Common;
using GoogleApi.Entities.Search.Common.Enums;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Search.Common;

[TestFixture]
public class CountryRestrictExpressionTests
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
}