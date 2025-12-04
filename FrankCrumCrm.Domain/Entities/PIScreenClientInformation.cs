using Newtonsoft.Json;

namespace FrankCrumCrm.Domain.Entities
{
    public class PIScreenClientInformation
    {
        [JsonProperty("clientId")]
        public string? ClientId { get; set; }

        [JsonProperty("clientName")]
        public string? ClientName { get; set; }

        [JsonProperty("clientDBA")]
        public string? ClientDba { get; set; }

        [JsonProperty("state")]
        public string? State { get; set; }

        [JsonProperty("payrollLevel")]
        public string? PayrollLevel { get; set; }

        [JsonProperty("payrollFrequency")]
        public string? PayrollFrequency { get; set; }

        [JsonProperty("annualContractAmount")]
        public double? AnnualContractAmount { get; set; }

        [JsonProperty("creditLimit")]
        public double? CreditLimit { get; set; }

        [JsonProperty("payPeriod")]
        public string? PayPeriod { get; set; }

        [JsonProperty("clientStartDate")]
        public DateTime? ClientStartDate { get; set; }

        [JsonProperty("contact")]
        public string? Contact { get; set; }

        [JsonProperty("processorName")]
        public string? ProcessorName { get; set; }

        [JsonProperty("notes")]
        public string? Notes { get; set; }

        [JsonProperty("payrollRule")]
        public string? PayrollRule { get; set; }

        [JsonProperty("division")]
        public string? Division { get; set; }

        [JsonProperty("backupPerson")]
        public string? BackupPerson { get; set; }

        [JsonProperty("processingOrder")]
        public string? ProcessingOrder { get; set; }

        [JsonProperty("dayPayPeriodStarts")]
        public string? DayPayPeriodStarts { get; set; }
    }
}
