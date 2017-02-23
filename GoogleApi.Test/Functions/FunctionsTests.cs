using System;
using System.Linq;
using GoogleApi.Entities.Common;
using NUnit.Framework;

namespace GoogleApi.Test.Functions
{
    [TestFixture]
    public class FunctionsTests : BaseTest
	{
        private const string POLY_LINE = "chdEchdEoxgFoxgFi`vEi`vE";
        private const string POLY_LINE_2 = "cbb|@cbb|@ore}@ore}@izs|@izs|@";

        private readonly Location location1 = new Location(1.0101, 1.0101);
        private readonly Location location2 = new Location(2.20202, 2.20202);
        private readonly Location location3 = new Location(3.30303, 3.30303);
        private readonly Location location4 = new Location(10.0101, 10.0101);
        private readonly Location location5 = new Location(20.20202, 20.20202);
        private readonly Location location6 = new Location(30.30303, 30.30303);

        [Test]
        public void EncodePolyLineTest()
        {
            var locations = new[] { new Location(1.0101, 1.0101), new Location(2.20202, 2.20202), new Location(3.30303, 3.30303) };
            var encodePolyLine = GoogleFunctions.EncodePolyLine(locations);

            Assert.IsNotNull(encodePolyLine.FirstOrDefault());
            Assert.AreEqual(FunctionsTests.POLY_LINE, encodePolyLine);
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
            var mergePolyLine = GoogleFunctions.MergePolyLine(FunctionsTests.POLY_LINE, FunctionsTests.POLY_LINE_2);

            Assert.IsNotNull(mergePolyLine);
            Assert.AreEqual("chdEchdEoxgFoxgFi`vEi`vEe~|g@e~|g@ore}@ore}@izs|@izs|@", mergePolyLine);

            var decodePolyLine = GoogleFunctions.DecodePolyLine(mergePolyLine).ToArray();

            Assert.IsNotNull(decodePolyLine.FirstOrDefault());
            Assert.AreEqual(6, decodePolyLine.Length);
            Assert.AreEqual(decodePolyLine[0].LocationString, location1.LocationString);
            Assert.AreEqual(decodePolyLine[1].LocationString, location2.LocationString);
            Assert.AreEqual(decodePolyLine[2].LocationString, location3.LocationString);
            Assert.AreEqual(decodePolyLine[3].LocationString, location4.LocationString);
            Assert.AreEqual(decodePolyLine[4].LocationString, location5.LocationString);
            Assert.AreEqual(decodePolyLine[5].LocationString, location6.LocationString);
        }
        [Test]
        public void MergePolyLineWhenEncdodedLocationsIsNullTest()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => GoogleFunctions.MergePolyLine(null));
            Assert.AreEqual("encodedLocations", exception.ParamName);
        }

        [Test]
        public void DecodePolyLineTest()
        {
            var decodePolyLine = GoogleFunctions.DecodePolyLine(FunctionsTests.POLY_LINE).ToArray();

            Assert.IsNotNull(decodePolyLine.FirstOrDefault());
            Assert.AreEqual(3, decodePolyLine.Length);
            Assert.AreEqual(decodePolyLine[0].LocationString, location1.LocationString);
            Assert.AreEqual(decodePolyLine[1].LocationString, location2.LocationString);
            Assert.AreEqual(decodePolyLine[2].LocationString, location3.LocationString);


        }
        [Test]
        public void DecodePolyLineWhenEncdodedLocationsIsNullTest()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
            {
                var decodePolyLine = GoogleFunctions.DecodePolyLine(null);
                Assert.IsNull(decodePolyLine);
            });
            Assert.AreEqual("encodedLocations", exception.ParamName);
        }
    }
}
