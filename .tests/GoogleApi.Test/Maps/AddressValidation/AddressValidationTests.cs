using System.Collections.Generic;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.AddressValidation.Request;
using GoogleApi.Exceptions;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.AddressValidation;

[TestFixture]
public class AddressValidationTests : BaseTest
{
    [Test]
    public async Task AddressValidationTest()
    {
        var request = new AddressValidationRequest
        {
            Key = this.Settings.ApiKey,
            Address = new PostalAddress
            {
                AddressLines = new List<string>
                {
                    "1600 Amphitheatre Pkwy"
                }
            }
        };

        var result = await GoogleMaps.AddressValidation.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task AddressValidationWhenEnableUspsCassTest()
    {
        var request = new AddressValidationRequest
        {
            Key = this.Settings.ApiKey,
            Address = new PostalAddress
            {
                AddressLines = new List<string>
                {
                    "1600 Amphitheatre Pkwy"
                }
            },
            EnableUspsCass = true
        };

        var result = await GoogleMaps.AddressValidation.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
        Assert.NotNull(result.Result.UspsData);
    }

    [Test]
    public void AddressValidationWhenBadRequestTest()
    {
        var request = new AddressValidationRequest
        {
            Key = this.Settings.ApiKey
        };

        var exception = Assert.ThrowsAsync<GoogleApiException>(async () => await GoogleMaps.AddressValidation.QueryAsync(request));
        Assert.IsNotNull(exception);
        Assert.AreEqual("InvalidArgument: Address is missing from request.", exception.Message);
    }
}