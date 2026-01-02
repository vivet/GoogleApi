using System.Collections.Generic;
using System.Threading.Tasks;
using GoogleApi;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.AddressValidation.Request;
using GoogleApi.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests.GoogleApi.Maps.AddressValidation;

[TestClass]
public class AddressValidationTests : BaseTest
{
    [TestMethod]
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
            },
            LanguageOptions = new LanguageOptions
            {
                ReturnEnglishLatinAddress = true
            }
        };

        var result = await GoogleMaps.AddressValidation.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
        Assert.IsNotNull(result.Result.Address.FormattedAddress);
    }

    [TestMethod]
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
        Assert.IsNotNull(result.Result.UspsData);
    }

    [TestMethod]
    public async Task AddressValidationWhenBadRequestTest()
    {
        var request = new AddressValidationRequest
        {
            Key = this.Settings.ApiKey
        };

        var exception = await Assert.ThrowsAsync<GoogleApiException>(async () => await GoogleMaps.AddressValidation.QueryAsync(request));
        Assert.IsNotNull(exception);
        Assert.AreEqual("InvalidArgument: Address is missing from request.", exception.Message);
    }
}