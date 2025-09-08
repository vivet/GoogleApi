using System;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.TimeZone.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.Test.Maps.TimeZone;

[TestClass]
public class TimeZoneTests : BaseTest
{
    [TestMethod]
    public async Task TimeZoneTest()
    {
        var location = new Coordinate(40.7141289, -73.9614074);
        var request = new TimeZoneRequest
        {
            Key = this.Settings.ApiKey,
            Location = location
        };

        var response = await GoogleMaps.TimeZone.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [TestMethod]
    public async Task TimeZoneWhenLanguageTest()
    {
        var location = new Coordinate(40.7141289, -73.9614074);
        var request = new TimeZoneRequest
        {
            Key = this.Settings.ApiKey,
            Location = location,
            Language = Language.German
        };

        var response = await GoogleMaps.TimeZone.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [TestMethod]
    public async Task TimeZoneWhenTimeStampTest()
    {
        var location = new Coordinate(40.7141289, -73.9614074);
        var request = new TimeZoneRequest
        {
            Key = this.Settings.ApiKey,
            Location = location,
            TimeStamp = DateTime.Now.AddMonths(6)
        };

        var response = await GoogleMaps.TimeZone.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }
}