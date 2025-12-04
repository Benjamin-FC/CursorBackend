using Newtonsoft.Json;

namespace FrankCrumCrmApiClient.Models
{
    public class ClientProcessingTeam
    {
        [JsonProperty("clientNumber")]
        public int ClientNumber { get; set; }

        [JsonProperty("client")]
        public string? Client { get; set; }

        [JsonProperty("supervisorId")]
        public int SupervisorId { get; set; }

        [JsonProperty("supervisor")]
        public string? Supervisor { get; set; }

        [JsonProperty("managerId")]
        public int ManagerId { get; set; }

        [JsonProperty("manager")]
        public string? Manager { get; set; }

        [JsonProperty("repId")]
        public int RepId { get; set; }

        [JsonProperty("representative")]
        public string? Representative { get; set; }
    }
}
