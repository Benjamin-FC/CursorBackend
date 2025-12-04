using Newtonsoft.Json;

namespace FrankCrumCrm.Domain.Entities
{
    public class EmployerOnbTemplatesProcessed
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("jobExecutionDateTimeUtc")]
        public DateTime JobExecutionDateTimeUtc { get; set; }

        [JsonProperty("newOnboardingPIN")]
        public string? NewOnboardingPin { get; set; }

        [JsonProperty("processedFlag")]
        public bool ProcessedFlag { get; set; }

        [JsonProperty("createdDateTimeUtc")]
        public DateTime CreatedDateTimeUtc { get; set; }

        [JsonProperty("processedFlagUpdatedDateTimeUtc")]
        public DateTime ProcessedFlagUpdatedDateTimeUtc { get; set; }

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
