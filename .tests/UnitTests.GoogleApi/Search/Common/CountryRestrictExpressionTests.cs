using GoogleApi.Entities.Search.Common;
using GoogleApi.Entities.Search.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests.Search.Common;

[TestClass]
public class CountryRestrictExpressionTests
{
    [TestMethod]
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

    [TestMethod]
    public void ToStringWhenNestedCountryRestrictTest()
    {
        Assert.Inconclusive();
    }
}