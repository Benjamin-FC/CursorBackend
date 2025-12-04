using Newtonsoft.Json;

namespace FrankCrumCrmApiClient.Models
{
    public class ClientDataListResponse
    {
        [JsonProperty("clients")]
        public List<ClientData>? Clients { get; set; }
    }
}
