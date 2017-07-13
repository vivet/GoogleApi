using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GoogleApi.Test
{
    [TestFixture]
    public abstract class BaseTest
    {
        protected virtual AppSettings Settings { get; private set; }
        protected virtual string ApiKey => this.Settings.ApiKey;
        protected virtual string CryptoKey => this.Settings.CryptoKey;
        protected virtual string ClientId => this.Settings.ClientId;
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

            [DataMember(Name = "CryptoKey")]
            public string CryptoKey { get; set; }

            [DataMember(Name = "ClientId")]
            public string ClientId { get; set; }

            [DataMember(Name = "SearchEngineId")]
            public string SearchEngineId { get; set; }

            [DataMember(Name = "SearchEngineUrl")]
            public string SearchEngineUrl { get; set; }
        }
    }
}