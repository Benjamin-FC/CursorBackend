using Newtonsoft.Json;

namespace FrankCrumCrmApiClient.Models
{
    public class AddEmployerOnbTemplatesProcessedRequest
    {
        [JsonProperty("newOnboardingPIN")]
        public string? NewOnboardingPin { get; set; }

        [JsonProperty("processedFlag")]
        public bool ProcessedFlag { get; set; }

        [JsonProperty("ultiproCompanyID")]
        public string? UltiproCompanyId { get; set; }

        [JsonProperty("worklioID")]
        public string? WorklioId { get; set; }

        [JsonProperty("clientNumber")]
        public string? ClientNumber { get; set; }

        [JsonProperty("legalEntityDivisionID")]
        public int LegalEntityDivisionId { get; set; }
    }
}
