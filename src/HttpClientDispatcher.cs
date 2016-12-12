using System.Net.Http;
using System.Threading.Tasks;

namespace Asana
{
    public class HttpClientDispatcher : IDispatcher
    {
        private readonly HttpClient httpClient;

        public HttpClientDispatcher()
            : this(new HttpClient())
        { }

        public HttpClientDispatcher(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return httpClient.SendAsync(request);
        }
    }
}