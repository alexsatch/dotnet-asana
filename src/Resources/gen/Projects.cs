using Asana.Models;
using Asana.Requests;

namespace Asana.Resources 
{
    /// <summary>
    ///     A _project_ represents a prioritized list of tasks in Asana. It exists in a
    ///     single workspace or organization and is accessible to a subset of users in
    ///     that workspace or organization, depending on its permissions.
    ///     
    ///     Projects in organizations are shared with a single team. You cannot currently
    ///     change the team of a project via the API. Non-organization workspaces do not
    ///     have teams and so you should not specify the team of project in a
    ///     regular workspace.
    /// </summary>
    public partial class Projects : Resource 
    {
        public Projects(Client client)
            : base(client) 
        { }    

        /// <summary>
        ///     Creates a new project in a workspace or team.
        ///     
        ///     Every project is required to be created in a specific workspace or
        ///     organization, and this cannot be changed once set. Note that you can use
        ///     the `workspace` parameter regardless of whether or not it is an
        ///     organization.
        ///     
        ///     If the workspace for your project _is_ an organization, you must also
        ///     supply a `team` to share the project with.
        ///     
        ///     Returns the full record of the newly created project.
        /// </summary>
        /// <returns> Request object </returns>        
        public ItemRequest<Project> Create() 
        {
            return new ItemRequest<Project>(this.Client, "/projects", "POST");
        }    

        /// <summary>
        ///     If the workspace for your project _is_ an organization, you must also
        ///     supply a `team` to share the project with.
        ///     
        ///     Returns the full record of the newly created project.
        /// </summary>
        /// <param name="workspace">
        ///     The workspace or organization to create the project in. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Project> CreateInWorkspace(string workspace) 
        {
            string path = string.Format("/workspaces/{0}/projects", workspace);
            return new ItemRequest<Project>(this.Client, path, "POST");
        }    

        /// <summary>
        ///     Creates a project shared with the given team.
        ///     
        ///     Returns the full record of the newly created project.
        /// </summary>
        /// <param name="team">
        ///     The team to create the project in. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Project> CreateInTeam(string team) 
        {
            string path = string.Format("/teams/{0}/projects", team);
            return new ItemRequest<Project>(this.Client, path, "POST");
        }    

        /// <summary>
        ///     Returns the complete project record for a single project.
        /// </summary>
        /// <param name="project">
        ///     The project to get. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Project> FindById(string project) 
        {
            string path = string.Format("/projects/{0}", project);
            return new ItemRequest<Project>(this.Client, path, "GET");
        }    

        /// <summary>
        ///     A specific, existing project can be updated by making a PUT request on the
        ///     URL for that project. Only the fields provided in the `data` block will be
        ///     updated; any unspecified fields will remain unchanged.
        ///     
        ///     When using this method, it is best to specify only those fields you wish
        ///     to change, or else you may overwrite changes made by another user since
        ///     you last retrieved the task.
        ///     
        ///     Returns the complete updated project record.
        /// </summary>
        /// <param name="project">
        ///     The project to update. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Project> Update(string project) 
        {
            string path = string.Format("/projects/{0}", project);
            return new ItemRequest<Project>(this.Client, path, "PUT");
        }    

        /// <summary>
        ///     A specific, existing project can be deleted by making a DELETE request
        ///     on the URL for that project.
        ///     
        ///     Returns an empty data record.
        /// </summary>
        /// <param name="project">
        ///     The project to delete. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Project> Delete(string project) 
        {
            string path = string.Format("/projects/{0}", project);
            return new ItemRequest<Project>(this.Client, path, "DELETE");
        }    

        /// <summary>
        ///     Returns the compact project records for some filtered set of projects.
        ///     Use one or more of the parameters provided to filter the projects returned.
        /// </summary>
        /// <returns> Request object </returns>        
        public CollectionRequest<Project> FindAll() 
        {
            return new CollectionRequest<Project>(this.Client, "/projects", "GET");
        }    

        /// <summary>
        ///     Returns the compact project records for all projects in the workspace.
        /// </summary>
        /// <param name="workspace">
        ///     The workspace or organization to find projects in. 
        /// </param> 
        /// <returns> Request object </returns>        
        public CollectionRequest<Project> FindByWorkspace(string workspace) 
        {
            string path = string.Format("/workspaces/{0}/projects", workspace);
            return new CollectionRequest<Project>(this.Client, path, "GET");
        }    

        /// <summary>
        ///     Returns the compact project records for all projects in the team.
        /// </summary>
        /// <param name="team">
        ///     The team to find projects in. 
        /// </param> 
        /// <returns> Request object </returns>        
        public CollectionRequest<Project> FindByTeam(string team) 
        {
            string path = string.Format("/teams/{0}/projects", team);
            return new CollectionRequest<Project>(this.Client, path, "GET");
        }    

        /// <summary>
        ///     Returns compact records for all sections in the specified project.
        /// </summary>
        /// <param name="project">
        ///     The project to get sections from. 
        /// </param> 
        /// <returns> Request object </returns>        
        public CollectionRequest<Project> Sections(string project) 
        {
            string path = string.Format("/projects/{0}/sections", project);
            return new CollectionRequest<Project>(this.Client, path, "GET");
        }    

        /// <summary>
        ///     Returns the compact task records for all tasks within the given project,
        ///     ordered by their priority within the project. Tasks can exist in more than one project at a time.
        /// </summary>
        /// <param name="project">
        ///     The project in which to search for tasks. 
        /// </param> 
        /// <returns> Request object </returns>        
        public CollectionRequest<Project> Tasks(string project) 
        {
            string path = string.Format("/projects/{0}/tasks", project);
            return new CollectionRequest<Project>(this.Client, path, "GET");
        }    

        /// <summary>
        ///     Adds the specified list of users as followers to the project. Followers are a subset of members, therefore if
        ///     the users are not already members of the project they will also become members as a result of this operation.
        ///     Returns the updated project record.
        /// </summary>
        /// <param name="project">
        ///     The project to add followers to. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Project> AddFollowers(string project) 
        {
            string path = string.Format("/projects/{0}/addFollowers", project);
            return new ItemRequest<Project>(this.Client, path, "POST");
        }    

        /// <summary>
        ///     Removes the specified list of users from following the project, this will not affect project membership status.
        ///     Returns the updated project record.
        /// </summary>
        /// <param name="project">
        ///     The project to remove followers from. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Project> RemoveFollowers(string project) 
        {
            string path = string.Format("/projects/{0}/removeFollowers", project);
            return new ItemRequest<Project>(this.Client, path, "POST");
        }    

        /// <summary>
        ///     Adds the specified list of users as members of the project. Returns the updated project record.
        /// </summary>
        /// <param name="project">
        ///     The project to add members to. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Project> AddMembers(string project) 
        {
            string path = string.Format("/projects/{0}/addMembers", project);
            return new ItemRequest<Project>(this.Client, path, "POST");
        }    

        /// <summary>
        ///     Removes the specified list of members from the project. Returns the updated project record.
        /// </summary>
        /// <param name="project">
        ///     The project to remove members from. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Project> RemoveMembers(string project) 
        {
            string path = string.Format("/projects/{0}/removeMembers", project);
            return new ItemRequest<Project>(this.Client, path, "POST");
        }    

        /// <summary>
        ///     Create a new custom field setting on the project.
        /// </summary>
        /// <param name="project">
        ///     The project to associate the custom field with 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Project> AddCustomFieldSetting(string project) 
        {
            string path = string.Format("/projects/{0}/addCustomFieldSetting", project);
            return new ItemRequest<Project>(this.Client, path, "POST");
        }    

        /// <summary>
        ///     Remove a custom field setting on the project.
        /// </summary>
        /// <param name="project">
        ///     The project to associate the custom field with 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Project> RemoveCustomFieldSetting(string project) 
        {
            string path = string.Format("/projects/{0}/removeCustomFieldSetting", project);
            return new ItemRequest<Project>(this.Client, path, "POST");
        }
    }
}