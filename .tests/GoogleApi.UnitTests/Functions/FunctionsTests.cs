using GoogleApi.Entities.Common;
using NUnit.Framework;
using System;
using System.Linq;

namespace GoogleApi.UnitTests.Functions
{
    [TestFixture]
    public class FunctionsTests
    {
        private const string POLY_LINE = "chdEchdEoxgFoxgFi`vEi`vE";
        private const string POLY_LINE_2 = "cbb|@cbb|@ore}@ore}@izs|@izs|@";

        private readonly Coordinate location1 = new Coordinate(1.0101, 1.0101);
        private readonly Coordinate location2 = new Coordinate(2.20202, 2.20202);
        private readonly Coordinate location3 = new Coordinate(3.30303, 3.30303);
        private readonly Coordinate location4 = new Coordinate(10.0101, 10.0101);
        private readonly Coordinate location5 = new Coordinate(20.20202, 20.20202);
        private readonly Coordinate location6 = new Coordinate(30.30303, 30.30303);

        [Test]
        public void EncodePolyLineTest()
        {
            var locations = new[] { new Coordinate(1.0101, 1.0101), new Coordinate(2.20202, 2.20202), new Coordinate(3.30303, 3.30303) };
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
            Assert.AreEqual(decodePolyLine[0].ToString(), location1.ToString());
            Assert.AreEqual(decodePolyLine[1].ToString(), location2.ToString());
            Assert.AreEqual(decodePolyLine[2].ToString(), location3.ToString());
            Assert.AreEqual(decodePolyLine[3].ToString(), location4.ToString());
            Assert.AreEqual(decodePolyLine[4].ToString(), location5.ToString());
            Assert.AreEqual(decodePolyLine[5].ToString(), location6.ToString());
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
            Assert.AreEqual(decodePolyLine[0].ToString(), location1.ToString());
            Assert.AreEqual(decodePolyLine[1].ToString(), location2.ToString());
            Assert.AreEqual(decodePolyLine[2].ToString(), location3.ToString());


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
