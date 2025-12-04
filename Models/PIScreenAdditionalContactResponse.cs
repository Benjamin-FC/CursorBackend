using Newtonsoft.Json;

namespace FrankCrumCrmApiClient.Models
{
    public class PIScreenAdditionalContactResponse
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("firstName")]
        public string? FirstName { get; set; }

        [JsonProperty("lastName")]
        public string? LastName { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("coiTransmission")]
        public string? CoiTransmission { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("businessPhone")]
        public string? BusinessPhone { get; set; }

        [JsonProperty("cellPhone")]
        public string? CellPhone { get; set; }

        [JsonProperty("fax")]
        public string? Fax { get; set; }

        [JsonProperty("contactType")]
        public List<string>? ContactType { get; set; }

        [JsonProperty("location")]
        public string? Location { get; set; }

        [JsonProperty("notes")]
        public string? Notes { get; set; }

        [JsonProperty("isPrimaryContact")]
        public bool IsPrimaryContact { get; set; }

        [JsonProperty("isContractSigner")]
        public bool IsContractSigner { get; set; }

        [JsonProperty("notifications")]
        public Notification? Notifications { get; set; }
    }
}
