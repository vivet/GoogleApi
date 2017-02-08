using System;
using System.IO;
using GoogleApi.Extensions;
using NUnit.Framework;

namespace GoogleApi.Test.Extensions
{
    [TestFixture]
    public class StreamExtensionTest
    {
        [Test]
        public void JsonDeserializeTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void JsonDeserializeWhenStreamIsNullTest()
        {
            Assert.Throws<ArgumentNullException>(() => ((MemoryStream)null).JsonDeserialize<object>());
        }
    }
}