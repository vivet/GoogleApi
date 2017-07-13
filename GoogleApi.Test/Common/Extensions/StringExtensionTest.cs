using System;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Extensions;
using NUnit.Framework;

namespace GoogleApi.Test.Common.Extensions
{
    [TestFixture]
    public class StringExtensionTest
    {
        [Test]
        public void ToEnumTest()
        {
            var enumString = "floor";
            var result = enumString.ToEnum<LocationType>();

            Assert.IsNotNull(result);
            Assert.AreEqual(LocationType.Floor, result);
        }     
        
        [Test]
        public void ToEnumWhenStringIsNullTests()
        {
            Assert.Throws<ArgumentNullException>(() => ((string) null).ToEnum<LocationType>());
        }        
    }
}