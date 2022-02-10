using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAWebAPI.Models
{
    public class Table
    {
        public int Id { get; set; }
        public Boolean isReserved { get; set; }
        public Boolean isInUse { get; set; }
    }
}
