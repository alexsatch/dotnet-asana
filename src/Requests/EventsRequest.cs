namespace Asana.Requests
{
    public class EventsRequest<T> : Request
    {
        public EventsRequest(Client client, string path, string method)
            : base(client, path, method)
        {
        }
    }
}