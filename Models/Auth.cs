using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RAWebAPI.Models
{
    public class Auth
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(455)]
        [JsonProperty(PropertyName = "Email")]
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        public string Nickname { get; set; }
        [JsonProperty(PropertyName = "Picture")]
        public string Picture { get; set; }
        [JsonProperty(PropertyName = "Sub")]
        public string Sub { get; set; }
        [JsonProperty(PropertyName = "Role")]
        public string Role { get; set; }
        [JsonProperty(PropertyName = "Pin")]
        public int Pin { get; set; }
    }
}
