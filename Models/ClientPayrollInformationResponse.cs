using Newtonsoft.Json;

namespace FrankCrumCrmApiClient.Models
{
    public class ClientPayrollInformationResponse
    {
        [JsonProperty("clientNumber")]
        public int ClientNumber { get; set; }

        [JsonProperty("divisionNumber")]
        public string? DivisionNumber { get; set; }

        [JsonProperty("complianceHold")]
        public bool ComplianceHold { get; set; }

        [JsonProperty("payrollLevel")]
        public int PayrollLevel { get; set; }

        [JsonProperty("payrollSubmitMethod")]
        public string? PayrollSubmitMethod { get; set; }

        [JsonProperty("editApproval")]
        public bool? EditApproval { get; set; }

        [JsonProperty("paymentOffsetDay")]
        public int PaymentOffsetDay { get; set; }

        [JsonProperty("receivedOffsetDay")]
        public int ReceivedOffsetDay { get; set; }

        [JsonProperty("paymentMethod")]
        public string? PaymentMethod { get; set; }

        [JsonProperty("states")]
        public string? States { get; set; }

        [JsonProperty("payrollManager")]
        public string? PayrollManager { get; set; }

        [JsonProperty("payrollManagerExt")]
        public string? PayrollManagerExt { get; set; }

        [JsonProperty("ntReimbursements")]
        public bool? NtReimbursements { get; set; }

        [JsonProperty("relatedClients")]
        public List<RelatedClient>? RelatedClients { get; set; }
    }
}
