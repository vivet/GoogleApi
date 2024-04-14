using System.Linq;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Common;
using GoogleApi.Entities.Places.Search.Find.Request;
using GoogleApi.Entities.Places.Search.Find.Request.Enums;
using NUnit.Framework;

namespace GoogleApi.Test.Places.Search.Find;

[TestFixture]
public class FindSearchTests : BaseTest
{
    [Test]
    public async Task PlacesFindSearchTest()
    {
        var request = new PlacesFindSearchRequest
        {
            Key = this.Settings.ApiKey,
            Input = "picadelly circus",
            Type = InputType.TextQuery,
            Fields = FieldTypes.Basic
        };

        var response = await GooglePlaces.Search.FindSearch.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);

        var candidate = response.Candidates.FirstOrDefault();
        Assert.IsNotNull(candidate);
        Assert.IsNotNull(candidate.PlaceId);
        Assert.AreEqual(candidate.BusinessStatus, BusinessStatus.Operational);
    }

    [Test]
    public async Task PlacesFindSearchWhenTypeIsPhoneNumberTest()
    {
        var request = new PlacesFindSearchRequest
        {
            Key = this.Settings.ApiKey,
            Input = "+4533333333",
            Type = InputType.PhoneNumber
        };

        var response = await GooglePlaces.Search.FindSearch.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public async Task PlacesFindSearchWhenFieldsTest()
    {
        var request = new PlacesFindSearchRequest
        {
            Key = this.Settings.ApiKey,
            Input = "picadelly circus",
            Type = InputType.TextQuery,
            Fields = FieldTypes.Basic
        };

        var response = await GooglePlaces.Search.FindSearch.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);

        var candidate = response.Candidates.FirstOrDefault();
        Assert.IsNotNull(candidate);
        Assert.IsNotNull(candidate.Name);
        Assert.IsNotNull(candidate.Icon);
        Assert.IsNotNull(candidate.PlaceId);
        Assert.IsNotNull(candidate.Geometry);
        Assert.IsNotNull(candidate.Geometry.Location);
        Assert.IsNotNull(candidate.Geometry.ViewPort);
    }

    [Test]
    public async Task PlacesFindSearchWhenLocationBiasAndIpBiasTest()
    {
        var request = new PlacesFindSearchRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 København",
            LocationBias = new LocationBias
            {
                IpBias = true
            }
        };

        var response = await GooglePlaces.Search.FindSearch.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    [Ignore("Google documentation states that 'point' bias is possible, but Google returns invalid request")]
    public async Task PlacesFindSearchWhenLocationBiasAndPointTest()
    {
        var request = new PlacesFindSearchRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 København",
            LocationBias = new LocationBias
            {
                Location = new Coordinate(55.69987296762697, 12.552359427579363)
            }
        };

        var response = await GooglePlaces.Search.FindSearch.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public async Task PlacesFindSearchWhenLocationBiasAndCircleTest()
    {
        var request = new PlacesFindSearchRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 København",
            LocationBias = new LocationBias
            {
                Location = new Coordinate(1, 1),
                Radius = 1000
            }
        };

        var response = await GooglePlaces.Search.FindSearch.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public async Task PlacesFindSearchWhenLocationBiasAndRectangularTest()
    {
        var request = new PlacesFindSearchRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 København",
            LocationBias = new LocationBias
            {
                Bounds = new ViewPort(new Coordinate(1, 1), new Coordinate(2, 2))
            }
        };

        var response = await GooglePlaces.Search.FindSearch.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public async Task PlacesFindSearchWhenLocationRestrictionAndCircleTest()
    {
        var request = new PlacesFindSearchRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 København",
            LocationRestriction = new LocationRestriction
            {
                Location = new Coordinate(55.69987296762697, 12.552359427579363),
                Radius = 50000
            }
        };

        var response = await GooglePlaces.Search.FindSearch.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public async Task PlacesFindSearchWhenLocationRestrictionAndRectangularTest()
    {
        var request = new PlacesFindSearchRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 København",
            LocationRestriction = new LocationRestriction
            {
                Bounds = new ViewPort(new Coordinate(54.69987296762697, 11.552359427579363), new Coordinate(56.69987296762697, 13.552359427579363))
            }
        };

        var response = await GooglePlaces.Search.FindSearch.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }
}