using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CARPDataGenerator.Models
{
    public class PEP
    {
        [Key]
        public int ID { get; set; }

        public string CUSTOMER_TYPE { get; set; }
        public string NAME_OF_PEP { get; set; }
        public string PEP_STATUS { get; set; }
        public DateTime? DATE_OF_BIRTH_OR_INCORPORATION { get; set; }
        public string OCCUPATION_OR_BUSINESS_TYPE { get; set; }
        public string SOURCE_OF_FUNDS { get; set; }
        public string CUSTOMER_ADDRESS { get; set; }
        public double AMOUNT { get; set; }
        public string CURRENCY { get; set; }
        public string NATIONALITY_OR_COUNTRY_OF_INCORPORATION { get; set; }
        public string ACCOUNT_NAME { get; set; }
        public string TYPE_OF_IDENTIFICATION { get; set; }
        public string IDENTIFICATION_NO { get; set; }
        public string ISSUING_AUTHORITY { get; set; }
        public DateTime? TRANSACTION_DATE { get; set; }
        public string TRANSACTION_TYPE { get; set; }

        public string RELATIONSHIP_WITH_PEP { get; set; }
        public string TRANSACTION_NUMBER { get; set; }
        public string ACCOUNT_TYPE { get; set; }
        public DateTime? DATE_GENERATED_FROM_DB { get; set; }


        /// FOR CBN
        public string BRANCH_NAME { get; set; }
        public string BRANCH_CODE { get; set; }
        public string BVN { get; set; }
        public string TAX_IDENTIFICATION_NO { get; set; }
        public string PHONE_NUMBER { get; set; }
        public string ACCOUNT_NUMBER { get; set; }
        public string FIRST_NAME { get; set; }
        public string MIDDLE_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string REFERENCE_NUMBER { get; set; }
        public string TRANSACTION_DETAILS { get; set; }
        public string MODE_OF_TRANSACTION { get; set; }
        public string OTHER_ACCOUNT_NO_INVOLVED { get; set; }
        public string RELATED_ACCOUNT_NUMBERS { get; set; }
        public string BANK_VERIFICATION_OF_PEP { get; set; }
        public string REMARKS { get; set; }
    }

}
