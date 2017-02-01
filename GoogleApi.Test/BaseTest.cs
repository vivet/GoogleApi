using System;
using System.IO;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Interfaces;
using NUnit.Framework;

namespace GoogleApi.Test
{
    [TestFixture]
    public abstract class BaseTest
    {
        public string apiKey; // your API key...

        [OneTimeSetUp]
        public void Setup()
        {
            try
            {
                const string FILENAME = "keyfile.txt";

                var directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent?.Parent?.Parent;
                var fileInfo = directoryInfo?.GetFiles().FirstOrDefault(x => x.Name == FILENAME);

                using (var streamReader = new StreamReader(fileInfo?.FullName ?? FILENAME))
                {
                    this.apiKey = streamReader.ReadToEnd();
                }
            }
            catch
            {
                this.apiKey = string.Empty;
            }
        }

        // Nested classes
        public class TestRequest : BaseRequest
        {
            protected override string BaseUrl => "www.test.com";
        }

        public class TestResponse : IResponseFor
        {

        }   
    }
}