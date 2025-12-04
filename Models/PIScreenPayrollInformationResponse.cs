using Newtonsoft.Json;

namespace FrankCrumCrmApiClient.Models
{
    public class PIScreenPayrollInformationResponse
    {
        [JsonProperty("jobEndDate")]
        public DateTime? JobEndDate { get; set; }

        [JsonProperty("ownerMinimumAmount")]
        public string? OwnerMinimumAmount { get; set; }

        [JsonProperty("nonTaxableReimb")]
        public string? NonTaxableReimb { get; set; }

        [JsonProperty("preNote")]
        public string? PreNote { get; set; }

        [JsonProperty("specialApprovals")]
        public string? SpecialApprovals { get; set; }

        [JsonProperty("ntReimbursements")]
        public string? NtReimbursements { get; set; }

        [JsonProperty("payrollLevel")]
        public string? PayrollLevel { get; set; }
    }
}
