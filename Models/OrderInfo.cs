using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAWebAPI.Models
{
    public class OrderInfo
    {
        public int id { get; set; }
        public int tableId { get; set; }
        public Boolean orderPayed { get; set; }
    }
}
