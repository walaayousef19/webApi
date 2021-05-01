using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiAngularEcommerce
{
   public class Payment
    {
        public int ID { get; set; }
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public string OwnerName { get; set; }
        [Required]

        public DateTime ExpDate { get; set; }
        
        public User User { get; set; }

    }
}
