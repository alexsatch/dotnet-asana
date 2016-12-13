namespace Asana.Requests
{
    public class ItemRequest<T> : Request
    {
        public ItemRequest(Client client, string path, string method)
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
}