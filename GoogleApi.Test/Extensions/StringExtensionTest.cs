using System;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Extensions;
using NUnit.Framework;

namespace GoogleApi.Test.Extensions
{
    [TestFixture]
    public class StringExtensionTest
    {
        [Test]
        public void ToEnumTest()
        {
            var _enumString = "floor";
            var _result = _enumString.ToEnum<LocationType>();

            Assert.IsNotNull(_result);
            Assert.AreEqual(LocationType.FLOOR, _result);
        }        
        [Test]
        public void ToEnumWhenStringIsNullTests()
        {
            Assert.Throws<ArgumentNullException>(() => ((string) null).ToEnum<LocationType>());
        }        
    }
}