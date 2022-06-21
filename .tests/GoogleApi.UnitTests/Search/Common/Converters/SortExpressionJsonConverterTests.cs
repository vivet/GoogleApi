using System;
using System.IO;
using GoogleApi.Entities.Search.Common;
using GoogleApi.Entities.Search.Common.Converters;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Search.Common.Converters;

[TestFixture]
public class SortExpressionJsonConverterTests
{
    [Test]
    public void CanConvertWhenTrueTest()
    {
        var converter = new SortExpressionJsonConverter();

        var result = converter.CanConvert(typeof(SortExpression));
        Assert.IsTrue(result);
    }

    [Test]
    public void CanConvertWhenFalseTest()
    {
        var converter = new SortExpressionJsonConverter();

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
        var writer = new JsonTextWriter(TextWriter.Null);
        var serializer = new JsonSerializer();
        var converter = new SortExpressionJsonConverter();

        Assert.Throws<NotImplementedException>(() => converter.WriteJson(writer, new object(), serializer));
    }
}