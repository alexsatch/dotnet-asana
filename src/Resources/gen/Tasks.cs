using Asana.Models;
using Asana.Requests;
using Asana.Resources;

namespace Asana.Requests 
{
    /// <summary>
    ///     The _task_ is the basic object around which many operations in Asana are
    ///     centered. In the Asana application, multiple tasks populate the middle pane
    ///     according to some view parameters, and the set of selected tasks determines
    ///     the more detailed information presented in the details pane.
    /// </summary>
    public partial class Tasks : Resource 
    {
        public Tasks(Client client)
            : base(client) 
        { }    

        /// <summary>
        ///     Creating a new task is as easy as POSTing to the `/tasks` endpoint
        ///     with a data block containing the fields you'd like to set on the task.
        ///     Any unspecified fields will take on default values.
        ///     
        ///     Every task is required to be created in a specific workspace, and this
        ///     workspace cannot be changed once set. The workspace need not be set
        ///     explicitly if you specify `projects` or a `parent` task instead.
        ///     
        ///     `projects` can be a comma separated list of projects, or just a single
        ///     project the task should belong to.
        /// </summary>
        /// <returns> Request object </returns>        
        public ItemRequest<Task> Create() 
        {
            return new ItemRequest<Task>(this.Client, "/tasks", "POST");
        }    

        /// <summary>
        ///     Creating a new task is as easy as POSTing to the `/tasks` endpoint
        ///     with a data block containing the fields you'd like to set on the task.
        ///     Any unspecified fields will take on default values.
        ///     
        ///     Every task is required to be created in a specific workspace, and this
        ///     workspace cannot be changed once set. The workspace need not be set
        ///     explicitly if you specify a `project` or a `parent` task instead.
        /// </summary>
        /// <param name="workspace">
        ///     The workspace to create a task in. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Task> CreateInWorkspace(string workspace) 
        {
            string path = string.Format("/workspaces/%s/tasks", workspace);
            return new ItemRequest<Task>(this.Client, path, "POST");
        }    

        /// <summary>
        ///     Returns the complete task record for a single task.
        /// </summary>
        /// <param name="task">
        ///     The task to get. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Task> FindById(string task) 
        {
            string path = string.Format("/tasks/%s", task);
            return new ItemRequest<Task>(this.Client, path, "GET");
        }    

        /// <summary>
        ///     A specific, existing task can be updated by making a PUT request on the
        ///     URL for that task. Only the fields provided in the `data` block will be
        ///     updated; any unspecified fields will remain unchanged.
        ///     
        ///     When using this method, it is best to specify only those fields you wish
        ///     to change, or else you may overwrite changes made by another user since
        ///     you last retrieved the task.
        ///     
        ///     Returns the complete updated task record.
        /// </summary>
        /// <param name="task">
        ///     The task to update. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Task> Update(string task) 
        {
            string path = string.Format("/tasks/%s", task);
            return new ItemRequest<Task>(this.Client, path, "PUT");
        }    

        /// <summary>
        ///     A specific, existing task can be deleted by making a DELETE request on the
        ///     URL for that task. Deleted tasks go into the "trash" of the user making
        ///     the delete request. Tasks can be recovered from the trash within a period
        ///     of 30 days; afterward they are completely removed from the system.
        ///     
        ///     Returns an empty data record.
        /// </summary>
        /// <param name="task">
        ///     The task to delete. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Task> Delete(string task) 
        {
            string path = string.Format("/tasks/%s", task);
            return new ItemRequest<Task>(this.Client, path, "DELETE");
        }    

        /// <summary>
        ///     Returns the compact task records for all tasks within the given project,
        ///     ordered by their priority within the project.
        /// </summary>
        /// <param name="projectId">
        ///     The project in which to search for tasks. 
        /// </param> 
        /// <returns> Request object </returns>        
        public CollectionRequest<Task> FindByProject(string projectId) 
        {
            string path = string.Format("/projects/%s/tasks", projectId);
            return new CollectionRequest<Task>(this.Client, path, "GET");
        }    

        /// <summary>
        ///     Returns the compact task records for all tasks with the given tag.
        /// </summary>
        /// <param name="tag">
        ///     The tag in which to search for tasks. 
        /// </param> 
        /// <returns> Request object </returns>        
        public CollectionRequest<Task> FindByTag(string tag) 
        {
            string path = string.Format("/tags/%s/tasks", tag);
            return new CollectionRequest<Task>(this.Client, path, "GET");
        }    

        /// <summary>
        ///     Returns the compact task records for some filtered set of tasks. Use one
        ///     or more of the parameters provided to filter the tasks returned. You must
        ///     specify a `project` or `tag` if you do not specify `assignee` and `workspace`.
        /// </summary>
        /// <returns> Request object </returns>        
        public CollectionRequest<Task> FindAll() 
        {
            return new CollectionRequest<Task>(this.Client, "/tasks", "GET");
        }    

        /// <summary>
        ///     Adds each of the specified followers to the task, if they are not already
        ///     following. Returns the complete, updated record for the affected task.
        /// </summary>
        /// <param name="task">
        ///     The task to add followers to. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Task> AddFollowers(string task) 
        {
            string path = string.Format("/tasks/%s/addFollowers", task);
            return new ItemRequest<Task>(this.Client, path, "POST");
        }    

        /// <summary>
        ///     Removes each of the specified followers from the task if they are
        ///     following. Returns the complete, updated record for the affected task.
        /// </summary>
        /// <param name="task">
        ///     The task to remove followers from. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Task> RemoveFollowers(string task) 
        {
            string path = string.Format("/tasks/%s/removeFollowers", task);
            return new ItemRequest<Task>(this.Client, path, "POST");
        }    

        /// <summary>
        ///     Returns a compact representation of all of the projects the task is in.
        /// </summary>
        /// <param name="task">
        ///     The task to get projects on. 
        /// </param> 
        /// <returns> Request object </returns>        
        public CollectionRequest<Task> Projects(string task) 
        {
            string path = string.Format("/tasks/%s/projects", task);
            return new CollectionRequest<Task>(this.Client, path, "GET");
        }    

        /// <summary>
        ///     Adds the task to the specified project, in the optional location
        ///     specified. If no location arguments are given, the task will be added to
        ///     the beginning of the project.
        ///     
        ///     `addProject` can also be used to reorder a task within a project that
        ///     already contains it.
        ///     
        ///     Returns an empty data block.
        /// </summary>
        /// <param name="task">
        ///     The task to add to a project. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Task> AddProject(string task) 
        {
            string path = string.Format("/tasks/%s/addProject", task);
            return new ItemRequest<Task>(this.Client, path, "POST");
        }    

        /// <summary>
        ///     Removes the task from the specified project. The task will still exist
        ///     in the system, but it will not be in the project anymore.
        ///     
        ///     Returns an empty data block.
        /// </summary>
        /// <param name="task">
        ///     The task to remove from a project. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Task> RemoveProject(string task) 
        {
            string path = string.Format("/tasks/%s/removeProject", task);
            return new ItemRequest<Task>(this.Client, path, "POST");
        }    

        /// <summary>
        ///     Returns a compact representation of all of the tags the task has.
        /// </summary>
        /// <param name="task">
        ///     The task to get tags on. 
        /// </param> 
        /// <returns> Request object </returns>        
        public CollectionRequest<Task> Tags(string task) 
        {
            string path = string.Format("/tasks/%s/tags", task);
            return new CollectionRequest<Task>(this.Client, path, "GET");
        }    

        /// <summary>
        ///     Adds a tag to a task. Returns an empty data block.
        /// </summary>
        /// <param name="task">
        ///     The task to add a tag to. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Task> AddTag(string task) 
        {
            string path = string.Format("/tasks/%s/addTag", task);
            return new ItemRequest<Task>(this.Client, path, "POST");
        }    

        /// <summary>
        ///     Removes a tag from the task. Returns an empty data block.
        /// </summary>
        /// <param name="task">
        ///     The task to remove a tag from. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Task> RemoveTag(string task) 
        {
            string path = string.Format("/tasks/%s/removeTag", task);
            return new ItemRequest<Task>(this.Client, path, "POST");
        }    

        /// <summary>
        ///     Returns a compact representation of all of the subtasks of a task.
        /// </summary>
        /// <param name="task">
        ///     The task to get the subtasks of. 
        /// </param> 
        /// <returns> Request object </returns>        
        public CollectionRequest<Task> Subtasks(string task) 
        {
            string path = string.Format("/tasks/%s/subtasks", task);
            return new CollectionRequest<Task>(this.Client, path, "GET");
        }    

        /// <summary>
        ///     Creates a new subtask and adds it to the parent task. Returns the full record
        ///     for the newly created subtask.
        /// </summary>
        /// <param name="task">
        ///     The task to add a subtask to. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Task> AddSubtask(string task) 
        {
            string path = string.Format("/tasks/%s/subtasks", task);
            return new ItemRequest<Task>(this.Client, path, "POST");
        }    

        /// <summary>
        ///     Returns a compact representation of all of the stories on the task.
        /// </summary>
        /// <param name="task">
        ///     The task containing the stories to get. 
        /// </param> 
        /// <returns> Request object </returns>        
        public CollectionRequest<Task> Stories(string task) 
        {
            string path = string.Format("/tasks/%s/stories", task);
            return new CollectionRequest<Task>(this.Client, path, "GET");
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
        public ItemRequest<Task> AddComment(string task) 
        {
            string path = string.Format("/tasks/%s/stories", task);
            return new ItemRequest<Task>(this.Client, path, "POST");
        }
    }
}