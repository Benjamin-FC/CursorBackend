using Newtonsoft.Json;

namespace FrankCrumCrm.Domain.Entities
{
    public class ProcessingTeamContacts
    {
        [JsonProperty("payrollRep")]
        public Contact? PayrollRep { get; set; }

        [JsonProperty("payrollSupervisor")]
        public Contact? PayrollSupervisor { get; set; }
    }

    public class Contact
    {
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }

        [JsonProperty("lastName")]
        public string? LastName { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }
    }
}
