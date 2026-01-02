using System;
using GoogleApi.Entities.PlacesNew.Photos.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.GoogleApi.PlacesNew.Photos;

[TestClass]
public class PhotosNewRequestTests
{
    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new PlacesNewPhotosRequest
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
        var request = new PlacesNewPhotosRequest
        {
            Key = string.Empty
        };

        var exception = Assert.Throws<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Key' is required");
    }
}