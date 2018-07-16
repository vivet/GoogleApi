using System;
using System.Collections.Generic;
using GoogleApi.Entities.Common.Extensions;
using NUnit.Framework;

namespace GoogleApi.Test.Common.Extensions
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
            Assert.AreEqual("Value cannot be null.\r\nParameter name: key", exception.Message);
        }
    }
}