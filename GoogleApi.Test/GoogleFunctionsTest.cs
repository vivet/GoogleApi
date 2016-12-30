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
            var locations = new[] { new Location(1.0101, 1.0101), new Location(2.20202, 2.20202), new Location(3.30303, 3.30303) };
            var encodePolyLine = GoogleFunctions.EncodePolyLine(locations);

            Assert.IsNotEmpty(encodePolyLine);
            Assert.AreEqual(GoogleFunctionsTest.POLY_LINE, encodePolyLine);
        }
        [Test]
        public void EncodePolyLineWhenLocationsIsNullTest()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => GoogleFunctions.EncodePolyLine(null));
            Assert.AreEqual("locations", exception.ParamName);
        }

        [Test]
        public void MergePolyLineTest()
        {
            var mergePolyLine = GoogleFunctions.MergePolyLine(GoogleFunctionsTest.POLY_LINE, GoogleFunctionsTest.POLY_LINE_2);

            Assert.IsNotNull(mergePolyLine);
            Assert.AreEqual("chdEchdEoxgFoxgFi`vEi`vEe~|g@e~|g@ore}@ore}@izs|@izs|@", mergePolyLine);

            var decodePolyLine = GoogleFunctions.DecodePolyLine(mergePolyLine).ToArray();

            Assert.IsNotEmpty(decodePolyLine);
            Assert.AreEqual(6, decodePolyLine.Length);
            Assert.AreEqual(decodePolyLine[0].LocationString, _location1.LocationString);
            Assert.AreEqual(decodePolyLine[1].LocationString, _location2.LocationString);
            Assert.AreEqual(decodePolyLine[2].LocationString, _location3.LocationString);
            Assert.AreEqual(decodePolyLine[3].LocationString, _location4.LocationString);
            Assert.AreEqual(decodePolyLine[4].LocationString, _location5.LocationString);
            Assert.AreEqual(decodePolyLine[5].LocationString, _location6.LocationString);
        }
        [Test]
        public void MergePolyLineWhenEncdodedLocationsIsNullTest()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => GoogleFunctions.MergePolyLine(null));
            Assert.AreEqual("encdodedLocations", exception.ParamName);
        }

        [Test]
        public void DecodePolyLineTest()
        {
            var decodePolyLine = GoogleFunctions.DecodePolyLine(GoogleFunctionsTest.POLY_LINE).ToArray();

            Assert.IsNotEmpty(decodePolyLine);
            Assert.AreEqual(3, decodePolyLine.Length);
            Assert.AreEqual(decodePolyLine[0].LocationString, _location1.LocationString);
            Assert.AreEqual(decodePolyLine[1].LocationString, _location2.LocationString);
            Assert.AreEqual(decodePolyLine[2].LocationString, _location3.LocationString);


        }
        [Test]
        public void DecodePolyLineWhenEncdodedLocationsIsNullTest()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
            {
                var decodePolyLine = GoogleFunctions.DecodePolyLine(null);
                Assert.IsNull(decodePolyLine);
            });
            Assert.AreEqual("encdodedLocations", exception.ParamName);
        }
    }
}
