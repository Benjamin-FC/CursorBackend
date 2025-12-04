using Newtonsoft.Json;

namespace FrankCrumCrm.Domain.Entities
{
    public class PIScreenClientContact
    {
        [JsonProperty("contactId")]
        public int ContactId { get; set; }

        [JsonProperty("contact")]
        public string? Contact { get; set; }

        [JsonProperty("contactType")]
        public List<string>? ContactType { get; set; }

        [JsonProperty("businessPhone")]
        public string? BusinessPhone { get; set; }

        [JsonProperty("cellPhone")]
        public string? CellPhone { get; set; }

        [JsonProperty("fax")]
        public string? Fax { get; set; }

        [JsonProperty("emailAddress")]
        public string? EmailAddress { get; set; }
    }
}
