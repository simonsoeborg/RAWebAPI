using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAWebAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Role { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
