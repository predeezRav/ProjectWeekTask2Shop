using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models
{
    public class Tøjtype
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TøjtypeID { get; set; }

        public string Titel { get; set; }
    }
}
