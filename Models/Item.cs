﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAWebAPI.Models
{
    public class Item
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public string ImgUrl { get; set; }
    }
}
