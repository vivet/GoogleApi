using System;
using System.Linq;
using GoogleApi.Helpers;
using NUnit.Framework;

namespace GoogleApi.Test.Helpers
{
    [TestFixture]
    public class QueryStringParametersListTest
	{
        [Test]
        public void AddTest()
        {
            const string KEY = "key";
            const string VALUE = "value";

            var queryStringParametersList = new QueryStringParametersList { { KEY, VALUE } };

            Assert.IsTrue(queryStringParametersList.Keys.Contains(KEY));
            Assert.AreEqual(VALUE, queryStringParametersList[KEY]);
        }
        [Test]
        public void AddwhenKeyExistsTest()
        {
            const string KEY = "key";
            const string VALUE = "value";
            const string VALUE_NEW = "value_new";

            var queryStringParametersList = new QueryStringParametersList { { KEY, VALUE }, { KEY, VALUE_NEW } };

            Assert.IsTrue(queryStringParametersList.Keys.Contains(KEY));
            Assert.AreEqual(VALUE_NEW, queryStringParametersList[KEY]);
            Assert.AreEqual(1, queryStringParametersList.Count);
        }
        [Test]
        public void AddWhenKeyIsNullTest()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new QueryStringParametersList().Add(null, "value"));
            Assert.AreEqual("key", exception.ParamName);
        }
        [Test]
        public void AddWhenValueIsNullTest()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new QueryStringParametersList().Add("key", null));
            Assert.AreEqual("value", exception.ParamName);
        }

        [Test]
        public void RemoveTest()
        {
            const string KEY = "key";
            const string VALUE = "value";

            var queryStringParametersList = new QueryStringParametersList { { KEY, VALUE } };
            queryStringParametersList.Remove(KEY);

            Assert.AreEqual(0, queryStringParametersList.Count);
        }
        [Test]
        public void RemoveWhenKeyIsNullTest()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new QueryStringParametersList().Remove(null));
            Assert.AreEqual("key", exception.ParamName);
        }

        [Test]
        public void GetQueryStringPostfixTest()
		{
		    var queryStringParametersList = new QueryStringParametersList
		    {
		        { "1", "1" },
                { "2", "2" },
                { "3", "3" }
		    };

		    var actual = queryStringParametersList.GetQueryStringPostfix();
            var expected = string.Join("&", queryStringParametersList.Select(x => Uri.EscapeDataString(x.Key) + "=" + Uri.EscapeDataString(x.Value)));

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
		}
	}
}
