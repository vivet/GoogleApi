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
            var type = typeof(WebClientExtension);
            var fieldInfo = type.GetField("PreCancelledTask", BindingFlags.NonPublic | BindingFlags.Static);
            var value = fieldInfo == null ? null : (Task<byte[]>)fieldInfo.GetValue(null);
        
            Assert.IsNotNull(value);
            Assert.IsTrue(value.IsCanceled);
        }

        [Test]
        public void DefaultTimeoutTest()
        {
            Assert.AreEqual(WebClientExtension.DefaultTimeout, TimeSpan.FromMilliseconds(-1));
        }
        
        [Test]
        public void DownloadDataTaskAsyncTest()
        {
            var uri = new Uri("https://www.google.com");
            var timout = new TimeSpan(0, 0, 30);
            var webClient = new WebClient();
            var result = webClient.DownloadDataTaskAsync(uri, timout).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(byte[]), result.GetType());
        }
        [Test]
        public void DownloadDataTaskAsyncWhenWebClientIsNullTest()
        {
            var uri = new Uri("https://test.com");
            var exception = Assert.Throws<ArgumentNullException>(() => ((WebClient)null).DownloadDataTaskAsync(uri, new TimeSpan(0, 0, 0, 30)));
    
            Assert.AreEqual("webClient", exception.ParamName);
        }
        [Test]
        public void DownloadDataTaskAsyncWhenUriIsNullTest()
        {
            var webClient = new WebClient();
            var exception = Assert.Throws<ArgumentNullException>(() => webClient.DownloadDataTaskAsync(null, new TimeSpan(0, 0, 0, 30)));
         
            Assert.AreEqual("uri", exception.ParamName);
        }

        [Test]
        public void DownloadDataTaskAsyncWhenCancellationTokenTest()
        {
            var uri = new Uri("https://www.google.com");
            var cancellationToken = new CancellationToken();
            var webClient = new WebClient();

            var result = webClient.DownloadDataTaskAsync(uri, cancellationToken).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(byte[]), result.GetType());
        }
        [Test]
        public void DownloadDataTaskAsyncWhenCancellationTokenAndWebClientIsNullTest()
        {
            var uri = new Uri("https://test.com");
            var exception = Assert.Throws<ArgumentNullException>(() => ((WebClient)null).DownloadDataTaskAsync(uri, new CancellationToken()));

            Assert.AreEqual("webClient", exception.ParamName);
        }
        [Test]
        public void DownloadDataTaskAsyncWhenCancellationTokenAndUriIsNullTest()
        {
            var webClient = new WebClient();
            var exception = Assert.Throws<ArgumentNullException>(() => webClient.DownloadDataTaskAsync(null, new CancellationToken()));

            Assert.AreEqual("uri", exception.ParamName);
        }

        [Test]
        public void DownloadDataTaskAsyncWhenCancellationTokenAndTimeoutTest()
        {
            var uri = new Uri("https://www.google.com");
            var timout = new TimeSpan(0, 0, 30);
            var cancellationToken = new CancellationToken();
            var webClient = new WebClient();

            var result = webClient.DownloadDataTaskAsync(uri, timout, cancellationToken).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(byte[]), result.GetType());
        }
        [Test]
        public void DownloadDataTaskAsyncWhenCancellationTokenAndTimeoutAndWebClientIsNullTest()
        {
            var uri = new Uri("https://test.com");
            var exception = Assert.Throws<ArgumentNullException>(() => ((WebClient)null).DownloadDataTaskAsync(uri, new TimeSpan(0, 0, 0, 30), new CancellationToken()));

            Assert.AreEqual("webClient", exception.ParamName);
        }  
        [Test]
        public void DownloadDataTaskAsyncWhenCancellationTokenAndTimeoutAndUriIsNullTest()
        {
            var webClient = new WebClient();
            var exception = Assert.Throws<ArgumentNullException>(() => webClient.DownloadDataTaskAsync(null, new TimeSpan(0, 0, 0, 30), new CancellationToken()));

            Assert.AreEqual("uri", exception.ParamName);
        }  
    }
}
