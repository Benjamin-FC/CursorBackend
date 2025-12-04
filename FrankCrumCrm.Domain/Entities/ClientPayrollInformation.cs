using Newtonsoft.Json;

namespace FrankCrumCrm.Domain.Entities
{
    public class ClientPayrollInformation
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
