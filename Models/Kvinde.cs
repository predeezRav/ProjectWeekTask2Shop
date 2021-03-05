using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models
{
    public class Kvinde
    {
        public int ProductID{ get; set; }
        public int KvindeID { get; set; }

        public int TøjtypeID { get; set; }

        public Tøjtype Tøjtype { get; set; }

        public Product Product { get; set; }

    }
}
