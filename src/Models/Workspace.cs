using System.Collections.Generic;
using Newtonsoft.Json;

namespace Asana.Models
{
    public class Workspace
    {
        public string Id;
        public string Name;

        [JsonProperty("email_domains")]
        public List<string> EmailDomains;

        [JsonProperty("is_organization")]
        public bool IsOrganization;

        public Workspace()
        {
            //no-arg constructor
        }

        // constructor with id arg provided for convenience
        public Workspace(string id)
        {
            this.Id = id;
        }
    }
}