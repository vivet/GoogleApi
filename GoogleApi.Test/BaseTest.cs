using System;
using System.IO;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Interfaces;
using NUnit.Framework;

namespace GoogleApi.Test
{
    // TODO: Implement: New Forward Geocoder FAQ (https://developers.google.com/maps/documentation/geocoding/faq)

    [TestFixture]
    public abstract class BaseTest
    {
        // BUG: Create config file for ApiKey and also Search engine id / url.
        protected virtual string ApiKey { get; set; }
        protected virtual string KeyFile { get; set; } = "keyfile.txt";

        [OneTimeSetUp]
        public virtual void Setup()
        {
            try
            {
                var directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent?.Parent?.Parent;
                var fileInfo = directoryInfo?.GetFiles().FirstOrDefault(x => x.Name == this.KeyFile);

                using (var streamReader = new StreamReader(fileInfo?.FullName ?? this.KeyFile))
                {
                    this.ApiKey = streamReader.ReadToEnd();
                }
            }
            catch
            {
                this.ApiKey = string.Empty;
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