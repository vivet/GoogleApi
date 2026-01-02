using System;
using GoogleApi.Entities.PlacesNew.Details.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.GoogleApi.PlacesNew.Details;

[TestClass]
public class DetailsNewRequestTests
{
    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new PlacesNewDetailsRequest
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
        var request = new PlacesNewDetailsRequest
        {
            Key = string.Empty
        };

        var exception = Assert.Throws<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Key' is required");
    }
}