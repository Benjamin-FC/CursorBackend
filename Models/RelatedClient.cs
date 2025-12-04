using Newtonsoft.Json;

namespace FrankCrumCrmApiClient.Models
{
    public class RelatedClient
    {
        [JsonProperty("organizationParentId")]
        public int OrganizationParentId { get; set; }

        [JsonProperty("clientNumber")]
        public int ClientNumber { get; set; }

        [JsonProperty("clientName")]
        public string? ClientName { get; set; }
    }
}
