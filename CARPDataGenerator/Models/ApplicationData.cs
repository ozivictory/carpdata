using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CARPDataGenerator.Models
{
    public class ApplicationData
    {

        public bool T_from_my_client_from_account { get; set; }
        public bool T_from_from_account { get; set; }
        public bool T_from_my_client_from_entity { get; set; }
        public bool T_from_from_entity { get; set; }
    }
}
