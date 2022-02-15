using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAWebAPI.Models
{
    public static class Roles
    {
        public const string
            Administrator = "Administrator",
            RestaurantOwner = "RestaurantOwner",
            Waiter = "Waiter",
            Host = "Host",
            KitchenStaff = "KitchenStaff";
    }
}
