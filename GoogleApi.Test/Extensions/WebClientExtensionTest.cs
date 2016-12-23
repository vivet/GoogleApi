using System;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using GoogleApi.Extensions;

namespace GoogleApi.Test.Extensions
{
    [TestFixture]
    public class WebClientExtensionTest
    {
        [Test]
        public void StaticConstructorInitializesPreCancelledTaskTest()
        {
            var _type = typeof(WebClientExtension);
            var _fieldInfo = _type.GetField("_preCancelledTask", BindingFlags.NonPublic | BindingFlags.Static);
            var _value = _fieldInfo == null ? null : (Task<byte[]>)_fieldInfo.GetValue(null);
        
            Assert.IsNotNull(_value);
            Assert.IsTrue(_value.IsCanceled);
        }

        [Test]
        public void DefaultTimeoutTest()
        {
            Assert.AreEqual(WebClientExtension.DefaultTimeout, TimeSpan.FromMilliseconds(-1));
        }
        
        [Test]
        public void DownloadDataTaskAsyncTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void DownloadDataTaskAsyncWhenWebClientIsNullTest()
        {
            var _uri = new Uri("https://test.com");
            var _exception = Assert.Throws<ArgumentNullException>(() => ((WebClient)null).DownloadDataTaskAsync(_uri, new TimeSpan(0, 0, 0, 30)));
    
            Assert.AreEqual("_webClient", _exception.ParamName);
        }
        [Test]
        public void DownloadDataTaskAsyncWhenUriIsNullTest()
        {
            var _webClient = new WebClient();
            var _exception = Assert.Throws<ArgumentNullException>(() => _webClient.DownloadDataTaskAsync(null, new TimeSpan(0, 0, 0, 30)));
         
            Assert.AreEqual("_uri", _exception.ParamName);
        }

        [Test]
        public void DownloadDataTaskAsyncWhenCancellationTokenTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void DownloadDataTaskAsyncWhenCancellationTokenAndWebClientIsNullTest()
        {
            var _uri = new Uri("https://test.com");
            var _exception = Assert.Throws<ArgumentNullException>(() => ((WebClient)null).DownloadDataTaskAsync(_uri, new CancellationToken()));

            Assert.AreEqual("_webClient", _exception.ParamName);
        }
        [Test]
        public void DownloadDataTaskAsyncWhenCancellationTokenAndUriIsNullTest()
        {
            var _webClient = new WebClient();
            var _exception = Assert.Throws<ArgumentNullException>(() => _webClient.DownloadDataTaskAsync(null, new CancellationToken()));

            Assert.AreEqual("_uri", _exception.ParamName);
        }

        [Test]
        public void DownloadDataTaskAsyncWhenCancellationTokenAndTimeoutTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void DownloadDataTaskAsyncWhenCancellationTokenAndTimeoutAndWebClientIsNullTest()
        {
            var _uri = new Uri("https://test.com");
            var _exception = Assert.Throws<ArgumentNullException>(() => ((WebClient)null).DownloadDataTaskAsync(_uri, new TimeSpan(0, 0, 0, 30), new CancellationToken()));

            Assert.AreEqual("_webClient", _exception.ParamName);
        }  
        [Test]
        public void DownloadDataTaskAsyncWhenCancellationTokenAndTimeoutAndUriIsNullTest()
        {
            var _webClient = new WebClient();
            var _exception = Assert.Throws<ArgumentNullException>(() => _webClient.DownloadDataTaskAsync(null, new TimeSpan(0, 0, 0, 30), new CancellationToken()));

            Assert.AreEqual("_uri", _exception.ParamName);
        }  
    }
}
