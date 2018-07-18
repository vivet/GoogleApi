using System;
using System.IO;
using GoogleApi.Entities.Common.Converters;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Common.Converters
{
    [TestFixture]
    public class StringEnumOrDefaultConverterTest
    {
        [Test]
        public void CanConvertWhenTrueTest()
        {
            var converter = new StringEnumOrDefaultConverter<DayOfWeek>();

            var result = converter.CanConvert(typeof(DayOfWeek));
            Assert.IsTrue(result);
        }

        [Test]
        public void CanConvertWhenFalseTest()
        {
            var converter = new StringEnumOrDefaultConverter<decimal>();

            var result = converter.CanConvert(typeof(DayOfWeek));
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
            var converter = new StringEnumOrDefaultConverter<DayOfWeek>();

            Assert.DoesNotThrow(() => converter.WriteJson(writer, DayOfWeek.Sunday, serializer));
        }
    }
}