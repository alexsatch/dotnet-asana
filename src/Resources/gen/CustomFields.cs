using Asana.Models;
using Asana.Requests;

namespace Asana.Resources 
{
    /// <summary>
    ///     Custom Fields store the metadata that is used in order to add user-specified
    ///     information to tasks in Asana. Be sure to reference the [Custom
    ///     Fields](/developers/documentation/getting-started/custom-fields) developer
    ///     documentation for more information about how custom fields relate to various
    ///     resources in Asana.
    /// </summary>
    public partial class CustomFields : Resource 
    {
        public CustomFields(Client client)
            : base(client) 
        { }    

        /// <summary>
        ///     Returns the complete definition of a custom field's metadata.
        /// </summary>
        /// <param name="customField">
        ///     Globally unique identifier for the custom field. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<CustomField> FindById(string customField) 
        {
            string path = string.Format("/custom_fields/{0}", customField);
            return new ItemRequest<CustomField>(this.Client, path, "GET");
        }    

        /// <summary>
        ///     Returns a list of the compact representation of all of the custom fields in a workspace.
        /// </summary>
        /// <param name="workspace">
        ///     The workspace or organization to find custom field definitions in. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<CustomField> FindByWorkspace(string workspace) 
        {
            string path = string.Format("/workspaces/{0}/custom_fields", workspace);
            return new ItemRequest<CustomField>(this.Client, path, "GET");
        }
    }
}