using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CARPDataGenerator.Models
{
    /// <summary>
    ///  STR - Suspicious Transaction Reporting tables
    ///  uses InstitutionDbContext
    /// </summary>
    public class STR : TRANSACTIONS
    {
        [Key]
        public int ID { get; set; }

        public string FLAG_INDICATOR { get; set; }
        public string REASON_FOR_FLAGGING { get; set; }
        public bool IsFlagged { get; set; }

    }
}
