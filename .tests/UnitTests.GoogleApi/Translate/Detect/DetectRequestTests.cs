using System;
using System.Linq;
using GoogleApi.Entities.Translate.Detect.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests.Translate.Detect;

[TestClass]
public class DetectRequestTests
{
    [TestMethod]
    public void GetQueryStringParametersTest()
    {
        var request = new DetectRequest
        {
            Key = "key",
            Qs =
            [
                "qs"
            ]
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var key = queryStringParameters.FirstOrDefault(x => x.Key == "key");
        var keyExpected = request.Key;
        Assert.IsNotNull(key);
        Assert.AreEqual(keyExpected, key.Value);

        var qs = queryStringParameters.FirstOrDefault(x => x.Key == "q");
        var qsExpected = request.Qs.First();
        Assert.IsNotNull(qs);
        Assert.AreEqual(qsExpected, qs.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new DetectRequest
        {
            Key = null
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Key' is required");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsStringEmptyTest()
    {
        var request = new DetectRequest
        {
            Key = string.Empty
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Key' is required");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenQsIsNullTest()
    {
        var request = new DetectRequest
        {
            Key = "abc",
            Qs = null
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Qs' is required");
    }
}