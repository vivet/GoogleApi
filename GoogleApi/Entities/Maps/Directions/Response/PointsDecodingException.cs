using System;
using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Directions.Response
{
	[Serializable]
	public class PointsDecodingException : Exception
	{
		// For guidelines regarding the creation of new exception types, see
		//    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
		// and
		//    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp

        public virtual string EncodedString { get; set; }

		public PointsDecodingException()
		{
		}

        public PointsDecodingException(string message)
            : base(message)
		{
		}

        public PointsDecodingException(string message, string encodedString, Exception inner)
            : base(message, inner)
		{
            EncodedString = encodedString;
		}

		protected PointsDecodingException(
			SerializationInfo info,
			StreamingContext context) : base(info, context)
		{
		}
	}
}