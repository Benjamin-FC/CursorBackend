using Newtonsoft.Json;

namespace FrankCrumCrm.Domain.Entities
{
    public class TerminatedClientsInformation
    {
        [JsonProperty("terminatedClientIds")]
        public List<int>? TerminatedClientIds { get; set; }
    }
}
