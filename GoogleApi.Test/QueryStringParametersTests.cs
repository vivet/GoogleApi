using System;
using System.Linq;
using GoogleApi.Entities;
using NUnit.Framework;

namespace GoogleApi.Test
{
    [TestFixture]
    public class QueryStringParametersTests : BaseTest
    {
        [Test]
        public void Add()
        {
            const string NAME = "testName";
            var queryStringParameters = new QueryStringParameters
            {
                NAME
            };

            var result = queryStringParameters.FirstOrDefault();
            Assert.IsNotNull(result);
            Assert.AreEqual(NAME, result.Name);
            Assert.AreEqual(string.Empty, result.Value);
        }

        [Test]
        public void AddWhhenNameIsNull()
        {
            var queryStringParameters = new QueryStringParameters();

            var exception = Assert.Throws<ArgumentNullException>(() => queryStringParameters.Add(null));
            Assert.AreEqual("Value cannot be null.\r\nParameter name: name", exception.Message);
        }

        [Test]
        public void AddWhenValue()
        {
            const string NAME = "testName";
            const string VALUE = "testName";

            var queryStringParameters = new QueryStringParameters
            {
                { NAME, VALUE }
            };

            var result = queryStringParameters.FirstOrDefault();
            Assert.IsNotNull(result);
            Assert.AreEqual(NAME, result.Name);
            Assert.AreEqual(VALUE, result.Value);
        }

        [Test]
        public void AddWhenValueAndNameIsNull()
        {
            const string VALUE = "testName";
            var queryStringParameters = new QueryStringParameters();

            var exception = Assert.Throws<ArgumentNullException>(() => queryStringParameters.Add(null, VALUE));
            Assert.AreEqual("Value cannot be null.\r\nParameter name: name", exception.Message);
        }

        [Test]
        public void AddWhenValueAndValueIsNull()
        {
            const string NAME = "testName";
            var queryStringParameters = new QueryStringParameters();

            var exception = Assert.Throws<ArgumentNullException>(() => queryStringParameters.Add(NAME, null));
            Assert.AreEqual("Value cannot be null.\r\nParameter name: value", exception.Message);
        }
    }
}