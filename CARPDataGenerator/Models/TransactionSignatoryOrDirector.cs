using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CARPDataGenerator.Models
{
    public class TransactionSignatoryOrDirector
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string TRANSACTION_NUMBER { get; set; }

        /// <summary>
        /// if signatory record is for source transaction
        /// </summary>
        public bool? FOR_SOURCE_TRANSACTION { get; set; }

        /// <summary>
        /// if signatory record is for destination transaction
        /// </summary>
        public bool? FOR_DESTINATION_TRANSACTION { get; set; }


        /// <summary>
        /// indicates whether record is represented as signatory
        /// </summary>
        public bool? FOR_SIGNATORY_RECORD { get; set; }


        /// <summary>
        /// indicates whether record is represented as director
        /// </summary>
        public bool? FOR_DIRECTOR_RECORD { get; set; }

        /// <summary>
        /// unique Identification for signatory or director
        /// </summary>
        public string SIGNATORY_OR_DIRECTOR_ID { get; set; }


        /// <summary>
        /// values: M or F
        /// </summary>
        public string GENDER { get; set; }

        [MaxLength(length: 30)]
        public string TITLE { get; set; }

        [MaxLength(length: 100)]
        public string FIRST_NAME { get; set; }

        [MaxLength(length: 100)]
        public string MIDDLE_NAME { get; set; }

        [MaxLength(length: 100)]
        public string PREFIX { get; set; }

        [MaxLength(length: 100)]
        public string LAST_NAME { get; set; }

        public DateTime? BIRTHDATE { get; set; }

        [MaxLength(length: 255)]
        public string BIRTH_PLACE { get; set; }

        [MaxLength(length: 100)]
        public string MOTHERS_NAME { get; set; }

        [MaxLength(length: 100)]
        public string ALIAS { get; set; }

        [MaxLength(length: 25)]
        public string SSN { get; set; }

        [MaxLength(length: 25)]
        public string PASSPORT_NUMBER { get; set; }

        [MaxLength(length: 25)]
        public string PASSPORT_COUNTRY { get; set; }

        [MaxLength(length: 25)]
        public string ID_NUMBER { get; set; }



        // SIGNATORY OR DIRECTOR PHONE -> type 't_phone'

        /// <summary>
        /// Enumeration -> contact_type
        /// </summary>
        public string SIGNATORY_OR_DIRECTOR_TPH_CONTACT_TYPE { get; set; }

        /// <summary>
        /// Enumeration -> communication_type
        /// </summary>
        public string SIGNATORY_OR_DIRECTOR_TPH_COMMUNICATION_TYPE { get; set; }

        [MaxLength(length: 4)]
        public string SIGNATORY_OR_DIRECTOR_COUNTRY_PREFIX { get; set; }

        [MaxLength(length: 50)]
        public string SIGNATORY_OR_DIRECTOR_NUMBER { get; set; }

        [MaxLength(length: 10)]
        public string SIGNATORY_OR_DIRECTOR_TPH_EXTENSION { get; set; }

        [MaxLength(length: 4000)]
        public string SIGNATORY_OR_DIRECTOR_PHONE_COMMENTS { get; set; }

        // SIGNATORY PHONE END



        // SIGNATORY ADDRESS NODE START -> type 't_address'

        /// <summary>
        /// Enumeration -> contact_type
        /// </summary>
        public string SIGNATORY_OR_DIRECTOR_ADDRESS_TYPE { get; set; }

        [MaxLength(length: 100)]
        public string SIGNATORY_OR_DIRECTOR_ADDRESS { get; set; }

        [MaxLength(length: 255)]
        public string SIGNATORY_OR_DIRECTOR_TOWN { get; set; }

        [MaxLength(length: 255)]
        public string SIGNATORY_OR_DIRECTOR_CITY { get; set; }

        [MaxLength(length: 10)]
        public string SIGNATORY_OR_DIRECTOR_ZIP { get; set; }

        /// <summary>
        /// Enumeration -> country_codes
        /// </summary>
        public string SIGNATORY_OR_DIRECTOR_COUNTRY_CODE { get; set; }

        [MaxLength(length: 255)]
        public string SIGNATORY_OR_DIRECTOR_STATE { get; set; }

        [MaxLength(length: 25)]
        public string SIGNATORY_OR_DIRECTOR_ADDRESS_COMMENTS { get; set; }

        // SIGNATORY ADDRESS NODE END -> TYPE 't_address'



        /// <summary>
        /// Enumeration -> country_codes
        /// </summary>
        public string NATIONALITY1 { get; set; }
        /// <summary>
        /// Enumeration -> country_codes
        /// </summary>
        public string NATIONALITY2 { get; set; }
        /// <summary>
        /// Enumeration -> country_codes
        /// </summary>
        public string NATIONALITY3 { get; set; }

        /// <summary>
        /// Enumeration -> country_codes
        /// </summary>
        public string RESIDENCE { get; set; }

        // up to 5 emails
        public string EMAIL1 { get; set; }
        public string EMAIL2 { get; set; }
        public string EMAIL3 { get; set; }
        public string EMAIL4 { get; set; }
        public string EMAIL5 { get; set; }


        [MaxLength(length: 255)]
        public string OCCUPATION { get; set; }


        [MaxLength(length: 255)]
        public string EMPLOYER_NAME { get; set; }

        // EMPLOYER ADDRESS NODE START -> type 't_address'

        /// <summary>
        /// Enumeration -> contact_type
        /// </summary>
        public string EMPLOYER_ADDRESS_TYPE { get; set; }

        [MaxLength(length: 100)]
        public string EMPLOYER_ADDRESS { get; set; }

        [MaxLength(length: 255)]
        public string EMPLOYER_TOWN { get; set; }

        [MaxLength(length: 255)]
        public string EMPLOYER_CITY { get; set; }

        [MaxLength(length: 10)]
        public string EMPLOYER_ZIP { get; set; }

        /// <summary>
        /// Enumeration -> country_codes
        /// </summary>
        public string EMPLOYER_COUNTRY_CODE { get; set; }

        [MaxLength(length: 255)]
        public string EMPLOYER_STATE { get; set; }

        [MaxLength(length: 25)]
        public string EMPLOYER_ADDRESS_COMMENTS { get; set; }

        // EMPLOYER ADDRESS NODE END -> TYPE 't_address'


        // EMPLOYER PHONE -> type 't_phone'

        /// <summary>
        /// Enumeration -> contact_type
        /// </summary>
        public string EMPLOYER_TPH_CONTACT_TYPE { get; set; }

        /// <summary>
        /// Enumeration -> communication_type
        /// </summary>
        public string EMPLOYER_TPH_COMMUNICATION_TYPE { get; set; }

        [MaxLength(length: 4)]
        public string EMPLOYER_COUNTRY_PREFIX { get; set; }

        [MaxLength(length: 50)]
        public string EMPLOYER_NUMBER { get; set; }

        [MaxLength(length: 10)]
        public string EMPLOYER_TPH_EXTENSION { get; set; }

        [MaxLength(length: 4000)]
        public string EMPLOYER_PHONE_COMMENTS { get; set; }
        // EMPLOYER PHONE END


        // identification (can include multiple records for the same signatory) -> type 't_person_identification' on table 

        public bool? DECEASED { get; set; }
        public DateTime? DECEASED_DATE { get; set; }

        [MaxLength(length: 100)]
        public string TAX_NUMBER { get; set; }

        [MaxLength(length: 100)]
        public string TAX_REG_NUMBER { get; set; }

        [MaxLength(length: 255)]
        public string SOURCE_OF_WEALTH { get; set; }

        [MaxLength(length: 4000)]
        public string SIGNATORY_OR_DIRECTOR_COMMENTS { get; set; }

    }
}
