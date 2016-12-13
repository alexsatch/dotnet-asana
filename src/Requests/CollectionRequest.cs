namespace Asana.Requests
{
    public class CollectionRequest<T> : Request
    {
        public CollectionRequest(Client client, string path, string method)
            : base(client, path, method)
        {
        }
    }
}