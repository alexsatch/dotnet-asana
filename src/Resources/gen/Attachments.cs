using Asana.Models;
using Asana.Requests;

namespace Asana.Resources 
{
    /// <summary>
    ///     An _attachment_ object represents any file attached to a task in Asana,
    ///     whether it's an uploaded file or one associated via a third-party service
    ///     such as Dropbox or Google Drive.
    /// </summary>
    public partial class Attachments : Resource 
    {
        public Attachments(Client client)
            : base(client) 
        { }    

        /// <summary>
        ///     Returns the full record for a single attachment.
        /// </summary>
        /// <param name="attachment">
        ///     Globally unique identifier for the attachment. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Attachment> FindById(string attachment) 
        {
            string path = string.Format("/attachments/{0}", attachment);
            return new ItemRequest<Attachment>(this.Client, path, "GET");
        }    

        /// <summary>
        ///     Returns the compact records for all attachments on the task.
        /// </summary>
        /// <param name="task">
        ///     Globally unique identifier for the task. 
        /// </param> 
        /// <returns> Request object </returns>        
        public CollectionRequest<Attachment> FindByTask(string task) 
        {
            string path = string.Format("/tasks/{0}/attachments", task);
            return new CollectionRequest<Attachment>(this.Client, path, "GET");
        }
    }
}