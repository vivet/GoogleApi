using System.Linq;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.AutoComplete.Request.Enums;
using GoogleApi.Entities.Places.Common;
using NUnit.Framework;

namespace GoogleApi.Test.Places.AutoComplete;

[TestFixture]
public class AutoCompleteTests : BaseTest
{
    [Test]
    public async Task PlacesAutoCompleteTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 KÝbenhavn"
        };

        var response = await GooglePlaces.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);

        var results = response.Predictions.ToArray();
        Assert.IsNotNull(results);
        Assert.IsNotEmpty(results);
        Assert.AreEqual(3, results.Length);

        var result = results.FirstOrDefault();
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.Terms);
        Assert.IsNotNull(result.PlaceId);
        Assert.IsNotNull(result.StructuredFormatting);

        var description = result.Description.ToLower();
        Assert.IsTrue(description.Contains("2200"), "1");
        Assert.IsTrue(description.Contains("jagtvej"), "2");

        var matchedSubstrings = result.MatchedSubstrings.ToArray();
        Assert.IsNotNull(matchedSubstrings);
        Assert.AreEqual(2, matchedSubstrings.Length);

        var types = result.Types.ToArray();
        Assert.IsNotNull(types);
        Assert.Contains(PlaceLocationType.Route, types);
        Assert.Contains(PlaceLocationType.Geocode, types);
    }

    [Test]
    public async Task PlacesAutoCompleteWhenLanguageTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 KÝbenhavn",
            Language = Language.Danish
        };

        var response = await GooglePlaces.AutoComplete.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);

        var results = response.Predictions.ToArray();
        Assert.IsNotNull(results);
        Assert.IsNotEmpty(results);
        Assert.GreaterOrEqual(results.Length, 2);

        var result = results.FirstOrDefault();
        Assert.IsNotNull(result);

        var description = result.Description.ToLower();
        Assert.IsTrue(description.Contains("2200"), "1");
        Assert.IsTrue(description.Contains("jagtvej"), "2");
    }

    [Test]
    public async Task PlacesAutoCompleteWhenOffsetTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 KÝbenhavn",
            Offset = "offset"
        };

        var response = await GooglePlaces.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public async Task PlacesAutoCompleteWhenLocationTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 KÝbenhavn",
            Location = new Coordinate(1, 1)
        };

        var response = await GooglePlaces.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public async Task PlacesAutoCompleteWhenLocationAndRadiusTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 KÝbenhavn",
            Radius = 100
        };

        var response = await GooglePlaces.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public async Task PlacesAutoCompleteWhenLocationAndRadiusAndRegionTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 KÝbenhavn",
            Radius = 100,
            Region = "KÝbenhavn"
        };

        var response = await GooglePlaces.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public async Task PlacesAutoCompleteWhenLocationBiasAndIpBiasTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 KÝbenhavn",
            LocationBias = new LocationBias
            {
                IpBias = true
            }
        };

        var response = await GooglePlaces.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    [Ignore("Google documentation states that 'point' bias is possible, but returns invalid request")]
    public async Task PlacesAutoCompleteWhenLocationBiasAndPointTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 KÝbenhavn",
            LocationBias = new LocationBias
            {
                Location = new Coordinate(55.69987296762697, 12.552359427579363)
            }
        };

        var response = await GooglePlaces.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public async Task PlacesAutoCompleteWhenLocationBiasAndCircleTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 KÝbenhavn",
            LocationBias = new LocationBias
            {
                Location = new Coordinate(1, 1),
                Radius = 1000
            }
        };

        var response = await GooglePlaces.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public async Task PlacesAutoCompleteWhenLocationBiasAndRectangularTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 KÝbenhavn",
            LocationBias = new LocationBias
            {
                Bounds = new ViewPort(new Coordinate(1, 1), new Coordinate(2, 2))
            }
        };

        var response = await GooglePlaces.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public async Task PlacesAutoCompleteWhenLocationRestrictionAndCircleTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 KÝbenhavn",
            LocationRestriction = new LocationRestriction
            {
                Location = new Coordinate(55.69987296762697, 12.552359427579363),
                Radius = 50000
            }
        };

        var response = await GooglePlaces.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public async Task PlacesAutoCompleteWhenLocationRestrictionAndRectangularTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 KÝbenhavn",
            LocationRestriction = new LocationRestriction
            {
                Bounds = new ViewPort(new Coordinate(54.69987296762697, 11.552359427579363), new Coordinate(56.69987296762697, 13.552359427579363))
            }
        };

        var response = await GooglePlaces.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public async Task PlacesAutoCompleteWhenRestrictTypeTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 KÝbenhavn",
            RestrictType = RestrictPlaceType.Address
        };

        var response = await GooglePlaces.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public async Task PlacesAutoCompleteWhenRestrictTypeCitiesTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "KÝbenhavn",
            RestrictType = RestrictPlaceType.Cities
        };

        var response = await GooglePlaces.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public async Task PlacesAutoCompleteWhenRestrictTypeRegionsTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "Denmark",
            RestrictType = RestrictPlaceType.Regions
        };

        var response = await GooglePlaces.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public async Task PlacesAutoCompleteWhenRestrictTypeGeocodeAndEstablishmentTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "Denmark",
            RestrictType = RestrictPlaceType.GeocodeAndEstablishment
        };

        var response = await GooglePlaces.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public async Task PlacesAutoCompleteWhenLocationTypesGeocodeAndEstablishmentTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "Denmark",
            LocationTypes = new[]
            {
                PlaceLocationType.Cafe,
                PlaceLocationType.Book_Store
            }
        };

        var response = await GooglePlaces.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }
}