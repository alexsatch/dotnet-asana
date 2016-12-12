using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Asana.Requests;
using Asana.Resources;

namespace Asana
{
    public class Client
    {
        private static readonly IDictionary<string, object> DefaultOptions =
            new Dictionary<string, object>
            {
                {"base_url", "https://app.asana.com/api/1.0"},
                {"item_limit", -1},
                {"page_size", 50},
                {"poll_interval", 5},
                {"max_retries", 5}
            };

        private static readonly string[] ApiOptions = {"pretty", "fields", "expand"};
        private static readonly string[] QueryOptions = {"limit", "offset", "sync"};
        private readonly IDispatcher dispatcher;

        public Client()
            : this(new HttpClientDispatcher())
        {
        }

        public Client(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
            this.Options = new Dictionary<string, object>(Client.DefaultOptions);

            this.Projects = new Projects(this);
        }

        public IDictionary<string, object> Options { get; }

        public Projects Projects { get;  }

        public HttpResponseMessage Execute(Request request)
        {
            throw new System.NotImplementedException();
        }

        public HttpRequestMessage CreateRequest(HttpMethod method, string requestUri)
        {
            var result = new HttpRequestMessage(method, requestUri);
            result.Content = new ByteArrayContent(new byte[] {});
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            ApplyOptions(result, this.Options);

            return result;
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
            => await dispatcher.SendAsync(request);

        private void ApplyOptions(HttpRequestMessage request, IDictionary<string, object> options)
        {
            if (request.Method == HttpMethod.Get)
            {
                foreach (var key in Client.ApiOptions)
                    request.Properties["opt_" + key] = options[key];
                foreach (var key in Client.QueryOptions)
                    request.Properties[key] = options[key];
            }
        }

        public static Client CreateBasicAuth(string apiKey)
        {
            throw new System.NotImplementedException();
        }

        
    }
}