using System;
using System.Linq;
using GoogleApi.Entities;
using NUnit.Framework;

namespace GoogleApi.Test.Entities
{
    [TestFixture]
    public class QueryStringParametersTest
	{
        [Test]
        public void AddTest()
        {
            const string KEY = "key";
            const string VALUE = "value";

            var queryStringParametersList = new QueryStringParameters { { KEY, VALUE } };

            Assert.IsTrue(queryStringParametersList.Keys.Contains(KEY));
            Assert.AreEqual(VALUE, queryStringParametersList[KEY]);
        }
        [Test]
        public void AddwhenKeyExistsTest()
        {
            const string KEY = "key";
            const string VALUE = "value";
            const string VALUE_NEW = "value_new";

            var queryStringParametersList = new QueryStringParameters { { KEY, VALUE }, { KEY, VALUE_NEW } };

            Assert.IsTrue(queryStringParametersList.Keys.Contains(KEY));
            Assert.AreEqual(VALUE_NEW, queryStringParametersList[KEY]);
            Assert.AreEqual(1, queryStringParametersList.Count);
        }
        [Test]
        public void AddWhenKeyIsNullTest()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new QueryStringParameters().Add(null, "value"));
            Assert.AreEqual("key", exception.ParamName);
        }
        [Test]
        public void AddWhenValueIsNullTest()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new QueryStringParameters().Add("key", null));
            Assert.AreEqual("value", exception.ParamName);
        }

        [Test]
        public void ToStringTest()
		{
		    var queryStringParametersList = new QueryStringParameters
		    {
		        { "1", "1" },
                { "2", "2" },
                { "3", "3" }
		    };

		    var actual = queryStringParametersList.ToString();
            var expected = string.Join("&", queryStringParametersList.Select(x => Uri.EscapeDataString(x.Key) + "=" + Uri.EscapeDataString(x.Value)));

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
		}
	}
}
