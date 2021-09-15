using System;
using GoogleApi.Entities.Common;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Common
{
    [TestFixture]
    public class PlusCodeTests
    {
        [Test]
        public void ConstructorTest()
        {
            var plusCode = new PlusCode("global", "local");

            Assert.AreEqual("global", plusCode.GlobalCode);
            Assert.AreEqual("local", plusCode.LocalCode);
        }

        [Test]
        public void ConstructorWhenGlobalCodeIsNullTest()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var plusCode = new PlusCode(null, "local");
                Assert.IsNotNull(plusCode);
            });
        }

        [Test]
        public void ConstructorWhenLocalCodeIsNullTest()
        {
            Assert.DoesNotThrow(() =>
            {
                var plusCode = new PlusCode("global");
                Assert.IsNotNull(plusCode);
            });
        }

        [Test]
        public void ToStringTest()
        {
            var plusCode = new PlusCode("global", "local");

            var toString = plusCode.ToString();
            Assert.AreEqual($"{plusCode.GlobalCode}{plusCode.LocalCode}", toString);
        }
    }
}