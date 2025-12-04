using FrankCrumCrm.Application.DTOs;
using FrankCrumCrm.Domain.Entities;

namespace FrankCrumCrm.Tests.Helpers
{
    public static class TestDataBuilder
    {
        public static ClientData CreateClientData(string? clientId = null, string? clientLegalName = null)
        {
            return new ClientData
            {
                ClientId = clientId ?? "123",
                ClientLegalName = clientLegalName ?? "Test Client",
                Dba = "Test DBA",
                Status = "Active"
            };
        }

        public static PayrollManager CreatePayrollManager(int id = 1, string? name = null)
        {
            return new PayrollManager
            {
                Id = id,
                Name = name ?? "Test Manager",
                FirstName = "Test",
                LastName = "Manager"
            };
        }

        public static PIScreenClientInformation CreatePIScreenClientInformation(string? clientId = null)
        {
            return new PIScreenClientInformation
            {
                ClientId = clientId ?? "123",
                ClientName = "Test Client",
                State = "FL",
                PayrollLevel = "Level 1"
            };
        }

        public static EmployerOnbTemplatesProcessed CreateEmployerOnbTemplatesProcessed(int id = 1, string? clientNumber = null)
        {
            return new EmployerOnbTemplatesProcessed
            {
                Id = id,
                ClientNumber = clientNumber ?? "123",
                ProcessedFlag = false,
                CreatedDateTimeUtc = DateTime.UtcNow
            };
        }

        public static CreateOnboardingRequest CreateOnboardingRequest(string? clientNumber = null)
        {
            return new CreateOnboardingRequest
            {
                ClientNumber = clientNumber ?? "123",
                ProcessedFlag = false,
                NewOnboardingPin = "PIN123",
                LegalEntityDivisionId = 1
            };
        }

        public static PIScreenBillingInformation CreatePIScreenBillingInformation(int clientNumber = 123)
        {
            return new PIScreenBillingInformation
            {
                ClientNumber = clientNumber,
                PaymentMethod = "Credit Card",
                Epli = 100.0,
                FrankAdviceRate = 0.05
            };
        }

        public static WCSurcharge CreateWCSurcharge(string? state = null, double amount = 100.0)
        {
            return new WCSurcharge
            {
                State = state ?? "FL",
                Amount = amount
            };
        }

        public static PIScreenPayrollInformation CreatePIScreenPayrollInformation()
        {
            return new PIScreenPayrollInformation
            {
                PayrollLevel = "Level 1",
                PreNote = "Test pre-note",
                SpecialApprovals = "None"
            };
        }

        public static EVerify CreateEVerify(string? eVerifyValue = null)
        {
            return new EVerify
            {
                EVerifyValue = eVerifyValue ?? "Yes",
                EVerifyState = "FL",
                EVerifyCost = "10.00"
            };
        }

        public static TerminatedClientsInformation CreateTerminatedClientsInformation(List<int>? clientIds = null)
        {
            return new TerminatedClientsInformation
            {
                TerminatedClientIds = clientIds ?? new List<int> { 123, 456 }
            };
        }

        public static PIScreenClientContact CreatePIScreenClientContact(int contactId = 1)
        {
            return new PIScreenClientContact
            {
                ContactId = contactId,
                Contact = "John Doe",
                EmailAddress = "john.doe@example.com",
                BusinessPhone = "555-1234"
            };
        }

        public static ContactTypeLookup CreateContactTypeLookup(string? contactTypeName = null)
        {
            return new ContactTypeLookup
            {
                Id = Guid.NewGuid(),
                ContactTypeName = contactTypeName ?? "Primary"
            };
        }

        public static PIScreenAdditionalContact CreatePIScreenAdditionalContact()
        {
            return new PIScreenAdditionalContact
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                IsPrimaryContact = true,
                IsContractSigner = false
            };
        }

        public static Offsets CreateOffsets(int clientNumber = 123, string? divisionNumber = null)
        {
            return new Offsets
            {
                ClientNumber = clientNumber,
                DivisionNumber = divisionNumber ?? "DIV1",
                PaymentOffestDay = 1,
                ReceivedOffestDay = 2,
                ShippingOffsetDay = 3,
                HolidayOffsetDay = 4
            };
        }

        public static ClientPayrollInformation CreateClientPayrollInformation(int clientNumber = 123)
        {
            return new ClientPayrollInformation
            {
                ClientNumber = clientNumber,
                DivisionNumber = "DIV1",
                ComplianceHold = false,
                PayrollLevel = 1,
                PaymentMethod = "ACH"
            };
        }

        public static ClientProcessingTeam CreateClientProcessingTeam(int clientNumber = 123)
        {
            return new ClientProcessingTeam
            {
                ClientNumber = clientNumber,
                Client = "Test Client",
                SupervisorId = 1,
                ManagerId = 2,
                RepId = 3
            };
        }

        public static ProcessingTeamContacts CreateProcessingTeamContacts()
        {
            return new ProcessingTeamContacts
            {
                PayrollRep = new Contact
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com"
                },
                PayrollSupervisor = new Contact
                {
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@example.com"
                }
            };
        }

        public static UpdateClientPinRequest CreateUpdateClientPinRequest(string? clientPin = null)
        {
            return new UpdateClientPinRequest
            {
                ClientPin = clientPin ?? "1234",
                LegalEntityDivisionId = 1
            };
        }
    }
}
