using System;
using System.IO;
using GoogleApi.Entities.Common.Converters;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Common.Converters
{
    [TestFixture]
    public class StringEnumListConverterTest
    {
        [Test]
        public void CanConvertWhenTrueTest()
        {
            var converter = new StringEnumListConverter<DayOfWeek>();

            var result = converter.CanConvert(typeof(DayOfWeek));
            Assert.IsTrue(result);
        }

        [Test]
        public void CanConvertWhenFalseTest()
        {
            var converter = new StringEnumListConverter<decimal>();

            var result = converter.CanConvert(typeof(DayOfWeek));
            Assert.IsFalse(result);
        }

        [Test]
        public void ReadJsonWhenTrueTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void WriteJsonTest()
        {
            var writer = new JsonTextWriter(TextWriter.Null);
            var serializer = new JsonSerializer();
            var converter = new StringEnumListConverter<DayOfWeek>();

            Assert.Throws<NotImplementedException>(() => converter.WriteJson(writer, new object(), serializer));
        }
    }
}