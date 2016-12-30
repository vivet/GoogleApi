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
        public void ConstructorInitializesParametersCollectionTest()
		{
            var queryStringParametersList = new QueryStringParametersList();
            Assert.IsNotNull(queryStringParametersList.List);
		}

        [Test]
        public void AddTest()
        {
            const string key = "key";
            const string value = "value";

            var queryStringParametersList = new QueryStringParametersList();
            queryStringParametersList.Add(key, value);

            Assert.IsNotNull(queryStringParametersList.List);
            Assert.Contains(key, queryStringParametersList.List.Keys);
            Assert.AreEqual(value, queryStringParametersList.List[key]);
        }
        [Test]
        public void AddwhenKeyExistsTest()
        {
            const string key = "key";
            const string value = "value";
            const string valueNew = "value_new";

            var queryStringParametersList = new QueryStringParametersList();
            queryStringParametersList.Add(key, value);
            queryStringParametersList.Add(key, valueNew);

            Assert.IsNotNull(queryStringParametersList.List);
            Assert.Contains(key, queryStringParametersList.List.Keys);
            Assert.AreEqual(valueNew, queryStringParametersList.List[key]);
            Assert.AreEqual(1, queryStringParametersList.List.Count);
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
            const string key = "key";
            const string value = "value";

            var queryStringParametersList = new QueryStringParametersList();
            queryStringParametersList.Add(key, value);
            queryStringParametersList.Remove(key);

            Assert.IsNotNull(queryStringParametersList.List);
            Assert.AreEqual(0, queryStringParametersList.List.Count);
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
            var queryStringParametersList = new QueryStringParametersList();
            queryStringParametersList.Add("1", "1");
            queryStringParametersList.Add("2", "2");
            queryStringParametersList.Add("3", "3");

            var actual = queryStringParametersList.GetQueryStringPostfix();
            var expected = string.Join("&", queryStringParametersList.List.Select(x => Uri.EscapeDataString(x.Key) + "=" + Uri.EscapeDataString(x.Value)));

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
		}
	}
}
