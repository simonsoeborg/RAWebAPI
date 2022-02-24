using System;

namespace RAWebAPI.Models
{
    public class ItemView
    {
        public int Id { get; set; }
        public String ItemName { get; set; }
        public int Price { get; set; }

        public String CategoryName { get; set; }

    }
}
