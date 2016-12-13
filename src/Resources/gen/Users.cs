using Asana.Models;
using Asana.Requests;

namespace Asana.Resources 
{
    /// <summary>
    ///     A _user_ object represents an account in Asana that can be given access to
    ///     various workspaces, projects, and tasks.
    ///     
    ///     Like other objects in the system, users are referred to by numerical IDs.
    ///     However, the special string identifier `me` can be used anywhere
    ///     a user ID is accepted, to refer to the current authenticated user.
    /// </summary>
    public partial class Users : Resource 
    {
        public Users(Client client)
            : base(client) 
        { }    

        /// <summary>
        ///     Returns the full user record for the currently authenticated user.
        /// </summary>
        /// <returns> Request object </returns>        
        public ItemRequest<User> Me() 
        {
            return new ItemRequest<User>(this.Client, "/users/me", "GET");
        }    

        /// <summary>
        ///     Returns the full user record for the single user with the provided ID.
        /// </summary>
        /// <param name="user">
        ///     An identifier for the user. Can be one of an email address,
        ///     the globally unique identifier for the user, or the keyword `me`
        ///     to indicate the current user making the request. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<User> FindById(String user) 
        {
            string path = string.Format("/users/{0}", user);
            return new ItemRequest<User>(this.Client, path, "GET");
        }    

        /// <summary>
        ///     Returns the user records for all users in the specified workspace or
        ///     organization.
        /// </summary>
        /// <param name="workspace">
        ///     The workspace in which to get users. 
        /// </param> 
        /// <returns> Request object </returns>        
        public CollectionRequest<User> FindByWorkspace(string workspace) 
        {
            string path = string.Format("/workspaces/{0}/users", workspace);
            return new CollectionRequest<User>(this.Client, path, "GET");
        }    

        /// <summary>
        ///     Returns the user records for all users in all workspaces and organizations
        ///     accessible to the authenticated user. Accepts an optional workspace ID
        ///     parameter.
        /// </summary>
        /// <returns> Request object </returns>        
        public CollectionRequest<User> FindAll() 
        {
            return new CollectionRequest<User>(this.Client, "/users", "GET");
        }
    }
}