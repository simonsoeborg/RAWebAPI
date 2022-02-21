using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAWebAPI.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public String RestaurantName { get; set; }
        public String  OwnerName { get; set; }
        public int OwnerID { get; set; }

    }
}
