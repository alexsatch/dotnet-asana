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
            this.Message = new HttpRequestMessage(method, path);
        }	

        public static ItemRequest<T> Create<T>(Client client, string path, string method)
        {
            return new ItemRequest<T>(client, path, method);
        }

        public static CollectionRequest<T> CreateCollection<T>(Client client, string path, string method)
        {
            return new CollectionRequest<T>(client, path, method);
        }

        public static EventsRequest<T> CreateEvents<T>(Client client, string path, string method)
        {
            return new EventsRequest<T>(client, path, method);
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

    public class ItemRequest<T> : Request
    {
        public ItemRequest(Client client, string path, HttpMethod method)
           : base(client, path, method)
        {
        }

        public ItemRequest<T> WithParam(string key, object value)
        {
            throw new System.NotImplementedException();
        }

        public T Execute()
        {
            var response = base.ExecuteRaw();

            throw new System.NotImplementedException();
        }
    }

    public class CollectionRequest<T> : Request
    {
        public CollectionRequest(Client client, string path, HttpMethod method)
           : base(client, path, method)
        {
        }
    }

    public class EventsRequest<T> : Request
    {
        public EventsRequest(Client client, string path, HttpMethod method)
           : base(client, path, method)
        {
        }
    }
}