using System;
using System.Collections.Generic;
using GoogleApi.Entities.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests.Common.Extensions;

[TestClass]
public class ListExtensionTest
{
    [TestMethod]
    public void AddTest()
    {
        var list = new List<KeyValuePair<string, string>>();
        const string KEY = "abc";
        const string VALUE = "123";

        list.Add(KEY, VALUE);

        Assert.IsTrue(list.Contains(new KeyValuePair<string, string>(KEY, VALUE)));
    }

    [TestMethod]
    public void AddWhenKeyIsNull()
    {
        const string VALUE = "testName";
        var queryStringParameters = new List<KeyValuePair<string, string>>();

        var exception = Assert.ThrowsException<ArgumentNullException>(() => queryStringParameters.Add(null, VALUE));

        Assert.IsNotNull(exception);
        Assert.IsTrue(exception.Message.StartsWith("Value cannot be null"));
        Assert.IsTrue(exception.Message.Contains("key"));
    }
}