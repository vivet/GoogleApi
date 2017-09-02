using System.Collections.Generic;
using GoogleApi.Entities.Search.Common;
using GoogleApi.Entities.Search.Common.Enums;
using NUnit.Framework;

namespace GoogleApi.Test.Search.Web.Entities
{
    [TestFixture]
    public class CountryRestrictTests : BaseTest
    {
        [Test]
        public void ToStringTest()
        {
            var countryRestriction = new CountryRestrict
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

            var expected = "-countryIT.countryAF";
            var actual = countryRestriction.ToString();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToStringWhenNestedExpressionsTest()
        {
            var countryRestriction = new CountryRestrict
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

            var expected = "(-countryIT.(-countryES|countryPT).countryAF).";
            var actual = countryRestriction.ToString();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);


            // "(-countryIT.(-countryES.countryPT.)countryAF.)"
            // "(-countryIT.(-countryES.countryPT).countryAF)."
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