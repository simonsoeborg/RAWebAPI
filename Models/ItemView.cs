using System;

namespace RAWebAPI.Models
{
    public class ItemView
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int Price { get; set; }
        public string CategoryName { get; set; }
        public string ImgUrl { get; set; }

    }
}
