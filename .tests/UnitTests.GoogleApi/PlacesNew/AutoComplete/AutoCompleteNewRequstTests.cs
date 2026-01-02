using System;
using GoogleApi.Entities.PlacesNew.AutoComplete.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.GoogleApi.PlacesNew.AutoComplete;

[TestClass]
public class AutoCompleteNewRequstTests
{
    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new PlacesNewAutoCompleteRequest
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
        var request = new PlacesNewAutoCompleteRequest
        {
            Key = string.Empty
        };

        var exception = Assert.Throws<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Key' is required");
    }
}