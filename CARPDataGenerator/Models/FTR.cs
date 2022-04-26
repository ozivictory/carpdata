using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CARPDataGenerator.Models
{
    
    public class FTR
    {
        [Key]
        public int Id { get; set; }

        [NotMapped]
        public string InstitutionCode { get; set; }
        [NotMapped]
        public string InstitutionBranch { get; set; }
        // --
        public string CustomerType { get; set; }
        [NotMapped]
        public string SurnameOrNameOfOrganisation { get; set; }
        [NotMapped]
        public string FirstName { get; set; }
        [NotMapped]
        public string MiddleName { get; set; }
        [NotMapped]
        public string Nationality { get; set; }
        [NotMapped]
        public DateTime? DateOfBirth { get; set; }
        [NotMapped]
        public string DateOfIncorporation { get; set; }
        [NotMapped]
        public string OccupationOrLineOfBusiness { get; set; }
        [NotMapped]
        public string TypeOfIdentification { get; set; }
        [NotMapped]
        public string IdentificationNo { get; set; }
        // --
        public string RegistrationNumber { get; set; }
        [NotMapped]
        public DateTime? DateOfIssue { get; set; }
        [NotMapped]
        public string PlaceOfIssue { get; set; }
        [NotMapped]
        public string IssuingAuthority { get; set; }
        [NotMapped]
        public string CustomerAddressType { get; set; }
        [NotMapped]
        public string FirstLineAddress { get; set; }
        // --
        public string SecondLineAddress { get; set; }
        [NotMapped]
        public string TownOrCity { get; set; }
        // --
        public string LocalGovernment { get; set; }
        [NotMapped]
        public string State { get; set; }
        [NotMapped]
        public string Telephone { get; set; }
        [NotMapped]
        public string Email { get; set; }
        [NotMapped]
        public string AccountType { get; set; }
        [NotMapped]
        public string AccountNumber { get; set; }
        [NotMapped]
        public string AccountStatus { get; set; }
        [NotMapped]
        public string DateOfAccountOpening { get; set; }
        // --
        public string LinkedAccounts { get; set; }
        [NotMapped]
        public string TransactionDate { get; set; }
        [NotMapped]
        public string TransactionType { get; set; }
        [NotMapped]
        public string TransactionDetails { get; set; }
        [NotMapped]
        public string CurrencyType { get; set; }
        [NotMapped]
        public string Amount { get; set; }
        // --
        public string PurposeOfTransaction { get; set; }
        [NotMapped]
        public string SourceOfFunds { get; set; }
        [NotMapped]
        public string NameOfBeneficiary { get; set; }
        // --
        public string AddressOfBeneficiary { get; set; }
        [NotMapped]
        public string NameOfSender { get; set; }
        // --
        public string AddressOfSender { get; set; }

        public string CMO { get; set; }
        public string TransactionNumber { get; set; }
        public string ReferenceNumber { get; set; }

        public bool? ForSourceTransaction { get; set; }
        public bool? ForDestinationTransaction { get; set; }
    }
}
