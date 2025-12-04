using Newtonsoft.Json;

namespace FrankCrumCrmApiClient.Models
{
    public class Contact
    {
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }

        [JsonProperty("lastName")]
        public string? LastName { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }
    }
}
