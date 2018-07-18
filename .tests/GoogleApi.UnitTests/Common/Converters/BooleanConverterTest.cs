using System;
using System.IO;
using GoogleApi.Entities.Common.Converters;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Common.Converters
{
    [TestFixture]
    public class BooleanConverterTest
    {
        [Test]
        public void CanConvertWhenTrueTest()
        {
            var converter = new StringBooleanConverter();

            var result = converter.CanConvert(typeof(string));
            Assert.IsTrue(result);
        }

        [Test]
        public void CanConvertWhenFalseTest()
        {
            var converter = new StringBooleanConverter();

            var result = converter.CanConvert(typeof(object));
            Assert.IsFalse(result);
        }

        [Test]
        public void ReadJsonWhenTrueTest()
        {
            var reader = new JsonTextReader(new StringReader("1"));
            var serializer = new JsonSerializer();
            var converter = new StringBooleanConverter();

            var result = converter.ReadJson(reader, typeof(string), null, serializer);
            Assert.IsTrue((bool)result);
        }

        [Test]
        public void ReadJsonWhenFalseTest()
        {
            var reader = new JsonTextReader(new StringReader("0"));
            var serializer = new JsonSerializer();
            var converter = new StringBooleanConverter();

            var result = converter.ReadJson(reader, typeof(string), null, serializer);
            Assert.IsFalse((bool)result);
        }

        [Test]
        public void WriteJsonTest()
        {
            var writer = new JsonTextWriter(TextWriter.Null);
            var serializer = new JsonSerializer();
            var converter = new StringBooleanConverter();

            Assert.Throws<NotImplementedException>(() => converter.WriteJson(writer, new object(), serializer));
        }
    }
}