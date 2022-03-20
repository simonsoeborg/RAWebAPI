﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RAWebAPI.Models
{
    public class AuthView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(455)]
        public string Email { get; set; }
        public bool Email_verified { get; set; }
        public string Family_name { get; set; }
        public string Given_name { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Picture { get; set; }
        public string Sub { get; set; }
        public string Role { get; set; }
        public int Pin { get; set; }
        public string UserEmail { get; set; }
    }
}
