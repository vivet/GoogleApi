using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GoogleApi.Test
{
    // TODO: Implement: New Forward Geocoder FAQ (https://developers.google.com/maps/documentation/geocoding/faq)
    // TODO: Implement: Search response (opensearch spec, Search Request Fields (https://developers.google.com/custom-search/json-api/v1/performance))

    [TestFixture]
    public abstract class BaseTest
    {
        protected virtual AppSettings Settings { get; private set; }

        protected virtual string ApiKey => this.Settings.ApiKey;
        protected virtual string SearchEngineId => this.Settings.SearchEngineId;
        protected virtual string SearchEngineUrl => this.Settings.SearchEngineUrl;

        [OneTimeSetUp]
        public virtual void Setup()
        {
            var directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent?.Parent;
            var fileInfo = directoryInfo?.GetFiles().FirstOrDefault(x => x.Name == "application.json") ?? directoryInfo?.GetFiles().FirstOrDefault(x => x.Name == "application.default.json");

            if (fileInfo == null)
                throw new NullReferenceException("fileinfo");

            using (var file = File.OpenText(fileInfo.FullName))
            {
                using (var reader = new JsonTextReader(file))
                {
                    var jsonSerializer = new JsonSerializer();
                    this.Settings = jsonSerializer.Deserialize<AppSettings>(reader);
                }
            }
        }

        [DataContract]
        public class AppSettings
        {
            [DataMember(Name = "ApiKey")]
            public string ApiKey { get; set; }

            [DataMember(Name = "SearchEngineId")]
            public string SearchEngineId { get; set; }

            [DataMember(Name = "SearchEngineUrl")]
            public string SearchEngineUrl { get; set; }
        }
    }
}