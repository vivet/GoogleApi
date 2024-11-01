using System;
using GoogleApi.Entities.Maps.AddressValidation.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests.Maps.AddressValidation;

[TestClass]
public class AddressValidationRequestTests
{
    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new AddressValidationRequest
        {
            Key = null
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual("'Key' is required", exception.Message);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsEmptyTest()
    {
        var request = new AddressValidationRequest
        {
            Key = string.Empty
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual("'Key' is required", exception.Message);
    }
}