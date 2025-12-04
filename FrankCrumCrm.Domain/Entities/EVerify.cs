using Newtonsoft.Json;

namespace FrankCrumCrm.Domain.Entities
{
    public class EVerify
    {
        [JsonProperty("eVerify")]
        public string? EVerifyValue { get; set; }

        [JsonProperty("eVerifyCost")]
        public string? EVerifyCost { get; set; }

        [JsonProperty("eVerifyState")]
        public string? EVerifyState { get; set; }
    }
}
