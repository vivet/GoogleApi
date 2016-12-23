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
            var _queryStringParametersList = new QueryStringParametersList();
            Assert.IsNotNull(_queryStringParametersList.List);
		}

        [Test]
        public void AddTest()
        {
            const string KEY = "key";
            const string VALUE = "value";

            var _queryStringParametersList = new QueryStringParametersList();
            _queryStringParametersList.Add(KEY, VALUE);

            Assert.IsNotNull(_queryStringParametersList.List);
            Assert.Contains(KEY, _queryStringParametersList.List.Keys);
            Assert.AreEqual(VALUE, _queryStringParametersList.List[KEY]);
        }
        [Test]
        public void AddwhenKeyExistsTest()
        {
            const string KEY = "key";
            const string VALUE = "value";
            const string VALUE_NEW = "value_new";

            var _queryStringParametersList = new QueryStringParametersList();
            _queryStringParametersList.Add(KEY, VALUE);
            _queryStringParametersList.Add(KEY, VALUE_NEW);

            Assert.IsNotNull(_queryStringParametersList.List);
            Assert.Contains(KEY, _queryStringParametersList.List.Keys);
            Assert.AreEqual(VALUE_NEW, _queryStringParametersList.List[KEY]);
            Assert.AreEqual(1, _queryStringParametersList.List.Count);
        }
        [Test]
        public void AddWhenKeyIsNullTest()
        {
            var _exception = Assert.Throws<ArgumentNullException>(() => new QueryStringParametersList().Add(null, "value"));
            Assert.AreEqual("_key", _exception.ParamName);
        }
        [Test]
        public void AddWhenValueIsNullTest()
        {
            var _exception = Assert.Throws<ArgumentNullException>(() => new QueryStringParametersList().Add("key", null));
            Assert.AreEqual("_value", _exception.ParamName);
        }

        [Test]
        public void RemoveTest()
        {
            const string KEY = "key";
            const string VALUE = "value";

            var _queryStringParametersList = new QueryStringParametersList();
            _queryStringParametersList.Add(KEY, VALUE);
            _queryStringParametersList.Remove(KEY);

            Assert.IsNotNull(_queryStringParametersList.List);
            Assert.AreEqual(0, _queryStringParametersList.List.Count);
        }
        [Test]
        public void RemoveWhenKeyIsNullTest()
        {
            var _exception = Assert.Throws<ArgumentNullException>(() => new QueryStringParametersList().Remove(null));
            Assert.AreEqual("_key", _exception.ParamName);
        }

        [Test]
        public void GetQueryStringPostfixTest()
		{
            var _queryStringParametersList = new QueryStringParametersList();
            _queryStringParametersList.Add("1", "1");
            _queryStringParametersList.Add("2", "2");
            _queryStringParametersList.Add("3", "3");

            var _actual = _queryStringParametersList.GetQueryStringPostfix();
            var _expected = string.Join("&", _queryStringParametersList.List.Select(_x => Uri.EscapeDataString(_x.Key) + "=" + Uri.EscapeDataString(_x.Value)));

            Assert.IsNotNull(_actual);
            Assert.AreEqual(_expected, _actual);
		}
	}
}
