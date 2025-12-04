using Newtonsoft.Json;

namespace FrankCrumCrmApiClient.Models
{
    public class ProcessingTeamContacts
    {
        [JsonProperty("payrollRep")]
        public Contact? PayrollRep { get; set; }

        [JsonProperty("payrollSupervisor")]
        public Contact? PayrollSupervisor { get; set; }
    }
}
