using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CARPDataGenerator.Models
{
    /// <summary>
    /// Super class for CTR and STR transactions
    /// </summary>
  
    public class TRANSACTIONS
    {
        [MaxLength(length: 50)]
        public string TRANSACTION_NUMBER { get; set; }

        /// <summary>
        /// Used for FTR
        /// </summary>
        public string REFERENCE_NUMBER { get; set; }

        [MaxLength(length: 4000)]
        public string TRANSACTION_DESCRIPTION { get; set; }

        [MaxLength(length: 255)]
        public string TRANSACTION_LOCATION { get; set; }

        public DateTime? TRANSACTION_DATE { get; set; } // should not be null

        [MaxLength(length: 20)]
        public string TELLER { get; set; }

        [MaxLength(length: 20)]
        public string AUTHORIZED { get; set; }

        public bool? LATE_DEPOSIT { get; set; }

        /// <summary>
        /// date of posting if different from date_of_transaction
        /// </summary>
        public DateTime? DATE_POSTING { get; set; }

        public DateTime? VALUE_DATE { get; set; }


        public double AMOUNT_LOCAL { get; set; }

        /// <summary>
        /// Enumeration - type conduction_type
        /// </summary>
        public string TRANSACTION_MODE_CODE { get; set; }
        public string TRANSACTION_MODE_DESC { get; set; }

        /// <summary>
        /// Description if transaction mode code is 'O' (other)
        /// </summary>
        [MaxLength(length: 50)]
        public string TRANSACTION_MODE_COMMENT { get; set; }

        public string PURPOSE_OF_TRANSACTION { get; set; }



        // FROM FOREIGN CURRENCY 
        /// <summary>
        /// Enumeration - currencies
        /// </summary>
        public string FROM_FOREIGN_CURRENCY_CODE { get; set; }
        public double? FROM_FOREIGN_AMOUNT { get; set; }
        public double? FROM_FOREIGN_EXCHANGE_RATE { get; set; }
        // FROM FOREIGN CURRENCY END


        public string FROM_FUNDS_CODE { get; set; }
        public string FROM_FUNDS_COMMENT { get; set; }
        /// <summary>
        /// Enumeration - country_codes
        /// </summary>
        public string FROM_COUNTRY { get; set; }


        public string TRANS_CONDUCTOR { get; set; }

        /// <summary>
        /// USED WITH FTR
        /// </summary>
        public string FROM_CUSTOMER_TYPE { get; set; }


        #region FROM_ACCOUNT RECORD

        public string FROM_CMO { get; set; }

        [MaxLength(length: 255)]
        public string FROM_INSTITUTION_NAME { get; set; }

        [MaxLength(length: 50)]
        public string FROM_INSTITUTION_CODE { get; set; }

        [MaxLength(length: 11)]
        public string FROM_INSTITUTION_SWIFT { get; set; }

        public bool? FROM_NON_BANK_INSTUTION { get; set; }

        [MaxLength(length: 255)]
        public string FROM_INSTITUTION_BRANCH { get; set; }

        /// <summary>
        /// BRANCH or BRANCH CODE for CTR
        /// </summary>
        public string FROM_INSTITUTION_BRANCH_CODE { get; set; }

        [MaxLength(length: 50)]
        public string FROM_ACCOUNT { get; set; }

        /// <summary>
        /// Enumeration -> currencies
        /// </summary>
        public string FROM_CURRENCY_CODE { get; set; }

        [MaxLength(length: 255)]
        public string FROM_ACCOUNT_NAME { get; set; }

        [MaxLength(length: 34)]
        public string FROM_ACCOUNT_IBAN { get; set; }

        [MaxLength(length: 11)]
        public string FROM_CLIENT_NUMBER { get; set; }

        /// <summary>
        /// Enumeration -> account_type
        /// </summary>
        public string FROM_PERSONAL_ACCOUNT_TYPE { get; set; }

        public string FROM_PERSONAL_ACCOUNT_DESC { get; set; }


        // FROM_ACCOUNT ENTITY RECORD - BUSINESS ENTITY OWNING THE ACCOUNT {type 't_entity'}
        // entity record held in 'from entity records' region


        // SIGNATORY RECORDS IN TRANSACTIONSIGNATORYORDIRECTORY TABLE


        public DateTime? OPENED { get; set; }
        public DateTime? CLOSED { get; set; }
        public double? BALANCE { get; set; }
        public DateTime? DATE_BALANCE { get; set; }

        /// <summary>
        /// Enumeration -> account_status_type
        /// </summary>
        public string STATUS_CODE { get; set; }
        public string STATUS_DESC { get; set; }

        [MaxLength(length: 100)]
        public string BENEFICIARY { get; set; }

        [MaxLength(length: 255)]
        public string BENEFICIARY_COMMENT { get; set; }

        [MaxLength(length: 4000)]
        public string FROM_ACCOUNT_COMMENTS { get; set; }

        #endregion



        #region FROM_PERSON RECORD

        /// <summary>
        /// values: M or F or '-'
        /// </summary>
        public string FROM_PERSON_GENDER { get; set; }

        [MaxLength(length: 30)]
        public string FROM_PERSON_TITLE { get; set; }

        [MaxLength(length: 100)]
        public string FROM_PERSON_FIRST_NAME { get; set; }

        [MaxLength(length: 100)]
        public string FROM_PERSON_MIDDLE_NAME { get; set; }

        [MaxLength(length: 100)]
        public string FROM_PERSON_PREFIX { get; set; }

        [MaxLength(length: 100)]
        public string FROM_PERSON_LAST_NAME { get; set; }

        public DateTime? FROM_PERSON_BIRTHDATE { get; set; }

        [MaxLength(length: 255)]
        public string FROM_PERSON_BIRTH_PLACE { get; set; }

        [MaxLength(length: 100)]
        public string FROM_PERSON_MOTHERS_NAME { get; set; }

        [MaxLength(length: 100)]
        public string FROM_PERSON_ALIAS { get; set; }

        [MaxLength(length: 25)]
        public string FROM_PERSON_SSN { get; set; }

        [MaxLength(length: 25)]
        public string FROM_PERSON_PASSPORT_NUMBER { get; set; }

        [MaxLength(length: 25)]
        public string FROM_PERSON_PASSPORT_COUNTRY { get; set; }

        [MaxLength(length: 25)]
        public string FROM_PERSON_ID_NUMBER { get; set; }



        // FROM_PERSON PHONE -> type 't_phone'

        /// <summary>
        /// Enumeration -> contact_type
        /// </summary>
        public string FROM_PERSON_TPH_CONTACT_TYPE { get; set; }

        /// <summary>
        /// Enumeration -> communication_type
        /// </summary>
        public string FROM_PERSON_TPH_COMMUNICATION_TYPE { get; set; }

        [MaxLength(length: 4)]
        public string FROM_PERSON_COUNTRY_PREFIX { get; set; }

        [MaxLength(length: 50)]
        public string FROM_PERSON_NUMBER { get; set; }

        [MaxLength(length: 10)]
        public string FROM_PERSON_TPH_EXTENSION { get; set; }

        [MaxLength(length: 4000)]
        public string FROM_PERSON_PHONE_COMMENTS { get; set; }

        // FROM_PERSON PHONE END



        // FROM_PERSON ADDRESS NODE START -> type 't_address'

        /// <summary>
        /// Enumeration -> contact_type
        /// </summary>
        public string FROM_PERSON_ADDRESS_TYPE { get; set; }

        [MaxLength(length: 100)]
        public string FROM_PERSON_ADDRESS { get; set; }

        [MaxLength(length: 255)]
        public string FROM_PERSON_TOWN { get; set; }

        [MaxLength(length: 255)]
        public string FROM_PERSON_CITY { get; set; }

        [MaxLength(length: 10)]
        public string FROM_PERSON_ZIP { get; set; }

        /// <summary>
        /// Enumeration -> country_codes
        /// </summary>
        public string FROM_PERSON_COUNTRY_CODE { get; set; }

        [MaxLength(length: 255)]
        public string FROM_PERSON_STATE { get; set; }

        [MaxLength(length: 25)]
        public string FROM_PERSON_ADDRESS_COMMENTS { get; set; }

        // FROM_PERSON ADDRESS NODE END -> TYPE 't_address'



        /// <summary>
        /// Enumeration -> country_codes
        /// </summary>
        public string FROM_PERSON_NATIONALITY1 { get; set; }
        /// <summary>
        /// Enumeration -> country_codes
        /// </summary>
        public string FROM_PERSON_NATIONALITY2 { get; set; }
        /// <summary>
        /// Enumeration -> country_codes
        /// </summary>
        public string FROM_PERSON_NATIONALITY3 { get; set; }

        /// <summary>
        /// Enumeration -> country_codes
        /// </summary>
        public string FROM_PERSON_RESIDENCE { get; set; }

        // up to 5 emails
        public string FROM_PERSON_EMAIL1 { get; set; }
        public string FROM_PERSON_EMAIL2 { get; set; }
        public string FROM_PERSON_EMAIL3 { get; set; }
        public string FROM_PERSON_EMAIL4 { get; set; }
        public string FROM_PERSON_EMAIL5 { get; set; }


        [MaxLength(length: 255)]
        public string FROM_PERSON_OCCUPATION { get; set; }


        [MaxLength(length: 255)]
        public string FROM_PERSON_EMPLOYER_NAME { get; set; }

        // EMPLOYER ADDRESS NODE START -> type 't_address'

        /// <summary>
        /// Enumeration -> contact_type
        /// </summary>
        public string FROM_PERSON_EMPLOYER_ADDRESS_TYPE { get; set; }

        [MaxLength(length: 100)]
        public string FROM_PERSON_EMPLOYER_ADDRESS { get; set; }

        [MaxLength(length: 255)]
        public string FROM_PERSON_EMPLOYER_TOWN { get; set; }

        [MaxLength(length: 255)]
        public string FROM_PERSON_EMPLOYER_CITY { get; set; }

        [MaxLength(length: 10)]
        public string FROM_PERSON_EMPLOYER_ZIP { get; set; }

        /// <summary>
        /// Enumeration -> country_codes
        /// </summary>
        public string FROM_PERSON_EMPLOYER_COUNTRY_CODE { get; set; }

        [MaxLength(length: 255)]
        public string FROM_PERSON_EMPLOYER_STATE { get; set; }

        [MaxLength(length: 25)]
        public string FROM_PERSON_EMPLOYER_ADDRESS_COMMENTS { get; set; }

        // EMPLOYER ADDRESS NODE END -> TYPE 't_address'


        // EMPLOYER PHONE -> type 't_phone'

        /// <summary>
        /// Enumeration -> contact_type
        /// </summary>
        public string FROM_PERSON_EMPLOYER_TPH_CONTACT_TYPE { get; set; }

        /// <summary>
        /// Enumeration -> communication_type
        /// </summary>
        public string FROM_PERSON_EMPLOYER_TPH_COMMUNICATION_TYPE { get; set; }

        [MaxLength(length: 4)]
        public string FROM_PERSON_EMPLOYER_COUNTRY_PREFIX { get; set; }

        [MaxLength(length: 50)]
        public string FROM_PERSON_EMPLOYER_NUMBER { get; set; }

        [MaxLength(length: 10)]
        public string FROM_PERSON_EMPLOYER_TPH_EXTENSION { get; set; }

        [MaxLength(length: 4000)]
        public string FROM_PERSON_EMPLOYER_PHONE_COMMENTS { get; set; }
        // EMPLOYER PHONE END


        // identification (can include multiple records for the same FROM_PERSON) -> type 't_person_identification' on TRANSACTIONPERSONIDENTIFICATION table 

        public bool? DECEASED { get; set; }
        public DateTime? FROM_PERSON_DECEASED_DATE { get; set; }

        [MaxLength(length: 100)]
        public string FROM_PERSON_TAX_NUMBER { get; set; }

        [MaxLength(length: 100)]
        public string FROM_PERSON_TAX_REG_NUMBER { get; set; }

        [MaxLength(length: 255)]
        public string FROM_PERSON_SOURCE_OF_WEALTH { get; set; }

        [MaxLength(length: 4000)]
        public string FROM_PERSON_COMMENTS { get; set; }



        // === FROM PERSON END ===

        #endregion



        #region FROM ENTITY RECORD
        // used for specifying 'from_entity' and 'from_account->t_entity' records

        [MaxLength(length: 255)]
        public string FROM_ENTITY_NAME { get; set; }

        [MaxLength(length: 255)]
        public string FROM_ENTITY_COMMERCIAL_NAME { get; set; }

        /// <summary>
        /// Enumeration -> legal_form_type
        /// </summary>
        public string FROM_ENTITY_INCORPORATION_LEGAL_FORM { get; set; }

        [MaxLength(length: 50)]
        public string FROM_ENTITY_INCORPORATION_NUMBER { get; set; }

        [MaxLength(length: 255)]
        public string FROM_ENTITY_BUSINESS { get; set; }



        // FROM_ENTITY PHONE -> type 't_phone'

        /// <summary>
        /// Enumeration -> contact_type
        /// </summary>
        public string FROM_ENTITY_TPH_CONTACT_TYPE { get; set; }

        /// <summary>
        /// Enumeration -> communication_type
        /// </summary>
        public string FROM_ENTITY_TPH_COMMUNICATION_TYPE { get; set; }

        [MaxLength(length: 4)]
        public string FROM_ENTITY_COUNTRY_PREFIX { get; set; }

        [MaxLength(length: 50)]
        public string FROM_ENTITY_NUMBER { get; set; }

        [MaxLength(length: 10)]
        public string FROM_ENTITY_TPH_EXTENSION { get; set; }

        [MaxLength(length: 4000)]
        public string FROM_ENTITY_PHONE_COMMENTS { get; set; }

        // FROM_ENTITY PHONE END


        // FROM_ENTITY ADDRESS NODE START -> type 't_address'

        /// <summary>
        /// Enumeration -> contact_type
        /// </summary>
        public string FROM_ENTITY_ADDRESS_TYPE { get; set; }

        public string FROM_ENTITY_ADDRESS_DESC { get; set; }

        [MaxLength(length: 100)]
        public string FROM_ENTITY_ADDRESS { get; set; }

        [MaxLength(length: 255)]
        public string FROM_ENTITY_TOWN { get; set; }

        [MaxLength(length: 255)]
        public string FROM_ENTITY_CITY { get; set; }

        [MaxLength(length: 10)]
        public string FROM_ENTITY_ZIP { get; set; }

        /// <summary>
        /// Enumeration -> country_codes
        /// </summary>
        public string FROM_ENTITY_COUNTRY_CODE { get; set; }

        [MaxLength(length: 255)]
        public string FROM_ENTITY_STATE { get; set; }

        [MaxLength(length: 25)]
        public string FROM_ENTITY_ADDRESS_COMMENTS { get; set; }

        // FROM_ENTITY ADDRESS NODE END -> TYPE 't_address'



        [MaxLength(length: 255)]
        public string FROM_ENTITY_EMAIL { get; set; }
        [MaxLength(length: 255)]
        public string FROM_ENTITY_URL { get; set; }

        [MaxLength(length: 255)]
        public string FROM_ENTITY_INCORPORATION_STATE { get; set; }

        /// <summary>
        /// Enumeration -> country_codes
        /// </summary>
        public string FROM_ENTITY_INCORPORATION_COUNTRY_CODE { get; set; }



        // ENTITY DIRECTOR ID -> TRANSACTIONSIGNATORYORDIRECTOR TABLE (multiple records)


        public DateTime? FROM_ENTITY_INCORPORATION_DATE { get; set; }
        public bool? FROM_ENTITY_BUSINESS_CLOSED { get; set; }
        public DateTime? FROM_ENTITY_DATE_BUSINESS_CLOSED { get; set; }

        [MaxLength(length: 100)]
        public string FROM_ENTITY_TAX_NUMBER { get; set; }

        [MaxLength(length: 100)]
        public string FROM_ENTITY_TAX_REG_NUMBER { get; set; }

        [MaxLength(length: 4000)]
        public string FROM_ENTITY_COMMENTS { get; set; }

        #endregion



        public string TO_FUNDS_CODE { get; set; }
        public string TO_FUNDS_COMMENT { get; set; }


        // TO FOREIGN CURRENCY 
        /// <summary>
        /// Enumeration - currencies
        /// </summary>
        public string TO_FOREIGN_CURRENCY_CODE { get; set; }
        public double? TO_FOREIGN_AMOUNT { get; set; }
        public double? TO_FOREIGN_EXCHANGE_RATE { get; set; }
        // TO FOREIGN CURRENCY END

        /// <summary>
        /// Enumeration - country_codes
        /// </summary>
        public string TO_COUNTRY_CODE { get; set; }

        #region TO_ACCOUNT RECORD
        public string TO_CMO { get; set; }

        /// <summary>
        /// USED WITH FTR
        /// </summary>
        public string TO_CUSTOMER_TYPE { get; set; }

        [MaxLength(length: 255)]
        public string TO_INSTITUTION_NAME { get; set; }

        [MaxLength(length: 50)]
        public string TO_INSTITUTION_CODE { get; set; }

        public string TO_INSTITUTION_BRANCH_CODE { get; set; }

        [MaxLength(length: 11)]
        public string TO_INSTITUTION_SWIFT { get; set; }

        public bool? TO_NON_BANK_INSTUTION { get; set; }

        [MaxLength(length: 255)]
        public string TO_INSTITUTION_BRANCH { get; set; }

        [MaxLength(length: 50)]
        public string TO_ACCOUNT { get; set; }

        /// <summary>
        /// Enumeration -> currencies
        /// </summary>
        public string TO_CURRENCY_CODE { get; set; }

        [MaxLength(length: 255)]
        public string TO_ACCOUNT_NAME { get; set; }

        [MaxLength(length: 34)]
        public string TO_ACCOUNT_IBAN { get; set; }

        [MaxLength(length: 11)]
        public string TO_CLIENT_NUMBER { get; set; }

        /// <summary>
        /// Enumeration -> account_type
        /// </summary>
        public string TO_PERSONAL_ACCOUNT_TYPE { get; set; }

        public string TO_PERSONAL_ACCOUNT_DESC { get; set; }


        // TO_ACCOUNT ENTITY RECORD - BUSINESS ENTITY OWNING THE ACCOUNT {type 't_entity'}
        // entity record held in 'TO entity records' region


        // SIGNATORY RECORDS IN TRANSACTIONSIGNATORYORDIRECTORY TABLE


        public DateTime? TO_OPENED { get; set; }
        public DateTime? TO_CLOSED { get; set; }
        public double? TO_BALANCE { get; set; }
        public DateTime? TO_DATE_BALANCE { get; set; }

        /// <summary>
        /// Enumeration -> account_type
        /// </summary>
        public string TO_STATUS_CODE { get; set; }
        public string TO_STATUS_DESC { get; set; }

        [MaxLength(length: 100)]
        public string TO_BENEFICIARY { get; set; }

        [MaxLength(length: 255)]
        public string TO_BENEFICIARY_COMMENT { get; set; }

        [MaxLength(length: 4000)]
        public string TO_ACCOUNT_COMMENTS { get; set; }

        #endregion



        #region TO_PERSON RECORD

        /// <summary>
        /// values: M or F
        /// </summary>
        public string TO_PERSON_GENDER { get; set; }

        [MaxLength(length: 30)]
        public string TO_PERSON_TITLE { get; set; }

        [MaxLength(length: 100)]
        public string TO_PERSON_FIRST_NAME { get; set; }

        [MaxLength(length: 100)]
        public string TO_PERSON_MIDDLE_NAME { get; set; }

        [MaxLength(length: 100)]
        public string TO_PERSON_PREFIX { get; set; }

        [MaxLength(length: 100)]
        public string TO_PERSON_LAST_NAME { get; set; }

        public DateTime? TO_PERSON_BIRTHDATE { get; set; }

        [MaxLength(length: 255)]
        public string TO_PERSON_BIRTH_PLACE { get; set; }

        [MaxLength(length: 100)]
        public string TO_PERSON_MOTHERS_NAME { get; set; }

        [MaxLength(length: 100)]
        public string TO_PERSON_ALIAS { get; set; }

        [MaxLength(length: 25)]
        public string TO_PERSON_SSN { get; set; }

        [MaxLength(length: 25)]
        public string TO_PERSON_PASSPORT_NUMBER { get; set; }

        [MaxLength(length: 25)]
        public string TO_PERSON_PASSPORT_COUNTRY { get; set; }

        [MaxLength(length: 25)]
        public string TO_PERSON_ID_NUMBER { get; set; }



        // TO_PERSON PHONE -> type 't_phone'

        /// <summary>
        /// Enumeration -> contact_type
        /// </summary>
        public string TO_PERSON_TPH_CONTACT_TYPE { get; set; }

        /// <summary>
        /// Enumeration -> communication_type
        /// </summary>
        public string TO_PERSON_TPH_COMMUNICATION_TYPE { get; set; }

        [MaxLength(length: 4)]
        public string TO_PERSON_COUNTRY_PREFIX { get; set; }

        [MaxLength(length: 50)]
        public string TO_PERSON_NUMBER { get; set; }

        [MaxLength(length: 10)]
        public string TO_PERSON_TPH_EXTENSION { get; set; }

        [MaxLength(length: 4000)]
        public string TO_PERSON_PHONE_COMMENTS { get; set; }

        // TO_PERSON PHONE END



        // TO_PERSON ADDRESS NODE START -> type 't_address'

        /// <summary>
        /// Enumeration -> contact_type
        /// </summary>
        public string TO_PERSON_ADDRESS_TYPE { get; set; }

        [MaxLength(length: 100)]
        public string TO_PERSON_ADDRESS { get; set; }

        [MaxLength(length: 255)]
        public string TO_PERSON_TOWN { get; set; }

        [MaxLength(length: 255)]
        public string TO_PERSON_CITY { get; set; }

        [MaxLength(length: 10)]
        public string TO_PERSON_ZIP { get; set; }

        /// <summary>
        /// Enumeration -> country_codes
        /// </summary>
        public string TO_PERSON_COUNTRY_CODE { get; set; }

        [MaxLength(length: 255)]
        public string TO_PERSON_STATE { get; set; }

        [MaxLength(length: 25)]
        public string TO_PERSON_ADDRESS_COMMENTS { get; set; }

        // TO_PERSON ADDRESS NODE END -> TYPE 't_address'



        /// <summary>
        /// Enumeration -> country_codes
        /// </summary>
        public string TO_PERSON_NATIONALITY1 { get; set; }
        /// <summary>
        /// Enumeration -> country_codes
        /// </summary>
        public string TO_PERSON_NATIONALITY2 { get; set; }
        /// <summary>
        /// Enumeration -> country_codes
        /// </summary>
        public string TO_PERSON_NATIONALITY3 { get; set; }

        /// <summary>
        /// Enumeration -> country_codes
        /// </summary>
        public string TO_PERSON_RESIDENCE { get; set; }

        // up to 5 emails
        public string TO_PERSON_EMAIL1 { get; set; }
        public string TO_PERSON_EMAIL2 { get; set; }
        public string TO_PERSON_EMAIL3 { get; set; }
        public string TO_PERSON_EMAIL4 { get; set; }
        public string TO_PERSON_EMAIL5 { get; set; }


        [MaxLength(length: 255)]
        public string TO_PERSON_OCCUPATION { get; set; }


        [MaxLength(length: 255)]
        public string TO_PERSON_EMPLOYER_NAME { get; set; }

        // EMPLOYER ADDRESS NODE START -> type 't_address'

        /// <summary>
        /// Enumeration -> contact_type
        /// </summary>
        public string TO_PERSON_EMPLOYER_ADDRESS_TYPE { get; set; }

        [MaxLength(length: 100)]
        public string TO_PERSON_EMPLOYER_ADDRESS { get; set; }

        [MaxLength(length: 255)]
        public string TO_PERSON_EMPLOYER_TOWN { get; set; }

        [MaxLength(length: 255)]
        public string TO_PERSON_EMPLOYER_CITY { get; set; }

        [MaxLength(length: 10)]
        public string TO_PERSON_EMPLOYER_ZIP { get; set; }

        /// <summary>
        /// Enumeration -> country_codes
        /// </summary>
        public string TO_PERSON_EMPLOYER_COUNTRY_CODE { get; set; }

        [MaxLength(length: 255)]
        public string TO_PERSON_EMPLOYER_STATE { get; set; }

        [MaxLength(length: 25)]
        public string TO_PERSON_EMPLOYER_ADDRESS_COMMENTS { get; set; }

        // EMPLOYER ADDRESS NODE END -> TYPE 't_address'


        // EMPLOYER PHONE -> type 't_phone'

        /// <summary>
        /// Enumeration -> contact_type
        /// </summary>
        public string TO_PERSON_EMPLOYER_TPH_CONTACT_TYPE { get; set; }

        /// <summary>
        /// Enumeration -> communication_type
        /// </summary>
        public string TO_PERSON_EMPLOYER_TPH_COMMUNICATION_TYPE { get; set; }

        [MaxLength(length: 4)]
        public string TO_PERSON_EMPLOYER_COUNTRY_PREFIX { get; set; }

        [MaxLength(length: 50)]
        public string TO_PERSON_EMPLOYER_NUMBER { get; set; }

        [MaxLength(length: 10)]
        public string TO_PERSON_EMPLOYER_TPH_EXTENSION { get; set; }

        [MaxLength(length: 4000)]
        public string TO_PERSON_EMPLOYER_PHONE_COMMENTS { get; set; }
        // EMPLOYER PHONE END


        // identification (can include multiple records for the same TO_PERSON) -> type 't_person_identification' on TRANSACTIONPERSONIDENTIFICATION table 

        public bool? TO_PERSON_DECEASED { get; set; }
        public DateTime? TO_PERSON_DECEASED_DATE { get; set; }

        [MaxLength(length: 100)]
        public string TO_PERSON_TAX_NUMBER { get; set; }

        [MaxLength(length: 100)]
        public string TO_PERSON_TAX_REG_NUMBER { get; set; }

        [MaxLength(length: 255)]
        public string TO_PERSON_SOURCE_OF_WEALTH { get; set; }

        [MaxLength(length: 4000)]
        public string TO_PERSON_COMMENTS { get; set; }



        // === TO PERSON END ===

        #endregion



        #region TO ENTITY RECORD
        // used for specifying 'TO_entity' and 'TO_account->t_entity' records

        [MaxLength(length: 255)]
        public string TO_ENTITY_NAME { get; set; }

        [MaxLength(length: 255)]
        public string TO_ENTITY_COMMERCIAL_NAME { get; set; }

        /// <summary>
        /// Enumeration -> legal_form_type
        /// </summary>
        public string TO_ENTITY_INCORPORATION_LEGAL_FORM { get; set; }

        [MaxLength(length: 50)]
        public string TO_ENTITY_INCORPORATION_NUMBER { get; set; }

        [MaxLength(length: 255)]
        public string TO_ENTITY_BUSINESS { get; set; }



        // TO_ENTITY PHONE -> type 't_phone'

        /// <summary>
        /// Enumeration -> contact_type
        /// </summary>
        public string TO_ENTITY_TPH_CONTACT_TYPE { get; set; }

        /// <summary>
        /// Enumeration -> communication_type
        /// </summary>
        public string TO_ENTITY_TPH_COMMUNICATION_TYPE { get; set; }

        [MaxLength(length: 4)]
        public string TO_ENTITY_COUNTRY_PREFIX { get; set; }

        [MaxLength(length: 50)]
        public string TO_ENTITY_NUMBER { get; set; }

        [MaxLength(length: 10)]
        public string TO_ENTITY_TPH_EXTENSION { get; set; }

        [MaxLength(length: 4000)]
        public string TO_ENTITY_PHONE_COMMENTS { get; set; }

        // TO_ENTITY PHONE END


        // TO_ENTITY ADDRESS NODE START -> type 't_address'

        /// <summary>
        /// Enumeration -> contact_type
        /// </summary>
        public string TO_ENTITY_ADDRESS_TYPE { get; set; }

        /// <summary>
        /// USED WITH FTR
        /// </summary>
        public string TO_ENTITY_ADDRESS_DESC { get; set; }

        [MaxLength(length: 100)]
        public string TO_ENTITY_ADDRESS { get; set; }

        [MaxLength(length: 255)]
        public string TO_ENTITY_TOWN { get; set; }

        [MaxLength(length: 255)]
        public string TO_ENTITY_CITY { get; set; }

        [MaxLength(length: 10)]
        public string TO_ENTITY_ZIP { get; set; }

        /// <summary>
        /// Enumeration -> country_codes
        /// </summary>
        public string TO_ENTITY_COUNTRY_CODE { get; set; }

        [MaxLength(length: 255)]
        public string TO_ENTITY_STATE { get; set; }

        [MaxLength(length: 25)]
        public string TO_ENTITY_ADDRESS_COMMENTS { get; set; }

        // TO_ENTITY ADDRESS NODE END -> TYPE 't_address'



        [MaxLength(length: 255)]
        public string TO_ENTITY_EMAIL { get; set; }
        [MaxLength(length: 255)]
        public string TO_ENTITY_URL { get; set; }

        [MaxLength(length: 255)]
        public string TO_ENTITY_INCORPORATION_STATE { get; set; }

        /// <summary>
        /// Enumeration -> country_codes
        /// </summary>
        public string TO_ENTITY_INCORPORATION_COUNTRY_CODE { get; set; }



        // ENTITY DIRECTOR ID -> TRANSACTIONSIGNATORYORDIRECTOR TABLE (multiple records)


        public DateTime? TO_ENTITY_INCORPORATION_DATE { get; set; }
        public bool? TO_ENTITY_BUSINESS_CLOSED { get; set; }
        public DateTime? TO_ENTITY_DATE_BUSINESS_CLOSED { get; set; }

        [MaxLength(length: 100)]
        public string TO_ENTITY_TAX_NUMBER { get; set; }

        [MaxLength(length: 100)]
        public string TO_ENTITY_TAX_REG_NUMBER { get; set; }

        [MaxLength(length: 4000)]
        public string TO_ENTITY_COMMENTS { get; set; }

        #endregion

        // EXTRAS
        public string CODE_FROM_TRANS { get; set; }
        public DateTime? DATE_GENERATED_FROM_DB { get; set; }

      }
 }
