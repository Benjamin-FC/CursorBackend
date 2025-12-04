using Newtonsoft.Json;

namespace FrankCrumCrmApiClient.Models
{
    public class ContactTypeLookupResponse
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("contactTypeName")]
        public string? ContactTypeName { get; set; }
    }
}
