using System.Collections.Generic;
using GoogleApi.Entities.Search.Common;
using GoogleApi.Entities.Search.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests.Search.Common;

[TestClass]
public class CountryRestrictTests
{
    [TestMethod]
    public void ToStringTest()
    {
        const string EXPECTED = "(-countryIT.countryAF).";

        var countryRestrict = new CountryRestrict
        {
            Expressions = new List<CountryRestrictExpression>
            {
                new()
                {
                    Not = true,
                    Operator = Operator.And,
                    Country = Country.Italy
                },
                new()
                {
                    Country = Country.Afghanistan
                }
            }
        };

        var actual = countryRestrict.ToString();

        Assert.IsNotNull(actual);
        Assert.AreEqual(EXPECTED, actual);
    }

    [TestMethod]
    public void ToStringWhenNestedExpressionsTest()
    {
        const string EXPECTED = "(-countryIT.(-countryES|countryPT).countryAF).";

        var countryRestrict = new CountryRestrict
        {
            Expressions = new List<CountryRestrictExpression>
            {
                new()
                {
                    Not = true,
                    Operator = Operator.And,
                    Country = Country.Italy,
                    NestedCountryRestrict = new CountryRestrict
                    {
                        Expressions = new List<CountryRestrictExpression>
                        {
                            new()
                            {
                                Not = true,
                                Operator = Operator.Or,
                                Country = Country.Spain
                            },
                            new()
                            {
                                Country = Country.Portugal
                            }
                        }
                    }
                },
                new()
                {
                    Country = Country.Afghanistan
                }
            }
        };

        var actual = countryRestrict.ToString();

        Assert.IsNotNull(actual);
        Assert.AreEqual(EXPECTED, actual);
    }

    [TestMethod]
    public void FromStringTest()
    {
        Assert.Inconclusive();
    }

    [TestMethod]
    public void FromStringNestedExpressionsTest()
    {
        Assert.Inconclusive();
    }
}