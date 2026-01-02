using System;
using System.IO;
using System.Text.Json;
using GoogleApi.Entities.Search.Common;
using GoogleApi.Entities.Search.Common.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.GoogleApi.Search.Common.Converters;

[TestClass]
public class DateRestrictJsonConverterTests
{
    [TestMethod]
    public void CanConvertWhenTrueTest()
    {
        var converter = new DateRestrictJsonConverter();

        var result = converter.CanConvert(typeof(DateRestrict));
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void CanConvertWhenFalseTest()
    {
        var converter = new DateRestrictJsonConverter();

        var result = converter.CanConvert(typeof(object));
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReadJsonTest()
    {
        Assert.Inconclusive();
    }

    [TestMethod]
    public void WriteJsonTest()
    {
        var writer = new Utf8JsonWriter(new MemoryStream());
        var sut = new DateRestrictJsonConverter();

        Assert.Throws<NotImplementedException>(() => sut.Write(writer, new DateRestrict(), new JsonSerializerOptions()));
    }
}