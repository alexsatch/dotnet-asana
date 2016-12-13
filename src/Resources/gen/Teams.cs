using Asana.Models;
using Asana.Requests;

namespace Asana.Resources 
{
    /// <summary>
    ///     A _team_ is used to group related projects and people together within an
    ///     organization. Each project in an organization is associated with a team.
    /// </summary>
    public partial class Teams : Resource 
    {
        public Teams(Client client)
            : base(client) 
        { }    

        /// <summary>
        ///     Returns the full record for a single team.
        /// </summary>
        /// <param name="team">
        ///     Globally unique identifier for the team. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Team> FindById(string team) 
        {
            string path = string.Format("/teams/{0}", team);
            return new ItemRequest<Team>(this.Client, path, "GET");
        }    

        /// <summary>
        ///     Returns the compact records for all teams in the organization visible to
        ///     the authorized user.
        /// </summary>
        /// <param name="organization">
        ///     Globally unique identifier for the workspace or organization. 
        /// </param> 
        /// <returns> Request object </returns>        
        public CollectionRequest<Team> FindByOrganization(string organization) 
        {
            string path = string.Format("/organizations/{0}/teams", organization);
            return new CollectionRequest<Team>(this.Client, path, "GET");
        }    

        /// <summary>
        ///     Returns the compact records for all teams to which user is assigned.
        /// </summary>
        /// <param name="user">
        ///     An identifier for the user. Can be one of an email address,
        ///     the globally unique identifier for the user, or the keyword `me`
        ///     to indicate the current user making the request. 
        /// </param> 
        /// <returns> Request object </returns>        
        public CollectionRequest<Team> FindByUser(String user) 
        {
            string path = string.Format("/users/{0}/teams", user);
            return new CollectionRequest<Team>(this.Client, path, "GET");
        }    

        /// <summary>
        ///     Returns the compact records for all users that are members of the team.
        /// </summary>
        /// <param name="team">
        ///     Globally unique identifier for the team. 
        /// </param> 
        /// <returns> Request object </returns>        
        public CollectionRequest<Team> Users(string team) 
        {
            string path = string.Format("/teams/{0}/users", team);
            return new CollectionRequest<Team>(this.Client, path, "GET");
        }    

        /// <summary>
        ///     The user making this call must be a member of the team in order to add others.
        ///     The user to add must exist in the same organization as the team in order to be added.
        ///     The user to add can be referenced by their globally unique user ID or their email address.
        ///     Returns the full user record for the added user.
        /// </summary>
        /// <param name="team">
        ///     Globally unique identifier for the team. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Team> AddUser(string team) 
        {
            string path = string.Format("/teams/{0}/addUser", team);
            return new ItemRequest<Team>(this.Client, path, "POST");
        }    

        /// <summary>
        ///     The user to remove can be referenced by their globally unique user ID or their email address.
        ///     Removes the user from the specified team. Returns an empty data record.
        /// </summary>
        /// <param name="team">
        ///     Globally unique identifier for the team. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Team> RemoveUser(string team) 
        {
            string path = string.Format("/teams/{0}/removeUser", team);
            return new ItemRequest<Team>(this.Client, path, "POST");
        }
    }
}