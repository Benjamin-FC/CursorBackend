using Newtonsoft.Json;

namespace FrankCrumCrm.Domain.Entities
{
    public class PayrollManager
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
