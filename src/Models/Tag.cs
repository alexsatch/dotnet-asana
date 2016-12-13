using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Asana.Models
{
    public class Tag
    {
        public string Id;
        public string Name;
        public string Notes;

        public string Color;
        public List<User> Followers;
        public Workspace Workspace;

        [JsonProperty("created_at")]
        public DateTime CreatedAt;
    }
}