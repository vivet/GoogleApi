using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Interfaces;
using NUnit.Framework;

namespace GoogleApi.Test
{
    [TestFixture]
    public abstract class BaseTest
    {
        public string _apiKey = ""; // your API key goes here...

        // Nested classes
        public class TestRequest : BaseRequest
        {
            protected override string BaseUrl
            {
                get { return "www.test.com"; }
            }
        }

        public class TestResponse : IResponseFor
        {

        }   
    }
}