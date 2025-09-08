using System;
using System.IO;
using System.Text.Json;
using GoogleApi.Entities.Search.Common;
using GoogleApi.Entities.Search.Common.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests.Search.Common.Converters;

[TestClass]
public class SortExpressionJsonConverterTests
{
    [TestMethod]
    public void CanConvertWhenTrueTest()
    {
        var converter = new SortExpressionJsonConverter();

        var result = converter.CanConvert(typeof(SortExpression));
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void CanConvertWhenFalseTest()
    {
        var converter = new SortExpressionJsonConverter();

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
        var sut = new SortExpressionJsonConverter();

        Assert.ThrowsException<NotImplementedException>(() => sut.Write(writer, new SortExpression(), new JsonSerializerOptions()));
    }
}