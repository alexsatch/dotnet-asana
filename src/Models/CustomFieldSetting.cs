using System;
using Newtonsoft.Json;

namespace Asana.Models
{
    public class CustomFieldSetting
    {
        [JsonProperty("created_at")]
        public DateTime CreatedAt;

        public CustomField CustomField;
        public string Id;

        [JsonProperty("is_important")]
        public bool IsImportant;

        public Project Project;
    }
}