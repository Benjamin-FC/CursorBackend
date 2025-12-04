using Newtonsoft.Json;

namespace FrankCrumCrmApiClient.Models
{
    public class WCSurchargeResponse
    {
        [JsonProperty("state")]
        public string? State { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }
    }
}
