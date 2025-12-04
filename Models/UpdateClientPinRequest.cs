using Newtonsoft.Json;

namespace FrankCrumCrmApiClient.Models
{
    public class UpdateClientPinRequest
    {
        [JsonProperty("clientPin")]
        public string? ClientPin { get; set; }

        [JsonProperty("legalEntityDivisionId")]
        public int LegalEntityDivisionId { get; set; }
    }
}
