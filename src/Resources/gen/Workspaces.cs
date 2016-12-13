using Asana.Models;
using Asana.Requests;
using Asana.Resources;

namespace Asana.Requests 
{
    /// <summary>
    ///     A _workspace_ is the highest-level organizational unit in Asana. All projects
    ///     and tasks have an associated workspace.
    ///     
    ///     An _organization_ is a special kind of workspace that represents a company.
    ///     In an organization, you can group your projects into teams. You can read
    ///     more about how organizations work on the Asana Guide.
    ///     To tell if your workspace is an organization or not, check its
    ///     `is_organization` property.
    ///     
    ///     Over time, we intend to migrate most workspaces into organizations and to
    ///     release more organization-specific functionality. We may eventually deprecate
    ///     using workspace-based APIs for organizations. Currently, and until after
    ///     some reasonable grace period following any further announcements, you can
    ///     still reference organizations in any `workspace` parameter.
    /// </summary>
    public partial class Workspaces : Resource 
    {
        public Workspaces(Client client)
            : base(client) 
        { }    

        /// <summary>
        ///     Returns the full workspace record for a single workspace.
        /// </summary>
        /// <param name="workspace">
        ///     Globally unique identifier for the workspace or organization. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Workspace> FindById(string workspace) 
        {
            string path = string.Format("/workspaces/%s", workspace);
            return new ItemRequest<Workspace>(this.Client, path, "GET");
        }    

        /// <summary>
        ///     Returns the compact records for all workspaces visible to the authorized user.
        /// </summary>
        /// <returns> Request object </returns>        
        public CollectionRequest<Workspace> FindAll() 
        {
            return new CollectionRequest<Workspace>(this.Client, "/workspaces", "GET");
        }    

        /// <summary>
        ///     A specific, existing workspace can be updated by making a PUT request on
        ///     the URL for that workspace. Only the fields provided in the data block
        ///     will be updated; any unspecified fields will remain unchanged.
        ///     
        ///     Currently the only field that can be modified for a workspace is its `name`.
        ///     
        ///     Returns the complete, updated workspace record.
        /// </summary>
        /// <param name="workspace">
        ///     The workspace to update. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Workspace> Update(string workspace) 
        {
            string path = string.Format("/workspaces/%s", workspace);
            return new ItemRequest<Workspace>(this.Client, path, "PUT");
        }    

        /// <summary>
        ///     Retrieves objects in the workspace based on an auto-completion/typeahead
        ///     search algorithm. This feature is meant to provide results quickly, so do
        ///     not rely on this API to provide extremely accurate search results. The
        ///     result set is limited to a single page of results with a maximum size,
        ///     so you won't be able to fetch large numbers of results.
        /// </summary>
        /// <param name="workspace">
        ///     The workspace to fetch objects from. 
        /// </param> 
        /// <returns> Request object </returns>        
        public CollectionRequest<Workspace> Typeahead(string workspace) 
        {
            string path = string.Format("/workspaces/%s/typeahead", workspace);
            return new CollectionRequest<Workspace>(this.Client, path, "GET");
        }    

        /// <summary>
        ///     The user can be referenced by their globally unique user ID or their email address.
        ///     Returns the full user record for the invited user.
        /// </summary>
        /// <param name="workspace">
        ///     The workspace or organization to invite the user to. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Workspace> AddUser(string workspace) 
        {
            string path = string.Format("/workspaces/%s/addUser", workspace);
            return new ItemRequest<Workspace>(this.Client, path, "POST");
        }    

        /// <summary>
        ///     The user making this call must be an admin in the workspace.
        ///     Returns an empty data record.
        /// </summary>
        /// <param name="workspace">
        ///     The workspace or organization to invite the user to. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Workspace> RemoveUser(string workspace) 
        {
            string path = string.Format("/workspaces/%s/removeUser", workspace);
            return new ItemRequest<Workspace>(this.Client, path, "POST");
        }
    }
}