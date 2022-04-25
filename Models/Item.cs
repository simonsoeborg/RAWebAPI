using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAWebAPI.Models
{
    public class Item
    {
        public int Id { get; set; }
        public String ItemName { get; set; }
        public int Price { get; set; }
        public string ImgUrl { get; set; }
    }
}
