using System;
using Newtonsoft.Json;

namespace Asana.Models
{
    public class Event
    {
        public string Action;
        public Entity Resource;
        public string Type;
        public User User;
        public Entity Parent;

        [JsonProperty("created_at")]
        public DateTime CreatedAt;
    }
}