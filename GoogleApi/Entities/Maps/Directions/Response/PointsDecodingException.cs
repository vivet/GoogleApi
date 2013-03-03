using System;
using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Directions.Response
{
	[Serializable]
	public class PointsDecodingException : Exception
	{
		//
		// For guidelines regarding the creation of new exception types, see
		//    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
		// and
		//    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
		//

		public string EncodedString { get; set; }

		public PointsDecodingException()
		{
		}

        public PointsDecodingException(string _message)
            : base(_message)
		{
		}

        public PointsDecodingException(string _message, string _encodedString, Exception _inner)
            : base(_message, _inner)
		{
            EncodedString = _encodedString;
		}

		protected PointsDecodingException(
			SerializationInfo _info,
			StreamingContext _context) : base(_info, _context)
		{
		}
	}
}