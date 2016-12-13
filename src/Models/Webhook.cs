using System;
using Newtonsoft.Json;

namespace Asana.Models
{
    public class Webhook
    {
        public string Id;
        public Entity Resource;
        public string Target;
        public bool Active;

        [JsonProperty("created_at")]
        public DateTime CreatedAt;

        [JsonProperty("last_success_at")]
        public DateTime LastSuccessAt;

        [JsonProperty("last_failure_at")]
        public DateTime LastFailureAt;

        [JsonProperty("last_failure_content")]
        public string LastFailureContent;
    }
}