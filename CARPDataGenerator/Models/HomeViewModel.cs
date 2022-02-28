using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CARPDataGenerator.Models
{
    public class HomeViewModel
    {
        public string from { get; set; }
        public string to { get; set; }

        public int NoOfrecords { get; set; }
        public string FundsTypeCode { get; set; }

        [Required]
        [MinLength(length: 4)]
        [MaxLength(length: 4)]
        public string codefromtrans { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool FromAddForeignCurrency { get; set; }
        public bool ToAddForeignCurrency { get; set; }

        public bool forFTR { get; set; }
        public bool fromentityaccount { get; set; }
        public bool toentityaccount { get; set; }

    }
}
