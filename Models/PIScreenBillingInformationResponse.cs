using Newtonsoft.Json;

namespace FrankCrumCrmApiClient.Models
{
    public class PIScreenBillingInformationResponse
    {
        [JsonProperty("clientNumber")]
        public int ClientNumber { get; set; }

        [JsonProperty("paymentMethod")]
        public string? PaymentMethod { get; set; }

        [JsonProperty("shippingAddress")]
        public Address? ShippingAddress { get; set; }

        [JsonProperty("wcSurcharges")]
        public List<WCSurchargeResponse>? WcSurcharges { get; set; }

        [JsonProperty("epli")]
        public double? Epli { get; set; }

        [JsonProperty("frankAdviceRate")]
        public double? FrankAdviceRate { get; set; }

        [JsonProperty("minimumWCFee")]
        public double? MinimumWcFee { get; set; }

        [JsonProperty("minimumAdminFee")]
        public double? MinimumAdminFee { get; set; }

        [JsonProperty("cyberInsuranceRate")]
        public double? CyberInsuranceRate { get; set; }
    }
}
