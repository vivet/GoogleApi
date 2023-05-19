using System;
using GoogleApi.Entities.Maps.AddressValidation.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.AddressValidation;

[TestFixture]
public class AddressValidationRequestTests
{
    [Test]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new AddressValidationRequest
        {
            Key = null
        };

        var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
        Assert.IsNotNull(exception);
        Assert.AreEqual("'Key' is required", exception.Message);
    }

    [Test]
    public void GetQueryStringParametersWhenKeyIsEmptyTest()
    {
        var request = new AddressValidationRequest
        {
            Key = string.Empty
        };

        var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
        Assert.IsNotNull(exception);
        Assert.AreEqual("'Key' is required", exception.Message);
    }
}