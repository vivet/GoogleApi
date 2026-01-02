using System;
using GoogleApi.Entities.Maps.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.GoogleApi.Maps.Common;

[TestClass]
public class PlaceTests
{
    [TestMethod]
    public void ConstructorTest()
    {
        var place = new Place("id");

        Assert.AreEqual("id", place.Id);
    }

    [TestMethod]
    public void ConstructorWhenNullTest()
    {
        Assert.Throws<ArgumentNullException>(() => new Place(null));
    }

    [TestMethod]
    public void ToStringTest()
    {
        var place = new Place("id");

        var toString = place.ToString();
        Assert.AreEqual(place.Id, toString);
    }

    [TestMethod]
    public void ToStringWhenPrefixTest()
    {
        var place = new Place("id");
        const string PREFIX = "place_id";

        var toString = place.ToString(PREFIX);
        Assert.AreEqual($"{PREFIX}:{place.Id}", toString);
    }
}