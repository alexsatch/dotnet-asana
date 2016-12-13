using Asana.Models;
using Asana.Requests;

namespace Asana.Resources 
{
    /// <summary>
    ///     Custom fields are attached to a particular project with the Custom
    ///     Field Settings resource. This resource both represents the many-to-many join
    ///     of the Custom Field and Project as well as stores information that is relevant to that
    ///     particular pairing; for instance, the `is_important` property determines
    ///     some possible application-specific handling of that custom field (see below)
    /// </summary>
    public partial class CustomFieldSettings : Resource 
    {
        public CustomFieldSettings(Client client)
            : base(client) 
        { }    

        /// <summary>
        ///     Returns a list of all of the custom fields settings on a project, in compact form. Note that, as in all queries to collections which return compact representation, `opt_fields` and `opt_expand` can be used to include more data than is returned in the compact representation. See the getting started guide on [input/output options](/developers/documentation/getting-started/input-output-options) for more information.
        /// </summary>
        /// <param name="project">
        ///     The ID of the project for which to list custom field settings 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<CustomFieldSetting> FindByProject(string project) 
        {
            string path = string.Format("/projects/{0}/custom_field_settings", project);
            return new ItemRequest<CustomFieldSetting>(this.Client, path, "GET");
        }
    }
}