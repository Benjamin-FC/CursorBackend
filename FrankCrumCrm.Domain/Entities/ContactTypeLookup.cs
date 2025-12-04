using Newtonsoft.Json;

namespace FrankCrumCrm.Domain.Entities
{
    public class ContactTypeLookup
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("contactTypeName")]
        public string? ContactTypeName { get; set; }
    }
}
