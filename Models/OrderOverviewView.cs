using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; 

namespace RAWebAPI.Models
{

    public class OrderOverviewView
    {
        public String name { get; set; }
        public int price { get; set; }
        [Key]
        public int orderId { get; set; }

    }
}


