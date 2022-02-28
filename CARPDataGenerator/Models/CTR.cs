using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CARPDataGenerator.Models
{
    public class CTR : TRANSACTIONS
    {
        [Key]
        public int ID { get; set; }



    }
}
