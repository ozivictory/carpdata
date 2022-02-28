using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CARPDataGenerator.Models
{
    public class TransactionPersonIdentification
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string TRANSACTION_NUMBER { get; set; }

        /// <summary>
        /// Identification for signatory or director
        /// not needed for person identification
        /// </summary>
        public string SIGNATORY_OR_DIRECTOR_ID { get; set; }

        /// <summary>
        /// if identification record is for a signatory
        /// </summary>
        public bool? FOR_SIGNATORY_IDENTIFICATION { get; set; }

        /// <summary>
        /// if identification record is for a director
        /// </summary>
        public bool? FOR_DIRECTOR_IDENTIFICATION { get; set; }


        /// <summary>
        /// if identification record is for a person
        /// </summary>
        public bool? FOR_PERSON_IDENTIFICATION { get; set; }

        /// <summary>
        /// if identification record is for a person source transaction
        /// </summary>
        public bool? FOR_PERSON_SOURCE_TRANSACTION { get; set; }

        /// <summary>
        /// if identification record is for a person destination transaction
        /// </summary>
        public bool? FOR_PERSON_DESTINATION_TRANSACTION { get; set; }





        /// <summary>
        /// Enumeration -> identifier_type
        /// </summary>
        public string TYPE { get; set; }

        [MaxLength(length: 255)]
        public string NUMBER { get; set; }

        public DateTime? ISSUE_DATE { get; set; }

        public DateTime? EXPIRY_DATE { get; set; }

        [MaxLength(length: 255)]
        public string ISSUED_BY { get; set; }

        /// <summary>
        /// Enumeration -> country_codes
        /// </summary>
        public string ISSUE_COUNTRY { get; set; }

        [MaxLength(length: 4000)]
        public string COMMENTS { get; set; }

    }
}
