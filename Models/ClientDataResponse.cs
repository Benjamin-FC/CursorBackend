using Newtonsoft.Json;

namespace FrankCrumCrmApiClient.Models
{
    public class ClientDataResponse
    {
        [JsonProperty("clientId")]
        public string? ClientId { get; set; }

        [JsonProperty("editApproval")]
        public string? EditApproval { get; set; }

        [JsonProperty("dba")]
        public string? Dba { get; set; }

        [JsonProperty("clientLegalName")]
        public string? ClientLegalName { get; set; }

        [JsonProperty("complianceHold")]
        public string? ComplianceHold { get; set; }

        [JsonProperty("level")]
        public string? Level { get; set; }

        [JsonProperty("paymentTermID")]
        public string? PaymentTermId { get; set; }

        [JsonProperty("paymentMethod")]
        public string? PaymentMethod { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }
    }
}
