namespace FrankCrumCrm.Application.DTOs
{
    public class CreateOnboardingRequest
    {
        public string? NewOnboardingPin { get; set; }
        public bool ProcessedFlag { get; set; }
        public string? UltiproCompanyId { get; set; }
        public string? WorklioId { get; set; }
        public string? ClientNumber { get; set; }
        public int LegalEntityDivisionId { get; set; }
    }
}
