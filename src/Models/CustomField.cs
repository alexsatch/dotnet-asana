using System;
using Newtonsoft.Json;

namespace Asana.Models
{
    public class CustomField
    {
        [JsonProperty("created_at")]
        public DateTime CreatedAt;

        public string Id;
        public string Name;

        // Only for type "enum"
        [JsonProperty("enum_options")]
        public CustomFieldEnumOptions EnumOptions;

        // Only for type "number"
        public int Precision;
        public string Type;
    }
}