/**
 * Type definitions for FrankCrum.Crm.Api
 * Generated from OpenAPI 3.0.1 specification
 */

export interface Address {
  address1?: string | null;
  address2?: string | null;
  city?: string | null;
  state?: string | null;
  zipCode?: string | null;
}

export interface ClientData {
  clientId?: string | null;
  editApproval?: string | null;
  dba?: string | null;
  clientLegalName?: string | null;
  complianceHold?: string | null;
  level?: string | null;
  paymentTermID?: string | null;
  paymentMethod?: string | null;
  status?: string | null;
}

export interface ClientDataResponse {
  clientId?: string | null;
  editApproval?: string | null;
  dba?: string | null;
  clientLegalName?: string | null;
  complianceHold?: string | null;
  level?: string | null;
  paymentTermID?: string | null;
  paymentMethod?: string | null;
  status?: string | null;
}

export interface ClientDataListResponse {
  clients?: ClientData[] | null;
}

export interface ClientPayrollInformationResponse {
  clientNumber: number;
  divisionNumber?: string | null;
  complianceHold: boolean;
  payrollLevel: number;
  payrollSubmitMethod?: string | null;
  editApproval?: boolean | null;
  paymentOffsetDay: number;
  receivedOffsetDay: number;
  paymentMethod?: string | null;
  states?: string | null;
  payrollManager?: string | null;
  payrollManagerExt?: string | null;
  ntReimbursements?: boolean | null;
  relatedClients?: RelatedClient[] | null;
}

export interface RelatedClient {
  organizationParentId: number;
  clientNumber: number;
  clientName?: string | null;
}

export interface ClientProcessingTeam {
  clientNumber: number;
  client?: string | null;
  supervisorId: number;
  supervisor?: string | null;
  managerId: number;
  manager?: string | null;
  repId: number;
  representative?: string | null;
}

export interface Contact {
  firstName?: string | null;
  lastName?: string | null;
  email?: string | null;
}

export interface ProcessingTeamContacts {
  payrollRep?: Contact;
  payrollSupervisor?: Contact;
}

export interface ContactTypeLookupResponse {
  id: string;
  contactTypeName?: string | null;
}

export interface EVerifyResponse {
  eVerify?: string | null;
  eVerifyCost?: string | null;
  eVerifyState?: string | null;
}

export interface Notification {
  security: boolean;
  newHire: boolean;
  termination: boolean;
}

export interface PIScreenAdditionalContactResponse {
  name?: string | null;
  firstName?: string | null;
  lastName?: string | null;
  title?: string | null;
  coiTransmission?: string | null;
  email?: string | null;
  businessPhone?: string | null;
  cellPhone?: string | null;
  fax?: string | null;
  contactType?: string[] | null;
  location?: string | null;
  notes?: string | null;
  isPrimaryContact: boolean;
  isContractSigner: boolean;
  notifications?: Notification;
}

export interface PIScreenBillingInformationResponse {
  clientNumber: number;
  paymentMethod?: string | null;
  shippingAddress?: Address;
  wcSurcharges?: WCSurchargeResponse[] | null;
  epli: number;
  frankAdviceRate: number;
  minimumWCFee: number;
  minimumAdminFee: number;
  cyberInsuranceRate: number;
}

export interface WCSurchargeResponse {
  state?: string | null;
  amount: number;
}

export interface PIScreenClientContactResponse {
  contactId: number;
  contact?: string | null;
  contactType?: string[] | null;
  businessPhone?: string | null;
  cellPhone?: string | null;
  fax?: string | null;
  emailAddress?: string | null;
}

export interface PIScreenClientInformationResponse {
  clientId?: string | null;
  clientName?: string | null;
  clientDBA?: string | null;
  state?: string | null;
  payrollLevel?: string | null;
  payrollFrequency?: string | null;
  annualContractAmount: number;
  creditLimit: number;
  payPeriod?: string | null;
  clientStartDate?: string | null;
  contact?: string | null;
  processorName?: string | null;
  notes?: string | null;
  payrollRule?: string | null;
  division?: string | null;
  backupPerson?: string | null;
  processingOrder?: string | null;
  dayPayPeriodStarts?: string | null;
}

export interface PIScreenPayrollInformationResponse {
  jobEndDate?: string | null;
  ownerMinimumAmount?: string | null;
  nonTaxableReimb?: string | null;
  preNote?: string | null;
  specialApprovals?: string | null;
  ntReimbursements?: string | null;
  payrollLevel?: string | null;
}

export interface OffsetsResponse {
  clientNumber: number;
  divisionNumber?: string | null;
  paymentOffestDay: number;
  receivedOffestDay: number;
  shippingOffsetDay: number;
  holidayOffsetDay: number;
}

export interface TerminatedClientsInformationResponse {
  terminatedClientIds?: number[] | null;
}

export interface UpdateClientPinRequest {
  clientPin?: string | null;
  legalEntityDivisionId: number;
}

export interface AddEmployerOnbTemplatesProcessedRequest {
  newOnboardingPIN?: string | null;
  processedFlag: boolean;
  ultiproCompanyID?: string | null;
  worklioID?: string | null;
  clientNumber?: string | null;
  legalEntityDivisionID: number;
}

export interface EmployerOnbTemplatesProcessedModel {
  id: number;
  jobExecutionDateTimeUtc: string;
  newOnboardingPIN?: string | null;
  processedFlag: boolean;
  createdDateTimeUtc: string;
  processedFlagUpdatedDateTimeUtc: string;
  ultiproCompanyID?: string | null;
  worklioID?: string | null;
  clientNumber?: string | null;
  legalEntityDivisionID: number;
}

export interface PayrollManagerResponse {
  id: number;
  name?: string | null;
  firstName?: string | null;
  lastName?: string | null;
  middleInitial?: string | null;
}
