using System.Net.Http;
using System.Threading.Tasks;

namespace Asana
{
    public interface IDispatcher
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}