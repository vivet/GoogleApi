using System;
using GoogleApi.Entities.PlacesNew.Search.Text.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.GoogleApi.PlacesNew.Search.Text;

[TestClass]
public class TextSearchNewRequestTests
{
    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new PlacesNewTextSearchRequest
        {
            Key = null
        };

        var exception = Assert.Throws<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Key' is required");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsStringEmptyTest()
    {
        var request = new PlacesNewTextSearchRequest
        {
            Key = string.Empty
        };

        var exception = Assert.Throws<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Key' is required");
    }
}