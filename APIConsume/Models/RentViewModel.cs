using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class RentViewModel
    {
        public int RentId { get; set; }
        public int MotobikeId { get; set; }
        public int CustomerId { get; set; }
        public DateTime FisrtDay { get; set; }
        public DateTime LastDay { get; set; }
        public int Price { get; set; }
    }
}
