using System;
using Newtonsoft.Json;

namespace Asana.Models
{
    public class Story
    {
        public string Id;
        public string Text;
        public string Type;

        [JsonProperty("created_by")]
        public User CreatedBy;

        [JsonProperty("created_at")]
        public DateTime CreatedAt;
    }
}