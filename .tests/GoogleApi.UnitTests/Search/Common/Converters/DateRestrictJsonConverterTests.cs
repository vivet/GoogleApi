using System;
using System.IO;
using System.Text.Json;
using GoogleApi.Entities.Search.Common;
using GoogleApi.Entities.Search.Common.Converters;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Search.Common.Converters;

[TestFixture]
public class DateRestrictJsonConverterTests
{
    [Test]
    public void CanConvertWhenTrueTest()
    {
        var converter = new DateRestrictJsonConverter();

        var result = converter.CanConvert(typeof(DateRestrict));
        Assert.IsTrue(result);
    }

    [Test]
    public void CanConvertWhenFalseTest()
    {
        var converter = new DateRestrictJsonConverter();

        var result = converter.CanConvert(typeof(object));
        Assert.IsFalse(result);
    }

    [Test]
    public void ReadJsonTest()
    {
        Assert.Inconclusive();
    }

    [Test]
    public void WriteJsonTest()
    {
        var writer = new Utf8JsonWriter(new MemoryStream());
        var sut = new DateRestrictJsonConverter();

        Assert.Throws<NotImplementedException>(() => sut.Write(writer, new DateRestrict(), new JsonSerializerOptions()));
    }
}