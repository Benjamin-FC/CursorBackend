using Newtonsoft.Json;

namespace FrankCrumCrm.Domain.Entities
{
    public class Offsets
    {
        [JsonProperty("clientNumber")]
        public int ClientNumber { get; set; }

        [JsonProperty("divisionNumber")]
        public string? DivisionNumber { get; set; }

        [JsonProperty("paymentOffestDay")]
        public int PaymentOffestDay { get; set; }

        [JsonProperty("receivedOffestDay")]
        public int ReceivedOffestDay { get; set; }

        [JsonProperty("shippingOffsetDay")]
        public int ShippingOffsetDay { get; set; }

        [JsonProperty("holidayOffsetDay")]
        public int HolidayOffsetDay { get; set; }
    }
}
