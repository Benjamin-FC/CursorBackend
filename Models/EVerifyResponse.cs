using Newtonsoft.Json;

namespace FrankCrumCrmApiClient.Models
{
    public class EVerifyResponse
    {
        [JsonProperty("eVerify")]
        public string? EVerify { get; set; }

        [JsonProperty("eVerifyCost")]
        public string? EVerifyCost { get; set; }

        [JsonProperty("eVerifyState")]
        public string? EVerifyState { get; set; }
    }
}
