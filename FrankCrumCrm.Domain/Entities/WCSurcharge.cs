using Newtonsoft.Json;

namespace FrankCrumCrm.Domain.Entities
{
    public class WCSurcharge
    {
        [JsonProperty("state")]
        public string? State { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }
    }
}
