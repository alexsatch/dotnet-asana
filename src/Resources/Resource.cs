namespace Asana.Resources
{
    public abstract class Resource
    {
        public Client Client { get; }

        protected Resource(Client client)
        {
            this.Client = client;
        }
    }
}