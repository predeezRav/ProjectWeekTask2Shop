using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Navn { get; set; }
        public string Beskrivelse { get; set; }
        
        public string Billeder { get; set; }

        public int Size { get; set; }

        public string Farver { get; set; }

        public int Pris { get; set; }



    }
}
