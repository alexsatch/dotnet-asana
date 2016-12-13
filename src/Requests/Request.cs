using System;
using System.Net.Http;

namespace Asana.Requests
{
    /// <summary>
    /// Encapsulates all the inputs to a request, including the path, query string, headers, and body.
    /// A single HTTP request can be initiated using the "Execute" or "ExecuteRaw" methods, or for collections methods
    /// the CollectionRequest subclass can be used as an IEnumerable.
    /// </summary>
    public abstract class Request
    {
        private readonly Client client;
        public readonly HttpMethod Method;
        public readonly string Path;

        public readonly HttpRequestMessage Message;

        protected Request(Client client, string path, string method)
        {
            this.client = client;
            this.Path = path;
            this.Method = ParseHttpMethod(method);
            this.Message = new HttpRequestMessage(this.Method, path);
        }

        protected HttpResponseMessage ExecuteRaw()
        {
            return this.client.Execute(this);
        }

        private static HttpMethod ParseHttpMethod(string method)
        {
            switch (method)
            {
                case "GET":
                    return HttpMethod.Get;
                case "PUT":
                    return HttpMethod.Put;
                case "POST":
                    return HttpMethod.Post;
                case "DELETE":
                    return HttpMethod.Delete;
                default:
                    throw new ArgumentException("method");
            }
        }
    }
}