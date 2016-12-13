using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Asana.Models
{
    public class Task
    {
        public class Membership
        {
            public Project Project;
            public Task Section;
        }

        public class Heart
        {
            public string Id;
            public User User;
        }

        public string Id;
        public string Name;
        public string Notes;

        [JsonProperty("completed_at")]
        public DateTime CompletedAt;

        [JsonProperty("due_at")]
        public DateTime DueAt;

        [JsonProperty("due_on")]
        public DateTime DueOn;

        public User Assignee;

        [JsonProperty("assignee_status")]
        public string AssigneeStatus;

        public bool Completed;

        public bool Hearted;
        public List<Heart> Hearts;

        [JsonProperty("num_hearts")]
        public int NumHearts;

        public Task Parent;
        public List<User> Followers;
        public List<Membership> Memberships;
        public List<Project> Projects;
        public List<Tag> Tags;
        public Workspace Workspace;

        [JsonProperty("created_at")]
        public DateTime CreatedAt;

        [JsonProperty("modified_at")]
        public DateTime ModifiedAt;
    }
}