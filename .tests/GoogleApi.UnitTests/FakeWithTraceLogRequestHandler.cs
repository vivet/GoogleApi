using RichardSzalay.MockHttp;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
#if NETCOREAPP3_1_OR_GREATER
using System.Text.Json;
#else
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
#endif

namespace GoogleApi.UnitTests
{

    public interface ILogger
    {
        void WriteLine(string message);
    }

    internal class ConsoleLogger : ILogger
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class FakeWithTraceLogRequestHandler : DelegatingHandler
    {
        private readonly ILogger _logger;
        private const string ApplicationJson = "application/json";

        public FakeWithTraceLogRequestHandler() : this(new ConsoleLogger())
        {

        }

        public FakeWithTraceLogRequestHandler(ILogger logger)
        {
            _logger = logger;

            InnerHandler = new MockHttpMessageHandler();
        }

        public HttpClient ToHttpClient() => new HttpClient((HttpMessageHandler)this);

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            _logger.WriteLine($"{request.Method} --> {request.RequestUri}");
            if (request.Headers.Any())
                _logger.WriteLine($"  Headers --> {request.Headers}");

            TraceWriteContent(request.Content);

            return base.SendAsync(request, cancellationToken).ContinueWith(ctx =>
            {
                var result = ctx.Result;

                _logger.WriteLine($"   ---> Response Status = {result.StatusCode} ({(int)ctx.Result.StatusCode})");

                if (result.StatusCode == HttpStatusCode.Created)
                {
                    _logger.WriteLine($"   ---> Location => {result.Headers.Location}");
                }

                TraceWriteContent(result.Content);

                return ctx.Result;
            }, cancellationToken);
        }

        protected void TraceWriteContent(HttpContent content)
        {
            if (content == null) return;

            var (contentType, contentText) = ReadBody(content);

            _logger.WriteLine($"    --> ContentType: {contentType}");

            if (contentType.Equals(ApplicationJson))
            {
                contentText = FormattedJson(contentText);
            }
            else if (contentType.Equals("text/plain") || (contentType.Equals("text/html")))
            {
                // Do nothing special, just print the body
            }
            else
            {
                contentText = "       --> [content type is not traced]";
            }

            _logger.WriteLine(new string('-', 50));
            _logger.WriteLine(contentText);
        }

        protected virtual (string, string) ReadBody(HttpContent content)
        {
            var body = string.Empty;
            var contentType = content.Headers.ContentType?.MediaType ?? "<NOT SET>";
            if (new[]
            {
                ApplicationJson,
                "text/plain",
                "text/html"
            }.Any(x => x.Equals(contentType)))
            {
                body = content.ReadAsStringAsync().Result;

                if (string.IsNullOrWhiteSpace(body)) Console.WriteLine("   ---> No Content");
            }

            return (contentType, body);
        }

#if NETCOREAPP3_1_OR_GREATER

        private static string FormattedJson(string content)
        {
            var settings = new JsonSerializerOptions()
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new CustomJsonStringEnumConverter(JsonNamingPolicy.CamelCase, true) }
            };

            return JsonSerializer.Serialize(JsonSerializer.Deserialize(content, typeof(object)), settings);
        }
#else
        private static string FormattedJson(string content)
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
                Converters = { new Newtonsoft.Json.Converters.StringEnumConverter() }
            };

            return JsonConvert.SerializeObject(JsonConvert.DeserializeObject(content, settings), settings);
        }
#endif
    }
}