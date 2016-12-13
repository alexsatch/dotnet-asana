using System.Collections.Generic;
using Newtonsoft.Json;

namespace Asana.Models
{
    public class ResultBodyCollection<T>
    {
        public List<T> Data;
        public string Sync;

        [JsonProperty("next_page")]
        public NextPage NextPage;
    }
}