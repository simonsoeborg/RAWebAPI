using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RAWebAPI.Models
{
    public class Auth
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(455)]
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Picture { get; set; }
        public string Sub { get; set; }
        public string Role { get; set; }
        public int Pin { get; set; }
    }
}
