using Asana.Models;
using Asana.Requests;
using Asana.Resources;

namespace Asana.Requests 
{
    /// <summary>
    ///     A _tag_ is a label that can be attached to any task in Asana. It exists in a
    ///     single workspace or organization.
    ///     
    ///     Tags have some metadata associated with them, but it is possible that we will
    ///     simplify them in the future so it is not encouraged to rely too heavily on it.
    ///     Unlike projects, tags do not provide any ordering on the tasks they
    ///     are associated with.
    /// </summary>
    public partial class Tags : Resource 
    {
        public Tags(Client client)
            : base(client) 
        { }    

        /// <summary>
        ///     Creates a new tag in a workspace or organization.
        ///     
        ///     Every tag is required to be created in a specific workspace or
        ///     organization, and this cannot be changed once set. Note that you can use
        ///     the `workspace` parameter regardless of whether or not it is an
        ///     organization.
        ///     
        ///     Returns the full record of the newly created tag.
        /// </summary>
        /// <returns> Request object </returns>        
        public ItemRequest<Tag> Create() 
        {
            return new ItemRequest<Tag>(this.Client, "/tags", "POST");
        }    

        /// <summary>
        ///     Creates a new tag in a workspace or organization.
        ///     
        ///     Every tag is required to be created in a specific workspace or
        ///     organization, and this cannot be changed once set. Note that you can use
        ///     the `workspace` parameter regardless of whether or not it is an
        ///     organization.
        ///     
        ///     Returns the full record of the newly created tag.
        /// </summary>
        /// <param name="workspace">
        ///     The workspace or organization to create the tag in. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Tag> CreateInWorkspace(string workspace) 
        {
            string path = string.Format("/workspaces/%s/tags", workspace);
            return new ItemRequest<Tag>(this.Client, path, "POST");
        }    

        /// <summary>
        ///     Returns the complete tag record for a single tag.
        /// </summary>
        /// <param name="tag">
        ///     The tag to get. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Tag> FindById(string tag) 
        {
            string path = string.Format("/tags/%s", tag);
            return new ItemRequest<Tag>(this.Client, path, "GET");
        }    

        /// <summary>
        ///     Updates the properties of a tag. Only the fields provided in the `data`
        ///     block will be updated; any unspecified fields will remain unchanged.
        ///     
        ///     When using this method, it is best to specify only those fields you wish
        ///     to change, or else you may overwrite changes made by another user since
        ///     you last retrieved the task.
        ///     
        ///     Returns the complete updated tag record.
        /// </summary>
        /// <param name="tag">
        ///     The tag to update. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Tag> Update(string tag) 
        {
            string path = string.Format("/tags/%s", tag);
            return new ItemRequest<Tag>(this.Client, path, "PUT");
        }    

        /// <summary>
        ///     A specific, existing tag can be deleted by making a DELETE request
        ///     on the URL for that tag.
        ///     
        ///     Returns an empty data record.
        /// </summary>
        /// <param name="tag">
        ///     The tag to delete. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Tag> Delete(string tag) 
        {
            string path = string.Format("/tags/%s", tag);
            return new ItemRequest<Tag>(this.Client, path, "DELETE");
        }    

        /// <summary>
        ///     Returns the compact tag records for some filtered set of tags.
        ///     Use one or more of the parameters provided to filter the tags returned.
        /// </summary>
        /// <returns> Request object </returns>        
        public CollectionRequest<Tag> FindAll() 
        {
            return new CollectionRequest<Tag>(this.Client, "/tags", "GET");
        }    

        /// <summary>
        ///     Returns the compact tag records for all tags in the workspace.
        /// </summary>
        /// <param name="workspace">
        ///     The workspace or organization to find tags in. 
        /// </param> 
        /// <returns> Request object </returns>        
        public CollectionRequest<Tag> FindByWorkspace(string workspace) 
        {
            string path = string.Format("/workspaces/%s/tags", workspace);
            return new CollectionRequest<Tag>(this.Client, path, "GET");
        }    

        /// <summary>
        ///     Returns the compact task records for all tasks with the given tag.
        ///     Tasks can have more than one tag at a time.
        /// </summary>
        /// <param name="tag">
        ///     The tag to fetch tasks from. 
        /// </param> 
        /// <returns> Request object </returns>        
        public CollectionRequest<Tag> GetTasksWithTag(string tag) 
        {
            string path = string.Format("/tags/%s/tasks", tag);
            return new CollectionRequest<Tag>(this.Client, path, "GET");
        }
    }
}