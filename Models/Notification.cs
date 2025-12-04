using Newtonsoft.Json;

namespace FrankCrumCrmApiClient.Models
{
    public class Notification
    {
        [JsonProperty("security")]
        public bool Security { get; set; }

        [JsonProperty("newHire")]
        public bool NewHire { get; set; }

        [JsonProperty("termination")]
        public bool Termination { get; set; }
    }
}
