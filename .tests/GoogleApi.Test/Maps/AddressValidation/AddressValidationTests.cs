using System;
using System.Collections.Generic;
using System.Threading;
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
    public void AddressValidationTest()
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

        var result = GoogleMaps.AddressValidation.Query(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void AddressValidationWhenEnableUspsCassTest()
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

        var result = GoogleMaps.AddressValidation.Query(request);

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

        var exception = Assert.Throws<AggregateException>(() => GoogleMaps.AddressValidation.Query(request));
        Assert.IsNotNull(exception);

        var innerException = exception.InnerException;
        Assert.IsNotNull(innerException);
        Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
        Assert.AreEqual("InvalidArgument: Address is missing from request.", innerException.Message);
    }

    [Test]
    public void AddressValidationWhenAsyncTest()
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

        var result = GoogleMaps.AddressValidation.QueryAsync(request).Result;
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void AddressValidationWhenAsyncAndCancelledTest()
    {
        var request = new AddressValidationRequest
        {
            Key = this.Settings.ApiKey
        };

        var cancellationTokenSource = new CancellationTokenSource();
        var task = GoogleMaps.AddressValidation.QueryAsync(request, cancellationTokenSource.Token);
        cancellationTokenSource.Cancel();

        var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "The operation was canceled.");
    }
}