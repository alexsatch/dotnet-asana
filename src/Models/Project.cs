using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Asana.Models
{
    public class Project
    {
        public string Id;
        public string Name;

        public string Notes;
        public string Color;

        [JsonProperty("archived")]
        public bool IsArchived;

        [JsonProperty("public")]
        public bool IsPublic;

        public List<User> Followers;
        public List<User> Members;

        public Team Team;
        public Workspace Workspace;

        [JsonProperty("created_at")]
        public DateTime CreatedAt;

        [JsonProperty("modified_at")]
        public DateTime ModifiedAt;

        public User Owner;

        public Project()
        {
            //no-arg constructor
        }

        // constructor with id arg provided for convenience
        public Project(string id)
        {
            this.Id = id;
        }
    }
}