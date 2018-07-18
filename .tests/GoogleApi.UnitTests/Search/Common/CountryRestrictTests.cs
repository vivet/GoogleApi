using System.Collections.Generic;
using GoogleApi.Entities.Search.Common;
using GoogleApi.Entities.Search.Common.Enums;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Search.Common
{
    [TestFixture]
    public class CountryRestrictTests
    {
        [Test]
        public void ToStringTest()
        {
            const string EXPECTED = "(-countryIT.countryAF).";

            var countryRestrict = new CountryRestrict
            {
                Expressions = new List<CountryRestrictExpression>
                {
                    new CountryRestrictExpression
                    {
                        Not = true,
                        Operator = Operator.And,
                        Country = Country.Italy
                    },
                    new CountryRestrictExpression
                    {
                        Country = Country.Afghanistan
                    }
                }
            };

            var actual = countryRestrict.ToString();

            Assert.IsNotNull(actual);
            Assert.AreEqual(EXPECTED, actual);
        }

        [Test]
        public void ToStringWhenNestedExpressionsTest()
        {
            const string EXPECTED = "(-countryIT.(-countryES|countryPT).countryAF).";

            var countryRestrict = new CountryRestrict
            {
                Expressions = new List<CountryRestrictExpression>
                {
                    new CountryRestrictExpression
                    {
                        Not = true,
                        Operator = Operator.And,
                        Country = Country.Italy,
                        NestedCountryRestrict = new CountryRestrict
                        {
                            Expressions = new List<CountryRestrictExpression>
                            {
                                new CountryRestrictExpression
                                {
                                    Not = true,
                                    Operator = Operator.Or,
                                    Country = Country.Spain
                                },
                                new CountryRestrictExpression
                                {
                                    Country = Country.Portugal
                                }
                            }
                        }
                    },
                    new CountryRestrictExpression
                    {
                        Country = Country.Afghanistan
                    }
                }
            };

            var actual = countryRestrict.ToString();

            Assert.IsNotNull(actual);
            Assert.AreEqual(EXPECTED, actual);
        }

        [Test]
        public void FromStringTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void FromStringNestedExpressionsTest()
        {
            Assert.Inconclusive();
        }
    }
}