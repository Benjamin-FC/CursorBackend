using Newtonsoft.Json;

namespace FrankCrumCrmApiClient.Models
{
    public class PayrollManagerResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("firstName")]
        public string? FirstName { get; set; }

        [JsonProperty("lastName")]
        public string? LastName { get; set; }

        [JsonProperty("middleInitial")]
        public string? MiddleInitial { get; set; }
    }
}
