using System;
using NUnit.Framework;

namespace GoogleApi.Test
{
    [TestFixture]
    public class GoogleFunctionsTest : BaseTest
	{
        [Test]
        public void EncodePolyLineTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void EncodePolyLineWhenLocationsIsNullTest()
        {
            var _exception = Assert.Throws<ArgumentNullException>(() => GoogleFunctions.EncodePolyLine(null));
            Assert.AreEqual("_locations", _exception.ParamName);
        }

        [Test]
        public void MergePolyLineTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void MergePolyLineWhenEncdodedLocationsIsNullTest()
        {
            var _exception = Assert.Throws<ArgumentNullException>(() => GoogleFunctions.MergePolyLine(null));
            Assert.AreEqual("_encdodedLocations", _exception.ParamName);
        }

        [Test]
        public void DecodePolyLineTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void DecodePolyLineWhenEncdodedLocationsIsNullTest()
        {
            var _exception = Assert.Throws<ArgumentNullException>(() =>
            {
                var _decodePolyLine = GoogleFunctions.DecodePolyLine(null);
                Assert.IsNull(_decodePolyLine);
            });
            Assert.AreEqual("_encdodedLocations", _exception.ParamName);
        }
    }
}
