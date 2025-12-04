using Newtonsoft.Json;

namespace FrankCrumCrmApiClient.Models
{
    public class TerminatedClientsInformationResponse
    {
        [JsonProperty("terminatedClientIds")]
        public List<int>? TerminatedClientIds { get; set; }
    }
}
