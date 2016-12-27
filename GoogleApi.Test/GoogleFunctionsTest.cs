using System;
using System.Linq;
using GoogleApi.Entities.Common;
using NUnit.Framework;

namespace GoogleApi.Test
{
    [TestFixture]
    public class GoogleFunctionsTest : BaseTest
	{
        private const string POLY_LINE = "chdEchdEoxgFoxgFi`vEi`vE";
        private const string POLY_LINE_2 = "cbb|@cbb|@ore}@ore}@izs|@izs|@";

        private readonly Location _location1 = new Location(1.0101, 1.0101);
        private readonly Location _location2 = new Location(2.20202, 2.20202);
        private readonly Location _location3 = new Location(3.30303, 3.30303);
        private readonly Location _location4 = new Location(10.0101, 10.0101);
        private readonly Location _location5 = new Location(20.20202, 20.20202);
        private readonly Location _location6 = new Location(30.30303, 30.30303);

        [Test]
        public void EncodePolyLineTest()
        {
            var _locations = new[] { new Location(1.0101, 1.0101), new Location(2.20202, 2.20202), new Location(3.30303, 3.30303) };
            var _encodePolyLine = GoogleFunctions.EncodePolyLine(_locations);

            Assert.IsNotEmpty(_encodePolyLine);
            Assert.AreEqual(GoogleFunctionsTest.POLY_LINE, _encodePolyLine);
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
            var _mergePolyLine = GoogleFunctions.MergePolyLine(GoogleFunctionsTest.POLY_LINE, GoogleFunctionsTest.POLY_LINE_2);

            Assert.IsNotNull(_mergePolyLine);
            Assert.AreEqual("chdEchdEoxgFoxgFi`vEi`vEe~|g@e~|g@ore}@ore}@izs|@izs|@", _mergePolyLine);

            var _decodePolyLine = GoogleFunctions.DecodePolyLine(_mergePolyLine).ToArray();

            Assert.IsNotEmpty(_decodePolyLine);
            Assert.AreEqual(6, _decodePolyLine.Length);
            Assert.AreEqual(_decodePolyLine[0].LocationString, _location1.LocationString);
            Assert.AreEqual(_decodePolyLine[1].LocationString, _location2.LocationString);
            Assert.AreEqual(_decodePolyLine[2].LocationString, _location3.LocationString);
            Assert.AreEqual(_decodePolyLine[3].LocationString, _location4.LocationString);
            Assert.AreEqual(_decodePolyLine[4].LocationString, _location5.LocationString);
            Assert.AreEqual(_decodePolyLine[5].LocationString, _location6.LocationString);
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
            var _decodePolyLine = GoogleFunctions.DecodePolyLine(GoogleFunctionsTest.POLY_LINE).ToArray();

            Assert.IsNotEmpty(_decodePolyLine);
            Assert.AreEqual(3, _decodePolyLine.Length);
            Assert.AreEqual(_decodePolyLine[0].LocationString, _location1.LocationString);
            Assert.AreEqual(_decodePolyLine[1].LocationString, _location2.LocationString);
            Assert.AreEqual(_decodePolyLine[2].LocationString, _location3.LocationString);


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
