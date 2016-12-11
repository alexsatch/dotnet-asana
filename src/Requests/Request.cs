using System.Collections.Generic;
using System.Net.Http;
using Asana.Resources;

namespace Asana.Requests
{
    /// <summary>
    /// Encapsulates all the inputs to a request, including the path, query string, headers, and body.
    /// A single HTTP request can be initiated using the "Execute" or "ExecuteRaw" methods, or for collections methods
    /// the CollectionRequest subclass can be used as an IEnumerable.
    /// </summary>
    public abstract class Request<T>
    {
        public readonly string Path;
        public readonly string Method;

        protected readonly Client Client;

        public HttpContent Content { get; private set; }

        public IDictionary<string, object> Data { get; private set; }
        public IDictionary<string, object> Query { get; private set; }
        public IDictionary<string, object> Options { get; }
        
        protected Request(Resource resource, string path, string method)
        {
            this.Client = resource.Client;

            this.Path = path;
            this.Method = method;
            this.Content = null;

            this.Data = new Dictionary<string, object>();
            this.Query = new Dictionary<string, object>();
            this.Options = new Dictionary<string, object>(this.Client.Options);
        }

        public Request<T> WithQuery(IDictionary<string, object> query)
        {
            this.Query = query;
            return this;
        }

        public Request<T> WithQuery(string key, object value)
        {
            this.Query[key] = value;
            return this;
        }

        public Request<T> WithData(HttpContent content)
        {
            this.Content = content;
            return this;
        }

        public Request<T> WithData(IDictionary<string, object> data)
        {
            this.Data = data;
            return this;
        }

        public Request<T> WithData(string key, object value)
        {
            this.Data[key] = value;
            return this;
        }

        public Request<T> WithOption(string key, object value)
        {
            this.Options[key] = value;
            return this;
        }
    }
}