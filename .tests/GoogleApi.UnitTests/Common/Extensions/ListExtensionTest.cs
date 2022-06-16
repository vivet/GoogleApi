using System;
using System.Collections.Generic;
using GoogleApi.Entities.Common.Extensions;
using NUnit.Framework;

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

            Assert.IsNotNull(exception);
            Assert.IsTrue(exception.Message.StartsWith("Value cannot be null"));
            Assert.IsTrue(exception.Message.Contains("key"));
        }
    }
}