using System.Linq;
using System.Threading.Tasks;
using GoogleApi;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.PlacesNew.AutoComplete.Request;
using GoogleApi.Entities.PlacesNew.Common;
using GoogleApi.Entities.PlacesNew.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests.GoogleApi.PlacesNew.AutoComplete;

[TestClass]
public class AutoCompleteNewTests : BaseTest
{
    [TestMethod]
    public async Task PlacesNewAutoCompleteTest()
    {
        var request = new PlacesNewAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 København"
        };

        var response = await GooglePlacesNew.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);

        var results = response.Suggestions.ToArray();
        Assert.IsNotNull(results);
        Assert.AreEqual(3, results.Length);

        var result = results.FirstOrDefault();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task PlacesNewAutoCompleteWhenIncludedPrimaryTypesTest()
    {
        var request = new PlacesNewAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 København",
            IncludedPrimaryTypes = 
            [
                PlaceLocationTypeAb.Geocode
            ]
        };

        var response = await GooglePlacesNew.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);

        var results = response.Suggestions.ToArray();
        Assert.IsNotNull(results);
        Assert.AreEqual(1, results.Length);

        var result = results.FirstOrDefault();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task PlacesNewAutoCompleteWhenIncludePureServiceAreaBusinessesTrueTest()
    {
        var request = new PlacesNewAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 København",
            IncludePureServiceAreaBusinesses = true
        };

        var response = await GooglePlacesNew.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);

        var results = response.Suggestions.ToArray();
        Assert.IsNotNull(results);
        Assert.AreEqual(3, results.Length);

        var result = results.FirstOrDefault();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task PlacesNewAutoCompleteWhenIncludePureServiceAreaBusinessesFalseTest()
    {
        var request = new PlacesNewAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 København",
            IncludePureServiceAreaBusinesses = true
        };

        var response = await GooglePlacesNew.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);

        var results = response.Suggestions.ToArray();
        Assert.IsNotNull(results);
        Assert.AreEqual(3, results.Length);

        var result = results.FirstOrDefault();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task PlacesNewAutoCompleteIncludeQueryPredictionsTest()
    {
        var request = new PlacesNewAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "pizza",
            IncludeQueryPredictions = true
        };

        var response = await GooglePlacesNew.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);

        var results = response.Suggestions.ToArray();
        Assert.IsNotNull(results);
        Assert.AreEqual(5, results.Length);
        Assert.AreEqual(3, results.Count(x => x.PlacePrediction != null));
        Assert.AreEqual(2, results.Count(x => x.QueryPrediction != null));
    }

    [TestMethod]
    public async Task PlacesNewAutoCompleteWhenIncludedRegionCodesTest()
    {
        await Task.CompletedTask;

        Assert.Inconclusive();
    }

    [TestMethod]
    public async Task PlacesNewAutoCompleteWhenInputOffsetTest()
    {
        var request = new PlacesNewAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 København",
            InputOffset = 3
        };

        var response = await GooglePlacesNew.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);

        var results = response.Suggestions.ToArray();
        Assert.IsNotNull(results);
        Assert.AreEqual(5, results.Length);
    }

    [TestMethod]
    public async Task PlacesNewAutoCompleteWhenLanguageTest()
    {
        var request = new PlacesNewAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 København",
            Language = Language.Danish
        };

        var response = await GooglePlacesNew.AutoComplete.QueryAsync(request);
        
        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);

        var results = response.Suggestions.ToArray();
        Assert.IsNotNull(results);
        Assert.AreEqual(3, results.Length);
    }

    [TestMethod]
    public async Task PlacesNewAutoCompleteWhenLocationBiasCircleTest()
    {
        var request = new PlacesNewAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "Art museum",
            LocationBias = new WithinCirle
            {
                Circle = new Circle
                {
                    Center = new LatLng
                    {
                        Latitude = 37.7749,
                        Longitude = -122.4194
                    },
                    Radius = 1000
                }
            }
        };

        var response = await GooglePlacesNew.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);

        var results = response.Suggestions.ToArray();
        Assert.IsNotNull(results);
        Assert.AreEqual(5, results.Length);
    }

    [TestMethod]
    public async Task PlacesNewAutoCompleteWhenLocationBiasRectangleTest()
    {
        var request = new PlacesNewAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "auto",
            LocationBias = new WithinRectangle
            {
                Rectangle = new Rectangle
                {
                    Low = new LatLng
                    {
                        Latitude = 55.600001654831816,
                        Longitude = 12.455312213341002
                    },
                    High = new LatLng
                    {
                        Latitude = 55.700001654831816,
                        Longitude = 12.555312213341002
                    }
                }
            }
        };

        var response = await GooglePlacesNew.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);

        var results = response.Suggestions.ToArray();
        Assert.IsNotNull(results);
        Assert.AreEqual(5, results.Length);
    }

    [TestMethod]
    public async Task PlacesNewAutoCompleteWhenLocationRestrictionCircleTest()
    {
        var request = new PlacesNewAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "auto",
            LocationRestriction = new WithinCirle
            {
                Circle = new Circle
                {
                    Center = new LatLng
                    {
                        Latitude = 55.700001654831816,
                        Longitude = 12.555312213341002
                    },
                    Radius = 15000
                }
            }
        };

        var response = await GooglePlacesNew.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);

        var results = response.Suggestions.ToArray();
        Assert.IsNotNull(results);
        Assert.AreEqual(5, results.Length);
    }

    [TestMethod]
    public async Task PlacesNewAutoCompleteWhenLocationRestrictionRectangleTest()
    {
        var request = new PlacesNewAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "auto",
            LocationRestriction = new WithinRectangle
            {
                Rectangle = new Rectangle
                {
                    Low = new LatLng
                    {
                        Latitude = 55.600001654831816,
                        Longitude = 12.455312213341002
                    },
                    High = new LatLng
                    {
                        Latitude = 55.700001654831816,
                        Longitude = 12.555312213341002
                    }
                }
            }
        };

        var response = await GooglePlacesNew.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);

        var results = response.Suggestions.ToArray();
        Assert.IsNotNull(results);
        Assert.AreEqual(5, results.Length);
    }

    [TestMethod]
    public async Task PlacesNewAutoCompleteWhenOriginTest()
    {
        var request = new PlacesNewAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 København",
            Origin = new LatLng
            {
                Latitude = 55.700001654831816,
                Longitude = 12.555312213341002
            }
        };

        var response = await GooglePlacesNew.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);

        var results = response.Suggestions.ToArray();
        Assert.IsNotNull(results);
        Assert.AreEqual(3, results.Length);
    }

    [TestMethod]
    public async Task PlacesNewAutoCompleteWhenRegionTest()
    {
        var request = new PlacesNewAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 København",
            Region = "dk"
        };

        var response = await GooglePlacesNew.AutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);

        var results = response.Suggestions.ToArray();
        Assert.IsNotNull(results);
        Assert.AreEqual(3, results.Length);
    }

    [TestMethod]
    public async Task PlacesNewAutoCompleteWhenSessionTokenTest()
    {
        await Task.CompletedTask;

        Assert.Inconclusive();
    }
}