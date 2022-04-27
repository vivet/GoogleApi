using GoogleApi.Entities.Common.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GoogleApi.UnitTests.Common.Extensions
{
    [TestFixture]
    public class ListExtensionTest
    {
        [Test]
        public void AddTest()
        {
            var list = new List<KeyValuePair<string, string>>();
            const string KEY = "abc";
            const string VALUE = "123";

            list.Add(KEY, VALUE);

            Assert.Contains(new KeyValuePair<string, string>(KEY, VALUE), list);
        }

        [Test]
        public void AddWhenKeyIsNull()
        {
            const string VALUE = "testName";
            var queryStringParameters = new List<KeyValuePair<string, string>>();

            var exception = Assert.Throws<ArgumentNullException>(() => queryStringParameters.Add(null, VALUE));
#if NETCOREAPP3_1_OR_GREATER
            Assert.AreEqual("Value cannot be null. (Parameter 'key')", exception.Message);
#else
            Assert.AreEqual("Value cannot be null.\r\nParameter name: key", exception.Message);
#endif
        }
    }
}