using Asana.Models;
using Asana.Requests;

namespace Asana.Resources 
{
    /// <summary>
    ///     A _story_ represents an activity associated with an object in the Asana
    ///     system. Stories are generated by the system whenever users take actions such
    ///     as creating or assigning tasks, or moving tasks between projects. _Comments_
    ///     are also a form of user-generated story.
    ///     
    ///     Stories are a form of history in the system, and as such they are read-only.
    ///     Once generated, it is not possible to modify a story.
    /// </summary>
    public partial class Stories : Resource 
    {
        public Stories(Client client)
            : base(client) 
        { }    

        /// <summary>
        ///     Returns the compact records for all stories on the task.
        /// </summary>
        /// <param name="task">
        ///     Globally unique identifier for the task. 
        /// </param> 
        /// <returns> Request object </returns>        
        public CollectionRequest<Story> FindByTask(string task) 
        {
            string path = string.Format("/tasks/{0}/stories", task);
            return new CollectionRequest<Story>(this.Client, path, "GET");
        }    

        /// <summary>
        ///     Returns the full record for a single story.
        /// </summary>
        /// <param name="story">
        ///     Globally unique identifier for the story. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Story> FindById(string story) 
        {
            string path = string.Format("/stories/{0}", story);
            return new ItemRequest<Story>(this.Client, path, "GET");
        }    

        /// <summary>
        ///     Adds a comment to a task. The comment will be authored by the
        ///     currently authenticated user, and timestamped when the server receives
        ///     the request.
        ///     
        ///     Returns the full record for the new story added to the task.
        /// </summary>
        /// <param name="task">
        ///     Globally unique identifier for the task. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Story> CreateOnTask(string task) 
        {
            string path = string.Format("/tasks/{0}/stories", task);
            return new ItemRequest<Story>(this.Client, path, "POST");
        }
    }
}