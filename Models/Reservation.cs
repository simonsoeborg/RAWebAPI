using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAWebAPI.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public SeatingTable Table { get; set; }
        public String ReservationName { get; set; }
        public DateTime TimeBegin { get; set; }
        public DateTime TimeEnd { get; set; }
        public User User { get; set; }
    }
}
