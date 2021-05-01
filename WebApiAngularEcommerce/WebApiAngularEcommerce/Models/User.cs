using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiAngularEcommerce
{
   public class User:IdentityUser
    {
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [MinLength(3)]
      
        public string Country { get; set; }
        public string confirmPassword { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        [JsonIgnore]

        public virtual List<Payment> Payment { get; set; }
    }
}
